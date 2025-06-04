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
            string maKH = txtMaKH.Text;
            string tenKH = txtTenKH.Text;
            string diaChi = txtDiachi.Text;
            string soDienThoai = txtSodienthoai.Text;
            string gioiTinh = cmbGioitinh.Text;
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrWhiteSpace(maKH) || string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(soDienThoai) || string.IsNullOrWhiteSpace(gioiTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            // Thêm khách hàng vào cơ sở dữ liệu
            if (bllQLKH.ThemKhachHang(maKH, tenKH, diaChi, soDienThoai, gioiTinh))
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                HienThiKhachHangLenListView(); // Cập nhật danh sách khách hàng
                ClearInputFields(); // Xóa nội dung trong các TextBox
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!");
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
            string maKH =int.Parse(txtMaKH.Text).ToString();
            string tenKH = txtTenKH.Text;
            string diaChi = txtDiachi.Text;
            string soDienThoai = txtSodienthoai.Text;
            string gioiTinh = cmbGioitinh.Text;

            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrWhiteSpace(maKH) || string.IsNullOrWhiteSpace(tenKH) || string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(soDienThoai) || string.IsNullOrWhiteSpace(gioiTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin khách hàng này không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cập nhật thông tin khách hàng trong cơ sở dữ liệu
                if (bllQLKH.CapNhatKhachHang(maKH, tenKH, diaChi, soDienThoai, gioiTinh))
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    HienThiKhachHangLenListView(); // Cập nhật danh sách khách hàng
                    ClearInputFields(); // Xóa nội dung trong các TextBox
                }
                else
                {
                    MessageBox.Show("Cập nhật khách hàng thất bại!");
                }
            }

        }
    }
}
