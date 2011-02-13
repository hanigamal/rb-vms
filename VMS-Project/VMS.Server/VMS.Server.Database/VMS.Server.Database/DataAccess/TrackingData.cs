using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.Server.Models;

namespace VMS.Server.Database.DataAccess
{
    public class TrackingData
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

        public void Save(TrackingModel model)
        {
            vmsServerLinqDataContext datacontext = new vmsServerLinqDataContext();
            Tracking objTracking = new Tracking();
            objTracking.TrackingID = GetLongID();
            objTracking.ModuleID = model.ModuleNumber;
            objTracking.Longtitude = model.Longtitude;
            objTracking.Latitude = model.Latitude;
            objTracking.Speed = model.Speed;
            objTracking.FuelLevel = model.FuelLevel;
            objTracking.Time = DateTime.Now;
            datacontext.Trackings.InsertOnSubmit(objTracking);
            datacontext.SubmitChanges();
        }

        public long GetLongID()
        {
            string strID = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Date.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            long ID = long.Parse(strID);
            return ID;
        }
    }
}
