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
        private void userAuthenticate() 
        {
            switch(csm.countSQL("select usertype from useraccount where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", "usertype"))
            {
                case "ADMIN":
                    thisMainForm.callFormToPnlContainer(new AdminMainMenuForm(thisMainForm));
                break;
                case "CASHIER":
                    thisMainForm.callFormToPnlContainer(new CashierMenuForm(thisMainForm));
                break;
                case "SUPERVISOR":
                    MessageBox.Show("Supervisor");
                break;
                case "STOCK CLERK":
                    thisMainForm.callFormToPnlContainer(new StockClerkMainMenu(thisMainForm));
                break;
                default:
                    lblIncorrect.Visible = true; label1.ForeColor = Color.Red; label2.ForeColor = Color.Red;
                break;
            }
            thisMainForm.btnLogin.Visible = true;
            thisMainForm.globalID = txtUsername.Text;
            thisMainForm._username = txtUsername.Text; thisMainForm._password = txtPassword.Text;
            thisMainForm.lblUser.Text = csm.countSQL("select Name from useraccount where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", "Name");
        }
        private void performLogin() 
        {
            if (csm.countSQL("select count(*)'countAll' from useraccount where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'", "countAll") == "1")
            {
                thisMainForm.btnLogin.Visible = true;
                thisMainForm.globalID = txtUsername.Text;
                thisMainForm._username = txtUsername.Text; thisMainForm._password = txtPassword.Text;
                thisMainForm.callFormToPnlContainer(new AdminMainMenuForm(thisMainForm));
            }
            else { lblIncorrect.Visible = true; label1.ForeColor = Color.Red; label2.ForeColor = Color.Red; }
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //performLogin();
            userAuthenticate();
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
            using(ForgotPassworUsername fpu = new ForgotPassworUsername()){fpu.ShowDialog();}
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            thisMainForm.Dispose();
        }
        
    }
}
