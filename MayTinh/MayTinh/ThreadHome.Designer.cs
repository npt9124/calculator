namespace MayTinh
{
    partial class ThreadHome
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
            this.process1 = new System.Diagnostics.Process();
            this.progressThread = new System.Windows.Forms.ProgressBar();
            this.progressTask = new System.Windows.Forms.ProgressBar();
            this.progressAsync = new System.Windows.Forms.ProgressBar();
            this.lblThread = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblAsync = new System.Windows.Forms.Label();
            this.startThread = new System.Windows.Forms.Button();
            this.stopThread0 = new System.Windows.Forms.Button();
            this.stopTask = new System.Windows.Forms.Button();
            this.startTask = new System.Windows.Forms.Button();
            this.stopAsync = new System.Windows.Forms.Button();
            this.startAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // progressThread
            // 
            this.progressThread.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.progressThread.Location = new System.Drawing.Point(176, 53);
            this.progressThread.Maximum = 1000;
            this.progressThread.Name = "progressThread";
            this.progressThread.Size = new System.Drawing.Size(414, 45);
            this.progressThread.TabIndex = 0;
            this.progressThread.Click += new System.EventHandler(this.progressThread_Click);
            // 
            // progressTask
            // 
            this.progressTask.Location = new System.Drawing.Point(176, 176);
            this.progressTask.Name = "progressTask";
            this.progressTask.Size = new System.Drawing.Size(414, 45);
            this.progressTask.TabIndex = 1;
            // 
            // progressAsync
            // 
            this.progressAsync.Location = new System.Drawing.Point(176, 314);
            this.progressAsync.Name = "progressAsync";
            this.progressAsync.Size = new System.Drawing.Size(414, 45);
            this.progressAsync.TabIndex = 2;
            // 
            // lblThread
            // 
            this.lblThread.AutoSize = true;
            this.lblThread.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThread.Location = new System.Drawing.Point(39, 53);
            this.lblThread.Name = "lblThread";
            this.lblThread.Size = new System.Drawing.Size(101, 32);
            this.lblThread.TabIndex = 3;
            this.lblThread.Text = "Thread";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTask.Location = new System.Drawing.Point(39, 178);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(69, 32);
            this.lblTask.TabIndex = 4;
            this.lblTask.Text = "Task";
            // 
            // lblAsync
            // 
            this.lblAsync.AutoSize = true;
            this.lblAsync.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsync.Location = new System.Drawing.Point(39, 321);
            this.lblAsync.Name = "lblAsync";
            this.lblAsync.Size = new System.Drawing.Size(87, 32);
            this.lblAsync.TabIndex = 5;
            this.lblAsync.Text = "Async";
            // 
            // startThread
            // 
            this.startThread.BackColor = System.Drawing.Color.Lime;
            this.startThread.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startThread.Location = new System.Drawing.Point(614, 53);
            this.startThread.Name = "startThread";
            this.startThread.Size = new System.Drawing.Size(96, 37);
            this.startThread.TabIndex = 6;
            this.startThread.Text = "Start";
            this.startThread.UseVisualStyleBackColor = false;
            this.startThread.Click += new System.EventHandler(this.startThread_Click);
            // 
            // stopThread0
            // 
            this.stopThread0.BackColor = System.Drawing.Color.DarkSalmon;
            this.stopThread0.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopThread0.Location = new System.Drawing.Point(721, 53);
            this.stopThread0.Name = "stopThread0";
            this.stopThread0.Size = new System.Drawing.Size(96, 37);
            this.stopThread0.TabIndex = 7;
            this.stopThread0.Text = "Stop";
            this.stopThread0.UseVisualStyleBackColor = false;
            this.stopThread0.Click += new System.EventHandler(this.endThread_Click);
            // 
            // stopTask
            // 
            this.stopTask.BackColor = System.Drawing.Color.DarkSalmon;
            this.stopTask.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopTask.Location = new System.Drawing.Point(721, 178);
            this.stopTask.Name = "stopTask";
            this.stopTask.Size = new System.Drawing.Size(96, 37);
            this.stopTask.TabIndex = 9;
            this.stopTask.Text = "Stop";
            this.stopTask.UseVisualStyleBackColor = false;
            this.stopTask.Click += new System.EventHandler(this.endTask_Click);
            // 
            // startTask
            // 
            this.startTask.BackColor = System.Drawing.Color.Lime;
            this.startTask.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTask.Location = new System.Drawing.Point(614, 178);
            this.startTask.Name = "startTask";
            this.startTask.Size = new System.Drawing.Size(96, 37);
            this.startTask.TabIndex = 8;
            this.startTask.Text = "Start";
            this.startTask.UseVisualStyleBackColor = false;
            this.startTask.Click += new System.EventHandler(this.startTask_Click);
            // 
            // stopAsync
            // 
            this.stopAsync.BackColor = System.Drawing.Color.DarkSalmon;
            this.stopAsync.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopAsync.Location = new System.Drawing.Point(721, 316);
            this.stopAsync.Name = "stopAsync";
            this.stopAsync.Size = new System.Drawing.Size(96, 37);
            this.stopAsync.TabIndex = 11;
            this.stopAsync.Text = "Stop";
            this.stopAsync.UseVisualStyleBackColor = false;
            this.stopAsync.Click += new System.EventHandler(this.endAsync_Click);
            // 
            // startAsync
            // 
            this.startAsync.BackColor = System.Drawing.Color.Lime;
            this.startAsync.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startAsync.Location = new System.Drawing.Point(614, 316);
            this.startAsync.Name = "startAsync";
            this.startAsync.Size = new System.Drawing.Size(96, 37);
            this.startAsync.TabIndex = 10;
            this.startAsync.Text = "Start";
            this.startAsync.UseVisualStyleBackColor = false;
            this.startAsync.Click += new System.EventHandler(this.startAsync_Click);
            // 
            // ThreadHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 450);
            this.Controls.Add(this.stopAsync);
            this.Controls.Add(this.startAsync);
            this.Controls.Add(this.stopTask);
            this.Controls.Add(this.startTask);
            this.Controls.Add(this.stopThread0);
            this.Controls.Add(this.startThread);
            this.Controls.Add(this.lblAsync);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblThread);
            this.Controls.Add(this.progressAsync);
            this.Controls.Add(this.progressTask);
            this.Controls.Add(this.progressThread);
            this.Name = "ThreadHome";
            this.Text = "ThreadHome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Label lblAsync;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label lblThread;
        private System.Windows.Forms.ProgressBar progressAsync;
        private System.Windows.Forms.ProgressBar progressTask;
        private System.Windows.Forms.ProgressBar progressThread;
        private System.Windows.Forms.Button stopAsync;
        private System.Windows.Forms.Button startAsync;
        private System.Windows.Forms.Button stopTask;
        private System.Windows.Forms.Button startTask;
        private System.Windows.Forms.Button stopThread0;
        private System.Windows.Forms.Button startThread;
    }
}