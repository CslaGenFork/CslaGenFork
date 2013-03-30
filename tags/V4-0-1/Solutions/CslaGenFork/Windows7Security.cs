using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace CslaGenerator
{
    public static class Windows7Security
    {
        internal static bool IsVistaOrHigher()
        {
            return Environment.OSVersion.Version.Major > 5;// 5 is XP
        }

        /// <summary>
        /// Checks if the process is elevated
        /// </summary>
        /// <returns>If is elevated</returns>
        private static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal p = new WindowsPrincipal(id);
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }

        internal static void StartCodeSmithHandler()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.StartupPath + @"\" + "HandleCodeSmithExtension.exe";
            //if (IsVistaOrHigher())
            //{
            if (!IsAdmin())
            {
                startInfo.Verb = "runas";
            }
            //}

            try
            {
                Process process = Process.Start(startInfo);
                process.WaitForExit();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                return; //If cancelled, do nothing
            }
        }
    }
}