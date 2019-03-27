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
    public partial class StockClerkMainMenu : Form
    {
        MainMenuForm mmf;
        public StockClerkMainMenu(MainMenuForm mmf)
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

        private void msInventory_Click(object sender, EventArgs e)
        {
            StockClerkInventoryMenu scim = new StockClerkInventoryMenu();
            callFormToPnlContainer(scim);
        }

        private void msUserAccount_Click(object sender, EventArgs e)
        {
            UserAccountForm uaf = new UserAccountForm(mmf);
            uaf.getUsername();
            callFormToPnlContainer(uaf);
        }
    }
}
