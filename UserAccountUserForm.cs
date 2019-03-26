using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KOTL;
using MySql.Data.MySqlClient;

namespace SMCSM
{
    public partial class UserAccountUserForm : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public UserAccountUserForm()
        {
            InitializeComponent();
            fillTable();
        }
        #region Dev's Method
        public void fillTable() 
        {
            tblUserAccount.DataSource = csm.fillTable("select * from useraccount").Tables[0];
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            using(AddNewUser anu = new AddNewUser(this))
            {
                anu.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using(AddNewUser anu = new AddNewUser(this))
            {
                anu.fillDataField(tblUserAccount.CurrentRow.Cells[0].Value.ToString());
                anu.btnSave.Text = "UPDATE";
                anu.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(csm.saveInto("delete from useraccount where accno = '"+tblUserAccount.CurrentRow.Cells[0].Value.ToString()+"'"), "Deleting");
            fillTable();
        }

        private void tblUserAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }
    }
}
