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
    public partial class UserAccountForm : Form
    {
        MainMenuForm mmf; CallSqlModule csm = new CallSqlModule();
        public UserAccountForm(MainMenuForm mmf)
        {
            InitializeComponent();
            this.mmf = mmf;
        }
        #region Dev's Method
        public void getUsername() 
        {
            lblUsername.Text = mmf._username;
            txtPassword.Text = csm.countSQL("select password from useraccount where username = '"+mmf._username+"'","password");
        }
        #endregion

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using(UserAccountChangePassword uacp = new UserAccountChangePassword(this))
            {
                uacp._oldPassword = txtPassword.Text;
                uacp._username = lblUsername.Text;
                uacp.ShowDialog();
            }
        }
    }
}
