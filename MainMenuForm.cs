using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KOTL;

namespace SMCSM
{
    public partial class MainMenuForm : Form
    {
        public string _username = "", _password = "", globalID = "";
        CallSqlModule csm = new CallSqlModule();
        public MainMenuForm()
        {
            InitializeComponent();
            timeClock.Start();
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
        private void performClear() 
        {
            lblUser.Text = "";
             _username = "";
             _password = "";
            globalID = "";

        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Log Out?", "Logging Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                LoginForm lf = new LoginForm(this);
                callFormToPnlContainer(lf);
                performClear();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void timeClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToShortTimeString();
            lblDate.Text = DateTime.Now.ToShortDateString();
        }
    }
}
