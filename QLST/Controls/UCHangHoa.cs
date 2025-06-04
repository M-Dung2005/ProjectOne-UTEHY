using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Guna.UI2.WinForms;
using BLL;

namespace QLST.Controls
{
    public partial class UCHangHoa : UserControl
    {
        BLL_HangHoa bllHangHoa = new BLL_HangHoa();
        public UCHangHoa()
        {
            InitializeComponent();
        }

        private void ClearInputFields()
        {
            txtMahanghoa.Clear();
            txtTenHang.Clear();
            txtMaNCC.Clear();
            txtDongia.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (Guna2TextBox ctrl in tableLayout.Controls.OfType<Guna2TextBox>())
            {
                if (string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }
            }

            HangHoa hh = new HangHoa
            {
                MaHang =  Convert.ToInt32(txtMahanghoa.Text),
                TenHang = txtTenHang.Text,
                MaLoai = int.Parse(cmbMaloai.Text),
                MaNCC =int.Parse(txtMaNCC.Text),
                NgaySanXuat=DateTime.Now,
                HanSuDung = DateTime.Now.AddMonths(6), // Giả sử hạn sử dụng là 6 tháng kể từ ngày sản xuất
                DonGia = decimal.Parse(txtDongia.Text),
            };

            bool kq = bllHangHoa.ThemHangHoa(hh);

            if (kq)
            {
                MessageBox.Show("Thêm hàng hóa thành công!");
                dgvHanghoa.DataSource = bllHangHoa.LayDanhSachHangHoa();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Thêm hàng hóa thất bại!");
            }



        }

        private void UCHangHoa_Load(object sender, EventArgs e)
        {
            dgvHanghoa.DataSource = bllHangHoa.LayDanhSachHangHoa();
            dgvHanghoa.Columns["DonGia"].DefaultCellStyle.Format = "c0";
            dgvHanghoa.Columns["DonGia"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
        }

        private void dgvHanghoa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHanghoa.Columns[e.ColumnIndex].Name == "DonGia" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal donGia))
                {
                    e.Value = donGia.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            foreach (Guna2TextBox ctrl in tableLayout.Controls.OfType<Guna2TextBox>())
            {
                if (string.IsNullOrWhiteSpace(ctrl.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }
            }

            HangHoa hh = new HangHoa
            {
                MaHang = Convert.ToInt32(txtMahanghoa.Text),
                TenHang = txtTenHang.Text,
                MaLoai = int.Parse(cmbMaloai.Text),
                MaNCC = int.Parse(txtMaNCC.Text),
                NgaySanXuat = DateTime.Now,
                HanSuDung = DateTime.Now.AddMonths(6), // Giả sử hạn sử dụng là 6 tháng kể từ ngày sản xuất
                DonGia = decimal.Parse(cmbMaloai.Text),
            };

            bool kq = bllHangHoa.CapnhatHangHoa(hh);

            if (kq)
            {
                MessageBox.Show("Cập nhật hàng hóa thành công!");
                // Tải lại dữ liệu cho DataGridView
                dgvHanghoa.DataSource = bllHangHoa.LayDanhSachHangHoa();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Cập nhật hàng hóa thất bại!");
            }

        }
        private void dgvHanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHanghoa.Rows[e.RowIndex];
                txtMahanghoa.Text = row.Cells["MaHang"].Value.ToString();
                txtTenHang.Text = row.Cells["TenHang"].Value.ToString();
                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                cmbMaloai.Text = row.Cells["DonGia"].Value.ToString();
                dtpNgaysanxuat.Value = Convert.ToDateTime(row.Cells["NgaySanXuat"].Value);
                dtpHSD.Value = Convert.ToDateTime(row.Cells["HanSuDung"].Value);
                txtDongia.Text = row.Cells["DonGia"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMahanghoa.Text))
            {
                MessageBox.Show("Vui lòng chọn hàng hóa để xóa!");
                return;
            }
            string maHang = txtMahanghoa.Text;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool kq = bllHangHoa.XoaHangHoa(maHang);
                if (kq)
                {
                    MessageBox.Show("Xóa hàng hóa thành công!");
                    dgvHanghoa.DataSource = bllHangHoa.LayDanhSachHangHoa();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Xóa hàng hóa thất bại!");
                }
            }
        }
    }
}
