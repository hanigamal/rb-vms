namespace VMS.Server.Monitor
{
    partial class VMSMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VMSMainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.runServiceButton = new System.Windows.Forms.Button();
            this.stopServiceButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusValueLabel = new System.Windows.Forms.Label();
            this.serviceController = new System.ServiceProcess.ServiceController();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Điều khiển bật / tắt máy chủ - Hệ thống quản lý vận tải (Vehicle Management Syste" +
                "m)";
            // 
            // runServiceButton
            // 
            this.runServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runServiceButton.Image = ((System.Drawing.Image)(resources.GetObject("runServiceButton.Image")));
            this.runServiceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.runServiceButton.Location = new System.Drawing.Point(125, 176);
            this.runServiceButton.Name = "runServiceButton";
            this.runServiceButton.Size = new System.Drawing.Size(103, 41);
            this.runServiceButton.TabIndex = 2;
            this.runServiceButton.Text = "Bật";
            this.runServiceButton.UseVisualStyleBackColor = true;
            this.runServiceButton.Click += new System.EventHandler(this.RunServiceButton_Click);
            // 
            // stopServiceButton
            // 
            this.stopServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopServiceButton.Image = ((System.Drawing.Image)(resources.GetObject("stopServiceButton.Image")));
            this.stopServiceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopServiceButton.Location = new System.Drawing.Point(250, 176);
            this.stopServiceButton.Name = "stopServiceButton";
            this.stopServiceButton.Size = new System.Drawing.Size(103, 41);
            this.stopServiceButton.TabIndex = 3;
            this.stopServiceButton.Text = "Tắt";
            this.stopServiceButton.UseVisualStyleBackColor = true;
            this.stopServiceButton.Click += new System.EventHandler(this.StopServiceButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Brown;
            this.statusLabel.Location = new System.Drawing.Point(12, 136);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(99, 24);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Trạng thái:";
            // 
            // statusValueLabel
            // 
            this.statusValueLabel.AutoSize = true;
            this.statusValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.statusValueLabel.ForeColor = System.Drawing.Color.Teal;
            this.statusValueLabel.Location = new System.Drawing.Point(117, 136);
            this.statusValueLabel.Name = "statusValueLabel";
            this.statusValueLabel.Size = new System.Drawing.Size(25, 24);
            this.statusValueLabel.TabIndex = 5;
            this.statusValueLabel.Text = "...";
            // 
            // serviceController
            // 
            this.serviceController.ServiceName = "VMSServerService";
            // 
            // statusTimer
            // 
            this.statusTimer.Interval = 300;
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 250);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(493, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(74, 17);
            this.toolStripStatusLabel.Text = "Please wait...";
            this.toolStripStatusLabel.Visible = false;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(499, 72);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.logoPictureBox_Click);
            // 
            // VMSMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 272);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.statusValueLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.stopServiceButton);
            this.Controls.Add(this.runServiceButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VMSMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "May Chu He Thong Quan Ly Van Tai";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runServiceButton;
        private System.Windows.Forms.Button stopServiceButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusValueLabel;
        private System.ServiceProcess.ServiceController serviceController;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

