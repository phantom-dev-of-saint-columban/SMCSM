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
    public partial class AdminUserAccountMenu : Form
    {
        MainMenuForm mmf;
        public AdminUserAccountMenu(MainMenuForm mmf)
        {
            InitializeComponent();
            this.mmf = mmf;
        }
        #region Dev's Method
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

        private void msUserAccountMyAccount_Click(object sender, EventArgs e)
        {
            UserAccountForm uaf = new UserAccountForm(mmf);
            uaf.getUsername();
            callFormToPnlContainer(uaf);
        }

        private void msUserAccountUsers_Click(object sender, EventArgs e)
        {
            UserAccountUserForm uauf = new UserAccountUserForm();
            callFormToPnlContainer(uauf);
        }


    }
}
