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
    public partial class UserAccountUserForm : Form
    {
        public UserAccountUserForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(AddNewUser anu = new AddNewUser())
            {
                anu.ShowDialog();
            }
        }
    }
}
