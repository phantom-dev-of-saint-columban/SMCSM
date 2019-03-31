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
    public partial class VoidItem : Form
    {
        CallSqlModule csm = new CallSqlModule();
        CashierPurchased cp;
        public VoidItem(CashierPurchased cp)
        {
            InitializeComponent();
            this.cp = cp;
            autoCompleteTransactNo();
        }
        #region Dev's Method
        private void autoCompleteTransactNo()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select transactionNo from salesOrder").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                ad.Add(reader.GetString("TransactionNo"));
            }
            csm.closeSql();
            textBox1.AutoCompleteCustomSource = ad;
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataReader _reader = csm.sqlCommand("Select p.ProdNo, Description, Quantity, UnitPrice from product p inner join salesorder so on p.prodNo = so.ProdNo where transactionNo = '"+textBox1.Text+"'").ExecuteReader();
            while(_reader.Read())
            {
                cp.tblOrder.Rows.Add(_reader.GetString("ProdNo"), _reader.GetString("Description"), _reader.GetString("Quantity"), _reader.GetString("UnitPrice"));
            }
            csm.closeSql();
            cp.lblTransactNo.Text = textBox1.Text;

            
            this.Dispose();
        }
    }
}
