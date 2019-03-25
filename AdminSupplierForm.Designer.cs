namespace SMCSM
{
    partial class AdminSupplierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contactnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faxnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephonenum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.supplieraddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.supplieraname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblSupplier = new System.Windows.Forms.DataGridView();
            this.lblUSERTYPE = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // contactnum
            // 
            this.contactnum.FillWeight = 99.76229F;
            this.contactnum.HeaderText = "CONTACT #";
            this.contactnum.Name = "contactnum";
            // 
            // website
            // 
            this.website.FillWeight = 104.1478F;
            this.website.HeaderText = "WEBSITE";
            this.website.Name = "website";
            // 
            // email
            // 
            this.email.FillWeight = 103.2491F;
            this.email.HeaderText = "E-MAIL ADD";
            this.email.Name = "email";
            // 
            // faxnum
            // 
            this.faxnum.FillWeight = 102.2298F;
            this.faxnum.HeaderText = "FAX #";
            this.faxnum.Name = "faxnum";
            // 
            // telephonenum
            // 
            this.telephonenum.FillWeight = 101.0736F;
            this.telephonenum.HeaderText = "TELEPHONE #";
            this.telephonenum.Name = "telephonenum";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(40, 32);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(23, 19);
            this.lblID.TabIndex = 71;
            this.lblID.Text = "ID";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 19);
            this.label8.TabIndex = 70;
            this.label8.Text = "ID:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(594, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(288, 42);
            this.label6.TabIndex = 69;
            this.label6.Text = "LIST OF SUPPLIERS";
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Location = new System.Drawing.Point(219, 72);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(150, 27);
            this.cmbSearchBy.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(115, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 58;
            this.label7.Text = "SEARCH BY:";
            // 
            // supplieraddress
            // 
            this.supplieraddress.FillWeight = 98.27497F;
            this.supplieraddress.HeaderText = "SUPPLIER ADDRESS";
            this.supplieraddress.Name = "supplieraddress";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(710, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(139, 27);
            this.btnSearch.TabIndex = 68;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchBy
            // 
            this.txtSearchBy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBy.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBy.Location = new System.Drawing.Point(375, 72);
            this.txtSearchBy.Name = "txtSearchBy";
            this.txtSearchBy.Size = new System.Drawing.Size(329, 27);
            this.txtSearchBy.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 56;
            this.label2.Text = "WELCOME";
            // 
            // supplieraname
            // 
            this.supplieraname.FillWeight = 96.58797F;
            this.supplieraname.HeaderText = "SUPPLIER NAME";
            this.supplieraname.Name = "supplieraname";
            // 
            // supplierid
            // 
            this.supplierid.FillWeight = 94.67457F;
            this.supplierid.HeaderText = "SUPPLIER ID";
            this.supplierid.Name = "supplierid";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintPreview.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPreview.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreview.Location = new System.Drawing.Point(1098, 422);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(186, 36);
            this.btnPrintPreview.TabIndex = 61;
            this.btnPrintPreview.Text = "PRINT PREVIEW";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(44, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 29);
            this.panel1.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "LIST OF SOLD ITEMS";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tblSupplier);
            this.panel2.Location = new System.Drawing.Point(44, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1240, 275);
            this.panel2.TabIndex = 57;
            // 
            // tblSupplier
            // 
            this.tblSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.supplierid,
            this.supplieraname,
            this.supplieraddress,
            this.contactnum,
            this.telephonenum,
            this.faxnum,
            this.email,
            this.website});
            this.tblSupplier.Location = new System.Drawing.Point(9, 8);
            this.tblSupplier.Name = "tblSupplier";
            this.tblSupplier.Size = new System.Drawing.Size(1215, 253);
            this.tblSupplier.TabIndex = 0;
            // 
            // lblUSERTYPE
            // 
            this.lblUSERTYPE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUSERTYPE.AutoSize = true;
            this.lblUSERTYPE.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSERTYPE.Location = new System.Drawing.Point(97, 9);
            this.lblUSERTYPE.Name = "lblUSERTYPE";
            this.lblUSERTYPE.Size = new System.Drawing.Size(75, 19);
            this.lblUSERTYPE.TabIndex = 62;
            this.lblUSERTYPE.Text = "USERTYPE";
            // 
            // AdminSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 467);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblUSERTYPE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminSupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminSupplierForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn contactnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn website;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn faxnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephonenum;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplieraddress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplieraname;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierid;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tblSupplier;
        private System.Windows.Forms.Label lblUSERTYPE;
    }
}