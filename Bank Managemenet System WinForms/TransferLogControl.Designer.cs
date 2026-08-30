namespace Bank_Managemenet_System_WinForms
{
    partial class TransferLogControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTransferLog = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransferLog
            // 
            this.dgvTransferLog.AllowUserToAddRows = false;
            this.dgvTransferLog.AllowUserToDeleteRows = false;
            this.dgvTransferLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferLog.Location = new System.Drawing.Point(26, 266);
            this.dgvTransferLog.Name = "dgvTransferLog";
            this.dgvTransferLog.ReadOnly = true;
            this.dgvTransferLog.RowHeadersWidth = 62;
            this.dgvTransferLog.RowTemplate.Height = 28;
            this.dgvTransferLog.Size = new System.Drawing.Size(1107, 514);
            this.dgvTransferLog.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank_Managemenet_System_WinForms.Properties.Resources.document;
            this.pictureBox1.Location = new System.Drawing.Point(477, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 207);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label1.Location = new System.Drawing.Point(107, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 61);
            this.label1.TabIndex = 4;
            this.label1.Text = "Transfer Log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label2.Location = new System.Drawing.Point(809, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 61);
            this.label2.TabIndex = 5;
            this.label2.Text = "List";
            // 
            // TransferLogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTransferLog);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TransferLogControl";
            this.Size = new System.Drawing.Size(1158, 810);
            this.Load += new System.EventHandler(this.TransferLogControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransferLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
