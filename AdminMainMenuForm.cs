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
    public partial class AdminMainMenuForm : Form
    {
        Form thisForm;
        #region
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
        public AdminMainMenuForm()
        {
            InitializeComponent();
        }

        private void msInventory_Click(object sender, EventArgs e)
        {
        }
    }
}
