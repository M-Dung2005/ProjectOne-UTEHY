namespace QLST.Controls
{
    partial class UCBanHang
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
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnTaohoadon = new Guna.UI2.WinForms.Guna2Button();
            this.cmbNhanVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpNgayban = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtMaHDX = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBanHang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.txtSoluong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDongia = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMahang = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaloai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTensp = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanHang)).BeginInit();
            this.guna2GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.btnTaohoadon);
            this.guna2GroupBox1.Controls.Add(this.cmbNhanVien);
            this.guna2GroupBox1.Controls.Add(this.dtpNgayban);
            this.guna2GroupBox1.Controls.Add(this.txtMaHDX);
            this.guna2GroupBox1.Controls.Add(this.txtMaKH);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1107, 211);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Thông tin hóa đơn";
            // 
            // btnTaohoadon
            // 
            this.btnTaohoadon.BorderRadius = 5;
            this.btnTaohoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaohoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaohoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaohoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaohoadon.FillColor = System.Drawing.Color.Silver;
            this.btnTaohoadon.Font = new System.Drawing.Font("Nunito", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaohoadon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTaohoadon.Location = new System.Drawing.Point(872, 116);
            this.btnTaohoadon.Name = "btnTaohoadon";
            this.btnTaohoadon.Size = new System.Drawing.Size(168, 35);
            this.btnTaohoadon.TabIndex = 4;
            this.btnTaohoadon.Text = "Tạo hóa đơn";
            this.btnTaohoadon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.cmbNhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbNhanVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbNhanVien.ItemHeight = 30;
            this.cmbNhanVien.Location = new System.Drawing.Point(202, 107);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(194, 36);
            this.cmbNhanVien.TabIndex = 3;
            // 
            // dtpNgayban
            // 
            this.dtpNgayban.Checked = true;
            this.dtpNgayban.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpNgayban.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayban.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayban.Location = new System.Drawing.Point(572, 115);
            this.dtpNgayban.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayban.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayban.Name = "dtpNgayban";
            this.dtpNgayban.Size = new System.Drawing.Size(194, 36);
            this.dtpNgayban.TabIndex = 2;
            this.dtpNgayban.Value = new System.DateTime(2025, 5, 5, 16, 55, 5, 42);
            // 
            // txtMaHDX
            // 
            this.txtMaHDX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaHDX.DefaultText = "";
            this.txtMaHDX.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaHDX.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaHDX.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaHDX.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaHDX.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaHDX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaHDX.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaHDX.Location = new System.Drawing.Point(572, 48);
            this.txtMaHDX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaHDX.Name = "txtMaHDX";
            this.txtMaHDX.PlaceholderText = "";
            this.txtMaHDX.SelectedText = "";
            this.txtMaHDX.Size = new System.Drawing.Size(194, 36);
            this.txtMaHDX.TabIndex = 1;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaKH.DefaultText = "";
            this.txtMaKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKH.Location = new System.Drawing.Point(202, 56);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.PlaceholderText = "";
            this.txtMaKH.SelectedText = "";
            this.txtMaKH.Size = new System.Drawing.Size(194, 36);
            this.txtMaKH.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(444, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày bán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhân viên bán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã HĐX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã KH";
            // 
            // dgvBanHang
            // 
            this.dgvBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvBanHang.Location = new System.Drawing.Point(366, 220);
            this.dgvBanHang.Name = "dgvBanHang";
            this.dgvBanHang.RowHeadersWidth = 51;
            this.dgvBanHang.RowTemplate.Height = 24;
            this.dgvBanHang.Size = new System.Drawing.Size(688, 455);
            this.dgvBanHang.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã loại";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã hàng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên SP";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Đơn giá";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Số lượng";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.Controls.Add(this.btnThem);
            this.guna2GroupBox3.Controls.Add(this.txtSoluong);
            this.guna2GroupBox3.Controls.Add(this.txtDongia);
            this.guna2GroupBox3.Controls.Add(this.txtMahang);
            this.guna2GroupBox3.Controls.Add(this.txtMaloai);
            this.guna2GroupBox3.Controls.Add(this.label15);
            this.guna2GroupBox3.Controls.Add(this.label14);
            this.guna2GroupBox3.Controls.Add(this.label13);
            this.guna2GroupBox3.Controls.Add(this.label12);
            this.guna2GroupBox3.Controls.Add(this.label11);
            this.guna2GroupBox3.Controls.Add(this.cmbTensp);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2GroupBox3.Location = new System.Drawing.Point(3, 220);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.Size = new System.Drawing.Size(357, 452);
            this.guna2GroupBox3.TabIndex = 3;
            this.guna2GroupBox3.Text = "Thông tin hàng hóa";
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.Silver;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThem.Location = new System.Drawing.Point(67, 401);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 30);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoluong.DefaultText = "";
            this.txtSoluong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSoluong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSoluong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoluong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoluong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoluong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoluong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoluong.Location = new System.Drawing.Point(104, 328);
            this.txtSoluong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.PlaceholderText = "";
            this.txtSoluong.SelectedText = "";
            this.txtSoluong.Size = new System.Drawing.Size(217, 33);
            this.txtSoluong.TabIndex = 2;
            // 
            // txtDongia
            // 
            this.txtDongia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDongia.DefaultText = "";
            this.txtDongia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDongia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDongia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDongia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDongia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDongia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDongia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDongia.Location = new System.Drawing.Point(103, 270);
            this.txtDongia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDongia.Name = "txtDongia";
            this.txtDongia.PlaceholderText = "";
            this.txtDongia.SelectedText = "";
            this.txtDongia.Size = new System.Drawing.Size(218, 33);
            this.txtDongia.TabIndex = 2;
            // 
            // txtMahang
            // 
            this.txtMahang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMahang.DefaultText = "";
            this.txtMahang.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMahang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMahang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMahang.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMahang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMahang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMahang.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMahang.Location = new System.Drawing.Point(103, 205);
            this.txtMahang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMahang.Name = "txtMahang";
            this.txtMahang.PlaceholderText = "";
            this.txtMahang.SelectedText = "";
            this.txtMahang.Size = new System.Drawing.Size(218, 33);
            this.txtMahang.TabIndex = 2;
            // 
            // txtMaloai
            // 
            this.txtMaloai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaloai.DefaultText = "";
            this.txtMaloai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaloai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaloai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaloai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaloai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaloai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaloai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaloai.Location = new System.Drawing.Point(103, 132);
            this.txtMaloai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaloai.Name = "txtMaloai";
            this.txtMaloai.PlaceholderText = "";
            this.txtMaloai.SelectedText = "";
            this.txtMaloai.Size = new System.Drawing.Size(218, 33);
            this.txtMaloai.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(0, 333);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 28);
            this.label15.TabIndex = 1;
            this.label15.Text = "Số lượng";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 275);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 28);
            this.label14.TabIndex = 1;
            this.label14.Text = "Đơn giá";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 28);
            this.label13.TabIndex = 1;
            this.label13.Text = "Mã hàng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 28);
            this.label12.TabIndex = 1;
            this.label12.Text = "Mã loại";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 28);
            this.label11.TabIndex = 1;
            this.label11.Text = "Tên SP";
            // 
            // cmbTensp
            // 
            this.cmbTensp.BackColor = System.Drawing.Color.Transparent;
            this.cmbTensp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTensp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTensp.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTensp.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbTensp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTensp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTensp.ItemHeight = 30;
            this.cmbTensp.Location = new System.Drawing.Point(103, 57);
            this.cmbTensp.Name = "cmbTensp";
            this.cmbTensp.Size = new System.Drawing.Size(218, 36);
            this.cmbTensp.TabIndex = 0;
            // 
            // UCBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GroupBox3);
            this.Controls.Add(this.dgvBanHang);
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "UCBanHang";
            this.Size = new System.Drawing.Size(1123, 689);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanHang)).EndInit();
            this.guna2GroupBox3.ResumeLayout(false);
            this.guna2GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHDX;
        private Guna.UI2.WinForms.Guna2TextBox txtMaKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnTaohoadon;
        private Guna.UI2.WinForms.Guna2ComboBox cmbNhanVien;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayban;
        private System.Windows.Forms.DataGridView dgvBanHang;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTensp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2TextBox txtSoluong;
        private Guna.UI2.WinForms.Guna2TextBox txtDongia;
        private Guna.UI2.WinForms.Guna2TextBox txtMahang;
        private Guna.UI2.WinForms.Guna2TextBox txtMaloai;
    }
}
