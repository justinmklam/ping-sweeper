using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synchronous_Ping_Sweep
{
    public partial class FormMain : Form
    {
        PingSweep pingSweep = new PingSweep();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonPingSweep_Click(object sender, EventArgs e)
        {
            buttonSweepSync.Enabled = false;
            pingSweep.RunPingSweep_Sync();
            buttonSweepSync.Enabled = true;
        }

        private void buttonSweepAsync_Click(object sender, EventArgs e)
        {
            buttonSweepSync.Enabled = false;
            pingSweep.RunPingSweep_Async();
            buttonSweepSync.Enabled = true;
        }
    }

    public class PingSweep
    {
        private string BaseIP = "192.168.1.";
        private int StartIP = 1;
        private int StopIP = 255;
        private string ip;

        private int timeout = 100;
        private int nFound = 0;

        static object lockObj = new object();
        Stopwatch stopWatch = new Stopwatch();
        TimeSpan ts;

        public void RunPingSweep_Sync()
        {
            nFound = 0;

            stopWatch.Start();
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();

            for (int i = StartIP; i <= StopIP; i++)
            {
                ip = BaseIP + i.ToString();
                System.Net.NetworkInformation.PingReply rep = p.Send(ip, timeout);

                if (rep.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    nFound++;
                }
            }

            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            MessageBox.Show(nFound.ToString() + " devices found! Elapsed time: " + ts.ToString(), "Synchronous");
        }

        public async void RunPingSweep_Async()
        {
            nFound = 0;

            var tasks = new List<Task>();

            stopWatch.Start();

            for (int i = StartIP; i <= StopIP; i++)
            {
                ip = BaseIP + i.ToString();

                System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                var task = PingAndUpdateAsync(p, ip);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks).ContinueWith(t =>
            {
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                MessageBox.Show(nFound.ToString() + " devices found! Elapsed time: " + ts.ToString(), "Asynchronous");
            });
        }

        private async Task PingAndUpdateAsync(System.Net.NetworkInformation.Ping ping, string ip)
        {
            var reply = await ping.SendPingAsync(ip, timeout);

            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                lock(lockObj)
                {
                    nFound++;
                }
            }
        }
    }
}
