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

        public UCThongKe()
        {
            InitializeComponent();
            SetupInitialState();
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
                item.SubItems.Add(row["TenLoai"].ToString());

                // Các cột có thể không tồn tại trong mọi truy vấn, cần kiểm tra
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
            DateTime fromDate = dateTimePicker1.Value;
            DateTime toDate = dateTimePicker2.Value;

            // Lấy giá trị từ ComboBox (cần kiểm tra null)
            int? maLoai = cmbLoaiHang.SelectedValue as int?;
            int? maNCC = cmbNhaCC.SelectedValue as int?;

            DataTable dt = bllThongKe.ThongKeNhapXuat(fromDate, toDate, maLoai, maNCC);

            listViewNhap.Items.Clear();
            listViewXuat.Items.Clear();

            decimal tongTienNhap = 0;
            decimal tongTienXuat = 0;
            int soLuongNhap = 0;
            int soLuongXuat = 0;
            int sttNhap = 1;
            int sttXuat = 1;

            foreach (DataRow row in dt.Rows)
            {
                if (row["LoaiGiaoDich"].ToString() == "Nhap")
                {
                    ListViewItem item = new ListViewItem(sttNhap++.ToString());
                    item.SubItems.Add(row["MaHang"].ToString());
                    item.SubItems.Add(row["TenHang"].ToString());
                    item.SubItems.Add(row["SoLuong"].ToString());
                    item.SubItems.Add(string.Format("{0:N0}", row["ThanhTien"])); // Định dạng tiền tệ
                    listViewNhap.Items.Add(item);

                    tongTienNhap += Convert.ToDecimal(row["ThanhTien"]);
                    soLuongNhap += Convert.ToInt32(row["SoLuong"]);
                }
                else // Xuat
                {
                    ListViewItem item = new ListViewItem(sttXuat++.ToString());
                    item.SubItems.Add(row["MaHang"].ToString());
                    item.SubItems.Add(row["TenHang"].ToString());
                    item.SubItems.Add(row["SoLuong"].ToString());
                    item.SubItems.Add(string.Format("{0:N0}", row["ThanhTien"]));
                    listViewXuat.Items.Add(item);

                    tongTienXuat += Convert.ToDecimal(row["ThanhTien"]);
                    soLuongXuat += Convert.ToInt32(row["SoLuong"]);
                }
            }
            // Cập nhật các textbox tổng kết
            txtSoSPNhap.Text = listViewNhap.Items.Count.ToString();
            txtSLNhap.Text = soLuongNhap.ToString();
            txtTienNhap.Text = string.Format("{0:N0} VNĐ", tongTienNhap);

            txtSoSPBan.Text = listViewXuat.Items.Count.ToString();
            txtSLBan.Text = soLuongXuat.ToString();
            txtTienBan.Text = string.Format("{0:N0} VNĐ", tongTienXuat);
        }
    }
}