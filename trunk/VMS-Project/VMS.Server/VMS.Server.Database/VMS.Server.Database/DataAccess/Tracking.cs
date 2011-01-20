using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.Server.Models;

namespace VMS.Server.Database.DataAccess
{
    public class Tracking
    {
        public TrackingModel GetModule(long id)
        {
            vmsServerLinqDataContext datacontext = new vmsServerLinqDataContext();
            var query = (from t in datacontext.Trackings
                        where t.TrackingID == id
                        select t).SingleOrDefault();
            TrackingModel model = new TrackingModel();
            try
            {
                model.TrackingID = query.TrackingID;
                model.ModuleNumber = query.ModuleID;
                model.Longtitude = Convert.ToDouble(query.Longtitude);
                model.Latitude = Convert.ToDouble(query.Latitude);
                model.Speed = Convert.ToDouble(query.Speed);
                model.FuelLevel = Convert.ToDouble(query.FuelLevel);
                model.Time = Convert.ToDateTime(query.Time);
                return model;
            }
            catch
            {
                return null;
            }
        }
    }
}
