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
    public partial class InventoryCountInformationForm : Form
    {
        public string AuditorName { get; private set; }
        public string CountedByName { get; private set; }
        private readonly UserInfoCollector userInfo;
        public InventoryCountInformationForm(UserInfoCollector userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
        }


        private void StartCounting_Click(object sender, EventArgs e)
        {
            AuditorName = auditorTextBox.Text;
            CountedByName = countedByTextBox.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InventoryCountInformationForm_Load(object sender, EventArgs e)
        {
            countedByTextBox.Text = $"{userInfo.FirstName} {userInfo.LastName}";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
