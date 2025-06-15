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

        // Trong file QLST/Controls/UCHangHoa.cs

        private void btnThem_Click(object sender, EventArgs e)
        {
            // === BẮT ĐẦU PHẦN KIỂM TRA RÀNG BUỘC ===

            // 1. Ràng buộc "Không được để trống"
            if (string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                cmbMaloai.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtMaNCC.Text) ||
                string.IsNullOrWhiteSpace(txtDongia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ràng buộc "Kiểu dữ liệu"
            if (!int.TryParse(txtMaNCC.Text, out int maNCC))
            {
                MessageBox.Show("Mã Nhà cung cấp phải là một con số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtDongia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là một số không âm!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Ràng buộc "Logic ngày tháng"
            if (dtpHSD.Value <= dtpNgaysanxuat.Value)
            {
                MessageBox.Show("Hạn sử dụng phải sau Ngày sản xuất.", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Ràng buộc "Tham chiếu" (Kiểm tra sự tồn tại của Mã Loại và Mã NCC)
            int maLoai = Convert.ToInt32(cmbMaloai.SelectedValue);

            // Tạo instance mới của BLL để kiểm tra
            if (!new BLL_LoaiHang().KiemTraLoaiHangTonTai(maLoai))
            {
                MessageBox.Show($"Mã loại '{maLoai}' không tồn tại. Vui lòng chọn lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!new BLL_NhaCungCap().KiemTraNhaCungCapTonTai(maNCC))
            {
                MessageBox.Show($"Mã nhà cung cấp '{maNCC}' không tồn tại. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // === KẾT THÚC PHẦN KIỂM TRA RÀNG BUỘC ===


            // Nếu tất cả ràng buộc đều hợp lệ, tiến hành thêm mới
            HangHoa hh = new HangHoa
            {
                TenHang = txtTenHang.Text,
                MaNCC = maNCC,
                MaLoai = maLoai,
                NgaySanXuat = dtpNgaysanxuat.Value,
                HanSuDung = dtpHSD.Value,
                DonGia = donGia
            };

            // Gọi BLL để thêm vào CSDL (giả sử đã sửa BLL trả về string lỗi)
            string errorMessage = bllHangHoa.ThemHangHoa(hh);

            if (errorMessage == null)
            {
                MessageBox.Show("Thêm hàng hóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHanghoa.DataSource = bllHangHoa.LayDanhSachHangHoa();
                ClearInputFields();
            }
            else
            {
                // Hiển thị lỗi từ BLL (nếu có lỗi từ CSDL mà code C# chưa bắt được)
                MessageBox.Show(errorMessage, "Lỗi từ CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // === BẮT ĐẦU PHẦN KIỂM TRA RÀNG BUỘC ===

            // 1. Ràng buộc "Phải chọn một hàng hóa"
            if (string.IsNullOrWhiteSpace(txtMahanghoa.Text))
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng từ danh sách để cập nhật!", "Chưa chọn hàng hóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ràng buộc "Không được để trống"
            if (string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                cmbMaloai.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtMaNCC.Text) ||
                string.IsNullOrWhiteSpace(txtDongia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Ràng buộc "Kiểu dữ liệu"
            if (!int.TryParse(txtMaNCC.Text, out int maNCC))
            {
                MessageBox.Show("Mã Nhà cung cấp phải là một con số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtDongia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là một số không âm!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Ràng buộc "Logic ngày tháng"
            if (dtpHSD.Value <= dtpNgaysanxuat.Value)
            {
                MessageBox.Show("Hạn sử dụng phải sau Ngày sản xuất.", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Ràng buộc "Tham chiếu" (Kiểm tra sự tồn tại)
            int maLoai = Convert.ToInt32(cmbMaloai.SelectedValue);
            if (!new BLL_LoaiHang().KiemTraLoaiHangTonTai(maLoai))
            {
                MessageBox.Show($"Mã loại '{maLoai}' không tồn tại. Vui lòng chọn lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!new BLL_NhaCungCap().KiemTraNhaCungCapTonTai(maNCC))
            {
                MessageBox.Show($"Mã nhà cung cấp '{maNCC}' không tồn tại. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // === KẾT THÚC PHẦN KIỂM TRA RÀNG BUỘC ===


            // Nếu tất cả ràng buộc đều hợp lệ, tiến hành cập nhật
            HangHoa hh = new HangHoa
            {
                MaHang = int.Parse(txtMahanghoa.Text), // Lấy mã hàng đang được chọn
                TenHang = txtTenHang.Text,
                MaNCC = maNCC,
                MaLoai = maLoai,
                NgaySanXuat = dtpNgaysanxuat.Value,
                HanSuDung = dtpHSD.Value,
                DonGia = donGia
            };

            string errorMessage = bllHangHoa.CapnhatHangHoa(hh);

            if (errorMessage == null)
            {
                MessageBox.Show("Cập nhật hàng hóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvHanghoa.DataSource = bllHangHoa.LayDanhSachHangHoa();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
