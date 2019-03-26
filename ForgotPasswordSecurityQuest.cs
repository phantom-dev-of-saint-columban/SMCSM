using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KOTL;
using MySql.Data.MySqlClient;

namespace SMCSM
{
    public partial class ForgotPasswordSecurityQuest : Form
    {
        CallSqlModule csm = new CallSqlModule(); string _answer = "",_password = "";
        public ForgotPasswordSecurityQuest()
        {
            InitializeComponent();
        }

        #region Dev's Method
        public void getQuestionAndAns(string a)
        {
            MySqlDataReader _reader = csm.sqlCommand("select question,answer,password from useraccount where username = '"+a+"'").ExecuteReader();
            while (_reader.Read()) 
            {
                txtQuestion.Text = _reader.GetString("Question");
                _answer = _reader.GetString("Answer");
                _password = _reader.GetString("password");
            }
            csm.closeSql();
            
        }
        #endregion

        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {
            if (txtAnswer.Text != "")
            {
                btnContinue.Enabled = true;
            }
            else { btnContinue.Enabled = false; }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text == _answer)
            {
                MessageBox.Show("Your password is: " + _password, "Password", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Dispose();
            }
            else 
            {
                MessageBox.Show("Incorrect Answer", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Dispose();
            }
        }
    }
}
