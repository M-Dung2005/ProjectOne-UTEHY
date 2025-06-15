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
        public DataTable LayDanhSachChiTietHoaDonNhap(int maHDN)
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
        JOIN HangHoa hh ON cthdn.MaHang = hh.MaHang
        WHERE cthdn.MaHDN = @MaHDN";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHDN", maHDN);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }

        public bool ThemChiTietHoaDonNhap(ChiTietHoaDonNhap ctn)
        {
            db.OpenDB();
            string sql = @"INSERT INTO ChiTietHoaDonNhap (MaHDN, MaHang, SoLuong, DonGia, ThanhTien)
                           VALUES (@MaHDN, @MaHang, @SoLuong, @DonGia, @ThanhTien)";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, db.conn);
                cmd.Parameters.AddWithValue("@MaHDN", ctn.MaHDN);
                cmd.Parameters.AddWithValue("@MaHang", ctn.MaHang);
                cmd.Parameters.AddWithValue("@SoLuong", ctn.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", ctn.DonGia);
                cmd.Parameters.AddWithValue("@ThanhTien", ctn.ThanhTien);

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
