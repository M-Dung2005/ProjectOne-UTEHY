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
    public partial class UCQLUser : UserControl
    {
        BLL_QLUsers bllQLUser = new BLL_QLUsers();
        public UCQLUser()
        {
            InitializeComponent();
            // Vô hiệu hóa ô nhập mã tài khoản
            txtMaTK.Enabled = false;
            txtMaTK.PlaceholderText = "Mã tự động";
            HienThiUserLenListView(); // Gọi hàm để hiển thị danh sách nhân viên khi khởi động
        }

        // Hiển thị danh sách nhân viên lên ListView
        private void HienThiUserLenListView()
        {
            lvDanhsachnguoidung.Items.Clear(); // Xóa các mục cũ
            DataTable dt = bllQLUser.LayDanhSachUser();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaTK"].ToString());
                item.SubItems.Add(row["TenDangNhap"].ToString());
                item.SubItems.Add(row["MatKhau"].ToString());
                item.SubItems.Add(row["QuyenHan"].ToString());
                lvDanhsachnguoidung.Items.Add(item);
            }
        }
        private void lvDanhsachnguoidung_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có mục nào được chọn
            if (lvDanhsachnguoidung.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDanhsachnguoidung.SelectedItems[0]; // Lấy mục được chọn đầu tiên
                // Gán giá trị từ các cột của mục được chọn vào các TextBox tương ứng
                txtMaTK.Text = selectedItem.SubItems[0].Text; // MaTK
                txtTendangnhap.Text = selectedItem.SubItems[1].Text; 
                txtMatkhau.Text = selectedItem.SubItems[2].Text; 
                cmbQuyen.Text = selectedItem.SubItems[3].Text;
            }
        }
        // Xử lý sự kiện thêm nhân viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTendangnhap.Text) || string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Tạo đối tượng TaiKhoan mà không cần MaTK
            TaiKhoan user = new TaiKhoan
            {
                TenDangNhap = txtTendangnhap.Text,
                MatKhau = txtMatkhau.Text,
                QuyenHan = cmbQuyen.Text
            };

            string errorMessage = bllQLUser.ThemUsers(user);

            if (errorMessage == null)
            {
                MessageBox.Show("Thêm người dùng thành công!");
                HienThiUserLenListView();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Xóa nội dung trong các TextBox và ComboBox
        private void ClearInputFields()
        {
            txtMaTK.Clear();
            txtTendangnhap.Clear();
            txtMatkhau.Clear();
            cmbQuyen.SelectedIndex = 0; // Đặt lại ComboBox về trạng thái chưa chọn
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng chọn người dùng để xóa!");
                return;
            }
            string maTK = txtMaTK.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Gọi phương thức xóa người dùng từ BLL
                bool kq = bllQLUser.XoaUser(maTK);
                if (kq)
                {
                    MessageBox.Show("Xóa người dùng thành công!");
                    HienThiUserLenListView(); // Cập nhật danh sách người dùng
                   // Xóa nội dung trong các TextBox và ComboBox
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Xóa người dùng thất bại!");
                }
            }
        }

        private void BtnCapnhat_Click(object sender, EventArgs e)
        {
            string maTK = txtMaTK.Text;
            string tendangnhap = txtTendangnhap.Text;
            string matkhau = txtMatkhau.Text;
            string quyen = cmbQuyen.Text;
            // Kiểm tra xem các trường thông tin đã được nhập đầy đủ chưa
            if (string.IsNullOrWhiteSpace(txtTendangnhap.Text) || string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            // Tạo đối tượng User và gán giá trị từ các TextBox
            // Gọi phương thức thêm người dùng từ BLL
            bool kq = bllQLUser.CapNhatUser(new DTO.TaiKhoan
            {
                MaTK = int.Parse(txtMaTK.Text),
                TenDangNhap = txtTendangnhap.Text,
                MatKhau = txtMatkhau.Text,
                QuyenHan = cmbQuyen.Text
            });

            if (kq)
            {
                MessageBox.Show("Cập nhật người dùng thành công!");
                HienThiUserLenListView(); // Cập nhật danh sách người dùng
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Cập nhật người dùng thất bại!");
            }
        }
    }
}
