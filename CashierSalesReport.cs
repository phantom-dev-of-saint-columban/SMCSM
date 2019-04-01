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
    public partial class CashierSalesReport : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public CashierSalesReport()
        {
            InitializeComponent();
        }
        #region
        private void populateComboDate() 
        {
            MySqlDataReader _reader = csm.sqlCommand("select distinct dateTransact from salesReg").ExecuteReader();
            while(_reader.Read())
            {
                cmbDate.Items.Add(_reader.GetString("dateTransact"));
            }
            csm.closeSql();
        }
        private void fillTable() 
        {
            dataGridView1.DataSource = csm.fillTable("select DateTransact, TimeTransact, sr.TransactioNno, p.OrderReceipt, So.InvoiceNo, So.ProdUctNo, Description, So.Quantity, Price from SalesOrder so inner join SalesReg sr on so.TransactionNo = sr.TransactionNo inner join product pr on so.productNo = pr.productno inner join payment p on sr.transactionNo = p.transactionNo").Tables[0];
            dataGridView1.Rows.Add("", "", "", "", "", "", "GrandTotal: ", csm.countSQL("select sum(quantity) from SalesOrder so inner join SalesReg sr on so.TransactionNo = sr.TransactionNo inner join product pr on so.productNo = pr.productno inner join payment p on sr.transactionNo = p.transactionN where dateTransact = '" + cmbDate.Text + "", "countAll"), (double.Parse(csm.countSQL("select sum(price) from SalesOrder so inner join SalesReg sr on so.TransactionNo = sr.TransactionNo inner join product pr on so.productNo = pr.productno inner join payment p on sr.transactionNo = p.transactionN where dateTransact = '" + cmbDate.Text + "", "countAll"))).ToString("N2"));
        }
        private void fillGrandTotal() 
        {
            txtQuan.Text = csm.countSQL("select sum(so.quantity)as'Quan' from SalesOrder so inner join SalesReg sr on so.TransactionNo = sr.TransactionNo inner join product pr on so.productNo = pr.productno inner join payment p on sr.transactionNo = p.transactionN", "Quan");
            txtTotal.Text = csm.countSQL("select sum(price)as'Tots' from SalesOrder so inner join SalesReg sr on so.TransactionNo = sr.TransactionNo inner join product pr on so.productNo = pr.productno inner join payment p on sr.transactionNo = p.transactionN", "Tots");
        }
        #endregion

        private void CashierSalesReport_Load(object sender, EventArgs e)
        {
            fillGrandTotal();
            fillTable();
            populateComboDate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Pagadian City Shoe Mate\nJamisola St.,Sta.Lucia Dist.,Pagadian City";
            printer.SubTitle = string.Format("Sales Report\nDate {0}", DateTime.Now.ToShortDateString());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;
            printer.TableAlignment = DGVPrinter.Alignment.Center;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "";
            printer.PageSettings.Landscape = false;
            printer.PrintDataGridView(dataGridView1);
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = csm.fillTable("select DateTransact, TimeTransact, sr.TransactioNno, p.OrderReceipt, So.InvoiceNo, So.ProdUctNo, Description, So.Quantity, Price from SalesOrder so inner join SalesReg sr on so.TransactionNo = sr.TransactionNo inner join product pr on so.productNo = pr.productno inner join payment p on sr.transactionNo = p.transactionNo where dateTransact = '"+cmbDate.Text+"'").Tables[0];
            dataGridView1.Rows.Add("", "", "", "", "", "", "GrandTotal: ", csm.countSQL("select sum(quantity) from SalesOrder so inner join SalesReg sr on so.TransactionNo = sr.TransactionNo inner join product pr on so.productNo = pr.productno inner join payment p on sr.transactionNo = p.transactionN where dateTransact = '" + cmbDate.Text + "", "countAll"), (double.Parse(csm.countSQL("select sum(price) from SalesOrder so inner join SalesReg sr on so.TransactionNo = sr.TransactionNo inner join product pr on so.productNo = pr.productno inner join payment p on sr.transactionNo = p.transactionN where dateTransact = '" + cmbDate.Text + "", "countAll"))).ToString("N2"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to close this form?", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
