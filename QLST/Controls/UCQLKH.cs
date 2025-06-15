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
    public partial class UCQLKH : UserControl
    {
        BLL_QLKH bllQLKH = new BLL_QLKH();
        public UCQLKH()
        {
            InitializeComponent();
            txtMaKH.Enabled = false;
            txtMaKH.PlaceholderText = "Mã tự động";
            HienThiKhachHangLenListView(); // Gọi hàm để hiển thị danh sách khách hàng khi khởi động
        }

        // Hiển thị danh sách khách hàng lên ListView
        private void HienThiKhachHangLenListView()
        {
            lvdanhsachkhachhang.Items.Clear(); // Xóa các mục cũ
            DataTable dt = bllQLKH.LayDanhSachKhachHang();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaKH"].ToString());
                item.SubItems.Add(row["TenKH"].ToString());
                item.SubItems.Add(row["DiaChi"].ToString());
                item.SubItems.Add(row["SoDienThoai"].ToString());
                item.SubItems.Add(row["GioiTinh"].ToString()); 
                lvdanhsachkhachhang.Items.Add(item);
            }
        }

        private void lvdanhsachkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có mục nào được chọn
            if (lvdanhsachkhachhang.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvdanhsachkhachhang.SelectedItems[0]; // Lấy mục được chọn đầu tiên
                // Gán giá trị từ các cột của mục được chọn vào các TextBox tương ứng
                txtMaKH.Text = selectedItem.SubItems[0].Text; // MaKH
                txtTenKH.Text = selectedItem.SubItems[1].Text; // TenKH
                txtDiachi.Text = selectedItem.SubItems[2].Text; // DiaChi
                txtSodienthoai.Text = selectedItem.SubItems[3].Text; // SoDienThoai
                cmbGioitinh.Text = selectedItem.SubItems[4].Text; // GioiTinh
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // --- BẮT ĐẦU PHẦN KIỂM TRA RÀNG BUỘC ---

            string tenKH = txtTenKH.Text;
            string diaChi = txtDiachi.Text;
            string soDienThoai = txtSodienthoai.Text;
            string gioiTinh = cmbGioitinh.Text;

            // 1. Ràng buộc "Không được để trống"
            if (string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(diaChi) ||
                string.IsNullOrWhiteSpace(soDienThoai) || string.IsNullOrWhiteSpace(gioiTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ràng buộc "Định dạng Số điện thoại" (theo CSDL của bạn)
            if (soDienThoai.Length != 10 || !soDienThoai.StartsWith("0") || !soDienThoai.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Phải là 10 chữ số và bắt đầu bằng 0.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Ràng buộc "Số điện thoại duy nhất"
            if (bllQLKH.KiemTraSoDienThoaiTonTai(soDienThoai))
            {
                MessageBox.Show($"Số điện thoại '{soDienThoai}' đã được đăng ký cho một khách hàng khác.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- KẾT THÚC PHẦN KIỂM TRA RÀNG BUỘC ---

            // Nếu tất cả đều hợp lệ, tiến hành thêm mới
            string errorMessage = bllQLKH.ThemKhachHang(tenKH, diaChi, soDienThoai, gioiTinh);

            if (errorMessage == null)
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiKhachHangLenListView();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi từ CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm để xóa nội dung trong các TextBox
        private void ClearInputFields()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiachi.Clear();
            txtSodienthoai.Clear();
            cmbGioitinh.SelectedIndex = -1; // Đặt lại ComboBox về trạng thái chưa chọn
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu mã khách hàng không được chọn
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!");
                return;
            }

            string maKH = txtMaKH.Text;

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, thực hiện xóa
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức xóa khách hàng từ BLL
                if (bllQLKH.XoaKhachHang(maKH))
                {
                    MessageBox.Show("Xóa khách hàng thành công!");
                    HienThiKhachHangLenListView(); // Cập nhật danh sách khách hàng

                    // Xóa nội dung trong các TextBox
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // --- BẮT ĐẦU PHẦN KIỂM TRA RÀNG BUỘC ---

            // 1. Ràng buộc "Phải chọn khách hàng"
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để sửa!", "Chưa chọn khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ các control
            int maKH = int.Parse(txtMaKH.Text);
            string tenKH = txtTenKH.Text;
            string diaChi = txtDiachi.Text;
            string soDienThoai = txtSodienthoai.Text;
            string gioiTinh = cmbGioitinh.Text;

            // 2. Ràng buộc "Không được để trống"
            if (string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(diaChi) ||
                string.IsNullOrWhiteSpace(soDienThoai) || string.IsNullOrWhiteSpace(gioiTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Ràng buộc "Định dạng Số điện thoại"
            if (soDienThoai.Length != 10 || !soDienThoai.StartsWith("0") || !soDienThoai.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Phải là 10 chữ số và bắt đầu bằng 0.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Ràng buộc "Số điện thoại duy nhất" (khi cập nhật)
            // Truyền MaKH vào để BLL không kiểm tra trùng với chính khách hàng này
            if (bllQLKH.KiemTraSoDienThoaiTonTai(soDienThoai, maKH))
            {
                MessageBox.Show($"Số điện thoại '{soDienThoai}' đã được đăng ký cho một khách hàng khác.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- KẾT THÚC PHẦN KIỂM TRA RÀNG BUỘC ---

            // Nếu hợp lệ, tiến hành cập nhật
            string errorMessage = bllQLKH.CapNhatKhachHang(maKH, tenKH, diaChi, soDienThoai, gioiTinh);

            if (errorMessage == null)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiKhachHangLenListView();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi từ CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
