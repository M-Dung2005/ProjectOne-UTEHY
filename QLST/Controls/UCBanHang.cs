using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QLST.Controls
{
    public partial class UCBanHang : UserControl
    {
        BLL_BanHang bllBanHang = new BLL_BanHang();
        BLL_Chitiethoadonxuat BLL_Chitiethoadonxuat = new BLL_Chitiethoadonxuat();
        BLL_HangHoa bllHangHoa = new BLL_HangHoa();
        BLL_QLNV bllNhanVien = new BLL_QLNV();
        public event EventHandler InvoiceCreated;
        private frmMain parentForm;
        public UCBanHang()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.UCBanHang_Load);

        }

        private void UCBanHang_Load(object sender, EventArgs e)
        {
            LoadProductComboBox();
            LoadEmployeeComboBox();
            txtMaHDX.Enabled = false;
            txtMaHDX.PlaceholderText = "Mã sẽ được tạo tự động";
        }

        private void LoadEmployeeComboBox()
        {
            try
            {
                cmbNhanVien.DataSource = bllNhanVien.LayNhanVienForComboBox();
                cmbNhanVien.DisplayMember = "TenNV"; // Cột hiển thị tên nhân viên
                cmbNhanVien.ValueMember = "MaNV";   // Cột chứa giá trị (ID)
                cmbNhanVien.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void LoadProductComboBox()
        {
            DataTable dtHangHoa = bllHangHoa.LayDanhSachHangHoa();
            cmbTensp.DataSource = dtHangHoa;
            cmbTensp.DisplayMember = "TenHang"; // Cột hiển thị tên
            cmbTensp.ValueMember = "MaHang";   // Cột chứa giá trị (ID)
            cmbTensp.SelectedIndex = -1; // Bỏ chọn mục mặc định
            cmbTensp.Text = "Chọn sản phẩm"; // Gợi ý cho người dùng
        }


        private void cmbTensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Đảm bảo rằng một mục hợp lệ đã được chọn
            if (cmbTensp.SelectedItem is DataRowView drv)
            {
                txtMahang.Text = drv["MaHang"].ToString();
                txtMaloai.Text = drv["MaLoai"].ToString();

                // Lấy và định dạng đơn giá
                decimal donGia = Convert.ToDecimal(drv["DonGia"]);
                txtDongia.Text = donGia.ToString(); // Hoặc định dạng theo ý muốn
            }
        }

        private void ClearInputFields()
        {
            txtMaHDX.Clear();
            dtpNgayban.Value = DateTime.Now; // Đặt ngày xuất về ngày hiện tại
            txtMaKH.Clear();
            txtMaloai.Clear();
            txtMahang.Clear();
            txtSoluong.Clear();
            txtDongia.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int soLuongTon = bllHangHoa.SoLuongHangTonKho(int.Parse(txtMahang.Text));
            if (string.IsNullOrWhiteSpace(txtMahang.Text) || string.IsNullOrWhiteSpace(txtSoluong.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng!");
                return;
            }
            else if (soLuongTon < int.Parse(txtSoluong.Text))
            {
                MessageBox.Show($"Số lượng sản phẩm trong kho không đủ! Hiện còn {soLuongTon} sản phẩm");
                return;
            }

            dgvBanHang.Rows.Add(
                txtMaloai.Text,
                txtMahang.Text,
                cmbTensp.Text,
                txtDongia.Text,
                txtSoluong.Text
            );

            // Xóa các ô để chuẩn bị cho lần nhập tiếp theo
            txtMaloai.Clear();
            txtMahang.Clear();
            txtDongia.Clear();
            txtSoluong.Clear();
            cmbTensp.SelectedIndex = -1;
            cmbTensp.Text = "Chọn sản phẩm";
        }


        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) || cmbNhanVien.SelectedValue == null || dgvBanHang.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã KH, chọn Nhân viên và thêm sản phẩm!");
                return;
            }

            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvBanHang.Rows)
            {
                if (row.IsNewRow) continue;
                tongTien += decimal.Parse(row.Cells["DonGia"].Value.ToString()) * int.Parse(row.Cells["SoLuong"].Value.ToString());
            }

            HoaDonXuat hd = new HoaDonXuat
            {
                NgayTao = dtpNgayban.Value,
                MaNV = Convert.ToInt32(cmbNhanVien.SelectedValue),
                MaKH = int.Parse(txtMaKH.Text),
                TongTien = tongTien
            };

            int newMaHDX = bllBanHang.ThemHoaDonXuat(hd);

            if (newMaHDX <= 0)
            {
                MessageBox.Show("Không thể tạo hóa đơn! Đã có lỗi xảy ra.");
                return;
            }

            txtMaHDX.Text = newMaHDX.ToString();

            // VÒNG LẶP QUAN TRỌNG: Lưu từng chi tiết hóa đơn
            foreach (DataGridViewRow row in dgvBanHang.Rows)
            {
                if (row.IsNewRow) continue;

                ChiTietHoaDonXuat ct = new ChiTietHoaDonXuat
                {
                    MaHDX = newMaHDX,
                    MaHang = int.Parse(row.Cells["MaHang"].Value.ToString()),
                    SoLuong = int.Parse(row.Cells["SoLuong"].Value.ToString()),
                    DonGia = decimal.Parse(row.Cells["DonGia"].Value.ToString()),
                    ThanhTien = int.Parse(row.Cells["SoLuong"].Value.ToString()) * decimal.Parse(row.Cells["DonGia"].Value.ToString())
                };

                // GỌI BLL ĐỂ LƯU CHI TIẾT
                BLL_Chitiethoadonxuat.ThemChiTietHoaDonXuat(ct);
            }

            MessageBox.Show($"Tạo hóa đơn thành công! Mã hóa đơn mới của bạn là: {newMaHDX}");
            InvoiceCreated?.Invoke(this, EventArgs.Empty);
            dgvBanHang.Rows.Clear();
            ClearInputFields();
        }



    }
    }
