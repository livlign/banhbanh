using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //register the event handler to catch all unhandled exceptions
                Application.ThreadException += new ThreadExceptionEventHandler(UnhandledExceptionHandler);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException); ;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogin());
            }
            catch (Exception ex)
            {
                Utilities.WriteLogError("Error start up: " + ex.Message);
            }
            
        }



        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exp = (Exception)e.ExceptionObject;
                Utilities.WriteLogError("Error: " + exp.Message + Environment.NewLine + exp.StackTrace);
            }
            catch (Exception ex)
            {
                Utilities.WriteLogError("Error CurrentDomain_UnhandledException: " + ex.Message);
            }
        }


        public static void UnhandledExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                var exp = e.Exception; 
                Utilities.WriteLogError("Error: " + exp.Message + Environment.NewLine + exp.StackTrace);
            }
            catch (Exception ex)
            {
                Utilities.WriteLogError("Error UnhandledExceptionHandler: " + ex.Message);
            }

        }
    }
}
