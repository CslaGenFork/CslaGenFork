using System;
using System.Windows.Forms;

namespace HandleCodeSmithExtension
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!CheckCommandLineArgs(args))
                Application.Exit();
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new HandleCodeSmithExtension());
            }
        }

        private static bool CheckCommandLineArgs(string[] args)
        {
            if (Windows7Security.IsAdmin())
            {
                return true;
            }
            MessageBox.Show(@"Administrative elevation is needed. Program will close now.", @"CodeSmith Extension Handler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}