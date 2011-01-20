using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using VMS.Server.Monitor;
using log4net;
using System.Reflection;

namespace VMS.Server.Monitor
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly RegistryKey ApplicationRegistryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        private static readonly RegistryKey StartTypeRegistryKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + global::VMS.Server.Monitor.Properties.Settings.Default.ServiceName, true);
        private NotifyIcon notifyIcon = null;
        private VMSMainForm configWindow = null;
        private ToolStripMenuItem configMenuItem = null;
        private ToolStripMenuItem runMenuItem = null;
        private ToolStripMenuItem stopMenuItem = null;
        private ToolStripMenuItem startUpMenuItem = null;
        private ToolStripMenuItem startTypeMenuItem = null;
        private ToolStripMenuItem exitMenuItem = null;

        private static TaskTrayApplicationContext instance = null;

        public static TaskTrayApplicationContext GetInstance()
        {
            try
            {
                instance = instance ?? new TaskTrayApplicationContext();
                return instance;
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        public void InitializeComponent()
        {
            try
            {
                this.notifyIcon = new NotifyIcon();
                this.configWindow = VMSMainForm.GetInstance();
                this.configMenuItem = new ToolStripMenuItem("Cấu hình", global::VMS.Server.Monitor.Properties.Resources.WindowImage);
                this.configMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.runMenuItem = new ToolStripMenuItem("Bật", global::VMS.Server.Monitor.Properties.Resources.RunImage, configWindow.RunServiceButton_Click);
                this.stopMenuItem = new ToolStripMenuItem("Tắt", global::VMS.Server.Monitor.Properties.Resources.StopImage, configWindow.StopServiceButton_Click);
                this.startUpMenuItem = new ToolStripMenuItem("Mở cửa sổ sau khi khởi động Windows");
                this.startTypeMenuItem = new ToolStripMenuItem("Khởi động chương trình cùng Windows");
                this.exitMenuItem = new ToolStripMenuItem("Thoát", global::VMS.Server.Monitor.Properties.Resources.ExitImage);
                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.AddRange(new ToolStripItem[] { configMenuItem, new ToolStripSeparator(), runMenuItem, stopMenuItem, new ToolStripSeparator(), startTypeMenuItem, startUpMenuItem, new ToolStripSeparator(), exitMenuItem });

                notifyIcon.Visible = true;
                notifyIcon.Icon = VMS.Server.Monitor.Properties.Resources.ApplicationServerRunning;
                notifyIcon.ContextMenuStrip = contextMenu;
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        public ContextMenuStrip GetContextMenuStrip()
        {
            try
            {
                return notifyIcon.ContextMenuStrip;
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        private TaskTrayApplicationContext()
        {
            try
            {
                InitializeComponent();
                EventHandler temp = (c, d) =>
                {
                    if (configWindow.Visible)
                        configWindow.Focus();
                    else
                        configWindow.ShowDialog();
                };

                if (ApplicationRegistryKey.GetValue(global::VMS.Server.Monitor.Properties.Settings.Default.AppName) == null)
                    this.startUpMenuItem.Checked = false;
                else
                    this.startUpMenuItem.Checked = true;

                var val = StartTypeRegistryKey.GetValue("Start");
                if (val == null)
                    this.startTypeMenuItem.Checked = false;
                else if (int.Parse(val.ToString()) == 2)
                    this.startTypeMenuItem.Checked = true;
                else
                    this.startTypeMenuItem.Checked = false;

                this.exitMenuItem.Click += (c, d) =>
                {
                    var result = MessageBox.Show("Thoát khỏi chương trình điều khiển?", "Xac nhan thoat ung dung", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No)
                        return;

                    notifyIcon.Visible = false;
                    Application.Exit();
                };

                this.startUpMenuItem.Click += (c, d) =>
                {
                    this.startUpMenuItem.Checked = !this.startUpMenuItem.Checked;

                    if (this.startUpMenuItem.Checked)
                        ApplicationRegistryKey.SetValue(global::VMS.Server.Monitor.Properties.Settings.Default.AppName, Application.ExecutablePath.ToString());
                    else
                        ApplicationRegistryKey.DeleteValue(global::VMS.Server.Monitor.Properties.Settings.Default.AppName, false);
                };

                this.startTypeMenuItem.Click += (c, d) =>
                {
                    this.startTypeMenuItem.Checked = !this.startTypeMenuItem.Checked;
                    StartTypeRegistryKey.SetValue("Start", this.startTypeMenuItem.Checked ? 0x2 : 0x3);
                };

                this.configMenuItem.Click += temp;
                this.notifyIcon.DoubleClick += temp;
            }
            catch (Exception ex)
            {
                log.Error("Exception(" + MethodBase.GetCurrentMethod().Name + "): " + ex);
                throw new Exception(ex.Message);
            }
        }

        public Icon Icon
        {
            get { return this.notifyIcon.Icon; }
            set { this.notifyIcon.Icon = value; }
        }

        public bool EnableRun
        {
            get { return this.runMenuItem.Enabled; }
            set { this.runMenuItem.Enabled = value; }
        }

        public bool EnableStop
        {
            get { return this.stopMenuItem.Enabled; }
            set { this.stopMenuItem.Enabled = value; }
        }
    }
}
