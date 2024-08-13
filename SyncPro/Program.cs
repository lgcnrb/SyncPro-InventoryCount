using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SyncPro
{
    internal static class Program
    {
        private static Mutex mutex = new Mutex(true, "{SYNC_PRO_MUTEX}", out bool isOwned);

        [STAThread]
        static void Main()
        {
            bool isOwned;
            using (Mutex mutex = new Mutex(true, "{SYNC_PRO_MUTEX}", out isOwned))
            {
                if (!isOwned)
                {
                    MessageBox.Show("Another instance of the application is already running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                CheckAndRunFlow();
            }
        }

        static void CheckAndRunFlow()
        {
            if (CheckIfFirstRun())
            {
                RunFirstRegistrationFlow();
            }
            else
            {
                RunAuthenticationFlow();
            }
        }

        static void RunFirstRegistrationFlow()
        {
            AdminRegistrationForm AdminRegistrationForm = new AdminRegistrationForm();
            AdminRegistrationForm.ShowDialog();

            DialogResult registrationResult = AdminRegistrationForm.RegistrationResult;
            LoginForm LoginForm = new LoginForm();

            if (registrationResult == DialogResult.OK)
            {
                LoginForm.ShowDialog();
            }
            else
            {
                ShowAndExit("Registration failed or canceled. Exiting application.");
                return;
            }

            DialogResult authenticationResult = LoginForm.AuthenticationResult;

            if (authenticationResult == DialogResult.OK)
            {
                UserInfoCollector userInfo = LoginForm.GetAuthenticatedUserInfo();
                SyncPro syncProMainForm = new SyncPro(userInfo);
                Application.Run(syncProMainForm);
            }
            else
            {
                ShowAndExit("Authentication failed or canceled. Exiting application.");
            }
        }

        static void RunAuthenticationFlow()
        {
            LoginForm LoginForm = new LoginForm();
            LoginForm.ShowDialog();
            DialogResult authenticationResult = LoginForm.AuthenticationResult;

            if (authenticationResult == DialogResult.OK)
            {
                UserInfoCollector userInfo = LoginForm.GetAuthenticatedUserInfo();
                SyncPro syncProMainForm = new SyncPro(userInfo);
                Application.Run(syncProMainForm);
            }
            else
            {
                ShowAndExit("Authentication failed or canceled. Exiting application.");
            }
        }

        public static void LogOutIn()
        {
            LoginForm LoginForm = new LoginForm();
            LoginForm.ShowDialog();

            DialogResult authenticationResult = LoginForm.AuthenticationResult;

            if (authenticationResult == DialogResult.OK)
            {
                UserInfoCollector userInfo = LoginForm.GetAuthenticatedUserInfo();
                LoginForm.Close();
                SyncPro syncProMainForm = new SyncPro(userInfo);
                Application.Run(syncProMainForm);
            }
            else
            {
                LoginForm.Close();
                ShowAndExit("Authentication failed or canceled. Exiting application.");
            }
        }

        static bool CheckIfFirstRun()
        {
            bool isFirstRun = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT TOP 1 1 FROM Users", connection))
                    {
                        isFirstRun = command.ExecuteScalar() == null;
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowAndExit($"Error checking first run: {ex.Message}");
            }

            return isFirstRun;
        }

        static void ShowAndExit(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        static void RestartApplication()
        {
            mutex.ReleaseMutex();

            Process.Start(Application.ExecutablePath);
            Application.Exit();
        }
    }
}
