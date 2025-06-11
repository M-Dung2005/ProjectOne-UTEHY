using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using DTO;
using QLST.Controls;

namespace QLST
{
    public partial class frmMain : Form
    {
        UserControl ucHangHoa = new UCHangHoa();
        UserControl ucHoaDon = new UCHoaDon();
        UserControl ucQLNV = new UCQLNV();
        UserControl ucQLKH = new UCQLKH();
        UserControl ucQLUser = new UCQLUser();
        UserControl ucThongKe = new UCThongKe();
        UserControl ucBanHang;
        UserControl ucThanhToan = new UCThanhToan();
        UserControl ucChiTietHoaDonNhap = new UCChitiethoadonNhap();
        UserControl ucChiTietHoaDonXuat = new UCChitiethoadonxuat();
        UserControl ucNhapHang = new UCNhapHang();
        public frmMain(string tenTK, string quyen)
        {
            InitializeComponent();

            tkLabel.Text = tenTK;
            quyenLabel.Text = quyen;
            ucBanHang = new UCBanHang();
            ((UCBanHang)ucBanHang).InvoiceCreated += FrmMain_InvoiceCreated;

        }

        public void ShowChiTietHoaDonXuat(int maHDX)
        {
            HideUCtrl();
            // Gọi phương thức LoadData để nạp dữ liệu mới
            ((UCChitiethoadonxuat)ucChiTietHoaDonXuat).LoadData(maHDX);
            ucChiTietHoaDonXuat.Show(); // ucChiTietHoaDonXuat đã được khai báo ở đầu frmMain
        }
        public void ShowChiTietHoaDonNhap(int maHDX)
        {
            HideUCtrl();
            // Gọi phương thức LoadData để nạp dữ liệu mới
            ((UCChitiethoadonNhap)ucChiTietHoaDonNhap).LoadData(maHDX);
            ucChiTietHoaDonNhap.Show(); // ucChiTietHoaDonXuat đã được khai báo ở đầu frmMain
        }

        public void ChuyenTabBanHang()
        {
            // Code này lặp lại logic của nút btnBanHang_Click
            HideUCtrl();
            ucBanHang.Show();
        }

        // Đây là phương thức sẽ được chạy khi hóa đơn được tạo thành công
        private void FrmMain_InvoiceCreated(object sender, EventArgs e)
        {
            // Ra lệnh cho ucHoaDon phải tải lại dữ liệu
            // Cần ép kiểu ucHoaDon về đúng loại của nó (UCHoaDon)
            ((UCHoaDon)ucHoaDon).RefreshData();

            // Tùy chọn: Tự động chuyển người dùng đến tab Hóa đơn để xem kết quả
            btnHoaDon.PerformClick();
        }

        public frmMain()
        {
            InitializeComponent();
        }

        public void ShowNhapHangView()
        {
            HideUCtrl();        // Ẩn tất cả các control khác
            ucNhapHang.Show();  // Chỉ hiển thị giao diện nhập hàng
        }


        public void LoadUCChiTietHoaDonNhap()
        {
            HideUCtrl();
            ucChiTietHoaDonNhap.Show();
        }
        public void LoadUCThanhToan()
        {
            HideUCtrl();
            ucThanhToan.Show();
        }

        private void HideUCtrl()
        {
            foreach (UserControl ctrl in clientArea.Controls.OfType<UserControl>())
            {
                ctrl.Hide();
                ctrl.Dock = DockStyle.Fill;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Set the size of the form
            clientArea.Controls.Add(ucHangHoa);
            clientArea.Controls.Add(ucHoaDon);
            clientArea.Controls.Add(ucQLNV);
            clientArea.Controls.Add(ucQLKH);
            clientArea.Controls.Add(ucQLUser);
            clientArea.Controls.Add(ucThongKe);
            clientArea.Controls.Add(ucBanHang);
            clientArea.Controls.Add(ucThanhToan);
            clientArea.Controls.Add(ucChiTietHoaDonNhap);
            clientArea.Controls.Add(ucChiTietHoaDonXuat);
            clientArea.Controls.Add(ucNhapHang);
            HideUCtrl();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            HideUCtrl();
            ucHangHoa.Show();
        }

        private void logoutToolStrip_Click(object sender, EventArgs e)
        {
            // Show the login form
            this.Close();
            System.Threading.Thread newThread = new System.Threading.Thread(() =>
            {
                Application.Run(new frmLogin());
            });
            newThread.SetApartmentState(System.Threading.ApartmentState.STA);
            newThread.Start();
        }

        private void exitToolStrip_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HideUCtrl();
            ucHoaDon.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            HideUCtrl();
            ucQLNV.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            HideUCtrl();
            ucQLKH.Show();
        }

        private void btnQLUser_Click(object sender, EventArgs e)
        {
            HideUCtrl();
            ucQLUser.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            HideUCtrl();
            ucThongKe.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            HideUCtrl();
            ucBanHang.Show();
        }

    }
}
