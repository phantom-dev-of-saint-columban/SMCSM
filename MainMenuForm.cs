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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            callLoginForm();
        }

        #region Dev Method
        private void callLoginForm()
        {
            LoginForm a = new LoginForm();

            pnlContainer.Controls.Remove(a);

            a.Dock = DockStyle.Fill;
            a.TopLevel = false;
            pnlContainer.Controls.Add(a);
            a.TopMost = true;
            a.Show();
        }
        #endregion
    }
}
