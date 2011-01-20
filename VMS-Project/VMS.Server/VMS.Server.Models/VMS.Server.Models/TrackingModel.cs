using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VMS.Server.Models
{
    public class TrackingModel
    {
        public long TrackingID { get; set; }
        public string ModuleNumber { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public double Speed { get; set; }
        public double FuelLevel { get; set; }
        public DateTime Time { get; set; }
    }
}
