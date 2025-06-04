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
        BLL_HoaDonXuat bllHoaDon = new BLL_HoaDonXuat();
        public UCHoaDon()
        {
            InitializeComponent();
            // Hiển thị danh sách hóa đơn lên listView
            HienThiHoaDonLenListView();



        }
        private void HienThiHoaDonLenListView()
        {
            lvDanhSachHoaDon.Items.Clear(); // Xóa các mục cũ
            DataTable dt = bllHoaDon.LayDanhSachHoaDonXuat();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaHDX"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy"));
                item.SubItems.Add(row["TenNhanVien"].ToString());
                item.SubItems.Add(row["TenKhachHang"].ToString());
                item.SubItems.Add(string.Format("{0:#,##0} VNĐ", row["TongTien"])); // Format tiền có dấu phẩy
                lvDanhSachHoaDon.Items.Add(item);
            }
        }

        private void lvDanhSachHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có mục nào được chọn
            if (lvDanhSachHoaDon.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDanhSachHoaDon.SelectedItems[0]; // Lấy mục được chọn đầu tiên
                // Gán giá trị từ các cột của mục được chọn vào các TextBox tương ứng
                txtMaHDX.Text = selectedItem.SubItems[0].Text; // MaHDX
                dtpNgayXuat.Value = DateTime.ParseExact(selectedItem.SubItems[1].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).Date; // NgayLap
                txtNhanVien.Text = selectedItem.SubItems[2].Text; // TenNhanVien
                txtKhachHang.Text = selectedItem.SubItems[3].Text; // TenKhachHang
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
                    NgayLap = dtpNgayXuat.Value,
                    MaNV = Convert.ToInt32(txtNhanVien.Text),
                    MaKH = Convert.ToInt32(txtKhachHang.Text)
                };

                bool kq = bllHoaDon.ThemHoaDonXuat(hd);
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
        




        private void btnChitietHD_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có mục nào được chọn
            if (lvDanhSachHoaDon.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDanhSachHoaDon.SelectedItems[0]; // Lấy mục được chọn đầu tiên
                int maHDX = Convert.ToInt32(selectedItem.SubItems[0].Text); // MaHDX
                // Cập nhật thông tin hóa đơn
                HoaDonXuat hd = new HoaDonXuat
                {
                    MaHDX = maHDX,
                    NgayLap = dtpNgayXuat.Value,
                    MaNV = Convert.ToInt32(txtNhanVien.Text),
                    MaKH = Convert.ToInt32(txtKhachHang.Text)
                };
                bool kq = bllHoaDon.CapNhatHoaDonXuat(hd);
                if (kq)
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công!");
                    HienThiHoaDonLenListView();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần cập nhật!");
            }

        }
    }
}
