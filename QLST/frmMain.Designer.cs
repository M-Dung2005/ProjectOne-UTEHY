namespace QLST
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBanHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnHangHoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhachHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btnQLUser = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.quyenLabel = new System.Windows.Forms.Label();
            this.quyenLabelTitle = new System.Windows.Forms.Label();
            this.tkLabel = new System.Windows.Forms.Label();
            this.tkLabelTitle = new System.Windows.Forms.Label();
            this.clientArea = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Nunito", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1527, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStrip,
            this.exitToolStrip});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(95, 27);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // logoutToolStrip
            // 
            this.logoutToolStrip.Image = global::QLST.Properties.Resources.door_open_house_exit;
            this.logoutToolStrip.Name = "logoutToolStrip";
            this.logoutToolStrip.Size = new System.Drawing.Size(224, 28);
            this.logoutToolStrip.Text = "Đăng xuất";
            this.logoutToolStrip.Click += new System.EventHandler(this.logoutToolStrip_Click);
            // 
            // exitToolStrip
            // 
            this.exitToolStrip.Image = global::QLST.Properties.Resources.exit;
            this.exitToolStrip.Name = "exitToolStrip";
            this.exitToolStrip.Size = new System.Drawing.Size(224, 28);
            this.exitToolStrip.Text = "Thoát";
            this.exitToolStrip.Click += new System.EventHandler(this.exitToolStrip_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnBanHang);
            this.flowLayoutPanel1.Controls.Add(this.btnHoaDon);
            this.flowLayoutPanel1.Controls.Add(this.btnHangHoa);
            this.flowLayoutPanel1.Controls.Add(this.btnThongKe);
            this.flowLayoutPanel1.Controls.Add(this.btnKhachHang);
            this.flowLayoutPanel1.Controls.Add(this.btnNhanVien);
            this.flowLayoutPanel1.Controls.Add(this.btnQLUser);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(307, 741);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnBanHang
            // 
            this.btnBanHang.BackColor = System.Drawing.Color.Transparent;
            this.btnBanHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBanHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBanHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBanHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBanHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBanHang.FillColor = System.Drawing.Color.SteelBlue;
            this.btnBanHang.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanHang.ForeColor = System.Drawing.Color.White;
            this.btnBanHang.Image = global::QLST.Properties.Resources.shop_cart_icon64;
            this.btnBanHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBanHang.ImageSize = new System.Drawing.Size(40, 40);
            this.btnBanHang.Location = new System.Drawing.Point(3, 2);
            this.btnBanHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(300, 71);
            this.btnBanHang.TabIndex = 0;
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.btnHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoaDon.FillColor = System.Drawing.Color.SteelBlue;
            this.btnHoaDon.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHoaDon.Image = global::QLST.Properties.Resources.invoice_icon64;
            this.btnHoaDon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHoaDon.ImageSize = new System.Drawing.Size(40, 40);
            this.btnHoaDon.Location = new System.Drawing.Point(3, 77);
            this.btnHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(300, 71);
            this.btnHoaDon.TabIndex = 1;
            this.btnHoaDon.Text = "Hóa Đơn";
            this.btnHoaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnHangHoa
            // 
            this.btnHangHoa.BackColor = System.Drawing.Color.Transparent;
            this.btnHangHoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHangHoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHangHoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHangHoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHangHoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHangHoa.FillColor = System.Drawing.Color.SteelBlue;
            this.btnHangHoa.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHangHoa.ForeColor = System.Drawing.Color.White;
            this.btnHangHoa.Image = global::QLST.Properties.Resources.hanghoa_icon64;
            this.btnHangHoa.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHangHoa.ImageSize = new System.Drawing.Size(40, 40);
            this.btnHangHoa.Location = new System.Drawing.Point(3, 152);
            this.btnHangHoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHangHoa.Name = "btnHangHoa";
            this.btnHangHoa.Size = new System.Drawing.Size(300, 71);
            this.btnHangHoa.TabIndex = 2;
            this.btnHangHoa.Text = "Hàng Hóa";
            this.btnHangHoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHangHoa.Click += new System.EventHandler(this.btnHangHoa_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FillColor = System.Drawing.Color.SteelBlue;
            this.btnThongKe.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Image = global::QLST.Properties.Resources.thongke_icon;
            this.btnThongKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKe.ImageSize = new System.Drawing.Size(40, 40);
            this.btnThongKe.Location = new System.Drawing.Point(3, 227);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(300, 71);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhachHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhachHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhachHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FillColor = System.Drawing.Color.SteelBlue;
            this.btnKhachHang.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Image = global::QLST.Properties.Resources.customer_icon;
            this.btnKhachHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhachHang.ImageSize = new System.Drawing.Size(40, 40);
            this.btnKhachHang.Location = new System.Drawing.Point(3, 302);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(300, 71);
            this.btnKhachHang.TabIndex = 4;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.btnNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhanVien.FillColor = System.Drawing.Color.SteelBlue;
            this.btnNhanVien.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.Image = global::QLST.Properties.Resources.employee_icon64;
            this.btnNhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhanVien.ImageSize = new System.Drawing.Size(40, 40);
            this.btnNhanVien.Location = new System.Drawing.Point(3, 377);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(300, 71);
            this.btnNhanVien.TabIndex = 5;
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnQLUser
            // 
            this.btnQLUser.BackColor = System.Drawing.Color.Transparent;
            this.btnQLUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQLUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQLUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQLUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQLUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLUser.FillColor = System.Drawing.Color.SteelBlue;
            this.btnQLUser.Font = new System.Drawing.Font("Nunito", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLUser.ForeColor = System.Drawing.Color.White;
            this.btnQLUser.Image = global::QLST.Properties.Resources.user_info_icon64;
            this.btnQLUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLUser.ImageSize = new System.Drawing.Size(40, 40);
            this.btnQLUser.Location = new System.Drawing.Point(3, 452);
            this.btnQLUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQLUser.Name = "btnQLUser";
            this.btnQLUser.Size = new System.Drawing.Size(300, 71);
            this.btnQLUser.TabIndex = 6;
            this.btnQLUser.Text = "QL Người Dùng";
            this.btnQLUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQLUser.Click += new System.EventHandler(this.btnQLUser_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.quyenLabel);
            this.panel1.Controls.Add(this.quyenLabelTitle);
            this.panel1.Controls.Add(this.tkLabel);
            this.panel1.Controls.Add(this.tkLabelTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 772);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1527, 42);
            this.panel1.TabIndex = 2;
            // 
            // quyenLabel
            // 
            this.quyenLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.quyenLabel.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quyenLabel.Location = new System.Drawing.Point(407, 0);
            this.quyenLabel.Name = "quyenLabel";
            this.quyenLabel.Size = new System.Drawing.Size(213, 42);
            this.quyenLabel.TabIndex = 4;
            this.quyenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // quyenLabelTitle
            // 
            this.quyenLabelTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.quyenLabelTitle.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quyenLabelTitle.Location = new System.Drawing.Point(307, 0);
            this.quyenLabelTitle.Name = "quyenLabelTitle";
            this.quyenLabelTitle.Size = new System.Drawing.Size(100, 42);
            this.quyenLabelTitle.TabIndex = 2;
            this.quyenLabelTitle.Text = "Quyền :";
            this.quyenLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tkLabel
            // 
            this.tkLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tkLabel.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tkLabel.Location = new System.Drawing.Point(123, 0);
            this.tkLabel.Name = "tkLabel";
            this.tkLabel.Size = new System.Drawing.Size(184, 42);
            this.tkLabel.TabIndex = 3;
            this.tkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tkLabelTitle
            // 
            this.tkLabelTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.tkLabelTitle.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tkLabelTitle.Location = new System.Drawing.Point(0, 0);
            this.tkLabelTitle.Name = "tkLabelTitle";
            this.tkLabelTitle.Size = new System.Drawing.Size(123, 42);
            this.tkLabelTitle.TabIndex = 0;
            this.tkLabelTitle.Text = "Tài khoản :";
            this.tkLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clientArea
            // 
            this.clientArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientArea.Location = new System.Drawing.Point(307, 31);
            this.clientArea.Margin = new System.Windows.Forms.Padding(4);
            this.clientArea.Name = "clientArea";
            this.clientArea.Size = new System.Drawing.Size(1220, 741);
            this.clientArea.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1527, 814);
            this.Controls.Add(this.clientArea);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1423, 649);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStrip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnBanHang;
        private Guna.UI2.WinForms.Guna2Button btnHoaDon;
        private Guna.UI2.WinForms.Guna2Button btnHangHoa;
        private Guna.UI2.WinForms.Guna2Button btnThongKe;
        private Guna.UI2.WinForms.Guna2Button btnKhachHang;
        private Guna.UI2.WinForms.Guna2Button btnNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnQLUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label quyenLabelTitle;
        private System.Windows.Forms.Label tkLabelTitle;
        private System.Windows.Forms.Panel clientArea;
        private System.Windows.Forms.Label tkLabel;
        private System.Windows.Forms.Label quyenLabel;
    }
}