namespace Turbo.plugins.patrick.util.diablo
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class D3Client
    {
        private static Process Handle;

        public static Process GetHandle()
        {
            if (Handle != null)
                return Handle;

            var processList = Process.GetProcessesByName("Diablo III");

            if (!processList.Any())
            {
                processList = Process.GetProcessesByName("Diablo III64");

                if (!processList.Any())
                {
                    MessageBox.Show("Diablo not found!");
                    Application.Exit();
                    Environment.Exit(0);
                }
            }

            Handle = processList[0];
            return Handle;
        }

        public static bool IsInForeground()
        {
            return GetForegroundWindow() == GetHandle().MainWindowHandle;
        }
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
    }
}