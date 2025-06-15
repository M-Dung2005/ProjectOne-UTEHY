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
        private Bitmap memoryImage;

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

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int startX = 10;
            int startY = 20;
            int offsetY = 0;
            Font font = new Font("Arial", 10);
            Font fontBold = new Font("Arial", 10, FontStyle.Bold);
            Font fontTitle = new Font("Arial", 14, FontStyle.Bold);

            string ngay = $"{DateTime.Now.Date:dd/MM/yyyy}";
            string[] arr = guna2GroupBox1.Text.Split(' ');
            string maHD = arr[arr.Length - 1]; // Lấy phần tử cuối cùng

            // Đếm số dòng thực tế (bỏ dòng trắng cuối)
            int rowCount = dgvChiTietHDX.Rows.Count; // DataGridView tự động có 1 dòng trống cuối

            // Khởi tạo mảng 2 chiều
            string[,] data = new string[rowCount, 4];
            decimal tongThanhToan = 0;

            // Lấy dữ liệu từ DGV
            for (int i = 0; i < rowCount; i++)
            {
                if (dgvChiTietHDX.Rows[i].IsNewRow) continue; // Bỏ qua dòng mới

                for (int j = 0; j < 4; j++)
                {
                    data[i, j] = dgvChiTietHDX.Rows[i].Cells[j + 1].Value?.ToString() ?? "";
                }

                string value = dgvChiTietHDX.Rows[i].Cells[4].Value?.ToString() ?? "0";

                // Bỏ dấu phẩy
                value = value.Replace(",", "");

                // Chuyển sang decimal
                decimal.TryParse(value, out decimal thanhTien);
                tongThanhToan += thanhTien; // Cộng vào tổng thanh toán
            }

            // Vẽ nội dung
            g.DrawString($"Ngày: {ngay}", font, Brushes.Black, startX, startY + offsetY);
            offsetY += 20;
            g.DrawString($"Số hóa đơn: {maHD}", font, Brushes.Black, startX, startY + offsetY);
            offsetY += 25;
            g.DrawString("HÓA ĐƠN BÁN HÀNG", fontTitle, Brushes.Black, startX + 60, startY + offsetY);
            offsetY += 35;

            // Vẽ bảng hàng hóa
            int tableStartY = startY + offsetY;
            int[] colWidths = { 200, 100, 100, 100 };
            string[] headers = { "Tên hàng", "SL", "Đơn giá", "Thành tiền" };

            int tableX = startX;
            int tableY = tableStartY;
            int rowHeight = 25;

            // Header
            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawRectangle(Pens.Black, tableX, tableY, colWidths[i], rowHeight);
                g.DrawString(headers[i], fontBold, Brushes.Black, tableX + 2, tableY + 5);
                tableX += colWidths[i];
            }
            offsetY += rowHeight;
            // Data
            for (int r = 0; r < data.GetLength(0); r++)
            {
                tableX = startX;
                tableY = startY + offsetY;
                for (int c = 0; c < data.GetLength(1); c++)
                {
                    g.DrawRectangle(Pens.Black, tableX, tableY, colWidths[c], rowHeight);
                    g.DrawString(data[r, c], font, Brushes.Black, tableX + 2, tableY + 5);
                    tableX += colWidths[c];
                }
                offsetY += rowHeight;
            }

            offsetY += 20;

            // Tổng kết
            offsetY += 20;
            g.DrawString("Tổng tiền thanh toán: ", font, Brushes.Black, startX, startY + offsetY);
            g.DrawString(tongThanhToan.ToString(), fontBold, Brushes.Black, startX + 130, startY + offsetY);
        }

        private void printBillBtn_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog
            {
                Document = printDocument1
            };

            printPreviewDialog1.ShowDialog();
        }
    }
}
