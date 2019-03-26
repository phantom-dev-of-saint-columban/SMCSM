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
    public partial class AddNewUser : Form
    {
        CallSqlModule csm = new CallSqlModule();
        UserAccountUserForm acf;
        public AddNewUser(UserAccountUserForm acf)
        {
            InitializeComponent();
            lblAccNo.Text = "A" + String.Format("{0:D4}", int.Parse(csm.countSQL("select count(*)'all' from useraccount", "All")));
            this.acf = acf;
        }
        #region Dev's Method
        private void performClear()
        {
            txtName.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            cmbUserType.SelectedText = "";
        }
        private void performSave() 
        {
            MessageBox.Show(csm.saveInto("insert into useraccount (Accno, Name, Username, Password,Usertype) values ('"+lblAccNo.Text+"','"+txtName.Text+"','"+txtUsername.Text+"','"+txtPassword.Text+"','"+cmbUserType.Text+"')"),"Saving");
        }
        private void performUpdate() 
        {
            MessageBox.Show(csm.saveInto("UPDATE useraccount set name = '"+txtName.Text+"', Username = '"+txtUsername.Text+"',password= '"+txtPassword.Text+"',usertype= '"+cmbUserType.Text+"' where accno = '"+lblAccNo.Text+"'"), "Updating");
        }
        public void fillDataField(string a) 
        {
            MySqlDataReader reader = csm.sqlCommand("select * from useraccount where accno = '"+a+"'").ExecuteReader();
            while (reader.Read()) 
            {
                lblAccNo.Text = reader.GetString("accno");
                txtName.Text = reader.GetString("Name");
                txtPassword.Text = reader.GetString("Password");
                txtUsername.Text = reader.GetString("username");
                cmbUserType.Text = reader.GetString("usertype");
            }
        }
        
        #endregion
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "SAVE")
            {
                performSave();
            }
            else 
            {
                performUpdate();
            }
            this.Dispose();
            acf.fillTable();
        }
    }
}
