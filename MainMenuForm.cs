using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMCSM
{
    public partial class MainMenuForm : Form
    {
        public string globalID = "";
        public MainMenuForm()
        {
            InitializeComponent();
            LoginForm lf = new LoginForm(this);
            callFormToPnlContainer(lf);
        }

        
        #region Dev Method
        public void callFormToPnlContainer(Form b)
        {
            pnlContainer.Controls.Clear();

            b.Dock = DockStyle.Fill;
            b.TopLevel = false;
            pnlContainer.Controls.Add(b);
            b.TopMost = true;
            b.Show();
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Log Out?", "Logging Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                LoginForm lf = new LoginForm(this);
                callFormToPnlContainer(lf);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
