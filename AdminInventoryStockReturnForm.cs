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
    public partial class AdminInventoryStockReturnForm : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public AdminInventoryStockReturnForm()
        {
            InitializeComponent();
        }
        #region Dev's Method
        public void fillTable()
        {
            tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn sr inner join stockreturnreg srr on sr.returnslipno = srr.returnslipno").Tables[0];
        }
        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from stockreturn sr inner join stockreturnreg srr on sr.returnslipno = srr.returnslipno").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                switch (a)
                {
                    case "Return Slip No":
                        ad.Add(reader.GetString("TransactionNo"));
                        break;
                    case "Delivery No":
                        ad.Add(reader.GetString("ProductNo"));
                        break;
                    case "Remarks":
                        ad.Add(reader.GetString("invoice"));
                        break;
                    case "Return Date":
                        ad.Add(reader.GetString("discount"));
                        break;
                    case "Employee ID":
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
                case "Return Slip No":
                    tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn sr inner join stockreturnreg srr on sr.returnslipno = srr.returnslipno where sr.returnSlipNo = '"+txtSearchBy+"'").Tables[0];
                    break;
                case "Delivery No":
                    tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn sr inner join stockreturnreg srr on sr.returnslipno = srr.returnslipno where DRNo= '" + txtSearchBy + "'").Tables[0];
                    break;
                case "Remarks":
                    tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn sr inner join stockreturnreg srr on sr.returnslipno = srr.returnslipno where remarks = '" + txtSearchBy + "'").Tables[0];
                    break;
                case "Return Date":
                    tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn sr inner join stockreturnreg srr on sr.returnslipno = srr.returnslipno where returnDate = '" + txtSearchBy + "'").Tables[0];
                    break;
                case "Employee ID":
                    tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn sr inner join stockreturnreg srr on sr.returnslipno = srr.returnslipno where empNo = '" + txtSearchBy + "'").Tables[0];
                    break;
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Pagadian City Shoe Mate\nJamisola St.,Sta.Lucia Dist.,Pagadian City";
            printer.SubTitle = string.Format("List of Stock Return\nDate {0}", DateTime.Now.ToShortDateString());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;
            printer.TableAlignment = DGVPrinter.Alignment.Center;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "";
            printer.PageSettings.Landscape = false;
            printer.PrintDataGridView(tblStockReturn);
        }
    }
}