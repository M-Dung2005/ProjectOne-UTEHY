using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QLST.Controls
{
    public partial class UCNhapHang : UserControl
    {
        // Khai báo các BLL cần thiết
        private BLL_HoaDonNhap bllHoaDonNhap = new BLL_HoaDonNhap();
        private BLL_Chitiethoadonnhap bllChiTietNhap = new BLL_Chitiethoadonnhap();
        private BLL_QLNV bllQLNV = new BLL_QLNV();
        private BLL_HangHoa bllHangHoa = new BLL_HangHoa();

        // Sự kiện để thông báo cho frmMain biết đã nhập hàng xong
        public event EventHandler ImportInvoiceCreated;

        public UCNhapHang()
        {
            InitializeComponent();
        }

        private void UCNhapHang_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu cho các ComboBox
          
            LoadEmployeeComboBox();
            LoadProductComboBox();

            // Vô hiệu hóa ô mã hóa đơn nhập
            txtMaHDN.Enabled = false;
            txtMaHDN.PlaceholderText = "Mã tự động";
        }

        #region Load ComboBox Data

        private void LoadEmployeeComboBox()
        {
            cmbNhanVien.DataSource = bllQLNV.LayNhanVienForComboBox();
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";
            cmbNhanVien.SelectedIndex = -1;
        }

        private void LoadProductComboBox()
        {
            cmbTensp.DataSource = bllHangHoa.LayDanhSachHangHoa();
            cmbTensp.DisplayMember = "TenHang";
            cmbTensp.ValueMember = "MaHang";
            cmbTensp.SelectedIndex = -1;
            cmbTensp.Text = "Chọn sản phẩm";
        }
        #endregion

        private void cmbTensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTensp.SelectedItem is DataRowView drv)
            {
                txtMahang.Text = drv["MaHang"].ToString();

                // SỬA ĐỔI: Thêm dòng này để tự động điền Mã Loại
                txtMaloai.Text = drv["MaLoai"].ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbTensp.SelectedValue == null || !int.TryParse(txtSoluong.Text, out int soLuong))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và nhập Số lượng, Đơn giá nhập hợp lệ!");
                return;
            }

            // Thêm vào DataGridView để chờ lưu
            dgvNhaphang.Rows.Add(
                txtMaloai.Text, // Mã hóa đơn nhập
                txtMahang.Text, // Mã hàng
                cmbTensp.Text,
                soLuong
            );
            ClearProductInputs();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            // SỬA ĐỔI: Kiểm tra TextBox txtMaNCC thay vì ComboBox
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) || cmbNhanVien.SelectedValue == null || dgvNhaphang.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã Nhà cung cấp, chọn Nhân viên và thêm ít nhất một sản phẩm!");
                return;
            }

            // SỬA ĐỔI: Thêm kiểm tra để đảm bảo MaNCC là một con số
            if (!int.TryParse(txtMaNCC.Text, out int maNCC))
            {
                MessageBox.Show("Mã Nhà cung cấp phải là một con số hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvNhaphang.Rows)
            {
                DataTable dt = bllHangHoa.LayDanhSachHangHoa();

                // 2. Tìm DataRow có MaHang khớp
                DataRow rw = dt
                    .AsEnumerable()
                    .FirstOrDefault(r => r.Field<int>("MaHang") == Convert.ToInt32(row.Cells["Mahang"].Value));

                decimal donGiaNhap = rw == null ? 0m : Convert.ToDecimal(rw["DonGia"]);
                decimal soLuong = Convert.ToDecimal(row.Cells["Soluong"].Value);
                tongTien += soLuong * donGiaNhap;
            }

            HoaDonNhap hdn = new HoaDonNhap
            {
                MaNCC = maNCC, // SỬA ĐỔI: Lấy giá trị từ biến đã được kiểm tra
                MaNV = (int)cmbNhanVien.SelectedValue,
                NgayTao = dtpNgaynhap.Value,
                TongTien = tongTien
            };

            try
            {
                // 1. Lưu hóa đơn chính và nhận về mã mới
                int newMaHDN = bllHoaDonNhap.ThemHoaDonNhap(hdn);

                // 2. Lưu các chi tiết hóa đơn với mã mới nhận được
                foreach (DataGridViewRow row in dgvNhaphang.Rows)
                {
                    DataTable dt = bllHangHoa.LayDanhSachHangHoa();

                    // 2. Tìm DataRow có MaHang khớp
                    DataRow rw = dt
                        .AsEnumerable()
                        .FirstOrDefault(r => r.Field<int>("MaHang") == Convert.ToInt32(row.Cells["Mahang"].Value));

                    decimal donGiaNhap = rw == null ? 0m : Convert.ToDecimal(rw["DonGia"]);

                    ChiTietHoaDonNhap ctn = new ChiTietHoaDonNhap
                    {
                        MaHDN = newMaHDN,
                        MaHang = int.Parse(row.Cells["Mahang"].Value.ToString()),
                        SoLuong = int.Parse(row.Cells["Soluong"].Value.ToString()),
                        DonGia = donGiaNhap,
                        ThanhTien = donGiaNhap * int.Parse(row.Cells["Soluong"].Value.ToString())
                    };

                    bllChiTietNhap.ThemChiTietHoaDonNhap(ctn);
                }

                // 3. Thông báo thành công và dọn dẹp form
                MessageBox.Show($"Tạo phiếu nhập hàng thành công! Mã phiếu: {newMaHDN}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ImportInvoiceCreated?.Invoke(this, EventArgs.Empty);
                ClearAll();
            }
            catch (Exception ex)
            {
                // Nếu có bất kỳ lỗi nào từ BLL, hiển thị thông báo lỗi chi tiết
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearProductInputs()
        {
            cmbTensp.SelectedIndex = -1;
            txtMahang.Clear();
            txtSoluong.Clear();
            cmbTensp.Focus();
        }

        private void ClearAll()
        {
            ClearProductInputs();
            dgvNhaphang.Rows.Clear();
            txtMaNCC.Clear();
            cmbNhanVien.SelectedIndex = -1;
            txtMaHDN.Clear();
        }
    }
}
