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
    public class BLL_HoaDonXuat
    {
        private readonly Database db = new Database();

        // Lấy danh sách hóa đơn xuất từ cơ sở dữ liệu
        public DataTable LayDanhSachHoaDonXuat()
        {
                db.OpenDB();
                string sql = @"
            SELECT 
                hd.MaHDX, 
                hd.NgayTao, 
                nv.TenNV AS TenNhanVien,
                kh.TenKH AS TenKhachHang,
                hd.MaNV,  
                hd.MaKH,   
                SUM(ct.SoLuong * ct.DonGia) AS TongTien
            FROM HoaDonXuat hd
            JOIN NhanVien nv ON hd.MaNV = nv.MaNV
            JOIN KhachHang kh ON hd.MaKH = kh.MaKH
            JOIN ChiTietHoaDonXuat ct ON hd.MaHDX = ct.MaHDX
            GROUP BY hd.MaHDX, hd.NgayTao, nv.TenNV, kh.TenKH, hd.MaNV, hd.MaKH";

            SqlCommand cmd = new SqlCommand(sql, db.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                db.CloseDB();
                return dt;
        }

        // Thêm hóa đơn xuất vào cơ sở dữ liệu
        public bool ThemHoaDonXuat(HoaDonXuat hd)
        {
            db.OpenDB();

            // 1. Thêm hóa đơn (chưa có Tổng Tiền)
            string sqlInsert = "INSERT INTO HoaDonXuat (MaHDX, NgayTao, MaNV, MaKH) VALUES (@MaHDX, @NgayTao, @MaNV, @MaKH)";
            SqlCommand cmdInsert = new SqlCommand(sqlInsert, db.conn);
            cmdInsert.Parameters.AddWithValue("@MaHDX", hd.MaHDX);
            cmdInsert.Parameters.AddWithValue("@NgayTao", hd.NgayTao);
            cmdInsert.Parameters.AddWithValue("@MaNV", hd.MaNV);
            cmdInsert.Parameters.AddWithValue("@MaKH", hd.MaKH);
            int rows = cmdInsert.ExecuteNonQuery();

            // 2. Tính Tổng Tiền sau khi đã có các dòng ChiTietHDX
            decimal tongTien = TinhTongTien(hd.MaHDX.ToString());

            // 3. Cập nhật lại Tổng Tiền
            string sqlUpdate = "UPDATE HoaDonXuat SET TongTien = @TongTien WHERE MaHDX = @MaHDX";
            SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, db.conn);
            cmdUpdate.Parameters.AddWithValue("@TongTien", tongTien);
            cmdUpdate.Parameters.AddWithValue("@MaHDX", hd.MaHDX);
            cmdUpdate.ExecuteNonQuery();

            db.CloseDB();
            return rows > 0;
        }


        public decimal TinhTongTien(string maHDX)
        {
            decimal tongTien = 0;
            string sql = "SELECT SoLuong, DonGia FROM ChiTietHDX WHERE MaHDX = @MaHDX";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHDX", maHDX);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int soLuong = Convert.ToInt32(reader["SoLuong"]);
                decimal donGia = Convert.ToDecimal(reader["DonGia"]);
                tongTien += soLuong * donGia;
            }

            reader.Close();
            return tongTien;
        }

        public bool CapNhatHoaDonXuat(HoaDonXuat hd)
        {
            db.OpenDB();
            string sql = "UPDATE HoaDonXuat SET NgayTao = @NgayTao, MaNV = @MaNV, MaKH = @MaKH WHERE MaHDX = @MaHDX";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaHDX", hd.MaHDX);
            cmd.Parameters.AddWithValue("@NgayTao", hd.NgayTao);
            cmd.Parameters.AddWithValue("@MaNV", hd.MaNV);
            cmd.Parameters.AddWithValue("@MaKH", hd.MaKH);
            int rows = cmd.ExecuteNonQuery();
            db.CloseDB();
            return rows > 0;
        }


    }
}
