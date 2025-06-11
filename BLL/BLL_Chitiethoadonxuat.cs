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
    public class BLL_Chitiethoadonxuat
    {
        private readonly Database db = new Database();

        public bool ThemChiTietHoaDonXuat(ChiTietHoaDonXuat ct)
        {
            db.OpenDB();
            // Đảm bảo tên bảng là 'ChiTietHoaDonXuat', không phải 'ChiTietChiTiet...'
            string sql = @"INSERT INTO ChiTietHoaDonXuat (MaHDX, MaHang, SoLuong, DonGia, ThanhTien)
                           VALUES (@MaHDX, @MaHang, @SoLuong, @DonGia, @ThanhTien)";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@MaHDX", ct.MaHDX);
                cmd.Parameters.AddWithValue("@MaHang", ct.MaHang);
                cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
                cmd.Parameters.AddWithValue("@ThanhTien", ct.ThanhTien);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                db.CloseDB();
            }
        }

        public DataTable LayChiTietHoaDonXuat(int maHDX)
        {
            db.OpenDB();
            string sql = @"SELECT ct.MaHang, h.TenHang, ct.SoLuong, ct.DonGia, ct.ThanhTien
                FROM ChiTietHoaDonXuat ct
                JOIN HangHoa h ON ct.MaHang = h.MaHang
                WHERE ct.MaHDX = @MaHDX";

            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHDX", maHDX);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }
    }
}
