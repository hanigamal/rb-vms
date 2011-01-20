namespace VMS.Server.Service
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VMSServerServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.VMSServerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // VMSServerServiceProcessInstaller
            // 
            this.VMSServerServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.VMSServerServiceProcessInstaller.Password = null;
            this.VMSServerServiceProcessInstaller.Username = null;
            // 
            // VMSServerServiceInstaller
            // 
            this.VMSServerServiceInstaller.Description = "Listen Data From Vehicle";
            this.VMSServerServiceInstaller.DisplayName = "Vehicle Management System Server Service";
            this.VMSServerServiceInstaller.ServiceName = "VMSServerService";
            this.VMSServerServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.VMSServerServiceProcessInstaller,
            this.VMSServerServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller VMSServerServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller VMSServerServiceInstaller;
    }
}