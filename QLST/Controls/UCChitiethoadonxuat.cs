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
    public partial class UCChitiethoadonxuat : UserControl
    {
        private BLL_Chitiethoadonxuat bllChiTiet = new BLL_Chitiethoadonxuat();
        private int maHoaDonDuocChon;

        public UCChitiethoadonxuat()
        {
            InitializeComponent();
        }

        // Phương thức public để frmMain có thể truyền dữ liệu vào
        public void LoadData(int maHDX)
        {
            maHoaDonDuocChon = maHDX;
            guna2GroupBox1.Text = $"Chi tiết cho Hóa đơn Xuất: {maHoaDonDuocChon}";

            // Gán DataSource cho DataGridView
            DataTable dt = bllChiTiet.LayChiTietHoaDonXuat(maHoaDonDuocChon);

            dgvChiTietHDX.DataSource = dt;
            dgvChiTietHDX.Columns["MaHang"].HeaderText = "Mã Hàng Hóa";
            dgvChiTietHDX.Columns["TenHang"].HeaderText = "Tên Hàng Hóa";
            dgvChiTietHDX.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvChiTietHDX.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTietHDX.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvChiTietHDX.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietHDX.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
