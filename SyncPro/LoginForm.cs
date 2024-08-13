using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class LoginForm : Form
    {
        public DialogResult AuthenticationResult { get; private set; }
        private UserInfoCollector authenticatedUserInfo;
        public LoginForm()
        {
            InitializeComponent();

            UsernameBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            UsernameBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            LoadUsernamesForAutoComplete();
        }
        private void LoadUsernamesForAutoComplete()
        {
            AutoCompleteStringCollection usernamesCollection = new AutoCompleteStringCollection();

            string[] savedUsernames = Properties.Settings.Default.SavedUsernames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string username in savedUsernames)
            {
                usernamesCollection.Add(username.Trim());
            }

            UsernameBox.AutoCompleteCustomSource = usernamesCollection;
        }


        private void LogInButton_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RememberMeCheckBox.Checked)
            {
                try
                {
                    string encryptedUsername = EncryptionHelper.EncryptString(username);
                    string encryptedPassword = EncryptionHelper.EncryptString(password);

                    Properties.Settings.Default.RememberedUsername = encryptedUsername;
                    Properties.Settings.Default.RememberedPassword = encryptedPassword;
                    if (!Properties.Settings.Default.SavedUsernames.Contains(username))
                    {
                        Properties.Settings.Default.SavedUsernames += (Properties.Settings.Default.SavedUsernames.Length > 0 ? "," : "") + username;
                    }
                    Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving login information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Properties.Settings.Default.RememberedUsername = string.Empty;
                Properties.Settings.Default.RememberedPassword = string.Empty;
                if (!Properties.Settings.Default.SavedUsernames.Contains(username))
                {
                    Properties.Settings.Default.SavedUsernames += (Properties.Settings.Default.SavedUsernames.Length > 0 ? "," : "") + username;
                }
                Properties.Settings.Default.Save();
            }

            try
            {
                bool isAuthenticated = AuthenticateUser(username, password);

                if (isAuthenticated)
                {
                    authenticatedUserInfo = GetUserInfo(username);
                    AuthenticationResult = DialogResult.OK;
                    this.Hide();
                }
                else
                {
                    AuthenticationResult = DialogResult.No;
                    MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during authentication: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT PasswordHash, Salt FROM Users WHERE UserName = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPasswordHash = reader["PasswordHash"].ToString();
                            string salt = reader["Salt"].ToString();
                            isAuthenticated = PasswordHasher.VerifyPassword(password, storedPasswordHash, salt);
                        }
                    }
                }
            }

            return isAuthenticated;
        }

        private UserInfoCollector GetUserInfo(string username)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE UserName = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserInfoCollector userInfo = new UserInfoCollector
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Role = reader["Role"].ToString(),
                                ProfileImage = reader["ProfileImage"] != DBNull.Value ? (byte[])reader["ProfileImage"] : null,
                            };
                            return userInfo;
                        }
                    }
                }
            }

            return null;
        }

        public UserInfoCollector GetAuthenticatedUserInfo()
        {
            return authenticatedUserInfo;
        }

        private void ShowHidePass_Click(object sender, EventArgs e)
        {
            PasswordBox.UseSystemPasswordChar = !PasswordBox.UseSystemPasswordChar;
            ShowHidePass.ImageIndex = PasswordBox.UseSystemPasswordChar ? 1 : 0;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.RememberedUsername))
            {
                UsernameBox.Text = EncryptionHelper.DecryptString(Properties.Settings.Default.RememberedUsername);
                PasswordBox.Text = EncryptionHelper.DecryptString(Properties.Settings.Default.RememberedPassword);
                RememberMeCheckBox.Checked = true;
            }
        }
    }
}
