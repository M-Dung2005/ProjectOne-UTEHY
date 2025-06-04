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
    public partial class UCBanHang : UserControl
    {
        BLL_BanHang bllBanHang = new BLL_BanHang();
        BLL_Chitiethoadonxuat BLL_Chitiethoadonxuat = new BLL_Chitiethoadonxuat();
        private frmMain parentForm;
        public UCBanHang()
        {
            InitializeComponent();
            
           
        }

        private void ClearInputFields()
        {
            txtMaHDX.Clear();
            dtpNgayban.Value = DateTime.Now; // Đặt ngày xuất về ngày hiện tại
            txtMaKH.Clear();
            txtMaloai.Clear();
            txtMahang.Clear();
            txtSoluong.Clear();
            txtDongia.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrWhiteSpace(txtMaHDX.Text) || string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtMaloai.Text) ||
                string.IsNullOrWhiteSpace(txtMahang.Text) || string.IsNullOrWhiteSpace(txtSoluong.Text) || string.IsNullOrWhiteSpace(txtDongia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            dgvBanHang.Rows.Add(
            txtMaloai.Text,
            txtMahang.Text,
            cmbTensp.Text,
            txtDongia.Text,
            txtSoluong.Text
            );

            // Xóa thông tin đã nhập để tiện nhập dòng mới
            txtMaloai.Clear();
            txtMahang.Clear();
            txtDongia.Clear();
            txtSoluong.Clear();
            cmbTensp.SelectedIndex = -1;


        }


        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHDX.Text) ||
                string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                cmbNhanVien.SelectedItem == null ||
                dgvBanHang.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn và thêm sản phẩm!");
                return;
            }

            int tongTien = 0;
            foreach (DataGridViewRow row in dgvBanHang.Rows)
            {
                if (row.IsNewRow) continue;

                decimal donGiaValue = int.Parse(row.Cells["DonGia"].Value.ToString());
                int soLuongValue = int.Parse(row.Cells["SoLuong"].Value.ToString());

                tongTien += donGia * soLuong;
            }

            HoaDonXuat hd = new HoaDonXuat
            {
                MaHDX = int.Parse(txtMaHDX.Text),
                NgayLap = dtpNgayban.Value,
                MaNV = Convert.ToInt32(cmbNhanVien.SelectedValue),
                MaKH = int.Parse(txtMaKH.Text),
                TongTien = tongTien
            };

            if (!bllBanHang.ThemHoaDonXuat(hd))
            {
                MessageBox.Show("Không thể tạo hóa đơn!");
                return;
            }

            foreach (DataGridViewRow row in dgvBanHang.Rows)
            {
                if (row.IsNewRow) continue;

                ChiTietHoaDonXuat ct = new ChiTietHoaDonXuat
                {
                    MaHDX = hd.MaHDX,
                    MaHang = int.Parse(row.Cells["MaHang"].Value.ToString()),
                    SoLuong = int.Parse(row.Cells["SoLuong"].Value.ToString()),
                    DonGia = int.Parse(row.Cells["DonGia"].Value.ToString()),
                    ThanhTien = int.Parse(row.Cells["SoLuong"].Value.ToString()) * int.Parse(row.Cells["DonGia"].Value.ToString()) // Tính thành tiền
                };

                BLL_Chitiethoadonxuat.ThemChiTietHoaDonXuat(ct);
            }

            MessageBox.Show("Tạo hóa đơn thành công!");
            dgvBanHang.Rows.Clear();
            // Xóa input nếu cần
        }



    }
    }
