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
    public partial class AdminInventoryStockInForm : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public AdminInventoryStockInForm()
        {
            InitializeComponent();
        }
        #region Dev's Method
        public void fillTable()
        {
            tblStockIn.DataSource = csm.fillTable("Select * from stockin").Tables[0];
        }
        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from Stockin").ExecuteReader();
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
                case "Delivery Receipt No":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin where DRno= '"+txtSearchBy.Text+"'").Tables[0];
                    break;
                case "Product No":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin where productno= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Supplier ID":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin where supplierID= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Unit":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin where Unit= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Quantity":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin where Quantity= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Date":
                    tblStockIn.DataSource = csm.fillTable("Select * from stockin where StockDate= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                default:
                    MessageBox.Show("No record found.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
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

        private void dtDateTo_ValueChanged(object sender, EventArgs e)
        {
            tblStockIn.DataSource = csm.fillTable("Select * from stockin where stockDate Between '"+dpDateFrom.Text+"' and '"+dpDateTo.Text+"'").Tables[0];
        }
    }
}
