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
        BLL_LoaiHang bllLoaiHang = new BLL_LoaiHang();
        public UCHangHoa()
        {
            InitializeComponent();
        }


        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            // Lấy form cha và ép kiểu nó về frmMain
            frmMain mainForm = this.ParentForm as frmMain;

            // Kiểm tra để chắc chắn rằng form cha thực sự là frmMain
            if (mainForm != null)
            {
                // Gọi phương thức public của frmMain để chuyển giao diện
                mainForm.ShowNhapHangView();
            }
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
            // 1. Kiểm tra và chuyển đổi dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                cmbMaloai.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtMaNCC.Text) ||
                string.IsNullOrWhiteSpace(txtDongia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Tên hàng, Loại hàng, Mã NCC, Đơn giá)!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaNCC.Text, out int maNCC))
            {
                MessageBox.Show("Mã Nhà cung cấp phải là một con số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtDongia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá phải là một con số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Tạo đối tượng DTO để gửi đi
            HangHoa hh = new HangHoa
            {
                TenHang = txtTenHang.Text,
                MaNCC = maNCC, // Lấy giá trị từ TextBox đã được chuyển đổi
                MaLoai = Convert.ToInt32(cmbMaloai.SelectedValue),
                NgaySanXuat = dtpNgaysanxuat.Value,
                HanSuDung = dtpHSD.Value,
                DonGia = donGia
            };

            // 3. Gọi BLL và xử lý kết quả
            string errorMessage = bllHangHoa.ThemHangHoa(hh);

            if (errorMessage == null)
            {
                MessageBox.Show("Thêm hàng hóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                ClearInputFields();
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void UCHangHoa_Load(object sender, EventArgs e)
        {
            LoadComboBoxLoaiHang();
            dgvHanghoa.DataSource = bllHangHoa.LayDanhSachHangHoa();
            dgvHanghoa.Columns["DonGia"].DefaultCellStyle.Format = "c0";
            dgvHanghoa.Columns["DonGia"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
        }

        // Phương thức mới để tải dữ liệu vào ComboBox
        private void LoadComboBoxLoaiHang()
        {
            try
            {
                cmbMaloai.DataSource = bllLoaiHang.LayDanhSachLoaiHang();
                cmbMaloai.DisplayMember = "TenLoai"; // Cột hiển thị tên cho người dùng
                cmbMaloai.ValueMember = "MaLoai";   // Cột giá trị (ID) dùng để lưu vào CSDL
                cmbMaloai.SelectedIndex = -1;       // Bỏ chọn mục mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                // Gán giá trị cho TextBox MaNCC
                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();

                cmbMaloai.SelectedValue = row.Cells["MaLoai"].Value;
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
