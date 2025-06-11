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
    public partial class UCHoaDon : UserControl
    {
        // Khai báo các BLL cần thiết
        BLL_HoaDonXuat bllHoaDonXuat = new BLL_HoaDonXuat();
        BLL_HoaDonNhap bllHoaDonNhap = new BLL_HoaDonNhap();
        BLL_QLNV bllNhanVien = new BLL_QLNV();
        BLL_NhaCungCap bllNhaCungCap = new BLL_NhaCungCap();

        // Dùng để lấy mã nhân viên và khách hàng khi chọn từ ListView
        private int selectedMaNV_Xuat = -1;
        private int selectedMaKH_Xuat = -1;

        public UCHoaDon()
        {
            InitializeComponent();
            // Hiển thị danh sách hóa đơn lên listView
            HienThiHoaDonLenListView();

        }

        public void RefreshData()
        {
            MessageBox.Show("Đang cập nhật danh sách hóa đơn...");
            HienThiHoaDonXuatLenListView();
            HienThiHoaDonNhapLenGridView();
            MessageBox.Show("Danh sách hóa đơn đã được cập nhật!");
        }

        private void UCHoaDon_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu khi form được load
            LoadTabXuatData();
            LoadTabNhapData();
        }

        private void LoadTabXuatData()
        {
            HienThiHoaDonXuatLenListView();
            // Bạn có thể load ComboBox cho việc tìm kiếm/lọc ở đây nếu cần
        }

        private void HienThiHoaDonXuatLenListView()
        {
            lvDanhSachHoaDon.Items.Clear();
            DataTable dt = bllHoaDonXuat.LayDanhSachHoaDonXuat();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaHDX"].ToString()); // Cột 0: STT
                // SẮP XẾP LẠI THỨ TỰ CHO KHỚP VỚI DESIGNER                                    // Cột 1: Số HDX
                item.SubItems.Add(row["TenNhanVien"].ToString());                                // Cột 2: Tên Nhân Viên
                item.SubItems.Add(row["TenKhachHang"].ToString());                               // Cột 3: Tên Khách Hàng
                item.SubItems.Add(Convert.ToDateTime(row["NgayTao"]).ToString("dd/MM/yyyy"));  // Cột 4: Ngày Xuất
                item.SubItems.Add(string.Format("{0:N0} VNĐ", row["TongTien"]));                 // Cột 5: Thành Tiền

                item.Tag = new { MaNV = row["MaNV"], MaKH = row["MaKH"] };
                lvDanhSachHoaDon.Items.Add(item);
            }
        }

        private void lvDanhSachHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachHoaDon.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDanhSachHoaDon.SelectedItems[0];

                // Đọc dữ liệu theo đúng chỉ số cột mới
                txtMaHDX.Text = selectedItem.SubItems[0].Text;     // Cột 1 là Mã HĐX
                txtNhanVien.Text = selectedItem.SubItems[1].Text;   // Cột 2 là Tên Nhân Viên
                txtKhachHang.Text = selectedItem.SubItems[2].Text;  // Cột 3 là Tên Khách Hàng
                dtpNgayXuat.Value = DateTime.ParseExact(selectedItem.SubItems[3].Text, "dd/MM/yyyy", null);
            }
        }

        // Nút "Thêm HĐ" sẽ mở form bán hàng để tạo hóa đơn mới
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng chuyển qua tab 'Bán Hàng' để tạo hóa đơn mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Hoặc nếu bạn có form cha, bạn có thể gọi phương thức để chuyển tab
            //(this.ParentForm as frmMain)?.ChuyenTabBanHang();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHDX.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu ý: Việc sửa hóa đơn đã xuất cần được cân nhắc kỹ về mặt nghiệp vụ.
            // Ở đây chỉ ví dụ sửa ngày lập. Sửa nhân viên, khách hàng cũng tương tự.
            HoaDonXuat hd = new HoaDonXuat
            {
                MaHDX = int.Parse(txtMaHDX.Text),
                NgayTao = dtpNgayXuat.Value,
                MaNV = selectedMaNV_Xuat, // Lấy ID đã lưu
                MaKH = selectedMaKH_Xuat  // Lấy ID đã lưu
            };

            // Gọi BLL để cập nhật (chỉ ngày, hoặc các thông tin khác nếu logic cho phép)
            if (bllHoaDonXuat.CapNhatHoaDonXuat(hd))
            {
                MessageBox.Show("Cập nhật hóa đơn thành công!");
                HienThiHoaDonXuatLenListView();
                ClearInputFieldsXuat();
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn thất bại!");
            }
        }

        private void btnChitietHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDX.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.");
                return;
            }

            int maHDX = int.Parse(txtMaHDX.Text);
            (this.ParentForm as frmMain)?.ShowChiTietHoaDonXuat(maHDX);
        }


        private void ClearInputFieldsXuat()
        {
            txtMaHDX.Clear();
            dtpNgayXuat.Value = DateTime.Now;
            txtNhanVien.Clear();
            txtKhachHang.Clear();
            selectedMaNV_Xuat = -1;
            selectedMaKH_Xuat = -1;
        }

        private void LoadTabNhapData()
        {
            // Tải dữ liệu cho ComboBoxes
            LoadNhanVienComboBox();
            LoadNhaCungCapComboBox();
            // Tải danh sách hóa đơn nhập
            HienThiHoaDonNhapLenGridView();
        }

        private void LoadNhanVienComboBox()
        {
            cmbNhanvien.DataSource = bllNhanVien.LayNhanVienForComboBox();
            cmbNhanvien.DisplayMember = "TenNV";
            cmbNhanvien.ValueMember = "MaNV";
        }


        private void LoadNhaCungCapComboBox()
        {
            cmbNhacc.DataSource = bllNhaCungCap.LayNhaCungCapForComboBox();
            cmbNhacc.DisplayMember = "TenNCC";
            cmbNhacc.ValueMember = "MaNCC";
        }


        private void HienThiHoaDonNhapLenGridView()
        {
            dgvDanhsachhoadonnhap.DataSource = bllHoaDonNhap.LayDanhSachHoaDonNhap();
            // Định dạng cột nếu cần
            dgvDanhsachhoadonnhap.Columns["TongTien"].DefaultCellStyle.Format = "N0";
        }


        private void btnTaohoadon_Click(object sender, EventArgs e)
        {
            // Mở form/UC nhập hàng mới
            // (this.ParentForm as frmMain)?.LoadUCChiTietHoaDonNhap();
            MessageBox.Show("Chức năng tạo hóa đơn nhập mới đang được phát triển.");
        }


        private void dgvDanhsachhoadonnhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhsachhoadonnhap.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MaHDN"].Value.ToString();
                dtpNgaynhap.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
                cmbNhanvien.Text = row.Cells["TenNV"].Value.ToString();
                cmbNhacc.Text = row.Cells["TenNCC"].Value.ToString();
            }
        }


        private void HienThiHoaDonLenListView()
        {
            lvDanhSachHoaDon.Items.Clear(); // Xóa các mục cũ
            DataTable dt = bllHoaDonXuat.LayDanhSachHoaDonXuat();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaHDX"].ToString());
                item.SubItems.Add(row["TenNhanVien"].ToString());
                item.SubItems.Add(row["TenKhachHang"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["NgayTao"]).ToString("dd/MM/yyyy"));
                item.SubItems.Add(string.Format("{0:#,##0} VNĐ", row["TongTien"])); // Format tiền có dấu phẩy
                lvDanhSachHoaDon.Items.Add(item);
            }
        }

       

        private void ClearInputFields()
        {
            txtMaHDX.Clear();
            dtpNgayXuat.Value = DateTime.Now; // Đặt ngày xuất về ngày hiện tại
            txtNhanVien.Clear();
            txtKhachHang.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtNhanVien.Text) || string.IsNullOrWhiteSpace(txtKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                HoaDonXuat hd = new HoaDonXuat
                {
                    MaHDX = Convert.ToInt32(txtMaHDX.Text), // Chỉ giữ nếu bạn nhập tay, không dùng IDENTITY
                    NgayTao = dtpNgayXuat.Value,
                    MaNV = Convert.ToInt32(txtNhanVien.Text),
                    MaKH = Convert.ToInt32(txtKhachHang.Text)
                };

                bool kq = bllHoaDonXuat.ThemHoaDonXuat(hd);
                if (kq)
                {
                    MessageBox.Show("Thêm hóa đơn thành công!");
                    HienThiHoaDonLenListView();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnChitiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.");
                return;
            }

            int maHD = int.Parse(txtMaHD.Text);
            (this.ParentForm as frmMain)?.ShowChiTietHoaDonNhap(maHD);
        }
    }
}
