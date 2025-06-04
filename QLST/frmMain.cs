using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
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
        public frmMain(string tenTK, string quyen)
        {
            InitializeComponent();

            tkLabel.Text = tenTK;
            quyenLabel.Text = quyen;
            ucBanHang = new UCBanHang();
           
        }

        public frmMain()
        {
            InitializeComponent();
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
