using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using XYNetSocketLib;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace VMS.Server.Service
{
    public partial class ServerService : ServiceBase
    {
        private string ServerIP = null;
        private int PortNumber = 8080;
        private XYNetServer myServer = null;
        // Lag nghe Errors
        private void ExceptionHandler(Exception oBug)
        {
            VMSServerEventLog.WriteEntry(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "!! Error: " + oBug.Message, EventLogEntryType.Error);
            EventLogFile(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "!! Error: " + oBug.Message);
            Exception oEx = myServer.GetLastException();
            if (oEx != null)
            {
                VMSServerEventLog.WriteEntry(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "!! Error: " + oBug.Message, EventLogEntryType.Error);
                EventLogFile(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "!! Error: " + oBug.Message);
            }
        }
        // Lang nghe Data
        private void StringInputHandler(string sRemoteAddress, int nRemotePort, string sData)
        {
            VMSServerEventLog.WriteEntry(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " >> Received Data from: " + sRemoteAddress + ":" + nRemotePort.ToString(), EventLogEntryType.Information);
            VMSServerEventLog.WriteEntry("::" + sData, EventLogEntryType.SuccessAudit);
            DataReceivedFile(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " >> Received Data from: " + sRemoteAddress + ":" + nRemotePort.ToString());
            DataReceivedFile("::" + sData);
        }
        // Lang nghe Connection
        private void ConnectionFilter(string sRemoteAddress, int nRemotePort, Socket sock)
        {
            VMSServerEventLog.WriteEntry(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " << Connected to:" + sRemoteAddress + ":" + nRemotePort.ToString(), EventLogEntryType.Information);
        }
        public ServerService()
        {
            InitializeComponent();
            // VMSServerServiceEventLog
            if (!System.Diagnostics.EventLog.SourceExists("VMSServerServiceEvent_Source"))
            {
                System.Diagnostics.EventLog.CreateEventSource("VMSServerServiceEvent_Source", "VMSServerServiceEvent_Log");
            }
            VMSServerEventLog.Source = "VMSServerServiceEvent_Source";
            VMSServerEventLog.Log = "VMSServerServiceEvent_Log";
        }

        protected override void OnStart(string[] args)
        {
            try
            {   
                myServer = new XYNetServer(ServerIP,PortNumber, 0, 100);
                myServer.SetExceptionHandler(new ExceptionHandlerDelegate(this.ExceptionHandler));
                myServer.SetStringInputHandler(new StringInputHandlerDelegate(this.StringInputHandler));
                myServer.SetConnectionFilter(new ConnectionFilterDelegate(this.ConnectionFilter));
                if (myServer.StartServer() == true)
                {
                    VMSServerEventLog.WriteEntry(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "Server Listenning is Started", EventLogEntryType.SuccessAudit);
                    EventLogFile(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "Server Listenning is Started");
                }
            }
            catch (Exception oBug)
            {
                VMSServerEventLog.WriteEntry("Error Type: " + oBug.GetType().Name, EventLogEntryType.Warning);
                VMSServerEventLog.WriteEntry("Error Message: " + oBug.Message, EventLogEntryType.Warning);
                VMSServerEventLog.WriteEntry("Error Source: " + oBug.Source, EventLogEntryType.Warning);
                VMSServerEventLog.WriteEntry("Error StackTrace: " + oBug.StackTrace, EventLogEntryType.Warning);
            }
        }

        protected override void OnStop()
        {
            myServer.StopServer();
        }
        private void EventLogFile(string Log)
        {
            FileStream f = new FileStream(@"C:\EventLog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);

            sw.WriteLine(Log);
            f.Flush();
            sw.Flush();
            sw.Dispose();
        }
        private void DataReceivedFile(string sData)
        {
            FileStream f = new FileStream(@"C:\DataLog.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);

            sw.WriteLine(sData);
            f.Flush();
            sw.Flush();
            sw.Dispose();
        }
    }
}
