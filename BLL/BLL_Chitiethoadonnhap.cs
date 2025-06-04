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
    public class BLL_Chitiethoadonnhap
    {
        private readonly Database db = new Database();
        public DataTable LayDanhSachChiTietHoaDonNhap()
        {
            db.OpenDB();
            string sql = @"
        SELECT 
            cthdn.MaHDN, 
            cthdn.MaHang, 
            hh.TenHang AS TenHang,
            cthdn.SoLuong, 
            cthdn.DonGia, 
            cthdn.ThanhTien
        FROM ChiTietHoaDonNhap cthdn
        JOIN HangHoa hh ON cthdn.MaHang = hh.MaHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }

        public void Thanhtien(int maHDN, int maHang, int soLuong, decimal donGia)
        {
            db.OpenDB();
            string sql = "INSERT INTO ChiTietHoaDonNhap (MaHDN, MaHang, SoLuong, DonGia, ThanhTien) VALUES (@MaHDN, @MaHang, @SoLuong, @DonGia, @ThanhTien)";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHDN", maHDN);
            cmd.Parameters.AddWithValue("@MaHang", maHang);
            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@ThanhTien", soLuong * donGia);
            cmd.ExecuteNonQuery();
            db.CloseDB();
        }


    }
}
