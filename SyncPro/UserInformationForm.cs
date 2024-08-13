using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class UserInformationForm : Form
    {
        private readonly UserInfoCollector userInfo;

        public UserInformationForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }

        private void UserInformationForm_Load(object sender, EventArgs e)
        {
            SetUserInfo(userInfo.UserID);
        }
        private void SetUserInfo(int userID)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserId", connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // TextBox kontrollerine veriyi atama
                            UserNameTextBox.Text = reader["UserName"].ToString();
                            EmailTextBox.Text = reader["Email"].ToString();
                            FirstNameTextBox.Text = reader["FirstName"].ToString();
                            LastNameTextBox.Text = reader["LastName"].ToString();
                            RegistrationDateTimePicker.Value = DateTime.Parse(reader["RegistrationDate"].ToString());
                            RoleTextBox.Text = reader["Role"].ToString();
                            if (reader["ProfileImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["ProfileImage"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    ProfileBox.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                ProfileBox.Image = null;
                            }
                        }
                    }
                }
            }
        }

        private void PassRestButton_Click(object sender, EventArgs e)
        {
            PasswordUpdateForm passwordUpdateForm = new PasswordUpdateForm(userInfo);
            using (PasswordUpdateForm form = passwordUpdateForm)
            {
                form.isResetMode = true;
                form.ShowDialog();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            UserUpdateForm userUpdateForm = new UserUpdateForm(userInfo);
            using (UserUpdateForm form = userUpdateForm)
            {
                form.isResetMode = true;
                form.Id = userInfo.UserID.ToString();
                form.ShowDialog();
            }
            SetUserInfo(userInfo.UserID);
        }
    }
}
