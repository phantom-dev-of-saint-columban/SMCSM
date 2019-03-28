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
        MainMenuForm mmf;
        string empName;
        public AddStockIn(MainMenuForm mmf)
        {
            InitializeComponent();
            this.mmf = mmf;
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
            MySqlDataReader _reader = csm.sqlCommand("Select * from supplier").ExecuteReader();
            cmbSupplier.Items.Add("");
            while(_reader.Read())
            {
                cmbSupplier.Items.Add(_reader.GetString("suplierID"));
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

        //private void performSaveStockIn()
        //{
        //    csm.saveInto("insert into stockin (DRno, ProductNo, SupplierID, Unit, Quantity, StockDate) "+
        //        "values ('"+lblDRNo.Text+"','"+lblProdNo.Text+"','"+cmbSupplier.Text+"', '"+txtUnit.Text+"','"+txtQuan.Text+"','"+lblStockDate.Text+"')");
        //}
        //private void performSaveProduct() 
        //{
        //    csm.saveInto("insert into product (productno,description,price,barcode) "+
        //        "values ('"+lblProdNo.Text+"','"+txtDesc.Text+"','"+txtUnitPrice.Text+"','"+txtBarcode.Text+"')");
        //}
        //private void performSaveStockInReg() 
        //{
        //    csm.saveInto("insert into stockinreg (Drno, StockDate, empNo) values ('"+lblDRNo.Text+"','"+lblStockDate.Text+"','"+empName+"')");
        //}

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
                performSaveAll();
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
