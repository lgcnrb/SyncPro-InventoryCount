using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class UserUpdateForm : Form
    {
        public bool RestartApplication { get; private set; }
        private readonly UserInfoCollector userInfo;
        public bool isResetMode;

        public string Id { get; internal set; }
        private readonly PasswordHasher _passwordHasher;
        public DialogResult RegistrationResult { get; private set; }
        public string password { get; private set; }
        public string salt { get; private set; }
        public UserUpdateForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            _passwordHasher = new PasswordHasher();
            this.userInfo = userInfo;
            if (userInfo.Role == "Root") { RootCheckBox.Visible = true; }
            else { RootCheckBox.Visible = false; }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    string role = RootCheckBox.Checked ? "Root" : "User";
                    int userid = int.Parse(Id);
                    IUsersRepository repository = new UsersRepository();
                    bool result = await repository.Update(new UsersControl()
                    {
                        UserID = userid,
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        UserName = UsernameTextBox.Text,
                        PasswordHash = password,
                        Salt = salt,
                        Email = EmailTextBox.Text,
                        RegistrationDate = DateTime.Now,
                        Role = role,
                        ProfileImage = ProfileBox.Image != null ? ImageToByteArray(ProfileBox.Image) : null
                    });

                    if (!result)
                    {
                        MessageBox.Show("Error updating user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (isResetMode)
                    {
                        DialogResult dialogResult = MessageBox.Show("User updated successfully. Do you want to restart the application?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dialogResult == DialogResult.Yes)
                        {
                            RestartApplication = true;
                        }
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || FirstNameTextBox.Text.Length < 2)
            {
                MessageBox.Show("Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) || LastNameTextBox.Text.Length < 2)
            {
                MessageBox.Show("Please enter a valid surname.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || UsernameTextBox.Text.Length < 5)
            {
                MessageBox.Show("Please enter a valid username (at least 5 characters).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || !System.Text.RegularExpressions.Regex.IsMatch(EmailTextBox.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void UserUpdateForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@UserId", Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UsernameTextBox.Text = reader["UserName"].ToString();
                            FirstNameTextBox.Text = reader["FirstName"].ToString();
                            LastNameTextBox.Text = reader["LastName"].ToString();
                            EmailTextBox.Text = reader["Email"].ToString();
                            password = reader["PasswordHash"].ToString();
                            salt = reader["Salt"].ToString();

                            if (reader["Role"].ToString() == "Root")
                            {
                                RootCheckBox.Checked = true;
                            }
                            else
                            {
                                RootCheckBox.Checked = false;
                            }

                            // Profil fotoğrafını yükle
                            if (reader["ProfileImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["ProfileImage"];
                                using (var ms = new MemoryStream(imageBytes))
                                {
                                    ProfileBox.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private void ChooseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select a Profile Picture";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ProfileBox.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
