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
    public class BLL_HangHoa
    {
        private readonly Database db = new Database();
        public DataTable LayDanhSachHangHoa()
        {
            db.OpenDB();
            string query = "SELECT * FROM HangHoa";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);
            db.CloseDB();

            return dt;
        }

        public bool ThemHangHoa(HangHoa hh)
        {
            string sql = "INSERT INTO HangHoa (MaHang, TenHang, MaNCC, MaLoai, NgaySanXuat, HanSuDung, DonGia ) " +
                         "VALUES (@Mahang, @TenHang, @MaNCC, @MaLoai, @NgaySanXuat, @HanSuDung, @DonGia)";
            SqlCommand cmd = new SqlCommand(sql, db.conn);

            cmd.Parameters.AddWithValue("@MaHang", hh.MaHang);
            cmd.Parameters.AddWithValue("@TenHang", hh.TenHang);
            cmd.Parameters.AddWithValue("@MaNCC", hh.MaNCC);
            cmd.Parameters.AddWithValue("@MaLoai", hh.MaLoai);
            cmd.Parameters.AddWithValue("@NgaySanXuat", hh.NgaySanXuat);
            cmd.Parameters.AddWithValue("@HanSuDung", hh.HanSuDung);
            cmd.Parameters.AddWithValue("@DonGia", hh.DonGia);

            db.OpenDB();
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();

            return rows > 0;
        }

        public bool CapnhatHangHoa(HangHoa hh)
        {
            string sql = "UPDATE HangHoa SET TenHang = @TenHang, DonVi = @DonVi, MaLoai = @MaLoai, DonGia = @DonGia WHERE MaHang = @MaHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHang", hh.MaHang);
            cmd.Parameters.AddWithValue("@TenHang", hh.TenHang);
            cmd.Parameters.AddWithValue("@MaNCC", hh.MaNCC);
            cmd.Parameters.AddWithValue("@MaLoai", hh.MaLoai);
            cmd.Parameters.AddWithValue("@NgaySanXuat", hh.NgaySanXuat);
            cmd.Parameters.AddWithValue("@HanSuDung", hh.HanSuDung);
            cmd.Parameters.AddWithValue("@DonGia", hh.DonGia);
            db.OpenDB();
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0;
        }

        public bool XoaHangHoa(string maHang)
        {
            string sql = "DELETE FROM HangHoa WHERE MaHang = @MaHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHang", maHang);
            db.OpenDB();
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0;
        }
    }
}
