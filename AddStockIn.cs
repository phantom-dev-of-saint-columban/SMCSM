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
    public partial class AddStockIn : Form
    {
        CallSqlModule csm = new CallSqlModule();
        MainMenuForm mmf; StockClerkInventoryStockIn scisi;
        string empName;
        public AddStockIn(MainMenuForm mmf, StockClerkInventoryStockIn scisi)
        {
            InitializeComponent();
            this.mmf = mmf;
            this.scisi = scisi;
        }
        #region Dev's Method
        private string autoGenEmpID()
        {
            int a = Int32.Parse(csm.countSQL("select count(*)as'allcount' from stockin", "allcount"));
            string b = "S" + DateTime.Now.ToString("yy") + String.Format("{0:D3}", (a + 1));
            return b;
        }
        private void populateSupplier() 
        {
            cmbSupplier.Items.Clear();
            MySqlDataReader _reader = csm.sqlCommand("Select * from supplier").ExecuteReader();
            cmbSupplier.Items.Add("");
            while(_reader.Read())
            {
                cmbSupplier.Items.Add(_reader.GetString("supplierID"));
            }
            csm.closeSql();
        }
        private void performSaveAll() 
        {
            if (csm.saveInto("insert into stockin (DRno, ProductNo, SupplierID, Unit, Quantity, StockDate) " +
                "values ('" + lblDRNo.Text + "','" + lblProdNo.Text + "','" + cmbSupplier.Text + "', '" + txtUnit.Text + "','" + txtQuan.Text + "','" + lblStockDate.Text + "')") == "Successful")
            {
                if (csm.saveInto("insert into product (productno,description,price,barcode) " +
                "values ('" + lblProdNo.Text + "','" + txtDesc.Text + "','" + txtUnitPrice.Text + "','" + txtBarcode.Text + "')") == "Successful")
                {
                    MessageBox.Show(csm.saveInto("insert into stockinreg (Drno, StockDate, empNo) values ('"+lblDRNo.Text+"','"+lblStockDate.Text+"','"+empName+"')"),"Saving",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else { MessageBox.Show("Error on Product Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Error on StockIn Save","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void UpdateAll() 
        {
            if (csm.saveInto("update stockin set DrNo = '"+lblDRNo.Text+"', productno = '"+lblProdNo.Text+"', supplierID = '"+cmbSupplier.Text+"', unit = '"+txtUnit.Text+"',quantity = '"+txtQuan.Text+"',stockdate = '"+lblStockDate.Text+"' where DrNo = '"+lblDRNo.Text+"'") == "Successful")
            {
                if (csm.saveInto("update product set productNo = '"+lblProdNo.Text+"', description = '"+txtDesc.Text+"',price = '"+txtUnitPrice.Text+"', barcode = '"+txtBarcode.Text+"' where productno = '"+lblProdNo.Text+"'") == "Successful")
                {
                    MessageBox.Show(csm.saveInto("update stockinreg set drNo = '"+lblDRNo.Text+"', stockDate = '"+lblStockDate.Text+"', empno = '"+empName+"'"), "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { MessageBox.Show("Error on Product Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Error on StockIn Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void fillDataField(string a) 
        {
            MySqlDataReader _reader = csm.sqlCommand("select * from stockin si inner join product p on si.productNo = p.productno inner join stockinreg sir on si.drNo = sir.drNo where si.DRno = '"+a+"'").ExecuteReader();
            while(_reader.Read())
            {
                lblStockDate.Text = _reader.GetString("StockDate");
                lblProdNo.Text = _reader.GetString("StockDate");
                txtDesc.Text = _reader.GetString("descripton");
                txtUnitPrice.Text = _reader.GetString("Price");
                lblDRNo.Text = _reader.GetString("si.DrNo");
                txtQuan.Text = _reader.GetString("quantity");
                txtUnit.Text = _reader.GetString("unit");
                cmbSupplier.SelectedItem = _reader.GetString("SupplierID");
                txtBarcode.Text = _reader.GetString("barcode");
            }
            csm.closeSql();
        }


        #endregion
        private void AddStockIn_Load(object sender, EventArgs e)
        {
            lblStockDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblProdNo.Text = autoGenEmpID();
            populateSupplier();
            empName = csm.countSQL("select empno from employee inner join useraccount on name = empno where username = '"+mmf._username+"'","empno");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lblDRNo.Text != "" || txtBarcode.Text != "" || txtDesc.Text != "" || txtQuan.Text != "" || txtUnit.Text != "" || txtUnitPrice.Text != "")
            {
                if(btnAdd.Text == "SAVE")
                {
                    performSaveAll();
                    scisi.fillTable();
                    this.Dispose();
                }else if(btnAdd.Text == "UPDATE")
                {
                    UpdateAll();
                    scisi.fillTable();
                    this.Dispose();
                }
                
            }
            else { MessageBox.Show("Some field cannot be blank!","Oops!",MessageBoxButtons.OK,MessageBoxIcon.Stop); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Cancel?", "Cancelling Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
