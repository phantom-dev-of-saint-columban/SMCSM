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
    public partial class SupervisorInventorySales : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public SupervisorInventorySales()
        {
            InitializeComponent();
        }

        #region Dev's Method
        public void fillTable()
        {
            tblStockIn.DataSource = csm.fillTable("Select * from salesorder so inner join salesreg sr on so.Transactiono = sr.transationno inner join payment p on p.transactionNo = sr.transationno").Tables[0];
        }
        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from salesorder so inner join salesreg sr on so.Transactiono = sr.transationno inner join payment p  on p.transactionNo = sr.transationno").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                switch (a)
                {
                    case "Order Receipt No":
                        ad.Add(reader.GetString("OrderReceipt"));
                        break;
                    case "Item Code":
                        ad.Add(reader.GetString("productno"));
                        break;
                    case "Description":
                        ad.Add(reader.GetString("description"));
                        break;
                    case "Quantity":
                        ad.Add(reader.GetString("Quantity"));
                        break;
                    case "Price":
                        ad.Add(reader.GetString("price"));
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
            if (cmbSearchBy.Text != "") { txtSearchBy.Enabled = true; } else { txtSearchBy.Enabled = false; }
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.Text != "") { btnSearch.Enabled = true; } else { btnSearch.Enabled = false; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void dtDateTo_ValueChanged(object sender, EventArgs e)
        {
        }

        private void SupervisorInventorySales_Load(object sender, EventArgs e)
        {
            fillTable();
        }

        private void btnPrintReview_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Pagadian City Shoe Mate\nJamisola St.,Sta.Lucia Dist.,Pagadian City";
            printer.SubTitle = string.Format("List of Stock In\nDate {0}", DateTime.Now.ToShortDateString());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;
            printer.TableAlignment = DGVPrinter.Alignment.Center;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "";
            printer.PageSettings.Landscape = false;
            printer.PrintDataGridView(tblStockIn);
        }



    }
}
