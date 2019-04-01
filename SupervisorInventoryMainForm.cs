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
    public partial class SupervisorInventoryMainForm : Form
    {
        public SupervisorInventoryMainForm()
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

        private void msStockIn_Click_1(object sender, EventArgs e)
        {
            SupervisorInventoryStockIn sisi = new SupervisorInventoryStockIn();
            callFormToPnlContainer(sisi);
        }

        private void msSales_Click_1(object sender, EventArgs e)
        {
            SupervisorInventorySales sis = new SupervisorInventorySales();
            callFormToPnlContainer(sis);
        }

        private void msStockReturn_Click_1(object sender, EventArgs e)
        {
            SupervisorInventoryStockReturn sisr = new SupervisorInventoryStockReturn();
            callFormToPnlContainer(sisr);
        }
    }
}
