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
        public string ThemUsers(TaiKhoan user)
        {
            // Bỏ MaTK khỏi câu lệnh INSERT
            string sql = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, QuyenHan) VALUES (@TenDangNhap, @MatKhau, @QuyenHan)";
            try
            {
                db.OpenDB();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                // Không cần tham số @MaTK
                cmd.Parameters.AddWithValue("@TenDangNhap", user.TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", user.MatKhau);
                cmd.Parameters.AddWithValue("@QuyenHan", user.QuyenHan);
                cmd.ExecuteNonQuery();
                return null;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Lỗi UNIQUE
                {
                    return $"Lỗi: Tên đăng nhập '{user.TenDangNhap}' đã tồn tại.";
                }
                return "Lỗi CSDL: " + ex.Message;
            }
            finally
            {
                db.CloseDB();
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
