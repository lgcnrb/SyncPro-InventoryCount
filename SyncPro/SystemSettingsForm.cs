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
    public partial class SystemSettingsForm : Form
    {
        private readonly UserInfoCollector userInfo;

        public SystemSettingsForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }
        private void LoadSettings()
        {
            // Password Generator Settings
            LowerCheckBox.Checked = Properties.Settings.Default.LowerCase;
            UpperCheckBox.Checked = Properties.Settings.Default.UpperCase;
            NumbersCheckBox.Checked = Properties.Settings.Default.NumericCase;
            SpecialCheckBox.Checked = Properties.Settings.Default.SpacialCase;
            LowerBox.Text = Properties.Settings.Default.LOWER_CASE;
            UpperBox.Text = Properties.Settings.Default.UPPER_CASE;
            SpecialBox.Text = Properties.Settings.Default.SPECIAL_CHARACTER;
            NumbersBox.Text = Properties.Settings.Default.NUMBERIC;
            PasswordLengthNumbers.Value = Properties.Settings.Default.PasswordLength;

            // Diğer ayarları yükleme
            BackupBox.Text = Properties.Settings.Default.BackupFilePath;
            ProductsBox.Text = Properties.Settings.Default.FilterPath;
            ServerBox.Text = Properties.Settings.Default.SyncProDatabaseConnectionString;
            DomainComboBox.Text = Properties.Settings.Default.Domain;
        }
        private void SystemSettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void PassButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LowerCase = LowerCheckBox.Checked;
            Properties.Settings.Default.UpperCase = UpperCheckBox.Checked;
            Properties.Settings.Default.NumericCase = NumbersCheckBox.Checked;
            Properties.Settings.Default.SpacialCase = SpecialCheckBox.Checked;
            Properties.Settings.Default.LOWER_CASE = LowerBox.Text;
            Properties.Settings.Default.UPPER_CASE = UpperBox.Text;
            Properties.Settings.Default.SPECIAL_CHARACTER = SpecialBox.Text;
            Properties.Settings.Default.NUMBERIC = NumbersBox.Text;
            Properties.Settings.Default.PasswordLength = (int)PasswordLengthNumbers.Value;
            Properties.Settings.Default.Save();
        }

        private void ServerButton_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.SyncProDatabaseConnectionString = ServerBox.Text;
            Properties.Settings.Default.Save();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BackupFilePath = BackupBox.Text;
            Properties.Settings.Default.Save();
        }

        private void DomainButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Domain = DomainComboBox.Text;
            Properties.Settings.Default.Save();
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FilterPath = ProductsBox.Text;
            Properties.Settings.Default.Save();
        }

        private void ChooseProducts_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProductsBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void ChooseBackup_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    BackupBox.Text = folderDialog.SelectedPath;
                }
            }
        }
    }
}
