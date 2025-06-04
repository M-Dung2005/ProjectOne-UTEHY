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
    public class BLL_QLNV
    {
        private readonly Database db = new Database();

        // Thêm nhân viên vào cơ sở dữ liệu
        public bool ThemNhanVien(string maNV, string tenNV, string SoDienThoai, string DiaChi, string GioiTinh, string NgaySinh, int maTK)
        {
            db.OpenDB();
            string sql = "INSERT INTO NhanVien (MaNV, TenNV, SoDienThoai, NgaySinh, DiaChi, GioiTinh,MaTK) VALUES (@MaNV, @TenNV, @SoDienThoai, @NgaySinh, @DiaChi, @GioiTinh,@MaTK)";
            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@TenNV", tenNV);
            cmd.Parameters.AddWithValue("@SoDienThoai", SoDienThoai); 
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh",GioiTinh);
            cmd.Parameters.AddWithValue("@MaTK", maTK);

            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();

            return rows > 0; // Trả về true nếu thêm thành công
        }

        // Cập nhật thông tin nhân viên trong cơ sở dữ liệu
        public bool CapNhatNhanVien(string maNV, string tenNV, string SoDienThoai, string DiaChi, string GioiTinh, string NgaySinh, int MaTK)
        {
            db.OpenDB();
            string sql = "UPDATE NhanVien SET TenNV = @TenNV,  SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, MaTK= @MaTK WHERE MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@TenNV", tenNV);
            cmd.Parameters.AddWithValue("@SoDienThoai", SoDienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
            cmd.Parameters.AddWithValue("@MaTK", MaTK);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0; // Trả về true nếu cập nhật thành công
        }

        // Xóa nhân viên khỏi cơ sở dữ liệu
        public bool XoaNhanVien(string maNV)
        {
            db.OpenDB();
            string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0; // Trả về true nếu xóa thành công
        }

        // Lấy danh sách nhân viên từ cơ sở dữ liệu
        public DataTable LayDanhSachNhanVien()
        {
            db.OpenDB();
            string query = "SELECT * FROM NhanVien";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            db.CloseDB();

            return dt; // Trả về DataTable chứa danh sách nhân viên
        }
        // Tìm kiếm nhân viên theo mã nhân viên
        public DataTable TimKiemNhanVien(string maNV)
        {
            db.OpenDB();
            string query = "SELECT * FROM NhanVien WHERE MaNV LIKE @MaNV";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@MaNV", "%" + maNV + "%");
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            db.CloseDB();
            return dt; // Trả về DataTable chứa danh sách nhân viên tìm kiếm
        }

    }
}
