using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.IO;
using log4net;

namespace SingleInstance
{
    /// <summary>
    /// Summary description for SingleApp.
    /// </summary>
    public class SingleApplication
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SingleApplication()
        {

        }
        /// <summary>
        /// Imports 
        /// </summary>

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int IsIconic(IntPtr hWnd);

        /// <summary>
        /// GetCurrentInstanceWindowHandle
        /// </summary>
        /// <returns></returns>
        private static IntPtr GetCurrentInstanceWindowHandle()
        {
            try
            {
                IntPtr hWnd = IntPtr.Zero;
                Process process = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName(process.ProcessName);
                foreach (Process _process in processes)
                {
                    // Get the first instance that is not this instance, has the
                    // same process name and was started from the same file name
                    // and location. Also check that the process has a valid
                    // window handle in this session to filter out other user's
                    // processes.
                    if (_process.Id != process.Id &&
                        _process.MainModule.FileName == process.MainModule.FileName &&
                        _process.MainWindowHandle != IntPtr.Zero)
                    {
                        hWnd = _process.MainWindowHandle;
                        break;
                    }
                }
                return hWnd;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// SwitchToCurrentInstance
        /// </summary>
        private static void SwitchToCurrentInstance()
        {
            try
            {
                IntPtr hWnd = GetCurrentInstanceWindowHandle();
                if (hWnd != IntPtr.Zero)
                {
                    // Restore window if minimised. Do not restore if already in
                    // normal or maximised window state, since we don't want to
                    // change the current state of the window.
                    if (IsIconic(hWnd) != 0)
                    {
                        ShowWindow(hWnd, SW_RESTORE);
                    }

                    // Set foreground window.
                    SetForegroundWindow(hWnd);
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute a form base application if another instance already running on
        /// the system activate previous one
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>true if no previous instance is running</returns>
        public static bool Run(System.Windows.Forms.ApplicationContext context, System.Windows.Forms.Form form)
        {
            try
            {
                if (IsAlreadyRunning())
                {
                    Application.Run(form);
                    return false;
                }
                Application.Run(context);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute a form base application if another instance already running on
        /// the system activate previous one
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>true if no previous instance is running</returns>
        public static bool Run(System.Windows.Forms.Form form, System.Windows.Forms.ApplicationContext context)
        {
            try
            {
                if (IsAlreadyRunning())
                {
                    Application.Run(context);
                    return false;
                }
                Application.Run(form);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute a form base application if another instance already running on
        /// the system activate previous one
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>true if no previous instance is running</returns>
        public static bool Run(System.Windows.Forms.Form form, System.Windows.Forms.Form form2)
        {
            try
            {
                if (IsAlreadyRunning())
                {
                    Application.Run(form2);
                    return false;
                }
                Application.Run(form);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute a form base application if another instance already running on
        /// the system activate previous one
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>true if no previous instance is running</returns>
        public static bool Run(System.Windows.Forms.ApplicationContext context, System.Windows.Forms.ApplicationContext context2)
        {
            try
            {
                if (IsAlreadyRunning())
                {
                    Application.Run(context2);
                    return false;
                }
                Application.Run(context);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        public static bool Check(Action<object> action, Action<object> action2)
        {
            try
            {
                if (IsAlreadyRunning())
                {
                    action2(null);
                    return false;
                }
                action(null);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute a form base application if another instance already running on
        /// the system activate previous one
        /// </summary>
        /// <param name="frmMain">main form</param>
        /// <returns>true if no previous instance is running</returns>
        public static bool Run(System.Windows.Forms.Form frmMain)
        {
            try
            {
                if (IsAlreadyRunning())
                {
                    //set focus on previously running app
                    SwitchToCurrentInstance();
                    return false;
                }
                Application.Run(frmMain);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Execute a form base application if another instance already running on
        /// the system activate previous one
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>true if no previous instance is running</returns>
        public static bool Run(System.Windows.Forms.ApplicationContext context)
        {
            try
            {
                if (IsAlreadyRunning())
                {
                    //set focus on previously running app
                    SwitchToCurrentInstance();
                    return false;
                }
                Application.Run(context);
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// for console base application
        /// </summary>
        /// <returns></returns>
        public static bool Run()
        {
            try
            {
                if (IsAlreadyRunning())
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// check if given exe alread running or not
        /// </summary>
        /// <returns>returns true if already running</returns>
        private static bool IsAlreadyRunning()
        {
            try
            {
                string strLoc = Assembly.GetExecutingAssembly().Location;
                FileSystemInfo fileInfo = new FileInfo(strLoc);
                string sExeName = fileInfo.Name;
                bool bCreatedNew;

                mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
                if (bCreatedNew)
                    mutex.ReleaseMutex();

                return !bCreatedNew;
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex);
                throw new Exception(ex.Message);
            }
        }

        static Mutex mutex;
        const int SW_RESTORE = 9;
    }
}
