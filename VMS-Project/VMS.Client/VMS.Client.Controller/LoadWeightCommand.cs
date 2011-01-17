using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using NOIS.TruckWeightMonitoring.Model;

namespace NOIS.TruckWeightMonitoring.Controller
{
    public class LoadWeightCommand:SimpleCommand, ICommand
    {
        public override void Execute(INotification notification)
        {
            Facade.RegisterProxy(new LoadWeightProxy());
        }
    }
}
