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
    public partial class UserManagementPanel : UserControl
    {
        private readonly UserInfoCollector userInfo;

        public UserManagementPanel(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            FilterComboBox.SelectedIndex = 0;
        }

        private void UserManagementPanel_Load(object sender, EventArgs e)
        {
            usersTableAdapter.Fill(syncProDatabaseDataSet.Users);
        }

        private void UserAdd_Click(object sender, EventArgs e)
        {
            using (NewUserForm newUserForm = new NewUserForm(userInfo))
            {
                DialogResult result = newUserForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            usersTableAdapter.Fill(syncProDatabaseDataSet.Users);
        }

        private void UserDelete_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedUserId = usersDataGridView.CurrentRow.Cells[0].Value.ToString();
                    string selectedUsername = usersDataGridView.CurrentRow.Cells[2].Value.ToString();

                    string rootUserId = "Root";
                    int activeUserId = userInfo.UserID;

                    bool rootExists = CheckIfRootExists(rootUserId);

                    if ((rootExists && selectedUserId == rootUserId) || Convert.ToInt32(selectedUserId) == activeUserId)
                    {
                        MessageBox.Show("You cannot delete this user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool deletionSuccessful = DeleteUser(selectedUserId);
                        if (deletionSuccessful)
                        {
                            MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            usersTableAdapter.Fill(syncProDatabaseDataSet.Users);
                        }
                        else
                        {
                            MessageBox.Show("No data deleted in the database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bool CheckIfRootExists(string rootUserId)
            {
                bool rootExists = false;
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Role = @Role";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Role", rootUserId);
                        rootExists = (int)command.ExecuteScalar() > 0;
                    }
                }
                return rootExists;
            }

            bool DeleteUser(string userId)
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }

        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string columnName = FilterComboBox.Text;

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
            {
                con.Open();

                string query = $"SELECT * FROM Users WHERE {columnName} LIKE @SearchValue + '%'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", SearchTextBox.Text);

                    using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);
                        usersDataGridView.DataSource = dt;
                    }
                }
            }
        }

        private void UserEdit_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedUserId = usersDataGridView.CurrentRow.Cells[0].Value.ToString();
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                    {
                        connection.Open();
                        string query = "SELECT * FROM Users WHERE UserID = @UserID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserID", selectedUserId);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    UserUpdateForm userRegistrationUpdateForm = new UserUpdateForm(userInfo);
                                    using (UserUpdateForm form = userRegistrationUpdateForm)
                                    {
                                        form.isResetMode = false;
                                        form.Id = reader["UserID"].ToString();
                                        form.ShowDialog();
                                    }
                                    usersTableAdapter.Fill(syncProDatabaseDataSet.Users);
                                }
                                else
                                {
                                    MessageBox.Show("Data not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            usersTableAdapter.Fill(syncProDatabaseDataSet.Users);
        }

        private void UserPassEdit_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.CurrentRow != null)
            {
                try
                {
                    string selectedUserId = usersDataGridView.CurrentRow.Cells[0].Value.ToString();
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SyncProDatabaseConnectionString))
                    {
                        connection.Open();
                        string query = "SELECT * FROM Users WHERE UserID = @UserID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserID", selectedUserId);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    PasswordUpdateForm userRegistrationUpdateForm = new PasswordUpdateForm(userInfo);
                                    using (PasswordUpdateForm form = userRegistrationUpdateForm)
                                    {
                                        form.isResetMode = false;
                                        form.Id = reader["UserID"].ToString();
                                        form.ShowDialog();
                                    }
                                    usersTableAdapter.Fill(syncProDatabaseDataSet.Users);
                                }
                                else
                                {
                                    MessageBox.Show("Data not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExternalMethods.ExportToExcel(usersDataGridView, "Users");
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            SearchTextBox.Clear();
        }
    }
}
