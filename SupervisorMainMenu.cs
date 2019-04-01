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
    public partial class SupervisorMainMenu : Form
    {
        MainMenuForm mmf;
        public SupervisorMainMenu(MainMenuForm mmf)
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
            SupervisorInventoryMainForm simf = new SupervisorInventoryMainForm();
            callFormToPnlContainer(simf);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserAccountForm uaf = new UserAccountForm(mmf);
            callFormToPnlContainer(uaf);
        }

    }
}
