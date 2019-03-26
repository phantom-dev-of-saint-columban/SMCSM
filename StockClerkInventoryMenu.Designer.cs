namespace SMCSM
{
    partial class StockClerkInventoryMenu
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
            this.msStockIn = new System.Windows.Forms.ToolStripMenuItem();
            this.msSales = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msStockReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msStockIn
            // 
            this.msStockIn.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.msStockIn.Name = "msStockIn";
            this.msStockIn.Padding = new System.Windows.Forms.Padding(250, 0, 4, 0);
            this.msStockIn.Size = new System.Drawing.Size(340, 27);
            this.msStockIn.Text = "STOCK IN";
            // 
            // msSales
            // 
            this.msSales.Name = "msSales";
            this.msSales.Padding = new System.Windows.Forms.Padding(200, 0, 4, 0);
            this.msSales.Size = new System.Drawing.Size(265, 27);
            this.msSales.Text = "SALES";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.menuStrip1);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(900, 455);
            this.pnlContainer.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msStockIn,
            this.msSales,
            this.msStockReturn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 31);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msStockReturn
            // 
            this.msStockReturn.Name = "msStockReturn";
            this.msStockReturn.Padding = new System.Windows.Forms.Padding(150, 0, 4, 0);
            this.msStockReturn.Size = new System.Drawing.Size(287, 27);
            this.msStockReturn.Text = "STOCK RETURN";
            // 
            // StockClerkInventoryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 455);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockClerkInventoryMenu";
            this.Text = "StockClerkInventoryMenu";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem msStockIn;
        private System.Windows.Forms.ToolStripMenuItem msSales;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msStockReturn;
    }
}