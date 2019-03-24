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
    public partial class LoginForm : Form
    {
        MainMenuForm thisMainForm; CallSqlModule csm = new CallSqlModule();
        public LoginForm(MainMenuForm a)
        {
            InitializeComponent();
            thisMainForm = a;
        }
        #region Dev's Method
        private void performLogin() 
        {
            if (csm.countSQL("select count(*)'countAll' from account where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", "countAll") == "1")
            {
                thisMainForm.btnLogin.Visible = true;
                thisMainForm.globalID = txtUsername.Text;
                thisMainForm.callFormToPnlContainer(new AdminMainMenuForm(thisMainForm));
            }
            else { lblIncorrect.Visible = true; label1.ForeColor = Color.Red; label2.ForeColor = Color.Red; }
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            performLogin();
        }

        #region lblForgot Region
        private void lblForgotPassword_MouseHover(object sender, EventArgs e)
        {
            lblForgotPassword.ForeColor = Color.Blue;
            Cursor.Current = Cursors.Hand;
        }

        private void lblForgotPassword_MouseLeave(object sender, EventArgs e)
        {
            lblForgotPassword.ForeColor = Color.Black;
            Cursor.Current = Cursors.Arrow;
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {

        }
        #endregion
        
    }
}
