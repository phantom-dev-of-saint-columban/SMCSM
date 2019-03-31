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
    public partial class CashierPurchased : Form
    {
        CallSqlModule csm = new CallSqlModule(); MainMenuForm mmf;
        public CashierPurchased(MainMenuForm mmf)
        {
            InitializeComponent();
            this.mmf = mmf;
        }

        #region Dev's Method
        private void getUnitPrice(string a)
        {
            txtUnitPrice.Text = Double.Parse(csm.countSQL("select price from product where productNo = '" + a + "'", "price")).ToString();
        }
        private void performClear() 
        {
            txtProdNo.Text = "";
            txtUnitPrice.Text = "0";
            txtQuan.Text = "";
            txtSubtotal.Text = "0";
            txtTotal.Text = "0";
        }
        private void performClearAll() 
        {
            txtCash.Text = "";
            txtChange.Text = "0";
            txtDiscount.Text = "";
            txtProdNo.Text = "";
            txtQuan.Text = "";
            txtSubtotal.Text = "0";
            txtTotal.Text = "0";
            txtTotalPur.Text = "0";
            txtUnitPrice.Text = "0";

            lblInvoiceNo.Text = autoGenInvoiceNo();
            lblOrderReceipt.Text = autoGenOrderReceipt();
            lblTransactNo.Text = autoGenTransactionNo();

            tblOrder.Rows.Clear();

            pnlPurchase.Visible = false;
            btnAdd.Enabled = true;
        }
        private void calculateTotal() 
        {
            for (int i = 0; i < tblOrder.RowCount; i++ )
            {
                txtTotal.Text = (Double.Parse(txtTotal.Text) + Double.Parse(tblOrder.Rows[i].Cells[3].Value.ToString())).ToString();
            }
        }
        private void setEmpNoAndEmpName() 
        {
            lblEmpNo.Text = csm.countSQL("select name from useraccount where username ='"+mmf._username+"' and password = '"+mmf._password+"'","name");
            lblEmpName.Text = csm.countSQL("select concat(fname,' ',mname,' ',Lname)as'Fullname' from employee where empno = '"+lblEmpNo.Text+"'", "Fullname");
        }
        private string autoGenTransactionNo()
        {
            int a = Int32.Parse(csm.countSQL("select count(*)as'allcount' from SalesReg", "allcount"));
            string b = "T" + String.Format("{0:D3}", (a + 1));
            return b;
        }
        private string autoGenInvoiceNo() 
        {
            int a = Int32.Parse(csm.countSQL("select count(*)as'allcount' from salesOrder", "allcount"));
            string b = "1" + String.Format("{0:D6}", (a + 1));
            return b;
        }
        private string autoGenOrderReceipt()
        {
            int a = Int32.Parse(csm.countSQL("select count(*)as'allcount' from payment", "allcount"));
            string b = "P" + DateTime.Now.ToString("yy") + "-" + String.Format("{0:D3}", (a + 1));
            return b;
        }
        private void saveToSalesOrder() 
        {
            csm.saveInto("insert into salesOrder (InvoiceNo, productNo,Quantity,TransactionNo) values('"+lblInvoiceNo.Text+"','"+txtProdNo.Text+"','"+txtQuan.Text+"','"+lblTransactNo.Text+"')");
        }
        private void saveToSalesRegAndPayment() 
        {
            if (csm.saveInto("insert into salesreg values('" + lblTransactNo.Text + "','" + DateTime.Now.ToShortTimeString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + lblEmpNo.Text + "')") == "Successful")
            {
                MessageBox.Show(csm.saveInto("insert into payment values('" + lblOrderReceipt.Text + "','" + txtTotalPur.Text + "','" + txtCash.Text + "','" + txtChange.Text + "','" + txtDiscount.Text + "','" + lblTransactNo.Text + "')"), "Transaction Notification!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Error on SalesReg Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        private void txtProdNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                getUnitPrice(txtProdNo.Text);
            }
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            txtSubtotal.Text = (Double.Parse(txtUnitPrice.Text)).ToString();
        }

        private void txtQuan_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                txtSubtotal.Text = (Double.Parse(txtUnitPrice.Text) * Double.Parse(txtQuan.Text)).ToString();
            }
            catch { txtSubtotal.Text = "Invalid Input"; }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try 
            {
            txtSubtotal.Text = (Double.Parse(txtSubtotal.Text) * Double.Parse("0." + txtDiscount.Text)).ToString();
            }
            catch { txtSubtotal.Text = "Invalid Input"; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Add?", "Adding Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                btnAdd.Enabled = false;
                tblOrder.Rows.Add(txtProdNo.Text,csm.countSQL("select description from product where productNo = '" + txtProdNo.Text + "'", "description"), txtQuan.Text, txtUnitPrice.Text);
                saveToSalesOrder();
                performClear();
                calculateTotal();
            }
        }

        private void CashierPurchased_Load(object sender, EventArgs e)
        {
            performClearAll();
            setEmpNoAndEmpName();
        }

        private void btnPurchased_Click(object sender, EventArgs e)
        {
            txtTotalPur.Text = txtTotal.Text;
            pnlPurchase.Visible = true;
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtChange.Text = (Double.Parse(txtTotalPur.Text) - Double.Parse(txtCash.Text)).ToString("N2");
            }
            catch { txtChange.Text = "Invalid Input"; }
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult dialogResult = MessageBox.Show("Confirm Transaction: Click [YES] to proceed.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    saveToSalesRegAndPayment();
                    performClearAll();

                    //PrintingReceipt() Start Here...
                }
            }
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "") { txtSubtotal.Text = (double.Parse(txtSubtotal.Text) - ((double.Parse(txtDiscount.Text) / double.Parse(txtSubtotal.Text)) * 100)).ToString(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Cancel", "Cancelling", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                performClearAll();
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Void an Item?", "Void Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using(VoidItem vi = new VoidItem(this))
                {
                    vi.ShowDialog();
                }
            }
        }

        private void CashierPurchased_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                btnCancel.PerformClick();
            }
            else if (e.KeyCode == Keys.F1) 
            {
                btnVoid.PerformClick();
            }
            else if (e.KeyCode == Keys.F5) 
            {
                btnPurchased.PerformClick();
            }
            else if (e.KeyCode == Keys.F2) 
            {
                btnSalesRep.PerformClick();
            }
        }

        private void tblOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove " + tblOrder.CurrentRow.Cells[0].Value.ToString(), "Void Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(csm.saveInto("delete from salesorder where productNo = '" + txtProdNo.Text + "' and transactionNo = '" + lblTransactNo.Text + "'"),"Deleting",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
