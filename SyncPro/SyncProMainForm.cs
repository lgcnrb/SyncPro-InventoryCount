using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Text.Json;

namespace SyncPro
{
    public partial class SyncProMainForm : UserControl
    {
        private readonly UserInfoCollector userInfo;
        private Timer timer;

        public SyncProMainForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            InitializeTimer();

        }
        private void CheckUserRestrictions()
        {
            if (userInfo.Role != "Root")
            {
                UserDashboardButton.Enabled = false;
                SystemInventoryButton.Enabled = false;
            }
            else
            {
                UserDashboardButton.Enabled = true;
                SystemInventoryButton.Enabled = true;
            }
        }
        private void SyncProMainForm_Load(object sender, EventArgs e)
        {
            using (var ms = new MemoryStream(userInfo.ProfileImage))
            {
                ProfileBox.Image = Image.FromStream(ms);
            }
            CheckUserRestrictions();
            label1.Text = $"{userInfo.FirstName} {userInfo.LastName}";
            label2.Text = $"{userInfo.UserName}";
            label3.Text = $"{userInfo.Email}";
            label4.Text = $"{userInfo.Role}";
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 saniye
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();

        }
        private void UpdateDateTimeLabel()
        {
            dateTimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        

        private void UserDashboardButton_Click(object sender, EventArgs e)
        {
            var syncProForm = this.FindForm() as SyncPro;

            if (syncProForm != null)
            {
                var syncProMenuItem = syncProForm.SyncProMenuItem;

                if (syncProMenuItem != null)
                {
                    syncProMenuItem.Text = "Users Dashboard";
                }
                else
                {
                    MessageBox.Show("SyncProToolStripMenuItem not found on SyncPro form.",
                                    "Control Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }

                var syncProLoader = syncProForm.Controls["SyncProLoader"] as Panel;

                if (syncProLoader != null)
                {
                    syncProLoader.Controls.Clear();
                    var controlPanel = new UserManagementPanel(userInfo) { Dock = DockStyle.Fill };
                    syncProLoader.Controls.Add(controlPanel);
                }
                else
                {
                    MessageBox.Show("SyncProLoader control not found on SyncPro form.",
                                    "Control Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("SyncPro form not found.",
                                "Form Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void UserInformationButton_Click(object sender, EventArgs e)
        {
            using (UserInformationForm userInformation = new UserInformationForm(userInfo))
            {
                DialogResult result = userInformation.ShowDialog();
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            using (SyncProAbout syncProAbout = new SyncProAbout())
            {
                DialogResult result = syncProAbout.ShowDialog();
            }
        }

        private void SystemInventoryButton_Click(object sender, EventArgs e)
        {
            var syncProForm = this.FindForm() as SyncPro;

            if (syncProForm != null)
            {
                var syncProMenuItem = syncProForm.SyncProMenuItem;

                if (syncProMenuItem != null)
                {
                    syncProMenuItem.Text = "System Inventory";
                }
                else
                {
                    MessageBox.Show("SyncProToolStripMenuItem not found on SyncPro form.",
                                    "Control Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }

                var syncProLoader = syncProForm.Controls["SyncProLoader"] as Panel;

                if (syncProLoader != null)
                {
                    syncProLoader.Controls.Clear();
                    var controlPanel = new SystemInventory(userInfo) { Dock = DockStyle.Fill };
                    syncProLoader.Controls.Add(controlPanel);
                }
                else
                {
                    MessageBox.Show("SyncProLoader control not found on SyncPro form.",
                                    "Control Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("SyncPro form not found.",
                                "Form Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void StocktakingListButton_Click(object sender, EventArgs e)
        {
            var syncProForm = this.FindForm() as SyncPro;

            if (syncProForm != null)
            {
                var syncProMenuItem = syncProForm.SyncProMenuItem;

                if (syncProMenuItem != null)
                {
                    syncProMenuItem.Text = "Stocktaking List";
                }
                else
                {
                    MessageBox.Show("SyncProToolStripMenuItem not found on SyncPro form.",
                                    "Control Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }

                var syncProLoader = syncProForm.Controls["SyncProLoader"] as Panel;

                if (syncProLoader != null)
                {
                    syncProLoader.Controls.Clear();
                    var controlPanel = new StocktakingList(userInfo) { Dock = DockStyle.Fill };
                    syncProLoader.Controls.Add(controlPanel);
                }
                else
                {
                    MessageBox.Show("SyncProLoader control not found on SyncPro form.",
                                    "Control Not Found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("SyncPro form not found.",
                                "Form Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
