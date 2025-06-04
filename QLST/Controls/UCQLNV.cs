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

namespace QLST.Controls
{
    public partial class UCQLNV : UserControl
    {
        BLL_QLNV bllQLNV = new BLL_QLNV();
        public UCQLNV()
        {
            InitializeComponent();
            HienThiNhanVienLenListView(); // Gọi hàm để hiển thị danh sách nhân viên khi khởi động
        }

        // Hiển thị danh sách nhân viên lên ListView
        private void HienThiNhanVienLenListView()
        {
            lvDSNV.Items.Clear(); // Xóa các mục cũ

            DataTable dt = bllQLNV.LayDanhSachNhanVien();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaNV"].ToString());
                item.SubItems.Add(row["MaTK"].ToString());
                item.SubItems.Add(row["TenNV"].ToString());
                item.SubItems.Add(row["DiaChi"].ToString());
                item.SubItems.Add(row["SoDienThoai"].ToString());
                item.SubItems.Add(DateTime.Parse(row["NgaySinh"].ToString()).ToString("dd/MM/yyyy"));
                item.SubItems.Add(row["GioiTinh"].ToString());
                lvDSNV.Items.Add(item);
            }
        }

        private void lvDSNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có mục nào được chọn
            if (lvDSNV.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDSNV.SelectedItems[0]; // Lấy mục được chọn đầu tiên
                // Gán giá trị từ các cột của mục được chọn vào các TextBox tương ứng
                txtMaNV.Text = selectedItem.SubItems[0].Text; // MaNV
                txtMaTK.Text = selectedItem.SubItems[1].Text; // MaTK
                txtTenNV.Text = selectedItem.SubItems[2].Text; // TenNV
                txtDiachi.Text = selectedItem.SubItems[3].Text; // DiaChi
                txtSĐT.Text = selectedItem.SubItems[4].Text; // SoDienThoai
                dtpNgaysinh.Value = DateTime.ParseExact(selectedItem.SubItems[5].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).Date; // NgaySinh
                cmbGioiTinh.Text = selectedItem.SubItems[6].Text; // GioiTinh
            }
        }

        private void ClearInputFields()
        {
            txtMaNV.Clear();
            txtMaTK.Clear();
            txtTenNV.Clear();
            txtDiachi.Clear();
            txtSĐT.Clear();
            dtpNgaysinh.Value = DateTime.Now; // Đặt ngày sinh về ngày hiện tại
            cmbGioiTinh.SelectedIndex = -1; // Bỏ chọn giới tính
        }

        // Xử lý sự kiện thêm nhân viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            string SoDienThoai = txtSĐT.Text;
            string DiaChi = txtDiachi.Text;
            string NgaySinh = dtpNgaysinh.Value.ToString("yyyy-MM-dd");
            string GioiTinh = cmbGioiTinh.Text;
            int.TryParse(txtMaTK.Text, out int maTK); 

            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(tenNV) || string.IsNullOrWhiteSpace(SoDienThoai) || string.IsNullOrWhiteSpace(DiaChi) || string.IsNullOrWhiteSpace(GioiTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và đúng định dạng!");
                return;
            }

            bool kq = bllQLNV.ThemNhanVien(maNV, tenNV, SoDienThoai, DiaChi, GioiTinh, NgaySinh,maTK);

            if (kq)
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                HienThiNhanVienLenListView(); // Làm mới danh sách
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!");
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            string SoDienThoai = txtSĐT.Text;
            string DiaChi = txtDiachi.Text;
            string NgaySinh = dtpNgaysinh.Value.ToString("yyyy-MM-dd");
            string GioiTinh = cmbGioiTinh.Text;
            int.TryParse(txtMaTK.Text, out int maTK); // Lấy mã tài khoản kiểu int

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(tenNV) ||
                string.IsNullOrWhiteSpace(SoDienThoai) || string.IsNullOrWhiteSpace(DiaChi) ||
                string.IsNullOrWhiteSpace(GioiTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin và đúng định dạng!");
                return;
            }

            // Gọi phương thức cập nhật từ BLL
            bool kq = bllQLNV.CapNhatNhanVien(maNV, tenNV, SoDienThoai, DiaChi, GioiTinh, NgaySinh, maTK);

            if (kq)
            {
                MessageBox.Show("Cập nhật nhân viên thành công!");
                HienThiNhanVienLenListView(); // Làm mới danh sách
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy mã nhân viên từ TextBox
            string maNV = txtMaNV.Text;

            // Kiểm tra nếu mã nhân viên không rỗng
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!");
                return;
            }

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, thực hiện xóa
            if (result == DialogResult.Yes)
            {
                // Lấy mã tài khoản liên kết với nhân viên (giả sử bạn lưu mã TK theo quy tắc TK + maNV)
                string maTK = "TK" + maNV;

                // Gọi phương thức xóa nhân viên từ BLL
                bool kqNV = bllQLNV.XoaNhanVien(maNV);

                // Gọi phương thức xóa tài khoản từ BLL hoặc DAL (bạn cần tự định nghĩa, ví dụ: XoaTaiKhoan)
             

                if (kqNV /* && kqTK */)
                {
                    MessageBox.Show("Xóa nhân viên và tài khoản thành công!");
                    HienThiNhanVienLenListView(); // Làm mới danh sách
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên hoặc tài khoản thất bại!");
                }
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để tìm kiếm!");
                return;
            }

            // Gọi phương thức tìm kiếm từ BLL
            DataTable dt = bllQLNV.TimKiemNhanVien(maNV);

            if (dt.Rows.Count > 0)
            {
                // Hiển thị kết quả lên ListView
                lvDSNV.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaNV"].ToString());
                    item.SubItems.Add(row["MaTK"].ToString());
                    item.SubItems.Add(row["TenNV"].ToString());
                    item.SubItems.Add(row["DiaChi"].ToString());
                    item.SubItems.Add(row["SoDienThoai"].ToString());
                    item.SubItems.Add(DateTime.Parse(row["NgaySinh"].ToString()).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(row["GioiTinh"].ToString());
                    lvDSNV.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên với mã này!");
            }
        }
    }
}
