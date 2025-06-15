using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;


namespace BLL
{
    public class BLL_HangHoa
    {
        private readonly Database db = new Database();
        public DataTable LayDanhSachHangHoa()
        {
            db.OpenDB();
            // Thay "SELECT *" bằng câu lệnh JOIN để lấy cả TenLoai
            string query = @"
        SELECT 
            hh.MaHang, 
            hh.TenHang, 
            lh.TenLoai, 
            hh.MaNCC, 
            hh.NgaySanXuat, 
            hh.HanSuDung, 
            hh.DonGia,
            hh.MaLoai -- Vẫn lấy MaLoai để dùng khi click
        FROM HangHoa hh
        JOIN LoaiHang lh ON hh.MaLoai = lh.MaLoai";

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }

        public int SoLuongHangTonKho(int maHang)
        {
            db.OpenDB();
            // Câu lệnh SQL tính tồn kho = (tổng nhập) - (tổng xuất)
            string sql = @"
        SELECT 
            (
                ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonNhap WHERE MaHang = @MaHang), 0) -
                ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonXuat WHERE MaHang = @MaHang), 0)
            )";

            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHang", maHang);

            object result = null;
            try
            {
                result = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                // Bỏ qua lỗi và trả về 0 nếu có sự cố
                return 0;
            }
            finally
            {
                db.CloseDB();
            }

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }

            return 0; // Trả về 0 nếu không tìm thấy hoặc có lỗi
        }

        public DataTable ThongKeHangHoa(string dieuKien)
        {
            db.OpenDB();
            string sqlQuery = "";
            switch (dieuKien)
            {
                case "Hàng bán chạy":
                    // Lấy top 10 sản phẩm bán chạy nhất
                    sqlQuery = @"
                SELECT TOP 10
                    hh.MaHang, hh.TenHang, lh.TenLoai,
                    SUM(ct.SoLuong) AS SoLuongBan,
                    (SELECT ISNULL(SUM(SoLuong), 0) FROM ChiTietHoaDonNhap WHERE MaHang = hh.MaHang) AS SoLuongNhap,
                    ((SELECT ISNULL(SUM(SoLuong), 0) FROM ChiTietHoaDonNhap WHERE MaHang = hh.MaHang) - SUM(ct.SoLuong)) AS SoLuongTon
                FROM HangHoa hh
                JOIN ChiTietHoaDonXuat ct ON hh.MaHang = ct.MaHang
                JOIN LoaiHang lh ON hh.MaLoai = lh.MaLoai
                GROUP BY hh.MaHang, hh.TenHang, lh.TenLoai
                ORDER BY SoLuongBan DESC";
                    break;
                case "Hàng tồn kho nhiều":
                    sqlQuery = @"
                SELECT TOP 10
                    hh.MaHang, hh.TenHang, lh.TenLoai,
                    ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonXuat WHERE MaHang = hh.MaHang), 0) AS SoLuongBan,
                    ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonNhap WHERE MaHang = hh.MaHang), 0) AS SoLuongNhap,
                    (ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonNhap WHERE MaHang = hh.MaHang), 0) - ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonXuat WHERE MaHang = hh.MaHang), 0)) AS SoLuongTon
                FROM HangHoa hh
                JOIN LoaiHang lh ON hh.MaLoai = lh.MaLoai
                ORDER BY SoLuongTon DESC";
                    break;
                case "Hàng sắp hết hạn":
                    // Giả sử "sắp hết hạn" là còn dưới 30 ngày
                    sqlQuery = @"
                SELECT
                    MaHang, TenHang, MaLoai, NgaySanXuat, HanSuDung, DonGia,
                    DATEDIFF(day, GETDATE(), HanSuDung) as NgayConLai
                FROM HangHoa
                WHERE DATEDIFF(day, GETDATE(), HanSuDung) BETWEEN 0 AND 30
                ORDER BY NgayConLai ASC";
                    break;
                default: // Mặc định là "Tất cả"
                    sqlQuery = @"
                SELECT
                    hh.MaHang, hh.TenHang, lh.TenLoai,
                    ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonXuat WHERE MaHang = hh.MaHang), 0) AS SoLuongBan,
                    ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonNhap WHERE MaHang = hh.MaHang), 0) AS SoLuongNhap,
                    (ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonNhap WHERE MaHang = hh.MaHang), 0) - ISNULL((SELECT SUM(SoLuong) FROM ChiTietHoaDonXuat WHERE MaHang = hh.MaHang), 0)) AS SoLuongTon
                FROM HangHoa hh
                JOIN LoaiHang lh ON hh.MaLoai = lh.MaLoai
                ORDER BY hh.MaHang ASC";
                    break;
            }

            SqlCommand cmd = new SqlCommand(sqlQuery, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }

        public string ThemHangHoa(HangHoa hh)
        {
            // Mã hàng đã được tự động tăng, không cần truyền vào
            string sql = "INSERT INTO HangHoa (TenHang, MaNCC, MaLoai, NgaySanXuat, HanSuDung, DonGia) " +
                         "VALUES (@TenHang, @MaNCC, @MaLoai, @NgaySanXuat, @HanSuDung, @DonGia)";

            try
            {
                db.OpenDB();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@TenHang", hh.TenHang);
                cmd.Parameters.AddWithValue("@MaNCC", hh.MaNCC);
                cmd.Parameters.AddWithValue("@MaLoai", hh.MaLoai);
                cmd.Parameters.AddWithValue("@NgaySanXuat", hh.NgaySanXuat);
                cmd.Parameters.AddWithValue("@HanSuDung", hh.HanSuDung);
                cmd.Parameters.AddWithValue("@DonGia", hh.DonGia);

                cmd.ExecuteNonQuery();
                return null; // Trả về null nghĩa là thành công
            }
            catch (SqlException ex)
            {
                // Bắt lỗi vi phạm ràng buộc khóa ngoại
                if (ex.Number == 547)
                {
                    if (ex.Message.Contains("FK_HangHoa_NhaCungCap"))
                        return $"Lỗi: Mã nhà cung cấp '{hh.MaNCC}' không tồn tại.";
                    if (ex.Message.Contains("FK_HangHoa_LoaiHang"))
                        return $"Lỗi: Mã loại '{hh.MaLoai}' không tồn tại.";
                }
                return "Lỗi CSDL: " + ex.Message;
            }
            finally
            {
                db.CloseDB();
            }
        }

        public string CapnhatHangHoa(HangHoa hh)
        {
            // Câu lệnh UPDATE này đã được sửa lại để cập nhật đầy đủ các trường
            string sql = @"UPDATE HangHoa SET 
                        TenHang = @TenHang, 
                        MaNCC = @MaNCC, 
                        MaLoai = @MaLoai, 
                        NgaySanXuat = @NgaySanXuat, 
                        HanSuDung = @HanSuDung, 
                        DonGia = @DonGia 
                   WHERE MaHang = @MaHang";
            try
            {
                db.OpenDB();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@MaHang", hh.MaHang);
                cmd.Parameters.AddWithValue("@TenHang", hh.TenHang);
                cmd.Parameters.AddWithValue("@MaNCC", hh.MaNCC);
                cmd.Parameters.AddWithValue("@MaLoai", hh.MaLoai);
                cmd.Parameters.AddWithValue("@NgaySanXuat", hh.NgaySanXuat);
                cmd.Parameters.AddWithValue("@HanSuDung", hh.HanSuDung);
                cmd.Parameters.AddWithValue("@DonGia", hh.DonGia);

                cmd.ExecuteNonQuery();
                return null; // Thành công
            }
            catch (SqlException ex)
            {
                // Bắt lỗi vi phạm ràng buộc khóa ngoại
                if (ex.Number == 547)
                {
                    if (ex.Message.Contains("FK_HangHoa_NhaCungCap"))
                        return $"Lỗi: Mã nhà cung cấp '{hh.MaNCC}' không tồn tại.";
                    if (ex.Message.Contains("FK_HangHoa_LoaiHang"))
                        return $"Lỗi: Mã loại '{hh.MaLoai}' không tồn tại.";
                }
                return "Lỗi CSDL khi cập nhật: " + ex.Message;
            }
            finally
            {
                db.CloseDB();
            }
        }

        public bool XoaHangHoa(string maHang)
        {
            string sql = "DELETE FROM HangHoa WHERE MaHang = @MaHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHang", maHang);
            db.OpenDB();
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0;
        }
    }
}
