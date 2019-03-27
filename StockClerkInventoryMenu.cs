using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMCSM
{
    public partial class StockClerkInventoryMenu : Form
    {
        public StockClerkInventoryMenu()
        {
            InitializeComponent();
        }
        #region Dev's Methods
        public void callFormToPnlContainer(Form b)
        {
            pnlContainer.Controls.Clear();

            b.Dock = DockStyle.Fill;
            b.TopLevel = false;
            pnlContainer.Controls.Add(b);
            b.TopMost = true;
            b.Show();
        }
        #endregion
        private void msStockIn_Click(object sender, EventArgs e)
        {
            StockClerkInventoryStockIn scisi = new StockClerkInventoryStockIn();
            callFormToPnlContainer(scisi);
        }

        private void msSales_Click(object sender, EventArgs e)
        {
            StockClerkInventorySales scis = new StockClerkInventorySales();
            callFormToPnlContainer(scis);
        }

        private void msStockReturn_Click(object sender, EventArgs e)
        {

        }
    }
}
