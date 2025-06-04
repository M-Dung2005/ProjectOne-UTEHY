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
    public class BLL_QLKH
    {
        private readonly Database db = new Database();
        // Thêm khách hàng vào cơ sở dữ liệu
        public bool ThemKhachHang(string MaKH, string TenKH, string DiaChi, string SoDienThoai,string GioiTinh)
        {
            db.OpenDB();
            string sql = "INSERT INTO KhachHang (MaKH, TenKH, DiaChi, SoDienThoai, GioiTinh ) VALUES (@MaKH, @TenKH, @DiaChi, @SoDienThoai, @GioiTinh)";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaKH", MaKH);
            cmd.Parameters.AddWithValue("@TenKH", TenKH);
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", SoDienThoai);
            cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0; // Trả về true nếu thêm thành công
        }
        // Lấy danh sách khách hàng từ cơ sở dữ liệu
        public DataTable LayDanhSachKhachHang()
        {
            db.OpenDB();
            string sql = "SELECT * FROM KhachHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }
        // Xóa khách hàng khỏi cơ sở dữ liệu
        public bool XoaKhachHang(string MaKH)
        {
            db.OpenDB();
            string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaKH", MaKH);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0; // Trả về true nếu xóa thành công
        }

        // Cập nhật thông tin khách hàng trong cơ sở dữ liệu
        public bool CapNhatKhachHang(string MaKH, string TenKH, string DiaChi, string SoDienThoai, string GioiTinh)
        {
            db.OpenDB();
            string sql = "UPDATE KhachHang SET TenKH = @TenKH, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, GioiTinh = @GioiTinh WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaKH", MaKH);
            cmd.Parameters.AddWithValue("@TenKH", TenKH);
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            cmd.Parameters.AddWithValue("@SoDienThoai", SoDienThoai);
            cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0; // Trả về true nếu cập nhật thành công
        }
    }
}
