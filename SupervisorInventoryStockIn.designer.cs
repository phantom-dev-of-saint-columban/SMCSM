﻿namespace SMCSM
{
    partial class SupervisorInventoryStockIn
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
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tblStockIn = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.txtSearchBy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrintReview = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tblStockIn)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "yyyy-MM-dd";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(622, 48);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(91, 20);
            this.dtDateTo.TabIndex = 121;
            this.dtDateTo.Visible = false;
            this.dtDateTo.ValueChanged += new System.EventHandler(this.dtDateTo_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(587, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 18);
            this.label5.TabIndex = 119;
            this.label5.Text = "TO:";
            // 
            // dpDateFrom
            // 
            this.dpDateFrom.CalendarForeColor = System.Drawing.Color.Coral;
            this.dpDateFrom.CustomFormat = "yyyy-MM-dd";
            this.dpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateFrom.Location = new System.Drawing.Point(481, 49);
            this.dpDateFrom.Name = "dpDateFrom";
            this.dpDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dpDateFrom.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 118;
            this.label3.Text = "FROM:";
            this.label3.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(417, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 115;
            this.label6.Text = "LIST OF ITEMS";
            // 
            // tblStockIn
            // 
            this.tblStockIn.AllowUserToAddRows = false;
            this.tblStockIn.AllowUserToDeleteRows = false;
            this.tblStockIn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblStockIn.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.tblStockIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblStockIn.Location = new System.Drawing.Point(6, 8);
            this.tblStockIn.Name = "tblStockIn";
            this.tblStockIn.Size = new System.Drawing.Size(888, 214);
            this.tblStockIn.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnSearch.Enabled = false;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(352, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 26);
            this.btnSearch.TabIndex = 114;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Items.AddRange(new object[] {
            "",
            "Delivery Receipt No",
            "Product No",
            "Supplier ID",
            "Unit",
            "Quantity",
            "Date"});
            this.cmbSearchBy.Location = new System.Drawing.Point(95, 47);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(121, 26);
            this.cmbSearchBy.TabIndex = 113;
            this.cmbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBy_SelectedIndexChanged);
            // 
            // txtSearchBy
            // 
            this.txtSearchBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBy.Enabled = false;
            this.txtSearchBy.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBy.Location = new System.Drawing.Point(222, 47);
            this.txtSearchBy.Name = "txtSearchBy";
            this.txtSearchBy.Size = new System.Drawing.Size(127, 26);
            this.txtSearchBy.TabIndex = 106;
            this.txtSearchBy.TextChanged += new System.EventHandler(this.txtSearchBy_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 18);
            this.label7.TabIndex = 104;
            this.label7.Text = "SEARCH BY:";
            // 
            // btnPrintReview
            // 
            this.btnPrintReview.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnPrintReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReview.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReview.Location = new System.Drawing.Point(741, 344);
            this.btnPrintReview.Name = "btnPrintReview";
            this.btnPrintReview.Size = new System.Drawing.Size(173, 36);
            this.btnPrintReview.TabIndex = 107;
            this.btnPrintReview.Text = "PRINT REVIEW";
            this.btnPrintReview.UseVisualStyleBackColor = false;
            this.btnPrintReview.Click += new System.EventHandler(this.btnPrintReview_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 29);
            this.panel1.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, -30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "LIST OF ITEMS AVAILABLE";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tblStockIn);
            this.panel2.Location = new System.Drawing.Point(13, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 236);
            this.panel2.TabIndex = 103;
            // 
            // SupervisorInventoryStockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 389);
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dpDateFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.txtSearchBy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPrintReview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SupervisorInventoryStockIn";
            this.Text = "SupervisorInventoryStockIn";
            this.Load += new System.EventHandler(this.SupervisorInventoryStockIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblStockIn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dpDateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView tblStockIn;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.TextBox txtSearchBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPrintReview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}