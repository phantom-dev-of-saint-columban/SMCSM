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
    public partial class StockClerkInventoryStockReturn : Form
    {
        CallSqlModule csm = new CallSqlModule();
        MainMenuForm mmf;
        public StockClerkInventoryStockReturn(MainMenuForm mmf)
        {
            InitializeComponent();
            fillTable();
            this.mmf = mmf;
        }
        #region Dev's Method

        public void fillTable()
        {
            tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn si inner join stockreturnreg sir on si.returnslipNo = sir.returnslipNo").Tables[0];
        }

        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from stockreturn si inner join stockreturnreg sir on si.returnslipNo = sir.returnslipNo").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                switch (a)
                {
                    case "Return Slip No":
                        ad.Add(reader.GetString("ReturnSlipNo"));
                        break;
                    case "Item Code":
                        ad.Add(reader.GetString("DRNo"));
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
            if (cmbSearchBy.Text == "Return Date") { pnlDate.Visible = true;}
            else if (cmbSearchBy.Text == "Return Slip No") { txtSearchBy.Enabled = true; }
            else if (cmbSearchBy.Text == "Item Code") { txtSearchBy.Enabled = true; }
            else { txtSearchBy.Enabled = false; pnlDate.Visible = false; fillTable(); }
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.Text != "") { btnSearch.Enabled = true; } else { btnSearch.Enabled = false; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cmbSearchBy.Text)
            {
                case "Return Date":
                    tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn si inner join stockreturnreg sir on si.returnslipNo = sir.returnslipNo where returnDate Between '" + dpDateFrom.Text + "' and '" + dtDateTo.Text + "'").Tables[0];
                    break;
                case "Return Slip No":
                    tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn si inner join stockreturnreg sir on si.returnslipNo = sir.returnslipNo where si.returnslipNo = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Item Code":
                    tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn si inner join stockreturnreg sir on si.returnslipNo = sir.returnslipNo where drNo = '" + txtSearchBy.Text + "'").Tables[0];
                    break;
            }
        }

        private void dtDateTo_ValueChanged(object sender, EventArgs e)
        {
            tblStockReturn.DataSource = csm.fillTable("Select * from stockreturn si inner join stockreturnreg sir on si.returnslipNo = sir.returnslipNo where returnDate Between '" + dpDateFrom.Text + "' and '" + dtDateTo.Text + "'").Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddStockReturn asr = new AddStockReturn(mmf,this)) 
            {
                asr.ShowDialog();
            }
        }
    }
}
