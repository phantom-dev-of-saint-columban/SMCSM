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
        MainMenuForm mmf;
        public StockClerkInventoryMenu(MainMenuForm mmf)
        {
            InitializeComponent();
            this.mmf = mmf;
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
        private void msStockIn_Click_1(object sender, EventArgs e)
        {

            StockClerkInventoryStockIn scisi = new StockClerkInventoryStockIn(mmf);
            callFormToPnlContainer(scisi);
        }

        private void msSales_Click_1(object sender, EventArgs e)
        {
            StockClerkInventorySales scis = new StockClerkInventorySales();
            callFormToPnlContainer(scis);
        }

        private void msStockReturn_Click_1(object sender, EventArgs e)
        {
            StockClerkInventoryStockReturn scisr = new StockClerkInventoryStockReturn();
            callFormToPnlContainer(scisr);
        }
    }
}
