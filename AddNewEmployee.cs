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
        public AddNewEmployee()
        {
            InitializeComponent();
        }
        #region
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
            var _result = csm.sqlCommand("INSERT INTO Employee (empno,fname,mname,lname,position,address,birthdate,age,sex,civilstatus,contactnum,face) "+
                "VALUES ('"+lblEmployeeID.Text+"','" + txtFirstName.Text + "','" + txtMiddleName.Text + "','"+txtLastName.Text+"','"+cmbPosition.Text+"','"+txtAddress.Text+"','"+dpBirthDate.Text+"','"+lblAge.Text+"','"+cmbSex.Text+"','"+cmbCivilStatus.Text+"','"+txtContactNumber.Text+"',@face)");
            _result.Parameters.Add("@face", MySqlDbType.Blob);
            _result.Parameters["@face"].Value = img;
            _result.ExecuteNonQuery();
            csm.closeSql();
            MessageBox.Show("Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            performSave();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performClear();
        }
    }
}
