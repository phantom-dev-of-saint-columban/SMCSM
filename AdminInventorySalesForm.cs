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
using DGVPrinterHelper;

namespace SMCSM
{
    public partial class AdminInventorySalesForm : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public AdminInventorySalesForm()
        {
            InitializeComponent();
            fillTable();
        }
        #region Dev's Method
        public void fillTable()
        {
            tblSales.DataSource = csm.fillTable("Select * from salesorder").Tables[0];
        }
        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from salesorder").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                switch (a)
                {
                    case "Transaction No":
                        ad.Add(reader.GetString("TransactionNo"));
                        break;
                    case "Product No":
                        ad.Add(reader.GetString("ProductNo"));
                        break;
                    case "Invoice No":
                        ad.Add(reader.GetString("invoice"));
                        break;
                    case "Discount":
                        ad.Add(reader.GetString("discount"));
                        break;
                    case "Quantity":
                        ad.Add(reader.GetString("quantity"));
                        break;
                }
            }
            csm.closeSql();
            txtSearchBy.AutoCompleteCustomSource = ad;
        }
        #endregion

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                case "Transaction No":
                    tblSales.DataSource = csm.fillTable("Select * from salesorder where transactioNo = '"+txtSearchBy.Text+"'").Tables[0];
                    break;
                case "Product No":
                    tblSales.DataSource = csm.fillTable("Select * from salesorder where ProductNo = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Invoice No":
                    tblSales.DataSource = csm.fillTable("Select * from salesorder where invoiceNo = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Discount":
                    tblSales.DataSource = csm.fillTable("Select * from salesorder where discount = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Quantity":
                    tblSales.DataSource = csm.fillTable("Select * from salesorder where quantity = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Pagadian City Shoe Mate\nJamisola St.,Sta.Lucia Dist.,Pagadian City";
            printer.SubTitle = string.Format("List of Sales\nDate {0}", DateTime.Now.ToShortDateString());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;
            printer.TableAlignment = DGVPrinter.Alignment.Center;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "";
            printer.PageSettings.Landscape = false;
            printer.PrintDataGridView(tblSales);
        }
    }
}
