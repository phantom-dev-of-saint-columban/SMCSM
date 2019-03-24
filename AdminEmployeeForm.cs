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
using System.IO;


namespace SMCSM
{
    public partial class AdminEmployeeForm : Form
    {
        CallSqlModule csm = new CallSqlModule();

        public AdminEmployeeForm(string UserID)
        {
            InitializeComponent();
            fillTable();

            lblUSERTYPE.Text = csm.countSQL("select concat(fname, ' ',Lname)as'Fullname' from employee em inner join account ac on em.empNo = ac.empID where username = '"+UserID+"'","fullname");
            lblID.Text = csm.countSQL("select EMPID from account where username = '" + UserID + "'", "empID");
        }

        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from Employee").ExecuteReader();
            while (reader.Read())
            {
                ad.Clear();
                switch (a) 
                {
                    case "First Name":
                        ad.Add(reader.GetString("fname"));
                        break;
                    case "Middle Initial":
                        ad.Add(reader.GetString("Mname"));
                        break;
                    case "Last Name":
                        ad.Add(reader.GetString("lname"));
                        break;
                    case "Employee ID":
                        ad.Add(reader.GetString("empNo"));
                        break;
                }
            }
            csm.closeSql();
            txtSearchBy.AutoCompleteCustomSource = ad;
        }
        #region
        private void fillEmpData(string a) 
        {
            /*
            MySqlDataReader reader = csm.sqlCommand("Select empno, concat(fname,' ',mname,' ',lname)as'Fullname',position,Address,birthdate,(year(now()) - year(birthdate))as'Age',sex,civilstatus,contactnum from Employee where empno = '" + a + "'").ExecuteReader();
            while (reader.Read())
            {
                lblIDNumber.Text = reader.GetString("EmpNo");
                lblLastName.Text = reader.GetString("Fullname");
                lblPosition.Text = reader.GetString("Position");
                lblAddress.Text = reader.GetString("Address");
                lblBirthDate.Text = reader.GetString("birthdate");
                lblAge.Text = reader.GetString("age");
                lblSex.Text = reader.GetString("sex");
                lblCivilStatus.Text = reader.GetString("civilstatus");
                lblContactNumber.Text = reader.GetString("ContactNum");
                
            }
            csm.closeSql();
            */
            try
            {
                MySqlDataReader reader;
                var _Result = csm.tblCommand("Select empno, concat(fname,' ',mname,' ',lname)as'Fullname',position,Address,birthdate,(year(now()) - year(birthdate))as'Age',sex,civilstatus,contactnum,face from Employee where empno = '" + a + "'");
                reader = _Result.Item2.ExecuteReader();
                while (reader.Read())
                {
                    lblIDNumber.Text = reader.GetString("EmpNo");
                    lblLastName.Text = reader.GetString("Fullname");
                    lblPosition.Text = reader.GetString("Position");
                    lblAddress.Text = reader.GetString("Address");
                    lblBirthDate.Text = reader.GetString("birthdate");
                    lblAge.Text = reader.GetString("age");
                    lblSex.Text = reader.GetString("sex");
                    lblCivilStatus.Text = reader.GetString("civilstatus");
                    lblContactNumber.Text = reader.GetString("ContactNum");

                    if (!DBNull.Value.Equals(_Result.Item1.Rows[0][9]))
                    {
                        picFace.Image = null;
                        byte[] img = (byte[])_Result.Item1.Rows[0][9];
                        MemoryStream ms = new MemoryStream(img);
                        picFace.Image = Image.FromStream(ms);
                        csm.disposeTableDtTable();
                    }
                }
                csm.closeSql();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Something's not right", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void fillTable() 
        {
            tblEmployee.DataSource = csm.fillTable("select EmpNo, concat(Fname,' ',Lname)as'Full Name', Birthdate, Sex, Address, ContactNum from employee").Tables[0];
            lblTotalEmployees.Text = csm.countSQL("select count(*)'all' from employee","all");
        }
        #endregion

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddNewEmployee ane = new AddNewEmployee();
            ane.ShowDialog();
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSearchBy.Text != "")
            {
                autoCompleteSearch(cmbSearchBy.Text);
                txtSearchBy.Enabled = true;
            }
            
        }

        private void tblEmployee_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fillEmpData(tblEmployee.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
