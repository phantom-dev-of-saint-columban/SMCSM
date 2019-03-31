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
        MainMenuForm mmf;
        public CashierMenuForm(MainMenuForm mmf)
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

        private void msSales_Click(object sender, EventArgs e)
        {
            CashierPurchased cp = new CashierPurchased(mmf);
            callFormToPnlContainer(cp);
        }

        private void msUserAccount_Click(object sender, EventArgs e)
        {
            UserAccountForm uaf = new UserAccountForm(mmf);
            uaf.getUsername();
            callFormToPnlContainer(uaf);
        }
    }
}
