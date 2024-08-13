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
    public partial class SyncProAbout : Form
    {
        public SyncProAbout()
        {
            InitializeComponent();
        }

        private void DevOp_LinkClicked(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://selimbirincioglu.bio.link/");

    }
}
