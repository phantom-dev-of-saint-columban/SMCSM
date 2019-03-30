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
    public partial class AddStockReturn : Form
    {
        CallSqlModule csm = new CallSqlModule();
        MainMenuForm mmf; StockClerkInventoryStockReturn scisr; string _EmpNo;
        public AddStockReturn(MainMenuForm mmf, StockClerkInventoryStockReturn scisr)
        {
            InitializeComponent();
            this.mmf = mmf; this.scisr = scisr;
        }
        #region Dev's Method
        private void fillDateField(string a) 
        {
            MySqlDataReader _reader = csm.sqlCommand("Select * from StockIn si inner join stockinreg sir on si.drNo = sir.drNo inner join product p on p.productno = si.productno where si.drNo = '"+ txtDRno.Text +"'").ExecuteReader();
            while(_reader.Read())
            {
                txtStockDate.Text = _reader.GetString("StockDate");
                txtQuan.Text = _reader.GetString("Quantity");
                txtUnit.Text = _reader.GetString("Unit");
                txtSupplierID.Text = _reader.GetString("SupplierID");

                txtItemCode.Text = _reader.GetString("ProductNo");
                txtDesc.Text = _reader.GetString("Description");
                txtUnitPrice.Text = _reader.GetString("price");
                txtBarcode.Text = _reader.GetString("Barcode");
            }
            csm.closeSql();
        }
        private void autoCompleteSearch()
        {
            txtDRno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDRno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select Si.DrNo from StockIn si inner join stockinreg sir on si.DrNo = sir.Drno").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {

                ad.Add(reader.GetString("DrNo"));
            }    
            csm.closeSql();
            txtDRno.AutoCompleteCustomSource = ad;
        }
        private void performSave() 
        {
            if (csm.saveInto("insert into stockreturn (returnSlipNo, DrNo, Remarks) values ('" + lblReturnSlipNo.Text + "','" + txtDRno.Text + "','" + txtRemarks.Text + "')") == "Successful")
            {
                MessageBox.Show("insert into stockReturnreg (returnslipNo, returnDate, empno) values ('"+lblReturnSlipNo.Text+"','"+lblReturnDate.Text+"','"+_EmpNo+"')");
            }
            else { MessageBox.Show("QueryError on StockReturn Save","Oops!",MessageBoxButtons.OK, MessageBoxIcon.Error); } 
        }
        private string autoGenReturnSlip()
        {
            int a = Int32.Parse(csm.countSQL("select count(*)as'allcount' from stockreturn", "allcount"));
            string b = "R" + DateTime.Now.ToString("yy") +"-"+ String.Format("{0:D3}", (a + 1));
            return b;
        }
        #endregion

        private void txtDRno_TextChanged(object sender, EventArgs e)
        {
            fillDateField(txtDRno.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            performSave();
            scisr.fillTable();
            this.Dispose();
        }

        private void AddStockReturn_Load(object sender, EventArgs e)
        {
            _EmpNo = csm.countSQL("select name from useraccount where username = '" + mmf._username + "'and password = " + mmf._password + "", "Name");
            lblReturnSlipNo.Text = autoGenReturnSlip();
            lblReturnDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            autoCompleteSearch();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Cancel?", "Cancelling Stock Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

    }
}
