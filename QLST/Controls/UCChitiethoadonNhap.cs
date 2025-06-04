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
    public partial class UCChitiethoadonNhap : UserControl
    {
        BLL_Chitiethoadonnhap bllChitiethoadonnhap = new BLL_Chitiethoadonnhap();

        public UCChitiethoadonNhap()
        {
            InitializeComponent();
            //Hiển thị chi tiết hóa đơn nhập lên dataGridView
            HienThiChiTietHoaDonNhap();

        }
        private void HienThiChiTietHoaDonNhap()
        {
            DataTable dt = bllChitiethoadonnhap.LayDanhSachChiTietHoaDonNhap();
            dgvChitiethoadonnhap.DataSource = dt;
            dgvChitiethoadonnhap.Columns["MaHDN"].HeaderText = "Mã Hóa Đơn Nhập";
            dgvChitiethoadonnhap.Columns["TenHang"].HeaderText = "Tên Hàng";
            dgvChitiethoadonnhap.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvChitiethoadonnhap.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvChitiethoadonnhap.Columns["ThanhTien"].HeaderText = "Thành Tiền";
        }

        private DataTable LayDanhSachChiTietHoaDonNhap()
        {
            return bllChitiethoadonnhap.LayDanhSachChiTietHoaDonNhap();
        }

       
    }
}
