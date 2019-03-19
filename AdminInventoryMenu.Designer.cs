namespace SMCSM
{
    partial class AdminInventoryMenu
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
            this.msInventorySales = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlInventoryContainer = new System.Windows.Forms.Panel();
            this.msInventoryStockIn = new System.Windows.Forms.ToolStripMenuItem();
            this.msInventoryStockReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msInventorySales
            // 
            this.msInventorySales.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.msInventorySales.Name = "msInventorySales";
            this.msInventorySales.Padding = new System.Windows.Forms.Padding(200, 0, 4, 0);
            this.msInventorySales.Size = new System.Drawing.Size(265, 27);
            this.msInventorySales.Text = "SALES";
            // 
            // pnlInventoryContainer
            // 
            this.pnlInventoryContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInventoryContainer.Location = new System.Drawing.Point(0, 31);
            this.pnlInventoryContainer.Name = "pnlInventoryContainer";
            this.pnlInventoryContainer.Size = new System.Drawing.Size(959, 386);
            this.pnlInventoryContainer.TabIndex = 4;
            // 
            // msInventoryStockIn
            // 
            this.msInventoryStockIn.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.msInventoryStockIn.Name = "msInventoryStockIn";
            this.msInventoryStockIn.Padding = new System.Windows.Forms.Padding(200, 0, 4, 0);
            this.msInventoryStockIn.Size = new System.Drawing.Size(290, 27);
            this.msInventoryStockIn.Text = "STOCK IN";
            // 
            // msInventoryStockReturn
            // 
            this.msInventoryStockReturn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msInventoryStockReturn.Name = "msInventoryStockReturn";
            this.msInventoryStockReturn.Padding = new System.Windows.Forms.Padding(200, 0, 4, 0);
            this.msInventoryStockReturn.Size = new System.Drawing.Size(337, 27);
            this.msInventoryStockReturn.Text = "STOCK RETURN";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msInventoryStockIn,
            this.msInventorySales,
            this.msInventoryStockReturn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(959, 31);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AdminInventoryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 417);
            this.Controls.Add(this.pnlInventoryContainer);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminInventoryMenu";
            this.Text = "AdminInventoryMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem msInventorySales;
        private System.Windows.Forms.Panel pnlInventoryContainer;
        private System.Windows.Forms.ToolStripMenuItem msInventoryStockIn;
        private System.Windows.Forms.ToolStripMenuItem msInventoryStockReturn;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}