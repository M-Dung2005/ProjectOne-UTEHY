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
    public class BLL_QLUsers
    {
        private readonly Database db = new Database();
        // Thêm người dùng vào cơ sở dữ liệu
        public bool ThemUsers(TaiKhoan user)
        {
            db.OpenDB();
            string sql = "INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhau, QuyenHan) VALUES (@MaTK, @TenDangNhap, @Matkhau, @QuyenHan)";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaTK", user.MaTK);
            cmd.Parameters.AddWithValue("@TenDangNhap", user.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
            cmd.Parameters.AddWithValue("@QuyenHan", user.QuyenHan);

            try
            {
                int rows = cmd.ExecuteNonQuery();
                db.CloseDB();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message);
                db.CloseDB();
                return false;
            }
        }

        public DataTable LayDanhSachUser()
        {
            db.OpenDB();
            string sql = "SELECT * FROM TaiKhoan";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }

        //Xóa người dùng
        public bool XoaUser(string MaTK)
        {
            db.OpenDB();
            string sql = "DELETE FROM TaiKhoan WHERE MaTK = @MaTK";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaTK", MaTK);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0; // Trả về true nếu xóa thành công
        }

        //Cập nhật người dùng
        public bool CapNhatUser(TaiKhoan user)
        {
            db.OpenDB();
            string sql = "UPDATE TaiKhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, QuyenHan = @QuyenHan WHERE MaTK = @MaTK";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaTK", user.MaTK);
            cmd.Parameters.AddWithValue("@TenDangNhap", user.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
            cmd.Parameters.AddWithValue("@QuyenHan", user.QuyenHan);

            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0;
        }
    }
}
