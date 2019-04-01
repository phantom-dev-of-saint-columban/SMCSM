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
            autoCompleteEmp();
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
            try 
            {
                MessageBox.Show(csm.saveInto("insert into useraccount (Name, Username, Password,Usertype,question,answer) values ('" + txtName.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + cmbUserType.Text + "','"+txtQuestion.Text+"','"+txtAnswer.Text+"')"), "Saving");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Invalid Username"); }
        }
        private void performUpdate()
        {
            try
            {
                MessageBox.Show(csm.saveInto("UPDATE useraccount set name = '" + txtName.Text + "', Username = '" + txtUsername.Text + "',password= '" + txtPassword.Text + "',usertype= '" + cmbUserType.Text + "',question = '"+txtQuestion.Text+"',answer = '"+txtAnswer.Text+"' where username = '" + lblAccNo.Text + "'"), "Updating");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Invalid Username",MessageBoxButtons.OK,MessageBoxIcon.Error); };
        }
        public void fillDataField(string a) 
        {
            MySqlDataReader reader = csm.sqlCommand("select * from useraccount where username = '"+a+"'").ExecuteReader();
            while (reader.Read()) 
            {
                lblAccNo.Text = reader.GetString("username");
                txtName.Text = reader.GetString("Name");
                txtPassword.Text = reader.GetString("Password");
                txtUsername.Text = reader.GetString("username");
                cmbUserType.SelectedText = reader.GetString("usertype");
                txtQuestion.Text = reader.GetString("Question");
                txtAnswer.Text = reader.GetString("Answer");
            }
        }
        private void autoCompleteEmp()
        {
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();

            MySqlDataReader reader = csm.sqlCommand("Select empno from employee").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                ad.Add(reader.GetString("EmpNo"));
            }
            csm.closeSql();
            txtName.AutoCompleteCustomSource = ad;
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtFullname.Text = csm.countSQL("select concat(Fname, ' ',Mname,' ',Lname)as'Fullname' from employee where empno = '"+txtName.Text+"'","fullname");
        }
    }
}
