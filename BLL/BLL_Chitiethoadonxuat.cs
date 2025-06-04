using System;
using System.Collections.Generic;
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
            string sql = @"INSERT INTO ChiTietChiTietHoaDonXuat (MaHDX, MaHang, SoLuong, DonGia, ThanhTien)
                       VALUES (@MaHDX, @MaHang, @SoLuong, @DonGia, @ThanhTien)";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHDX", ct.MaHDX);
            cmd.Parameters.AddWithValue("@MaHang", ct.MaHang);
            cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
            cmd.Parameters.AddWithValue("@DonGia", ct.DonGia);
            cmd.Parameters.AddWithValue("@ThanhTien", ct.ThanhTien);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0;
        }
    }
}
