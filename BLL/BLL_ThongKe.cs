// File mới: BLL/BLL_ThongKe.cs
using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLL_ThongKe
    {
        private readonly Database db = new Database();


        public DataTable ThongKeNhapXuat(DateTime fromDate, DateTime toDate, int? maLoai, int? maNCC)
        {
            db.OpenDB();
            string sql = @"
            -- Dữ liệu Nhập
            SELECT
                'Nhap' AS LoaiGiaoDich,
                hdn.MaHDN AS MaPhieu,
                hdn.NgayTao,
                hh.MaHang,
                hh.TenHang,
                ct.SoLuong,
                ct.DonGia,
                ct.ThanhTien
            FROM HoaDonNhap hdn
            JOIN ChiTietHoaDonNhap ct ON hdn.MaHDN = ct.MaHDN
            JOIN HangHoa hh ON ct.MaHang = hh.MaHang
            WHERE hdn.NgayTao BETWEEN @FromDate AND @ToDate
              AND (@MaLoai IS NULL OR hh.MaLoai = @MaLoai)
              AND (@MaNCC IS NULL OR hh.MaNCC = @MaNCC)

            UNION ALL

            -- Dữ liệu Xuất
            SELECT
                'Xuat' AS LoaiGiaoDich,
                hdx.MaHDX AS MaPhieu,
                hdx.NgayTao AS NgayTao,
                hh.MaHang,
                hh.TenHang,
                ct.SoLuong,
                ct.DonGia,
                ct.ThanhTien
            FROM HoaDonXuat hdx
            JOIN ChiTietHoaDonXuat ct ON hdx.MaHDX = ct.MaHDX
            JOIN HangHoa hh ON ct.MaHang = hh.MaHang
            WHERE hdx.NgayTao BETWEEN @FromDate AND @ToDate
              AND (@MaLoai IS NULL OR hh.MaLoai = @MaLoai)";

            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@FromDate", fromDate);
            cmd.Parameters.AddWithValue("@ToDate", toDate);
            cmd.Parameters.AddWithValue("@MaLoai", (object)maLoai ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MaNCC", (object)maNCC ?? DBNull.Value);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }
    }
}