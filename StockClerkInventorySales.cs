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
    public partial class StockClerkInventorySales : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public StockClerkInventorySales()
        {
            InitializeComponent();
        }
        #region Dev's Method
        public void fillTable()
        {
            tblSales.DataSource = csm.fillTable("Select InvoiceNo,So.TransactionNo,Quantity,p.ProductNo, Description,Price,DateTransact from salesOrder so inner join salesreg sr on so.transactionNo = sr.transactionNo inner join product p on p.productNo = so.productNo").Tables[0];
        }
        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from salesOrder so inner join salesreg sr on so.transactionNo = sr.transactionNo inner join Payment p on p.InvoiceNo = So.InvoiceNo").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                switch (a)
                {
                    case "Sales Date":
                        ad.Add(reader.GetString("DateTransact"));
                        break;
                    case "Order Receipt":
                        ad.Add(reader.GetString("OrderReceipt"));
                        break;
                }
            }
            csm.closeSql();
            txtSearchBy.AutoCompleteCustomSource = ad;
        }
        #endregion
        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            autoCompleteSearch(cmbSearchBy.Text);
            if(cmbSearchBy.Text == "Sales Date")
            {
                pnlDate.Visible = true;
            }
            else if(cmbSearchBy.Text == "Order Receipt")
            {
                txtSearchBy.Enabled = true;
            }
            else
            {
                pnlDate.Visible = false; txtSearchBy.Enabled = false;
            }
        }

        private void dtDateTo_ValueChanged(object sender, EventArgs e)
        {
            tblSales.DataSource = csm.fillTable("Select InvoiceNo,So.TransactionNo,Quantity,p.ProductNo, Description,Price,DateTransact from salesOrder so inner join salesreg sr on so.transactionNo = sr.transactionNo inner join product p on p.productNo = so.productNo where DateTransact Between '"+dpDateFrom.Text+"' and '"+dtDateTo.Text+"'").Tables[0];
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.Text != "") { btnSearch.Enabled = true; } else { btnSearch.Enabled = false; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cmbSearchBy.Text)
            {
                case "Sales Date":
                    tblSales.DataSource = csm.fillTable("Select InvoiceNo,So.TransactionNo,Quantity,p.ProductNo, Description,Price,DateTransact from salesOrder so inner join salesreg sr on so.transactionNo = sr.transactionNo inner join product p on p.productNo = so.productNo where DateTransact Between '" + dpDateFrom.Text + "' and '" + dtDateTo.Text + "'").Tables[0];
                    break;
                case "Order Receipt":
                    tblSales.DataSource = csm.fillTable("Select InvoiceNo,So.TransactionNo,Quantity,p.ProductNo, Description,Price,DateTransact from salesOrder so inner join salesreg sr on so.transactionNo = sr.transactionNo inner join product p on p.productNo = so.productNo inner join payment py on py.invoiceNo = so.invoiceNo where OrderReceipt = '"+txtSearchBy.Text+"'").Tables[0];
                    break;
                default:
                    fillTable();
                    break;
            }
        }
    }
}
