using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncPro
{
    public partial class SyncPro : Form
    {
        private readonly UserInfoCollector userInfo;
        public SyncPro(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            this.KeyPreview = true; // Key events are captured by the form

        }

        private void CheckUserRestrictions()
        {
            bool isRoot = userInfo.Role == "Root";

            usersToolStripMenuItem.Image = RoleList.Images[isRoot ? 1 : 0];
            usersDashboardToolStripMenuItem.Enabled = isRoot;
            ProductCodeEditorToolStripMenuItem.Enabled = isRoot;
        }


        public void RestartApplication()
        {
            System.Windows.Forms.Application.Restart();
        }

        private void SyncProInformation_Click(object sender, EventArgs e)
        {
            MainLoad();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SyncProAbout syncProAbout = new SyncProAbout())
            {
                DialogResult result = syncProAbout.ShowDialog();
            }
        }

        private void updateInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserUpdateForm usersRegistrationUpdateForm = new UserUpdateForm(userInfo);
            using (UserUpdateForm form = usersRegistrationUpdateForm)
            {
                form.isResetMode = true;
                form.Id = userInfo.UserID.ToString();
                form.ShowDialog();

                if (form.RestartApplication)
                {
                    RestartApplication();
                }
            }
        }

        public void usersDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            syncProToolStripMenuItem.Text = "Users Dashboard";
            UserManagementPanel controlPanel = new UserManagementPanel(userInfo) { Dock = DockStyle.Fill };
            SyncProLoader.Controls.Clear();
            SyncProLoader.Controls.Add(controlPanel);
        }

        private void MainLoad()
        {
            syncProToolStripMenuItem.Text = "SyncPro";
            SyncProMainForm syncProMainForm = new SyncProMainForm(userInfo) { Dock = DockStyle.Fill };
            SyncProLoader.Controls.Clear();
            SyncProLoader.Controls.Add(syncProMainForm);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordUpdateForm passwordUpdateForm = new PasswordUpdateForm(userInfo);
            using (PasswordUpdateForm form = passwordUpdateForm)
            {
                form.isResetMode = false;
                form.ShowDialog();
            }
        }

        private void viewInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserInformationForm userInformation = new UserInformationForm(userInfo))
            {
                DialogResult result = userInformation.ShowDialog();
            }
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DataBackupForm backupDatabaseForm = new DataBackupForm(userInfo))
            {
                DialogResult result = backupDatabaseForm.ShowDialog();
            }
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RestoreDatabaseForm restoreDatabaseForm = new RestoreDatabaseForm(userInfo))
            {
                DialogResult result = restoreDatabaseForm.ShowDialog();
            }
        }

        public ToolStripMenuItem SyncProMenuItem
        {
            get { return syncProToolStripMenuItem; }
        }

        private void SyncPro_Load(object sender, EventArgs e)
        {
            usersToolStripMenuItem.Text = $"{userInfo.FirstName} {userInfo.LastName}";
            MainLoad();
            CheckUserRestrictions();
        }
        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RestartApplication();
        }
        
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusStrip1.Visible)
            {
                statusStrip1.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
        }
        private void ToggleFullScreen()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                fullScreenToolStripMenuItem.Checked = false;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                fullScreenToolStripMenuItem.Checked = true;
            }
        }
        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void SyncPro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                ToggleFullScreen();
                e.Handled = true;
            }
        }

        private void ProductCodeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ProductCodeEditorForm productCodeEditorForm = new ProductCodeEditorForm(userInfo))
            {
                productCodeEditorForm.ShowDialog();
            }
        }

        private void SyncProStatusLabel_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://selimbirincioglu.bio.link/");

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartApplication();
        }
        private void CleanupSesion()
        {
            Properties.Settings.Default.RememberedUsername = string.Empty;
            Properties.Settings.Default.RememberedPassword = string.Empty;

            Properties.Settings.Default.SavedUsernames = string.Empty;

            Properties.Settings.Default.Save();
        }
        private void cleanupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear all saved session data?", "Clear Session Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                CleanupSesion();
                MessageBox.Show("Session data has been cleared successfully.", "Session Data Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void producTListEditingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ProductListEditingForm productListEditingForm = new ProductListEditingForm(userInfo))
            {
                productListEditingForm.ShowDialog();
            }            
        }

        private void systemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SystemSettingsForm systemSettingsForm = new SystemSettingsForm(userInfo))
            {
                systemSettingsForm.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
