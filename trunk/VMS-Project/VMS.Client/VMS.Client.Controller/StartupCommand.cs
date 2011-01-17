using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Reflection;
using VMS.Client.Facade;

namespace VMS.Client.Controller
{
    public class StartupCommand : SimpleCommand, ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void Execute(INotification notification)
        {
            log.Debug(String.Format("Get notification: {0}{1}", Environment.NewLine, notification.ToString()));

            if (notification.Body == null)
            {
                log.Error(String.Format("Body of notification is null: {0}{1}", Environment.NewLine, notification.ToString()));
                return;
            }

            log.Info("Registering LoginCommand");
           // Facade.RegisterCommand(ApplicationFacade.LOGIN_COMMAND, typeof(NOIS.TruckWeightMonitoring.Controller.LoginCommand));
            //Facade.RegisterMediator(new LoginMediator(notification.Body));
            //Facade.RegisterMediator(new ApplicationMediator());
        }
    }
}
