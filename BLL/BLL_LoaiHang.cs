// File mới: BLL/BLL_LoaiHang.cs
using DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLL_LoaiHang
    {
        private readonly Database db = new Database();

        public DataTable LayLoaiHangTheoNgay(DateTime fromDate, DateTime toDate)
        {
            db.OpenDB();
            string sql = @"
        SELECT DISTINCT lh.MaLoai, lh.TenLoai
        FROM LoaiHang lh
        JOIN HangHoa hh ON lh.MaLoai = hh.MaLoai
        WHERE hh.MaHang IN (
            -- Lấy mã hàng từ hóa đơn nhập trong khoảng ngày
            SELECT ctn.MaHang FROM ChiTietHoaDonNhap ctn
            JOIN HoaDonNhap hdn ON ctn.MaHDN = hdn.MaHDN
            WHERE hdn.NgayTao BETWEEN @FromDate AND @ToDate
            UNION
            -- Lấy mã hàng từ hóa đơn xuất trong khoảng ngày
            SELECT ctx.MaHang FROM ChiTietHoaDonXuat ctx
            JOIN HoaDonXuat hdx ON ctx.MaHDX = hdx.MaHDX
            WHERE hdx.NgayTao BETWEEN @FromDate AND @ToDate
        )
        ORDER BY lh.TenLoai;";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@FromDate", fromDate);
            cmd.Parameters.AddWithValue("@ToDate", toDate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }
        public DataTable LayDanhSachLoaiHang()
        {
            db.OpenDB();
            string sql = "SELECT MaLoai, TenLoai FROM LoaiHang";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }

        public bool KiemTraLoaiHangTonTai(int maLoai)
        {
            db.OpenDB();
            string sql = "SELECT COUNT(*) FROM LoaiHang WHERE MaLoai = @MaLoai";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaLoai", maLoai);
            int count = (int)cmd.ExecuteScalar();
            db.CloseDB();
            return count > 0;
        }
    }
}