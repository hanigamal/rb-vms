using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.ServiceProcess;
using VMS.Server.Database;
using XYNetSocketLib;
using VMS.Server.Models;
using VMS.Server.Database.DataAccess;
using log4net;
using System.Reflection;

namespace VMS.Server.Service
{
    public partial class ServerService : ServiceBase
    {
        #region DataAccess

        private ModuleData moduleAccess = null;
        private TrackingData trackingAccess = null;
        private SystemLogData logAccess = null;

        #endregion

        #region Configuration

        private string ServerIP = global::VMS.Server.Service.Properties.Setting.Default["ServerIP"].ToString();
        private int PortNumber = Convert.ToInt32(global::VMS.Server.Service.Properties.Setting.Default["Port"]);
        private int LongLength = Convert.ToInt32(global::VMS.Server.Service.Properties.Setting.Default["LongLength"]);
        private int LatLength = Convert.ToInt32(global::VMS.Server.Service.Properties.Setting.Default["LatLength"]);
        private int SpeedLength = Convert.ToInt32(global::VMS.Server.Service.Properties.Setting.Default["SpeedLength"]);
        private int FuelLength = Convert.ToInt32(global::VMS.Server.Service.Properties.Setting.Default["FuelLength"]);

        #endregion

        private XYNetServer myServer = null;
        private static readonly ILog log4net = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // Lag nghe Errors
        private void ExceptionHandler(Exception oBug)
        {
            log4net.Error(oBug.Message);
            RegisterLog(oBug.Message, "Error", oBug.Source, oBug.StackTrace);
            Exception oEx = myServer.GetLastException();
            if (oEx != null)
            {
                log4net.Error(oBug.Message);
                RegisterLog(oBug.Message, "Error", oBug.Source, oBug.StackTrace);
            }

        }
        // Lang nghe Data
        private void StringInputHandler(string sRemoteAddress, int nRemotePort, string sData)
        {
            log4net.Info("Received Data from: " + sRemoteAddress + ":" + nRemotePort.ToString());
            DataReceived(sData);
        }
        // Lang nghe Connection
        private void ConnectionFilter(string sRemoteAddress, int nRemotePort, Socket sock)
        {
            log4net.Info("Connected to:" + sRemoteAddress + ":" + nRemotePort.ToString());
        }
        public ServerService()
        {
            log4net.Info("Sevice Constructor");
            InitializeComponent();
            // VMSServerServiceEventLog
            moduleAccess = new ModuleData();
            trackingAccess = new TrackingData();
        }

        protected override void OnStart(string[] args)
        {
            logAccess = new SystemLogData();
            log4net.Info("Sevice is starting...");
            RegisterLog("Sevice is starting...", "Info", "Service", "Stack");
            log4net.Debug("TEst");
            try
            {
                log4net.Debug("Sever: " + ServerIP + " : " + PortNumber.ToString());
                myServer = new XYNetServer(ServerIP, PortNumber, 0, 100);
                myServer.SetExceptionHandler(new ExceptionHandlerDelegate(this.ExceptionHandler));
                myServer.SetStringInputHandler(new StringInputHandlerDelegate(this.StringInputHandler));
                myServer.SetConnectionFilter(new ConnectionFilterDelegate(this.ConnectionFilter));
                if (myServer.StartServer() == true)
                {
                    log4net.Info("Server Listenning is Started");
                    RegisterLog("Server Listenning is Started", "Info", "Service", "Unknown");
                }
            }
            catch (Exception oBug)
            {
                log4net.Error("Cannot Start Service" + oBug.Message);
                RegisterLog(oBug.Message, oBug.GetType().Name, oBug.Source, oBug.StackTrace);
            }
        }

        protected override void OnStop()
        {
            myServer.StopServer();
            log4net.Info("Sevice is stoping...");
        }
        private void RegisterLog(string logValue, string logType, string source, string stacktrace)
        {
            log4net.Info("Save Log:" + logValue + " - " + logType + " - " + source + " - " + stacktrace);
            try
            {
                SystemLogModel model = new SystemLogModel();
                model.LogValue = logValue;
                model.LogType = logType;
                model.Source = source;
                model.StackTrace = stacktrace;
                model.LogTime = DateTime.Now;
                logAccess.Save(model);
                log4net.Debug("te");
            }
            catch (Exception ex)
            {
                log4net.Error("Cannot save log. Reason:" + ex.Message);
            }
        }
        private void DataReceived(string sData)
        {
            string moduleNumber = sData.Substring(0, 11);
            double longtitude = Convert.ToDouble(sData.Substring(11, LongLength));
            double latitude = Convert.ToDouble(sData.Substring(11 + LongLength, LatLength));
            double speed = Convert.ToDouble(sData.Substring(11 + LongLength + LatLength, SpeedLength));
            double fuel = Convert.ToDouble(sData.Substring(11 + LongLength + LatLength + SpeedLength, FuelLength));
            ModuleModel module = moduleAccess.GetModule(moduleNumber);
            if (module == null)
            {
                module.ModuleNumber = moduleNumber;
                module.ModuleType = "Module Sensor";
                module.IsActive = true;
                moduleAccess.Save(module);
            }

            TrackingModel track = new TrackingModel();
            track.ModuleNumber = module.ModuleNumber;
            track.Longtitude = longtitude;
            track.Latitude = latitude;
            track.Speed = speed;
            track.FuelLevel = fuel;
            track.Time = DateTime.Now;
            trackingAccess.Save(track);
        }

    }
}
