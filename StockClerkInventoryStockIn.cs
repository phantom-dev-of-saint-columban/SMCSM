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
    public partial class StockClerkInventoryStockIn : Form
    {
        CallSqlModule csm = new CallSqlModule();
        MainMenuForm mmf;
        public StockClerkInventoryStockIn(MainMenuForm mmf)
        {
            InitializeComponent();
            this.mmf = mmf;
        }
        #region Dev's Method
        public void fillTable()
        {
            tblStockIn.DataSource = csm.fillTable("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo").Tables[0];
        }
        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                switch (a)
                {
                    case "Delivery Receipt No":
                        ad.Add(reader.GetString("DRno"));
                        break;
                    case "Product No":
                        ad.Add(reader.GetString("ProductNo"));
                        break;
                    case "Supplier ID":
                        ad.Add(reader.GetString("SupplierID"));
                        break;
                    case "Description":
                        ad.Add(reader.GetString("Description"));
                        break;
                    case "Unit":
                        ad.Add(reader.GetString("Unit"));
                        break;
                    case "Quantity":
                        ad.Add(reader.GetString("quantity"));
                        break;
                    case "Date":
                        ad.Add(reader.GetString("StockDate"));
                        break;
                }
            }
            csm.closeSql();
            txtSearchBy.AutoCompleteCustomSource = ad;
        }
        #endregion

        private void StockClerkInventoryStockIn_Load(object sender, EventArgs e)
        {
            fillTable();
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            autoCompleteSearch(cmbSearchBy.Text);
            if (cmbSearchBy.Text != "") { txtSearchBy.Enabled = true; } else { txtSearchBy.Enabled = false; }
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.Text != "") { btnSearch.Enabled = true; } else { btnSearch.Enabled = false; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cmbSearchBy.Text)
            {
                case "Delivery Receipt No":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo where si.DRNo = '"+txtSearchBy.Text+"'").Tables[0];
                    break;
                case "Product No":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo where si.productNo= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Supplier ID":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo where supplierID = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Unit":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo where unit = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Quantity":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo where quantity = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Date":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo where si.stockDate = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
            }
        }

        private void dtDateTo_ValueChanged(object sender, EventArgs e)
        {
            tblStockIn.DataSource = csm.fillTable("Select * from stockin si inner join stockinreg sir on si.DRNo = sir.DRNo where Si.stockDate Between '" + dpDateFrom.Text + "' and '" + dtDateTo.Text + "'").Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using(AddStockIn asi = new AddStockIn(mmf))
            {
                asi.ShowDialog();
            }
        }
    }
}
