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
    public partial class ForgotPassworUsername : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public ForgotPassworUsername()
        {
            InitializeComponent();

        }
        #region Dev's Method
        private void verifyUser(string a) 
        {
            if (csm.countSQL("select Count(*)'all' from useraccount where username = '" + a + "'", "all") == "1")
            {
                using (ForgotPasswordSecurityQuest fpsq = new ForgotPasswordSecurityQuest())
                {
                    fpsq.getQuestionAndAns(a);
                    fpsq.ShowDialog();
                }
            }
            else { MessageBox.Show("Invalid User Name!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
        #endregion
        private void btnContinue_Click(object sender, EventArgs e)
        {
            verifyUser(txtUsername.Text);
            this.Dispose();
        }
    }
}
