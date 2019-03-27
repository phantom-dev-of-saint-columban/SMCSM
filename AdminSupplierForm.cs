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
using DGVPrinterHelper;
using System.Diagnostics;

namespace SMCSM
{
    public partial class AdminSupplierForm : Form
    {
        CallSqlModule csm = new CallSqlModule();
        public AdminSupplierForm()
        {
            InitializeComponent();
            fillTable();
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
                    case "Supplier ID":
                        ad.Add(reader.GetString("SupplierID"));
                        break;
                    case "Supplier Name":
                        ad.Add(reader.GetString("Name"));
                        break;
                    case "Supplier Address":
                        ad.Add(reader.GetString("Address"));
                        break;
                    case "Contact":
                        ad.Add(reader.GetString("Contactnum"));
                        break;
                    case "Telephone":
                        ad.Add(reader.GetString("telNum"));
                        break;
                    case "Fax":
                        ad.Add(reader.GetString("Faxnum"));
                        break;
                    case "Email":
                        ad.Add(reader.GetString("email"));
                        break;
                    case "Website":
                        ad.Add(reader.GetString("website"));
                        break;
                }
            }
            csm.closeSql();
            txtSearchBy.AutoCompleteCustomSource = ad;
        }
        #endregion

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using(AddSupplier asf = new AddSupplier(this))
            {
                asf.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (AddSupplier asf = new AddSupplier(this)) 
            {
                asf.btnSave.Text = "UPDATE";
                asf.fillDataField(tblSupplier.CurrentRow.Cells[0].Value.ToString());
                asf.ShowDialog();
            }
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            autoCompleteSearch(cmbSearchBy.Text);
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.Text != "") { btnSearch.Enabled = true; } else { btnSearch.Enabled = false; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cmbSearchBy.Text)
            {
                case "Supplier ID":
                    tblSupplier.DataSource = csm.fillTable("Select * from Supplier where supplierID= '"+txtSearchBy.Text+"'").Tables[0];
                    break;
                case "Supplier Name":
                    tblSupplier.DataSource = csm.fillTable("Select * from Supplier where Name= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Supplier Address":
                    tblSupplier.DataSource = csm.fillTable("Select * from Supplier where Address= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Contact":
                    tblSupplier.DataSource = csm.fillTable("Select * from Supplier where contact= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Telephone":
                    tblSupplier.DataSource = csm.fillTable("Select * from Supplier where telnum= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Fax":
                    tblSupplier.DataSource = csm.fillTable("Select * from Supplier where faxnum= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Email":
                    tblSupplier.DataSource = csm.fillTable("Select * from Supplier where email= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                case "Website":
                    tblSupplier.DataSource = csm.fillTable("Select * from Supplier where website= '" + txtSearchBy.Text + "'").Tables[0];
                    break;
                default:
                    MessageBox.Show("No record found.","Record",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    break;
            }
        }

        private void tblSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "List of Suppliers";
            printer.SubTitle = string.Format("Date {0}", DateTime.Now.ToShortDateString());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;
            printer.TableAlignment = DGVPrinter.Alignment.Center;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Pagadian City ShoeMate Point-Of-Sale System";
            printer.PageSettings.Landscape = false;
            printer.PrintDataGridView(tblSupplier);
        }
    }
}
