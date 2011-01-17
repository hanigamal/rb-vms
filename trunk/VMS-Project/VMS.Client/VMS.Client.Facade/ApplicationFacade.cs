using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using System.Reflection;

namespace VMS.Client.Facade
{
    public class ApplicationFacade : PureMVC.Patterns.Facade
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static readonly BindingFlags BindingTemplate = BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance;

        #region Define command name here
        public const string STARTUP_COMMAND = "StartupCommand";
        public const string LOGIN_COMMAND = "LoginCommand";
        public const string LOGOUT_COMMAND = "LogoutCommand";
        public const string SCALE_COMMAND = "ScaleCommand";
        public const string MATERIALWEIGHT_COMMAND = "MaterialWeightCommand";
        public const string REPORT_COMMAND = "ReportCommand";
        #endregion

        #region Define notificatoin name here
        public const string LOGIN_SUCCESS = "loginSuccess";
        public const string LOGIN_FAILED = "loginFailed";
        public const string LOGGED_OUT = "loggedOut";


        public const string SCALE_CURRENT_VALUE = "scaleCurrentValue";
        public const string SCALE_ERROR = "scaleError";

        public const string CONFIRMSUCCESS = "confirmSuccess";
        public const string CONFIRMFAILED = "confirmFailed";

        public const string CONFIRMALC = "confirmALC";
        public const string CONFIRMALC_SUCCESS = "confrimALCSuccess";
        public const string CONFRIMALC_FAILED = "confrimALCFailed";

        public const string LOAD_MATERIALWEIGHTIN = "loadMaterialWeightIn";
        public const string LOAD_ALCWEIGHTIN = "loadALCWeightIn";

        public const string NORMAL_SESSION = "normalSession";
        public const string ALC_SESSION = "alcSession";

        public const string NORMAL_SESSION_COMPLETED = "normalSessionCompleted";
        public const string ALC_SESSION_COMPLETED = "alcSessionCompeted";

        public const string DELETEUSER = "deleteUser";
        public const string DELETEUSER_SUCCESS = "deleteUserSuccess";
        public const string DELETEUSER_FAILED = "deleteUserFailed";

        public const string SAVEUSER = "saveUser";
        public const string SAVEUSER_SUCCESS = "saveUserSuccess";
        public const string SAVEUSER_FAILED = "saveUserFailed";

        public const string SCARE_STOP = "scareStop";
        public const string SCALE_SIMULATION = "scaleSimulation";
        public const string RE_REGISTER_SCALE_PROXY = "registerProxy";

        #endregion

        #region Accessors

        /// <summary>
        /// Facade Singleton Factory method.  This method is thread safe.
        /// </summary>
        public new static IFacade Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_staticSyncRoot)
                    {
                        if (m_instance == null) m_instance = new ApplicationFacade();
                    }
                }

                return m_instance;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Start the application
        /// </summary>
        /// <param name="app"></param>
        public void Startup(object app)
        {
            SendNotification(STARTUP_COMMAND, app);
        }

        #endregion

        #region Protected & Internal Methods

        protected ApplicationFacade()
        {
            // Protected constructor.
        }

        /// <summary>
        /// Explicit static constructor to tell C# compiler 
        /// not to mark type as beforefieldinit
        ///</summary>
        static ApplicationFacade()
        {
        }

        /// <summary>
        /// Register Commands with the Controller
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();
            log.Info("Registering StartupCommand");

            var assembly = Assembly.Load("NOIS.TruckWeightMonitoring.Controller");

            Type type = assembly.GetType("NOIS.TruckWeightMonitoring.Controller.StartupCommand");
            RegisterCommand(STARTUP_COMMAND, type);
        }

        #endregion

    }
}
