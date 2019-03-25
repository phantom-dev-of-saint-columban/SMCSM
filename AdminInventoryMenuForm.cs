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
    public partial class AdminInventoryMenuForm : Form
    {
        public AdminInventoryMenuForm()
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
        private void msInventoryStockIn_Click(object sender, EventArgs e)
        {
            AdminInventoryStockInForm aisi = new AdminInventoryStockInForm();
            callFormToPnlContainer(aisi);
        }

        private void msInventorySales_Click(object sender, EventArgs e)
        {
            AdminInventorySalesForm aisf = new AdminInventorySalesForm();
            callFormToPnlContainer(aisf);
        }

        private void msInventoryStockReturn_Click(object sender, EventArgs e)
        {
            AdminInventoryStockReturnForm aisrf = new AdminInventoryStockReturnForm();
            callFormToPnlContainer(aisrf);
        }
    }
}
