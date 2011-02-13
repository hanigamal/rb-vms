using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.Server.Models;
using log4net;
using System.Reflection;

namespace VMS.Server.Database.DataAccess
{
    public class SystemLogData
    {
        private static readonly ILog log4net = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Save(SystemLogModel model)
        {
            log4net.Debug("end");
            vmsServerLinqDataContext datacontext = new vmsServerLinqDataContext();
            SystemLog log = new SystemLog();
            log.LogID = GetLongID();
            log.LogValue = model.LogValue;
            log.Type = model.LogType;
            log.Time = model.LogTime;
            log.Source = model.Source;
            log.StackTrace = model.StackTrace;
            datacontext.SystemLogs.InsertOnSubmit(log);

            log4net.Debug("end");
            datacontext.SubmitChanges();
            log4net.Debug("end");
        }

        public long GetLongID()
        {
            string strID = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            long ID = long.Parse(strID);
            return ID;
        }
    }
}
