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
        // Thêm phương thức này vào lớp BLL_QLNV
        public DataTable LayNhanVienForComboBox()
        {
            db.OpenDB();
            string query = "SELECT MaNV, TenNV FROM NhanVien";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }


        // Trong file BLL/BLL_QLNV.cs

        // Sửa kiểu trả về từ bool thành string
        public string ThemNhanVien(string tenNV, string soDienThoai, string diaChi, string gioiTinh, string ngaySinh, int maTK)
        {
            string sql = "INSERT INTO NhanVien (TenNV, SoDienThoai, NgaySinh, DiaChi, GioiTinh, MaTK) VALUES (@TenNV, @SoDienThoai, @NgaySinh, @DiaChi, @GioiTinh, @MaTK)";
            try
            {
                db.OpenDB();
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                // Không cần tham số @MaNV
                cmd.Parameters.AddWithValue("@TenNV", tenNV);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@MaTK", maTK);
                cmd.ExecuteNonQuery();
                return null;
            }
            catch (SqlException ex)
            {
                // Bắt lỗi và trả về thông báo lỗi cụ thể
                if (ex.Number == 2627) // Lỗi vi phạm khóa chính (PRIMARY KEY) hoặc UNIQUE
                {
                    if (ex.Message.Contains("PK_NhanVien")) // Tên ràng buộc khóa chính
                    if (ex.Message.Contains("UQ_NhanVien_SoDienThoai")) // Tên ràng buộc UNIQUE
                        return $"Lỗi: Số điện thoại '{soDienThoai}' đã được sử dụng.";
                }
                if (ex.Number == 547) // Lỗi vi phạm khóa ngoại (FOREIGN KEY)
                {
                    if (ex.Message.Contains("FK_NhanVien_TaiKhoan"))
                        return $"Lỗi: Mã tài khoản '{maTK}' không tồn tại.";
                }
                return "Lỗi CSDL: " + ex.Message; // Lỗi chung
            }
            catch (Exception ex)
            {
                return "Lỗi không xác định: " + ex.Message; // Các lỗi khác
            }
            finally
            {
                db.CloseDB();
            }
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
