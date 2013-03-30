using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace HandleCodeSmithExtension
{
    public static class Windows7Security
    {
        [DllImport("user32")]
        public static extern UInt32 SendMessage(IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);

        internal const int BCM_FIRST = 0x1600;
        internal const int BCM_SETSHIELD = (BCM_FIRST + 0x000C);

        internal static bool IsVistaOrHigher()
        {
            return Environment.OSVersion.Version.Major > 5;// 5 is XP
        }

        /// <summary>
        /// Checks if the process is elevated
        /// </summary>
        /// <returns>If is elevated</returns>
        internal static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal p = new WindowsPrincipal(id);
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// Add a shield icon to a button
        /// </summary>
        /// <param name="b">The button</param>
        internal static void AddShieldToButton(Button button)
        {
            button.FlatStyle = FlatStyle.System;
            SendMessage(button.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);
        }
    }
}