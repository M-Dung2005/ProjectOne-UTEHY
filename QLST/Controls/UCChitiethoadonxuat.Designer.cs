namespace QLST.Controls
{
    partial class UCChitiethoadonxuat
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
            this.dgvChiTietHDX = new System.Windows.Forms.DataGridView();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.printBillBtn = new Guna.UI2.WinForms.Guna2Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHDX)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChiTietHDX
            // 
            this.dgvChiTietHDX.AllowUserToAddRows = false;
            this.dgvChiTietHDX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHDX.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHDX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHDX.Location = new System.Drawing.Point(0, 40);
            this.dgvChiTietHDX.Name = "dgvChiTietHDX";
            this.dgvChiTietHDX.RowHeadersWidth = 51;
            this.dgvChiTietHDX.RowTemplate.Height = 24;
            this.dgvChiTietHDX.RowTemplate.ReadOnly = true;
            this.dgvChiTietHDX.Size = new System.Drawing.Size(1009, 527);
            this.dgvChiTietHDX.TabIndex = 0;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgvChiTietHDX);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1034, 567);
            this.guna2GroupBox1.TabIndex = 1;
            this.guna2GroupBox1.Text = "Chi tiết hóa đơn";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.printBillBtn);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 567);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1043, 47);
            this.guna2Panel1.TabIndex = 2;
            // 
            // printBillBtn
            // 
            this.printBillBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.printBillBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.printBillBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.printBillBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.printBillBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printBillBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(255)))));
            this.printBillBtn.Font = new System.Drawing.Font("Nunito", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBillBtn.ForeColor = System.Drawing.Color.White;
            this.printBillBtn.Location = new System.Drawing.Point(0, 0);
            this.printBillBtn.Name = "printBillBtn";
            this.printBillBtn.Size = new System.Drawing.Size(1043, 47);
            this.printBillBtn.TabIndex = 0;
            this.printBillBtn.Text = "In hóa đơn";
            this.printBillBtn.Click += new System.EventHandler(this.printBillBtn_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // UCChitiethoadonxuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UCChitiethoadonxuat";
            this.Size = new System.Drawing.Size(1043, 614);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHDX)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChiTietHDX;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button printBillBtn;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
