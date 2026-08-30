namespace Bank_Managemenet_System_WinForms
{
    partial class frmCurrencies
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrencies));
            this.dgvCurrencies = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateCurrencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnFindClient = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrencies)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCurrencies
            // 
            this.dgvCurrencies.AllowUserToAddRows = false;
            this.dgvCurrencies.AllowUserToDeleteRows = false;
            this.dgvCurrencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrencies.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCurrencies.Location = new System.Drawing.Point(29, 246);
            this.dgvCurrencies.Name = "dgvCurrencies";
            this.dgvCurrencies.ReadOnly = true;
            this.dgvCurrencies.RowHeadersWidth = 62;
            this.dgvCurrencies.RowTemplate.Height = 28;
            this.dgvCurrencies.Size = new System.Drawing.Size(1265, 433);
            this.dgvCurrencies.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateCurrencyToolStripMenuItem,
            this.deleteCurrencyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 68);
            // 
            // updateCurrencyToolStripMenuItem
            // 
            this.updateCurrencyToolStripMenuItem.Name = "updateCurrencyToolStripMenuItem";
            this.updateCurrencyToolStripMenuItem.Size = new System.Drawing.Size(216, 32);
            this.updateCurrencyToolStripMenuItem.Text = "Update Currency";
            this.updateCurrencyToolStripMenuItem.Click += new System.EventHandler(this.updateCurrencyToolStripMenuItem_Click);
            // 
            // deleteCurrencyToolStripMenuItem
            // 
            this.deleteCurrencyToolStripMenuItem.Name = "deleteCurrencyToolStripMenuItem";
            this.deleteCurrencyToolStripMenuItem.Size = new System.Drawing.Size(216, 32);
            this.deleteCurrencyToolStripMenuItem.Text = "Delete Currency";
            this.deleteCurrencyToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrencyToolStripMenuItem_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnAddClient.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.btnAddClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddClient.Image = global::Bank_Managemenet_System_WinForms.Properties.Resources.add_user;
            this.btnAddClient.Location = new System.Drawing.Point(165, 120);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(278, 92);
            this.btnAddClient.TabIndex = 6;
            this.btnAddClient.Text = " Add Currency";
            this.btnAddClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnFindClient
            // 
            this.btnFindClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnFindClient.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.btnFindClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFindClient.Image = global::Bank_Managemenet_System_WinForms.Properties.Resources.search__1_;
            this.btnFindClient.Location = new System.Drawing.Point(875, 120);
            this.btnFindClient.Name = "btnFindClient";
            this.btnFindClient.Size = new System.Drawing.Size(278, 92);
            this.btnFindClient.TabIndex = 5;
            this.btnFindClient.Text = " Find Currency";
            this.btnFindClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFindClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFindClient.UseVisualStyleBackColor = false;
            this.btnFindClient.Click += new System.EventHandler(this.btnFindClient_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank_Managemenet_System_WinForms.Properties.Resources.currencies__1_;
            this.pictureBox1.Location = new System.Drawing.Point(566, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmCurrencies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 704);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.btnFindClient);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvCurrencies);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCurrencies";
            this.Text = "Currencies";
            this.Load += new System.EventHandler(this.frmCurrencies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrencies)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCurrencies;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnFindClient;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateCurrencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrencyToolStripMenuItem;
    }
}