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
    public partial class LoginForm : Form
    {
        MainMenuForm thisMainForm;
        public LoginForm(MainMenuForm a)
        {
            InitializeComponent();
            thisMainForm = a;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            thisMainForm.callFormToPnlContainer(new AdminMainMenuForm());
        }
    }
}
