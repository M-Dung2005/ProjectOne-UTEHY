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
    public partial class UCThongKe : UserControl
    {
        private readonly BLL_HangHoa bllHangHoa = new BLL_HangHoa();
        private readonly BLL_ThongKe bllThongKe = new BLL_ThongKe();
        private readonly BLL_LoaiHang bllLoaiHang = new BLL_LoaiHang();
        private readonly BLL_NhaCungCap bllNhaCungCap = new BLL_NhaCungCap();

        public UCThongKe()
        {
            InitializeComponent();
        }

        private void UCThongKe_Load(object sender, EventArgs e)
        {
            SetupInitialState();
            // Tải dữ liệu lần đầu cho ComboBox
            UpdateDependentComboBoxes();
        }
        private void SetupInitialState()
        {
            // Thiết lập giá trị mặc định cho ComboBox thống kê hàng
            comboBox1.Items.AddRange(new object[] {
                "Tất cả",
                "Hàng bán chạy",
                "Hàng tồn kho nhiều",
                "Hàng sắp hết hạn"
            });
            comboBox1.SelectedIndex = 0;

            // Đăng ký sự kiện
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            btnShow.Click += BtnShow_Click;
            // Đăng ký sự kiện cho DateTimePickers
            dateTimePicker1.ValueChanged += DateTimePickers_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePickers_ValueChanged;
        }
        private void DateTimePickers_ValueChanged(object sender, EventArgs e)
        {
            UpdateDependentComboBoxes();
        }

        private void UpdateDependentComboBoxes()
        {
            DateTime fromDate = dateTimePicker1.Value.Date;
            DateTime toDate = dateTimePicker2.Value.Date;

            // Tải dữ liệu cho ComboBox Loại Hàng
            DataTable dtLoaiHang = bllLoaiHang.LayLoaiHangTheoNgay(fromDate, toDate);
            DataRow allLoaiHang = dtLoaiHang.NewRow();
            allLoaiHang["MaLoai"] = DBNull.Value; // Giá trị cho lựa chọn "Tất cả"
            allLoaiHang["TenLoai"] = "--- Tất cả Loại hàng ---";
            dtLoaiHang.Rows.InsertAt(allLoaiHang, 0);
            cmbLoaiHang.DataSource = dtLoaiHang;
            cmbLoaiHang.DisplayMember = "TenLoai";
            cmbLoaiHang.ValueMember = "MaLoai";

            // Tải dữ liệu cho ComboBox Nhà Cung Cấp
            DataTable dtNCC = bllNhaCungCap.LayNhaCungCapTheoNgay(fromDate, toDate);
            DataRow allNCC = dtNCC.NewRow();
            allNCC["MaNCC"] = DBNull.Value; // Giá trị cho lựa chọn "Tất cả"
            allNCC["TenNCC"] = "--- Tất cả Nhà cung cấp ---";
            dtNCC.Rows.InsertAt(allNCC, 0);
            cmbNhaCC.DataSource = dtNCC;
            cmbNhaCC.DisplayMember = "TenNCC";
            cmbNhaCC.ValueMember = "MaNCC";
        }

        // Sự kiện khi lựa chọn trong combobox thay đổi
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dieuKien = comboBox1.SelectedItem.ToString();
            LoadThongKeHangHoa(dieuKien);
        }

        // Tải dữ liệu thống kê hàng hóa
        private void LoadThongKeHangHoa(string dieuKien)
        {
            listView1.Items.Clear();
            DataTable dt = bllHangHoa.ThongKeHangHoa(dieuKien);

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["MaHang"].ToString());
                item.SubItems.Add(row["TenHang"].ToString());
                //item.SubItems.Add(row["TenLoai"].ToString());

                // Các cột có thể không tồn tại trong mọi truy vấn, cần kiểm tra
                if (dt.Columns.Contains("TenLoai"))
                    item.SubItems.Add(row["TenLoai"].ToString());
                else
                    item.SubItems.Add("N/A");
                if (dt.Columns.Contains("SoLuongNhap"))
                    item.SubItems.Add(row["SoLuongNhap"].ToString());
                else
                    item.SubItems.Add("N/A");

                if (dt.Columns.Contains("SoLuongBan"))
                    item.SubItems.Add(row["SoLuongBan"].ToString());
                else
                    item.SubItems.Add("N/A");

                if (dt.Columns.Contains("SoLuongTon"))
                    item.SubItems.Add(row["SoLuongTon"].ToString());
                else if (dt.Columns.Contains("HanSuDung")) // Dành cho trường hợp sắp hết hạn
                {
                    DateTime hsd = Convert.ToDateTime(row["HanSuDung"]);
                    item.SubItems.Add(hsd.ToString("dd/MM/yyyy"));
                }
                else
                {
                    item.SubItems.Add("N/A");
                }

                listView1.Items.Add(item);
            }
            // Đổi tên cột cuối cùng cho phù hợp
            if (dieuKien == "Hàng sắp hết hạn")
            {
                listView1.Columns[5].Text = "Hạn Sử Dụng";
            }
            else
            {
                listView1.Columns[5].Text = "Số Lượng Tồn";
            }
        }

        // Sự kiện cho nút "Show" ở tab Nhập/Xuất
        private void BtnShow_Click(object sender, EventArgs e)
        {
            // 1. Lấy các giá trị lọc từ giao diện
            DateTime fromDate = dateTimePicker1.Value.Date;
            // Lấy đến hết ngày được chọn (23:59:59)
            DateTime toDate = dateTimePicker2.Value.Date.AddDays(1).AddTicks(-1);

            // Lấy giá trị đã chọn, xử lý trường hợp người dùng chọn "Tất cả"
            int? maLoai = (cmbLoaiHang.SelectedValue == DBNull.Value || cmbLoaiHang.SelectedValue == null)
                          ? null
                          : (int?)Convert.ToInt32(cmbLoaiHang.SelectedValue);

            int? maNCC = (cmbNhaCC.SelectedValue == DBNull.Value || cmbNhaCC.SelectedValue == null)
                         ? null
                         : (int?)Convert.ToInt32(cmbNhaCC.SelectedValue);

            // 2. Gọi BLL để lấy về DataTable đã được lọc
            DataTable dt = bllThongKe.ThongKeNhapXuat(fromDate, toDate, maLoai, maNCC);

            // 3. Xóa dữ liệu cũ trên hai ListView
            listViewNhap.Items.Clear();
            listViewXuat.Items.Clear();

            // 4. Khởi tạo các biến để tính tổng
            decimal tongTienNhap = 0;
            decimal tongTienXuat = 0;
            int soLuongNhap = 0;
            int soLuongXuat = 0;
            int sttNhap = 1;
            int sttXuat = 1;

            // 5. Duyệt qua từng dòng dữ liệu trong DataTable và phân loại
            foreach (DataRow row in dt.Rows)
            {
                // Nếu là giao dịch "Nhập"
                if (row["LoaiGiaoDich"].ToString() == "Nhap")
                {
                    ListViewItem item = new ListViewItem(sttNhap++.ToString());
                    item.SubItems.Add(row["MaPhieu"].ToString());
                    item.SubItems.Add(row["TenHang"].ToString());
                    item.SubItems.Add(row["SoLuong"].ToString());
                    item.SubItems.Add(string.Format("{0:N0}", row["ThanhTien"])); // Định dạng số cho dễ đọc

                    listViewNhap.Items.Add(item);

                    // Cộng dồn vào biến tổng nhập
                    tongTienNhap += Convert.ToDecimal(row["ThanhTien"]);
                    soLuongNhap += Convert.ToInt32(row["SoLuong"]);
                }
                // Nếu là giao dịch "Xuất"
                else
                {
                    ListViewItem item = new ListViewItem(sttXuat++.ToString());
                    item.SubItems.Add(row["MaPhieu"].ToString());
                    item.SubItems.Add(row["TenHang"].ToString());
                    item.SubItems.Add(row["SoLuong"].ToString());
                    item.SubItems.Add(string.Format("{0:N0}", row["ThanhTien"]));

                    listViewXuat.Items.Add(item);

                    // Cộng dồn vào biến tổng xuất
                    tongTienXuat += Convert.ToDecimal(row["ThanhTien"]);
                    soLuongXuat += Convert.ToInt32(row["SoLuong"]);
                }
            }

            // 6. Cập nhật các TextBox tổng kết ở dưới cùng
            txtSoSPNhap.Text = listViewNhap.Items.Count.ToString();
            txtSLNhap.Text = soLuongNhap.ToString();
            txtTienNhap.Text = string.Format("{0:N0} VNĐ", tongTienNhap);

            txtSoSPBan.Text = listViewXuat.Items.Count.ToString();
            txtSLBan.Text = soLuongXuat.ToString();
            txtTienBan.Text = string.Format("{0:N0} VNĐ", tongTienXuat);
   }    }
}