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
    public partial class UserAccountChangePassword : Form
    {
        public string _oldPassword = "",_username = "";
        CallSqlModule csm = new CallSqlModule();
        UserAccountForm uaf;
        public UserAccountChangePassword(UserAccountForm uaf)
        {
            InitializeComponent();
            label5.Text = _username;
            this.uaf = uaf;
        }
        #region Dev's Method
        private void performChange() 
        {
            MessageBox.Show(csm.saveInto("update useraccount set password = '" + txtNewPassword.Text + "' where username = '" + _username + "' and password = '"+_oldPassword+"'"), "Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        #endregion
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == txtReEnterPassword.Text)
            {
                performChange();
                uaf.getUsername();
                this.Dispose();
            }
            else { MessageBox.Show("Password doesn't Match","Try Again",MessageBoxButtons.OK,MessageBoxIcon.Stop); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
