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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminEmployeeForm));

        public AdminEmployeeForm(string UserID)
        {
            InitializeComponent();
            fillTable();

            lblUSERTYPE.Text = csm.countSQL("select concat(fname, ' ',Lname)as'Fullname' from employee em inner join account ac on em.empNo = ac.empID where username = '"+UserID+"'","fullname");
            lblID.Text = csm.countSQL("select EMPID from account where username = '" + UserID + "'", "empID");
        }
        #region
        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from Employee").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
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
                    case "Position":
                        ad.Add(reader.GetString("Position"));
                        break;
                }
            }
            csm.closeSql();
            txtSearchBy.AutoCompleteCustomSource = ad;
        }
        public void fillEmpData(string a) 
        {
            try
            {
                MySqlDataReader reader;
                var _Result = csm.tblCommand("Select empno, concat(fname,' ',mname,' ',lname)as'Fullname',position,Address,birthdate,(year(now()) - year(birthdate))as'Age',sex,civilstatus,contactnum,face from Employee where empno = '" + a + "' or fname = '" + a + "' or mname = '" + a + "' or lname = '" + a + "' or position = '"+a+"'");
                reader = _Result.Item2.ExecuteReader();
                performClear();
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
        public void fillTable() 
        {
            tblEmployee.DataSource = csm.fillTable("select EmpNo, concat(Fname,' ',Lname)as'Full Name', Birthdate, Sex, Address, ContactNum from employee").Tables[0];
            lblTotalEmployees.Text = csm.countSQL("select count(*)'all' from employee","all");
            btnDeleteEmployee.Enabled = false;
            btnEditEmployee.Enabled = false;
        }
        private void performClear() 
        {
            lblIDNumber.Text = "";
            lblLastName.Text = "";
            lblPosition.Text = "";
            lblAddress.Text = "";
            lblBirthDate.Text = "";
            lblAge.Text = "";
            lblSex.Text = "";
            lblCivilStatus.Text = "";
            lblContactNumber.Text = "";

            picFace.Image = ((System.Drawing.Image)(resources.GetObject("picFace.Image")));
        }
        private void performDelete() 
        {
            MessageBox.Show(csm.saveInto("delete from employee where empNo ='"+lblIDNumber.Text+"'"),"Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
            performClear();
            fillTable();
        }
        #endregion

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddNewEmployee ane = new AddNewEmployee(this);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            fillEmpData(txtSearchBy.Text);
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.Text != "")
            {
                btnSearch.Enabled = true;
            }
            else { btnSearch.Enabled = false; }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            AddNewEmployee ane = new AddNewEmployee(this);
            ane.retrieveForEdit(lblIDNumber.Text);
            ane.btnSave.Text = "UPDATE";
            ane.ShowDialog();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            performDelete();
            performClear();
        }

        private void tblEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fillEmpData(tblEmployee.CurrentRow.Cells[0].Value.ToString());

            btnEditEmployee.Enabled = true;
            btnDeleteEmployee.Enabled = true;
        }
    }
}
