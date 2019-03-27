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
    public partial class AdminSupplierForm : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public AdminSupplierForm()
        {
            InitializeComponent();
        }
        #region
        public void fillTable()
        {
            tblSupplier.DataSource = csm.fillTable("Select * from Supplier").Tables[0];
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        private void performDelete()
        {
            MessageBox.Show(csm.saveInto("delete from supplier where empNo ='" + tblSupplier.CurrentRow.Cells[0].Value.ToString()+ "'"), "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fillTable();
        }
        private void autoCompleteSearch(string a)
        {
            txtSearchBy.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchBy.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection ad = new AutoCompleteStringCollection();
            MySqlDataReader reader = csm.sqlCommand("Select * from Supplier").ExecuteReader();
            ad.Clear();
            while (reader.Read())
            {
                switch (a)
                {
                    case "First Name":
                        ad.Add(reader.GetString("fname"));
                        break;
                    case "Middle Initial":
                        ad.Add(reader.GetString("Mname"));
                        break;
                    case "Last Name":
                        ad.Add(reader.GetString("lname"));
                        break;
                    case "Employee ID":
                        ad.Add(reader.GetString("empNo"));
                        break;
                }
            }
            csm.closeSql();
            txtSearchBy.AutoCompleteCustomSource = ad;
        }
        #endregion

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using(AddSupplier asf = new AddSupplier())
            {
                asf.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (AddSupplier asf = new AddSupplier()) 
            {
                asf.btnSave.Text = "UPDATE";
                asf.fillDataField(tblSupplier.CurrentRow.Cells[0].Value.ToString());
                asf.ShowDialog();
            }
        }
    }
}
