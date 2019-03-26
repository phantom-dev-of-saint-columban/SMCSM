using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using KOTL;

namespace SMCSM
{
    public partial class AddNewEmployee : Form
    {
        CallSqlModule csm = new CallSqlModule(); System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewEmployee));
        AdminEmployeeForm aef;
        public AddNewEmployee(AdminEmployeeForm aef)
        {
            InitializeComponent();
            lblEmployeeID.Text = autoGenEmpID();
            this.aef = aef;
        }

        #region Dev's Method
        private void performClear() 
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            picEmployee.Image = ((System.Drawing.Image)(resources.GetObject("picEmployee.Image")));
            cmbPosition.Text = "";
            txtAddress.Text = "";
            lblAge.Text = "-";
            txtContactNumber.Text = "+693";
        }
        private void performSave()
        {
            MemoryStream ms = new MemoryStream();
            try { picEmployee.Image.Save(ms, picEmployee.Image.RawFormat); }
            catch { MessageBox.Show("No Image Selected", "Select Random"); }
            byte[] img = ms.ToArray();
            var _result = csm.sqlCommand("INSERT INTO Employee (empno,fname,mname,lname,position,address,birthdate,sex,civilstatus,contactnum,face) "+
                "VALUES ('"+lblEmployeeID.Text+"','" + txtFirstName.Text + "','" + txtMiddleName.Text + "','"+txtLastName.Text+"','"+cmbPosition.Text+"','"+txtAddress.Text+"','"+dpBirthDate.Text+"','"+cmbSex.Text+"','"+cmbCivilStatus.Text+"','"+txtContactNumber.Text+"',@face)");
            _result.Parameters.Add("@face", MySqlDbType.Blob);
            _result.Parameters["@face"].Value = img;
            _result.ExecuteNonQuery();
            csm.closeSql();
            MessageBox.Show("Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            aef.fillTable();
            this.Dispose();
        }
        private void performUpdate()
        {
            MemoryStream ms = new MemoryStream();
            picEmployee.Image.Save(ms, picEmployee.Image.RawFormat);
            byte[] img = ms.ToArray();

            var _result = csm.sqlCommand("UPDATE employee SET fname = '"+txtFirstName.Text+"',mname = '"+txtMiddleName.Text+"', lname = '"+txtLastName.Text+"',"+
                "position = '"+cmbPosition.Text+"', address = '"+txtAddress.Text+"',birthdate= '"+dpBirthDate.Text+"',sex = '"+cmbSex.Text+"',civilstatus= '"+cmbCivilStatus.Text+"',"+
                "contactNum = '"+txtContactNumber.Text+"', face=@face WHERE empno = '"+lblEmployeeID.Text+"'");
            _result.Parameters.Add("@face", MySqlDbType.Blob);
            _result.Parameters["@face"].Value = img;
            _result.ExecuteNonQuery();
            csm.closeSql();
            MessageBox.Show("Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            aef.fillTable();
            aef.fillEmpData(lblEmployeeID.Text);
            this.Dispose();
        }
        private string autoGenEmpID()
        {
            int a = Int32.Parse(csm.countSQL("select count(*)as'allcount' from employee", "allcount"));
            string b = DateTime.Now.ToString("yy") + String.Format("{0:D4}", (a + 1));
            
            return b;
        }
        public void retrieveForEdit(string a) 
        {
            try
            {
                MySqlDataReader reader;
                var _Result = csm.tblCommand("Select empno, fname,mname,lname,position,Address,birthdate,(year(now()) - year(birthdate))as'Age',sex,civilstatus,contactnum,face from Employee where empno = '" + a + "' or fname = '" + a + "' or mname = '" + a + "' or lname = '" + a + "'");
                reader = _Result.Item2.ExecuteReader();
                performClear();
                while (reader.Read())
                {
                    lblEmployeeID.Text = reader.GetString("Empno");
                    txtFirstName.Text = reader.GetString("Fname");
                    txtMiddleName.Text = reader.GetString("Mname");
                    txtLastName.Text = reader.GetString("Lname");
                    cmbPosition.SelectedItem = reader.GetString("Position");
                    txtAddress.Text = reader.GetString("Address");
                    dpBirthDate.Text = reader.GetString("Birthdate");
                    lblAge.Text = reader.GetString("age");
                    cmbSex.SelectedItem = reader.GetString("sex");
                    cmbCivilStatus.SelectedItem = reader.GetString("civilStatus");
                    txtContactNumber.Text = reader.GetString("contactNum");
                    if (!DBNull.Value.Equals(_Result.Item1.Rows[0][11]))
                    {
                        picEmployee.Image = null;
                        byte[] img = (byte[])_Result.Item1.Rows[0][11];
                        MemoryStream ms = new MemoryStream(img);
                        picEmployee.Image = Image.FromStream(ms);
                        csm.disposeTableDtTable();
                    }
                }
                csm.closeSql();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Something's not right", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose image (*.jpg;*.png;*.gif)| *.jpg; *.png; *.gif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                picEmployee.Image = Image.FromFile(op.FileName);
            }
        }

        private void dpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            int years = DateTime.Now.Year - dpBirthDate.Value.Year;
            if (dpBirthDate.Value.AddYears(years) > DateTime.Now) years--;
            lblAge.Text = years.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(btnSave.Text == "SAVE")
            {
                performSave();
            }
            else if(btnSave.Text == "UPDATE")
            {
                performUpdate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performClear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
