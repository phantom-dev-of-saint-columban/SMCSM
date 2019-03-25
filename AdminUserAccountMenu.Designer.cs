namespace SMCSM
{
    partial class AdminUserAccountMenu
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
            this.msUserAccountMyAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msUserAccountUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msUserAccountMyAccount
            // 
            this.msUserAccountMyAccount.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.msUserAccountMyAccount.Name = "msUserAccountMyAccount";
            this.msUserAccountMyAccount.Padding = new System.Windows.Forms.Padding(686, 0, 0, 0);
            this.msUserAccountMyAccount.Size = new System.Drawing.Size(810, 27);
            this.msUserAccountMyAccount.Text = "MY ACCOUNT";
            this.msUserAccountMyAccount.Click += new System.EventHandler(this.msUserAccountMyAccount_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 31);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1370, 499);
            this.pnlContainer.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msUserAccountMyAccount,
            this.msUserAccountUsers});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 31);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msUserAccountUsers
            // 
            this.msUserAccountUsers.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msUserAccountUsers.Name = "msUserAccountUsers";
            this.msUserAccountUsers.Padding = new System.Windows.Forms.Padding(400, 0, 0, 0);
            this.msUserAccountUsers.Size = new System.Drawing.Size(464, 27);
            this.msUserAccountUsers.Text = "USERS";
            this.msUserAccountUsers.Click += new System.EventHandler(this.msUserAccountUsers_Click);
            // 
            // AdminUserAccountMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 530);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminUserAccountMenu";
            this.Text = "AdminUserAccountMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem msUserAccountMyAccount;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msUserAccountUsers;
    }
}