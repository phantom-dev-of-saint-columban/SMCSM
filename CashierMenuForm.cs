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
    public partial class CashierMenuForm : Form
    {
        public CashierMenuForm()
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

        private void msSales_Click(object sender, EventArgs e)
        {
            PointOfSaleForm posf = new PointOfSaleForm();
            callFormToPnlContainer(posf);
        }
    }
}
