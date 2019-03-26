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
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBy = new System.Windows.Forms.TextBox();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblSupplier = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblSupplier)).BeginInit();
            this.SuspendLayout();
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
            this.tblSupplier.AllowUserToAddRows = false;
            this.tblSupplier.AllowUserToDeleteRows = false;
            this.tblSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSupplier.Location = new System.Drawing.Point(9, 8);
            this.tblSupplier.Name = "tblSupplier";
            this.tblSupplier.Size = new System.Drawing.Size(1215, 253);
            this.tblSupplier.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(906, 422);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(186, 36);
            this.btnDelete.TabIndex = 72;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(714, 422);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(186, 36);
            this.btnEdit.TabIndex = 73;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddSupplier.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSupplier.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSupplier.Location = new System.Drawing.Point(522, 422);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(186, 36);
            this.btnAddSupplier.TabIndex = 74;
            this.btnAddSupplier.Text = "ADD SUPPLIER";
            this.btnAddSupplier.UseVisualStyleBackColor = false;
            // 
            // AdminSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 467);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSearchBy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchBy);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
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

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBy;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tblSupplier;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddSupplier;
    }
}