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
                }
            }
            csm.closeSql();
            txtSearchBy.AutoCompleteCustomSource = ad;
        }
        #endregion
        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
