namespace Synchronous_Ping_Sweep
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSweepSync = new System.Windows.Forms.Button();
            this.buttonSweepAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSweepSync
            // 
            this.buttonSweepSync.Location = new System.Drawing.Point(59, 19);
            this.buttonSweepSync.Name = "buttonSweepSync";
            this.buttonSweepSync.Size = new System.Drawing.Size(134, 30);
            this.buttonSweepSync.TabIndex = 0;
            this.buttonSweepSync.Text = "Synchronous";
            this.buttonSweepSync.UseVisualStyleBackColor = true;
            this.buttonSweepSync.Click += new System.EventHandler(this.buttonPingSweep_Click);
            // 
            // buttonSweepAsync
            // 
            this.buttonSweepAsync.Location = new System.Drawing.Point(59, 71);
            this.buttonSweepAsync.Name = "buttonSweepAsync";
            this.buttonSweepAsync.Size = new System.Drawing.Size(134, 30);
            this.buttonSweepAsync.TabIndex = 1;
            this.buttonSweepAsync.Text = "Asynchronous";
            this.buttonSweepAsync.UseVisualStyleBackColor = true;
            this.buttonSweepAsync.Click += new System.EventHandler(this.buttonSweepAsync_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 123);
            this.Controls.Add(this.buttonSweepAsync);
            this.Controls.Add(this.buttonSweepSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ping Sweeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSweepSync;
        private System.Windows.Forms.Button buttonSweepAsync;
    }
}

