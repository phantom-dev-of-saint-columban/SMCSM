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
    public partial class AddSupplier : Form
    {
        CallSqlModule csm = new CallSqlModule();

        public AddSupplier()
        {
            InitializeComponent();
            lblSupplierID.Text = autoGenEmpID();
        }
        #region Dev's Method
        private string autoGenEmpID()
        {
            int a = Int32.Parse(csm.countSQL("select count(*)as'allcount' from supplier", "allcount"));
            string b = DateTime.Now.ToString("yyyy") +"-"+ String.Format("{0:D2}", (a + 1));

            return b;
        }
        private void performUpdate()
        {
            MessageBox.Show(csm.saveInto("update supplier set name = '"+txtSupplierName.Text+"',address = '"+txtSupplierAddress.Text+"',contactnum = '"+txtContactNum.Text+"',telnum = '"+txtTelephoneNum.Text+"', email = '"+txtEmail.Text+"',website = '"+txtWebsite.Text+"' where supplierID = '"+lblSupplierID.Text+"'"), "Updating", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void performSave()
        {
            MessageBox.Show(csm.saveInto("insert into supplier (supplierID,Name,Address,ContactNum,TelNum,FaxNum,Email, Website) "+
                "values ('"+lblSupplierID.Text+"','"+txtSupplierName+"','"+txtSupplierAddress.Text+"','"+txtContactNum.Text+"','"+txtTelephoneNum.Text+"','"+txtFaxNum.Text+"','"+txtEmail.Text+"','"+txtWebsite.Text+"')"),"Saving",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
        public void fillDataField(string a) 
        {
            MySqlDataReader _reader = csm.sqlCommand("Select * from supplier where supplierID = '"+a+"'").ExecuteReader();
            while(_reader.Read())
            {
                lblSupplierID.Text = _reader.GetString("supplierID");
                txtSupplierName.Text = _reader.GetString("name");
                txtSupplierAddress.Text = _reader.GetString("address");
                txtContactNum.Text = _reader.GetString("contactnum");
                txtTelephoneNum.Text = _reader.GetString("telnum");
                txtFaxNum.Text = _reader.GetString("faxnum");
                txtEmail.Text = _reader.GetString("email");
                txtWebsite.Text = _reader.GetString("website");
            }
            csm.closeSql();
        }
        private void performClear() 
        {
            lblSupplierID.Text = autoGenEmpID();
            txtSupplierName.Text = "";
            txtSupplierAddress.Text = "";
            txtContactNum.Text = "";
            txtTelephoneNum.Text = "";
            txtFaxNum.Text = "";
            txtEmail.Text = "";
            txtWebsite.Text = "";
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "SAVE") 
            {
                performSave();
            }
            else if(btnSave.Text == "UPDATE")
            {
                performUpdate();
            }
            this.Dispose();
        }
    }
}
