namespace SMCSM
{
    partial class AdminMainMenuForm
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.msSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.msSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.msEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.msInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msUserAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 31);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(924, 231);
            this.pnlContainer.TabIndex = 3;
            // 
            // msSettings
            // 
            this.msSettings.Name = "msSettings";
            this.msSettings.Padding = new System.Windows.Forms.Padding(80, 0, 4, 0);
            this.msSettings.Size = new System.Drawing.Size(173, 27);
            this.msSettings.Text = "SETTINGS";
            // 
            // msSupplier
            // 
            this.msSupplier.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msSupplier.Name = "msSupplier";
            this.msSupplier.Padding = new System.Windows.Forms.Padding(80, 0, 4, 0);
            this.msSupplier.Size = new System.Drawing.Size(172, 27);
            this.msSupplier.Text = "SUPPLIER";
            // 
            // msEmployee
            // 
            this.msEmployee.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.msEmployee.Name = "msEmployee";
            this.msEmployee.Padding = new System.Windows.Forms.Padding(80, 0, 4, 0);
            this.msEmployee.Size = new System.Drawing.Size(182, 27);
            this.msEmployee.Text = "EMPLOYEE";
            // 
            // msInventory
            // 
            this.msInventory.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.msInventory.Name = "msInventory";
            this.msInventory.Padding = new System.Windows.Forms.Padding(80, 0, 4, 0);
            this.msInventory.Size = new System.Drawing.Size(191, 27);
            this.msInventory.Text = "INVENTORY";
            this.msInventory.Click += new System.EventHandler(this.msInventory_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msInventory,
            this.msEmployee,
            this.msSupplier,
            this.msSettings,
            this.msUserAccount});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 31);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msUserAccount
            // 
            this.msUserAccount.Name = "msUserAccount";
            this.msUserAccount.Padding = new System.Windows.Forms.Padding(50, 0, 4, 0);
            this.msUserAccount.Size = new System.Drawing.Size(192, 27);
            this.msUserAccount.Text = "USER ACCOUNT";
            // 
            // AdminMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 262);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminMainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainMenuForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.ToolStripMenuItem msSettings;
        private System.Windows.Forms.ToolStripMenuItem msSupplier;
        private System.Windows.Forms.ToolStripMenuItem msEmployee;
        private System.Windows.Forms.ToolStripMenuItem msInventory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msUserAccount;
    }
}