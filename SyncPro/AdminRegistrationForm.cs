using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SyncPro
{
    public partial class AdminRegistrationForm : Form
    {
        private readonly PasswordHasher _passwordHasher;
        public DialogResult RegistrationResult { get; private set; }

        public AdminRegistrationForm()
        {
            InitializeComponent();
            _passwordHasher = new PasswordHasher();
        }

        private async void SaveButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    string salt = PasswordHasher.GenerateSalt();
                    string hashedPassword = PasswordHasher.HashPassword(PasswordTextBox.Text, salt);
                    IUsersRepository repository = new UsersRepository();
                    string username = UsernameTextBox.Text;
                    string email = EmailTextBox.Text;

                    var existingUserByUsername = await repository.GetByUsername(username);
                    if (existingUserByUsername != null)
                    {
                        MessageBox.Show("Username is already taken. Please choose a different username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var existingUserByEmail = await repository.GetByEmail(email);
                    if (existingUserByEmail != null)
                    {
                        MessageBox.Show("Email is already taken. Please choose a different email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    UsersControl newUser = new UsersControl()
                    {
                        FirstName = FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        UserName = username,
                        PasswordHash = hashedPassword,
                        Salt = salt,
                        Email = email,
                        RegistrationDate = DateTime.Now,
                        Role = "Root",
                        ProfileImage = ProfileBox.Image != null ? ImageToByteArray(ProfileBox.Image) : null
                    };

                    int newUserId = await repository.InsertAndGetId(newUser);
                    RegistrationResult = DialogResult.OK;
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            string name = FirstNameTextBox.Text;
            string surname = LastNameTextBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Please enter your first name and last name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsernameTextBox.Text = GenerationFunctions.GenerateRandomUsername(name, surname);
            EmailTextBox.Text = GenerationFunctions.GenerateRandomEmail(name, surname, Properties.Settings.Default.Domain);
            PasswordTextBox.Text = GenerationFunctions.GenerateStrongPassword();
            PasswordReTextBox.Text = PasswordTextBox.Text;
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
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || FirstNameTextBox.Text.Length < 2)
            {
                MessageBox.Show("Please enter a valid name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) || LastNameTextBox.Text.Length < 2)
            {
                MessageBox.Show("Please enter a valid surname.", "Validation Error", MessageBoxButtons.OK   , MessageBoxIcon.Warning);
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

            string password = PasswordTextBox.Text;
            string confirmPassword = PasswordReTextBox.Text;
            if (!ValidatePassword(password, confirmPassword))
            {
                return false;
            }

            return true;
        }

        private void ShowHidePass_Click(object sender, EventArgs e)
        {
            bool isPasswordVisible = !PasswordTextBox.UseSystemPasswordChar;
            PasswordTextBox.UseSystemPasswordChar = !isPasswordVisible;
            PasswordReTextBox.UseSystemPasswordChar = !isPasswordVisible;
            ShowHidePass.ImageIndex = isPasswordVisible ? 1 : 0;

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
