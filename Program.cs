using System.Diagnostics;
using System.Security.Principal;

namespace Move_n_link
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (!IsAdministrator())
            {
                if (TryRestartAsAdministrator())
                {
                    return;
                }

                MessageBox.Show(
                    "Administrator privileges are required to create symbolic links. Please restart the application as administrator.",
                    "Administrator Privileges Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Application.Run(new Form1());
        }

        public static bool IsAdministrator()
        {
            using var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static bool TryRestartAsAdministrator()
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = Environment.ProcessPath ?? Application.ExecutablePath,
                    UseShellExecute = true,
                    Verb = "runas"
                };
                Process.Start(processInfo);
                return true;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // User cancelled the UAC prompt
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}