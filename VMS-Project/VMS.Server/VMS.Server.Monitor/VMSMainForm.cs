using System.Windows.Forms;
using System;
using System.Drawing;
using System.ServiceProcess;
using log4net;
using System.Reflection;

namespace VMS.Server.Monitor
{
    public partial class VMSMainForm : Form
    {
        private static VMSMainForm instance = null;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private bool showTaskTray = true;

        public static VMSMainForm GetInstance()
        {
            try
            {
                instance = instance ?? new VMSMainForm();
                return instance;
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        private bool? isRunAction = null;
        protected VMSMainForm()
        {
            try
            {
                InitializeComponent();
                this.statusTimer.Enabled = true;
                this.statusTimer.Start();
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        public VMSMainForm(bool showTaskTray)
        {
            try
            {
                InitializeComponent();
                this.showTaskTray = showTaskTray;
                this.statusTimer.Enabled = true;
                this.statusTimer.Start();
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        public void RunServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.serviceController.Start();
                this.runServiceButton.Enabled = false;
                this.statusValueLabel.ForeColor = Color.Green;
                isRunAction = true;
                TaskTrayApplicationContext.GetInstance().EnableRun = false;
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        public void StopServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to stop server?", "Stop barcode server", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                this.serviceController.Stop();
                this.stopServiceButton.Enabled = false;
                this.statusValueLabel.ForeColor = Color.Red;
                isRunAction = false;
                TaskTrayApplicationContext.GetInstance().EnableStop = false;
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.serviceController.Refresh();
                this.statusValueLabel.Text = serviceController.Status.ToString();
                if (this.statusValueLabel.Text.Equals(ServiceControllerStatus.Stopped.ToString()))
                {

                    this.toolStripStatusLabel.Visible = false;
                    this.toolStripProgressBar.Visible = false;
                    this.runServiceButton.Enabled = true;
                    this.stopServiceButton.Enabled = false;
                    this.stopServiceButton.ForeColor = Color.Red;
                    this.stopServiceButton.BackColor = Color.Coral;
                    this.runServiceButton.ForeColor = Color.DarkGreen;
                    this.runServiceButton.BackColor = SystemColors.Control;
                    this.runServiceButton.UseVisualStyleBackColor = true;
                    this.statusValueLabel.ForeColor = Color.Red;
                    if (!showTaskTray)
                        return;
                    var ttac = TaskTrayApplicationContext.GetInstance();
                    //ttac.Icon = global::VMS.Server.Monitor.Properties.Resources.ApplicationServerStopIcon;
                    ttac.EnableRun = true;
                    ttac.EnableStop = false;
                }
                else if (this.statusValueLabel.Text.Equals(ServiceControllerStatus.Running.ToString()))
                {
                    this.toolStripStatusLabel.Visible = false;
                    this.toolStripProgressBar.Visible = false;
                    this.runServiceButton.Enabled = false;
                    this.stopServiceButton.Enabled = true;
                    this.stopServiceButton.ForeColor = Color.Red;
                    this.stopServiceButton.BackColor = SystemColors.Control;
                    this.stopServiceButton.UseVisualStyleBackColor = true;
                    this.runServiceButton.ForeColor = Color.DarkGreen;
                    this.runServiceButton.BackColor = Color.LimeGreen;
                    this.statusValueLabel.ForeColor = Color.Green;
                    if (!showTaskTray)
                        return;
                    var ttac = TaskTrayApplicationContext.GetInstance();
                    //ttac.Icon = global::VMS.Server.Monitor.Properties.Resources.ApplicationServerRunIcon;
                    ttac.EnableRun = false;
                    ttac.EnableStop = true;
                }
                else
                {
                    if (showTaskTray)
                    {
                        var ttac = TaskTrayApplicationContext.GetInstance();
                        //ttac.Icon = global::VMS.Server.Monitor.Properties.Resources.ApplicationServerIcon;
                    }
                    this.toolStripStatusLabel.Visible = true;
                    this.toolStripProgressBar.Visible = true;

                    if (this.statusValueLabel.ForeColor == Color.Green ||
                        this.statusValueLabel.ForeColor == Color.Red)
                        this.statusValueLabel.ForeColor = Color.Yellow;
                    else
                    {
                        if (this.isRunAction == true)
                            this.statusValueLabel.ForeColor = Color.Green;
                        else if (this.isRunAction == false)
                            this.statusValueLabel.ForeColor = Color.Red;
                        else
                            this.statusValueLabel.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                TaskTrayApplicationContext.GetInstance().GetContextMenuStrip().Show(this.Location.X, this.Location.Y);
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!showTaskTray)
                    Application.Exit();
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }
    }
}