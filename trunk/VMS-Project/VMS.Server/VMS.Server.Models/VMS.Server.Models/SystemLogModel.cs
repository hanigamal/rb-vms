using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMS.Server.Models
{
    public class SystemLogModel
    {
        public long LogID { get; set; }
        public string LogValue { get; set; }
        public string LogType { get; set; }
        public DateTime LogTime { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
    }
}
