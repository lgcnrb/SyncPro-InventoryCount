using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class PasswordUpdateForm : Form
    {
        private readonly UserInfoCollector userInfo;
        private readonly PasswordHasher _passwordHasher;
        public string Id { get; internal set; }
        public string username { get; private set; }
        public string email { get; private set; }
        public string firstname { get; private set; }
        public string lastname { get; private set; }
        public DateTime registrationDate { get; private set; }
        public string role { get; private set; }
        public bool isResetMode;

        public DialogResult RegistrationResult { get; private set; }

        public PasswordUpdateForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            _passwordHasher = new PasswordHasher();
            this.userInfo = userInfo;
        }

        private bool ValidatePassword(string password, string confirmPassword)
        {
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (confirmPassword != password)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsPasswordSecure(password))
            {
                MessageBox.Show("Password must contain at least one uppercase letter, one lowercase letter, and one special character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsPasswordSecure(string password)
        {
            return password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(IsSpecialCharacter);
        }

        private bool IsSpecialCharacter(char c)
        {
            return "!@#$%^&*()-_+=<>?.".Contains(c);
        }

        private bool ValidateForm()
        {
            string password = PasswordTextBox.Text;
            string confirmPassword = PasswordReTextBox.Text;
            string oldPassword = PasswordOldBox.Text;

            if (!ValidateOldPassword(oldPassword))
            {
                return false;
            }

            if (!ValidatePassword(password, confirmPassword))
            {
                return false;
            }

            return true;
        }

        private bool ValidateOldPassword(string oldPassword)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                connection.Open();
                string query = "SELECT PasswordHash, Salt FROM Users WHERE UserID = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int userId = isResetMode ? userInfo.UserID : int.Parse(Id);
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedOldPassword = PasswordHasher.HashPassword(oldPassword, reader["Salt"].ToString());

                            if (hashedOldPassword != reader["PasswordHash"].ToString())
                            {
                                MessageBox.Show("Old password is incorrect.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private async Task SetUserInfoAsync(int userId)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            username = reader["UserName"].ToString();
                            email = reader["Email"].ToString();
                            firstname = reader["FirstName"].ToString();
                            lastname = reader["LastName"].ToString();
                            registrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            role = reader["Role"].ToString();
                        }
                    }
                }
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    string salt = PasswordHasher.GenerateSalt();
                    string hashedPassword = PasswordHasher.HashPassword(PasswordTextBox.Text, salt);
                    int userId = isResetMode ? userInfo.UserID : int.Parse(Id);

                    await SetUserInfoAsync(userId);

                    IUsersRepository repository = new UsersRepository();
                    bool result = await repository.UpdatePassword(new UsersControl()
                    {
                        UserID = userId,
                        FirstName = firstname,
                        LastName = lastname,
                        UserName = username,
                        PasswordHash = hashedPassword,
                        Salt = salt,
                        Email = email,
                        RegistrationDate = registrationDate,
                        Role = role
                    });

                    if (!result)
                    {
                        MessageBox.Show("Password update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegistrationResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Password update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneratePassButton_Click(object sender, EventArgs e)
        {
            string generatedPassword = GenerationFunctions.GenerateStrongPassword();

            PasswordTextBox.Text = generatedPassword;
            PasswordReTextBox.Text = generatedPassword;
        }

        private void ShowHidePass_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = !PasswordTextBox.UseSystemPasswordChar;
            PasswordReTextBox.UseSystemPasswordChar = !PasswordReTextBox.UseSystemPasswordChar;
            PasswordOldBox.UseSystemPasswordChar = !PasswordOldBox.UseSystemPasswordChar;

            ShowHidePass.ImageIndex = PasswordTextBox.UseSystemPasswordChar ? 1 : 0;
        }

        private void PasswordUpdateForm_Load(object sender, EventArgs e)
        {
            // Form yüklenirken yapılacak işlemler
        }
    }
}
