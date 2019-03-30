using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using KOTL;

namespace SMCSM
{
    public partial class PointOfSaleForm : Form
    {
        MySqlConnection conn = new MySqlConnection();
        double total = 0.0;
        int quantity = 0;
        System.Windows.Forms.Timer tmr = null;
        public PointOfSaleForm()
        {
            InitializeComponent();
            conn.ConnectionString = "datasource=localhost;port=3306;Initial Catalog='smcsm';username = root;password=1234";
            lblDate.Text = DateTime.Now.ToShortDateString();
            StartTimer();
        }

        //Methods
        private void newsubtotal()
        {
            if (txtquantity.Text != "")
            {
                double price = double.Parse(txtUnitPrice.Text);
                double subtotal = quantity * price;
                txtSubTotal.Text = subtotal.ToString("###,###.00");
            }
            else
            {
                MessageBox.Show("");
            }
        }
        private void searchItem() 
        {
            conn.Open();
            String myquery = "select * from product where productno = '" + txtItemCode.Text + "'";
            MySqlCommand cmd = new MySqlCommand(myquery, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    txtUnitPrice.Text = rd["price"].ToString();
                    txtquantity.Text = "1";
                    txtdescription.Text = rd["description"].ToString();
                    txtDiscount.Text = "0";
                    txtSubTotal.Text = (Int32.Parse(txtUnitPrice.Text) * Int32.Parse(txtquantity.Text)).ToString("###,###.00");
                    txtTotal.Text = "0";
                }
                conn.Close();
            }
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    searchItem();
                }
                catch {
                    MessageBox.Show("Code cannot be found.");
                }
            }
        }

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
              && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = true;
            }
        }

        private void txtquantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                addItemToDataGridView();
            }
        }

        private void addItemToDataGridView() 
        {
            if (txtUnitPrice.Text != "" && txtdescription.Text != "" && txtquantity.Text != "" && txtSubTotal.Text != "")
            {
                dgvitems.Rows.Add(txtdescription.Text, txtquantity.Text, txtUnitPrice.Text);
                total = total + double.Parse(txtSubTotal.Text);
                txtTotal.Text = total.ToString("###,###.00");
                txtUnitPrice.Clear();
                txtdescription.Clear();
                txtquantity.Clear();
                txtDiscount.Clear();
                txtSubTotal.Clear();
                txtItemCode.Clear();
            }
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {
            if (txtquantity.Text != "")
            {
                quantity = Int32.Parse(txtquantity.Text);
                newsubtotal();
            }
        }
        
        private void PointOfSaleForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void btexit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btCanncel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PointOfSaleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                btCancel.PerformClick();
            }
            else if (e.KeyCode == Keys.F1) {
                btVoidItem.PerformClick();
            }
            else if (e.KeyCode == Keys.F5) {
                btPurchased.PerformClick();
            }
            else if (e.KeyCode == Keys.F2) {
                btSalesReport.PerformClick();
            }
        }

        private void btVoidItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Void Item");
        }

        private void btPurchased_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "")
            {
                lblUnitPrice.Hide();
                lblItemCode.Hide();
                lblDescription.Hide();
                lblQuantity.Hide();
                lblDiscount.Hide();
                lblSubTotal.Hide();
                txtUnitPrice.Hide();
                txtItemCode.Hide();
                txtdescription.Hide();
                txtquantity.Hide();
                txtDiscount.Hide();
                txtSubTotal.Hide();
                lblPurchasedTotal.Show();
                lblPurchasedCash.Show();
                lblPurchasedChange.Show();
                txtPurchasedTotal.Show();
                txtPurchasedCash.Show();
                txtPurchasedChange.Show();
                txtPurchasedTotal.Text = txtTotal.Text;
            }
            else {
                MessageBox.Show("No items found.");
            }
        }

        private void btSalesReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sales Report");
        }

        private void txtPurchasedCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
             && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = true;
            }
        }

        private void txtPurchasedChange_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtPurchasedCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double total = double.Parse(txtPurchasedTotal.Text);
                double cash = double.Parse(txtPurchasedCash.Text);

                if (cash >= total)
                {
                    txtPurchasedChange.Text = (cash - total).ToString("###,###.00");
                    txtPurchasedCash.Text = cash.ToString("###,###.00");
                }
                else
                {
                    MessageBox.Show("Invalid.");
                }
            }
        } 
    }
}
