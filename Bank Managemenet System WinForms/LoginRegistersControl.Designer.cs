namespace Bank_Managemenet_System_WinForms
{
    partial class LoginRegistersControl
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
            this.dgvLoginRegisters = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginRegisters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoginRegisters
            // 
            this.dgvLoginRegisters.AllowUserToAddRows = false;
            this.dgvLoginRegisters.AllowUserToDeleteRows = false;
            this.dgvLoginRegisters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginRegisters.Location = new System.Drawing.Point(21, 268);
            this.dgvLoginRegisters.Name = "dgvLoginRegisters";
            this.dgvLoginRegisters.ReadOnly = true;
            this.dgvLoginRegisters.RowHeadersWidth = 62;
            this.dgvLoginRegisters.RowTemplate.Height = 28;
            this.dgvLoginRegisters.Size = new System.Drawing.Size(1107, 514);
            this.dgvLoginRegisters.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank_Managemenet_System_WinForms.Properties.Resources.document;
            this.pictureBox1.Location = new System.Drawing.Point(472, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 207);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoginRegistersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLoginRegisters);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LoginRegistersControl";
            this.Size = new System.Drawing.Size(1158, 810);
            this.Load += new System.EventHandler(this.LoginRegistersControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginRegisters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvLoginRegisters;
    }
}
