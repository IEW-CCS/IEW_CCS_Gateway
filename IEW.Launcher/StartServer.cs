using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using IEW.Platform.Kernel;
using System.Xml;

namespace IEW.Lanucher
{
    static class StartServer
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //v1.0.0.131-2
            var servername = string.Empty;
            try
            {
                string reason;
                var show = Platform_Diagnostics(out servername, out reason);
                if (show)
                {
                    AutoClosingMessageBox.Show(servername, reason, "Duplicated IEW_Platform", 10000);
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                
                AutoClosingMessageBox.Show(servername, "Platform Init Fail Please check Configration.\n" + ex.ToString(), "Initial", 10000);
                Environment.Exit(1);
            }

            Mutex mutex = null;

            IEW.Platform.Kernel.Platform Work = null;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {

                SplashScreenForm.ShowSplashScreen();
                IEW.Platform.Kernel.Platform.PlatformInitialStatus += new PlatformInitialStatusEventHandler(OnWorkbenchInitialStatus);
                IEW.Platform.Kernel.Platform.Instance.Init(@"startup.xml");
                Work = IEW.Platform.Kernel.Platform.Instance;
                var isAppRunning = false;
                try
                {
                     mutex = new Mutex(true, "Global\\"+ IEW.Platform.Kernel.Platform.ServerName, out isAppRunning);
                }
                catch 
                {
                }
                if (!isAppRunning)
                {
                    AutoClosingMessageBox.Show(servername, string.Format("{0} is already running, can't open again!", IEW.Platform.Kernel.Platform.ServerName), @"Execute Error", 10000);
                    Environment.Exit(1);
                }

                Work.Run();
               
                SplashScreenForm.SplashScreen.BeginInvoke(new MethodInvoker(SplashScreenForm.SplashScreen.Dispose));
                SplashScreenForm.SplashScreen = null;
                Application.Run(Work.MainForm);


            }
            catch (Exception ex)
            {
                AutoClosingMessageBox.Show(servername, "Workbench Init Fail Please check Configration.\n" + ex.ToString(), "Initial", 10000);
            }
            finally
            {
                if (mutex != null)
                    mutex.ReleaseMutex();
                if (SplashScreenForm.SplashScreen != null)
                {
                    SplashScreenForm.SplashScreen.Dispose();
                }
                if (Work != null)
                    Work.Shutdown();
            }

          

        }
        static void OnWorkbenchInitialStatus(string msg,bool isStart)
        {
           
            if (isStart)
                SplashScreenForm.SplashScreen.UpdateInitInformation(msg);
            else
                SplashScreenForm.SplashScreen.UpdateServerName(msg);
        }
        static bool Platform_Diagnostics(out string servername, out string reason)
        {
            servername = string.Empty;
            reason = string.Empty;
            try
            {
                if (!File.Exists(@"startup.xml"))
                {
                    reason = @"File not found. filename=[startup.xml].";
                    return true;
                }

                XmlDocument document = new XmlDocument();
                document.Load(@"startup.xml");
                XmlNode node = document.SelectSingleNode("//framework//servername");
                if (node == null)
                {
                    reason = "XmlNode not found. Node=[//framework//servername].";
                    return true;
                }
                servername = node.InnerXml.ToString();
                if (string.IsNullOrEmpty(servername))
                {
                    reason = "XmlNode node.InnerXml is null or empty. Node=[//framework//servername]";
                    return true;
                }

                 return false; 
            }
            catch (Exception ex)
            {
                reason = ex.StackTrace.ToString();
                return true;
            }
        }
    }

    internal class AutoClosingMessageBox
    {
      
        private System.Threading.Timer timeoutTimer;

        private string token;

        private AutoClosingMessageBox(string servername, string text, string caption, int timeout)
        {
            Processing(servername, text, caption, DateTime.Now.ToString("yyyyMMddHHmmssfff"), timeout);
        }

        private AutoClosingMessageBox(string servername, string text, string caption, string trxKey, int timeout)
        {
            Processing(servername, text, caption, trxKey, timeout);
        }

        private void Processing(string servername, string text, string caption, string trxKey, int timeout)
        {
            token = string.Format("{0}-{1}", caption, trxKey);
            var cproc = Process.GetCurrentProcess();
            var info = string.Format("IEW_Platform{0}[PID={1}] initial failed. {2}{3}{4}{3}",
                (string.IsNullOrEmpty(servername) ? string.Empty : string.Format("[{0}]", servername)), cproc.Id.ToString(), new string('=', 45), Environment.NewLine, text);
            timeoutTimer = new System.Threading.Timer(OnTimerElapsed, null, timeout, Timeout.Infinite);
            using (timeoutTimer) MessageBox.Show(info, token, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Show(string servername, string text, string caption, int timeout)
        {
            var autoClosingMessageBox = new AutoClosingMessageBox(servername, text, caption, timeout);
        }

        private void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", token); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero) SendMessage(mbWnd, WmClose, IntPtr.Zero, IntPtr.Zero);
            timeoutTimer.Dispose();
        }

        private const int WmClose = 0x0010;

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
