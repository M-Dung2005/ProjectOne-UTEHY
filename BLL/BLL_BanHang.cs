using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class BLL_BanHang
    {
        private readonly Database db = new Database();

        public DataTable LayDanhSachHoaDonXuat()
        {
            db.OpenDB();
            string sql = @"
            SELECT 
                hd.MaHDX, 
                hd.NgayTao, 
                nv.TenNV,
                kh.TenKH,
                hd.TongTien
            FROM HoaDonXuat hd
            JOIN NhanVien nv ON hd.MaNV = nv.MaNV
            JOIN KhachHang kh ON hd.MaKH = kh.MaKH";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }

        public int ThemHoaDonXuat(HoaDonXuat hd)
        {
            db.OpenDB();
            // Bỏ MaHDX khỏi câu lệnh INSERT và thêm "SELECT SCOPE_IDENTITY()" để lấy mã vừa tạo
            string sql = "INSERT INTO HoaDonXuat (NgayTao, MaNV, MaKH, TongTien) VALUES (@NgayTao, @MaNV, @MaKH, @TongTien); SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(sql, db.conn);
            // Không thêm tham số @MaHDX nữa
            cmd.Parameters.AddWithValue("@NgayTao", hd.NgayTao);
            cmd.Parameters.AddWithValue("@MaNV", hd.MaNV);
            cmd.Parameters.AddWithValue("@MaKH", hd.MaKH);
            cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);

            // Dùng ExecuteScalar để nhận về giá trị đơn (là mã hóa đơn mới)
            object result = null;
            try
            {
                result = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu có
            }
            finally
            {
                db.CloseDB();
            }

            if (result != null)
            {
                return Convert.ToInt32(result); // Trả về mã hóa đơn mới
            }

            return 0; // Trả về 0 nếu thất bại
        }


        public decimal TinhTongTien(int maHDX)
        {
            db.OpenDB();
            string sql = "SELECT SUM(SoLuong * DonGia) FROM ChiTietHDX WHERE MaHDX = @MaHDX";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHDX", maHDX);
            object result = cmd.ExecuteScalar();
            db.CloseDB();
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        
    }
}
