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
                hd.NgayLap, 
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



        public bool ThemHoaDonXuat(HoaDonXuat hd)
        {
            db.OpenDB();
            string sql = "INSERT INTO HoaDonXuat (MaHDX, NgayLap, MaNV, MaKH, TongTien) VALUES (@MaHDX, @NgayLap, @MaNV, @MaKH, @TongTien)";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHDX", hd.MaHDX);
            cmd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
            cmd.Parameters.AddWithValue("@MaNV", hd.MaNV);
            cmd.Parameters.AddWithValue("@MaKH", hd.MaKH);
            cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0;
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
