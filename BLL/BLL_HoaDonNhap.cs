// File: BLL/BLL_HoaDonNhap.cs
using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace BLL
{
    public class BLL_HoaDonNhap
    {
        private readonly Database db = new Database();

        public DataTable LayDanhSachHoaDonNhap()
        {
            db.OpenDB();
            string sql = @"
                SELECT
                    hdn.MaHDN,
                    hdn.NgayTao,
                    nv.TenNV,
                    ncc.TenNCC,
                    hdn.TongTien
                FROM HoaDonNhap hdn
                JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
                JOIN NhaCungCap ncc ON hdn.MaNCC = ncc.MaNCC
                ORDER BY hdn.NgayTao DESC";

            SqlCommand cmd = new SqlCommand(sql, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }


        // Phương thức thêm hóa đơn nhập và trả về mã HDN mới
        public int ThemHoaDonNhap(HoaDonNhap hdn)
        {
            db.OpenDB();
            string sql = @"INSERT INTO HoaDonNhap (MaNCC, MaNV, NgayTao, TongTien) 
                           VALUES (@MaNCC, @MaNV, @NgayTao, @TongTien); 
                           SELECT SCOPE_IDENTITY();";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@MaNCC", hdn.MaNCC);
                cmd.Parameters.AddWithValue("@MaNV", hdn.MaNV);
                cmd.Parameters.AddWithValue("@NgayTao", hdn.NgayTao);
                cmd.Parameters.AddWithValue("@TongTien", hdn.TongTien);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception)
            {
                return 0; // Trả về 0 nếu có lỗi
            }
            finally
            {
                db.CloseDB();
            }
            return 0;
        }

    }
}