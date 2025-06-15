using System;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLL_NhaCungCap
    {
        private readonly Database db = new Database();

        public DataTable LayNhaCungCapTheoNgay(DateTime fromDate, DateTime toDate)
        {
            db.OpenDB();
            string sql = @"
        SELECT DISTINCT ncc.MaNCC, ncc.TenNCC
        FROM NhaCungCap ncc
        JOIN HoaDonNhap hdn ON ncc.MaNCC = hdn.MaNCC
        WHERE hdn.NgayTao BETWEEN @FromDate AND @ToDate
        ORDER BY ncc.TenNCC;";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@FromDate", fromDate);
            cmd.Parameters.AddWithValue("@ToDate", toDate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }
        public DataTable LayNhaCungCapForComboBox()
        {
            db.OpenDB();
            string query = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            db.CloseDB();
            return dt;
        }

        public bool KiemTraNhaCungCapTonTai(int maNCC)
        {
            db.OpenDB();
            string sql = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC";
            SqlCommand cmd = new SqlCommand(sql, db.conn);
            cmd.Parameters.AddWithValue("@MaNCC", maNCC);
            int count = (int)cmd.ExecuteScalar();
            db.CloseDB();
            return count > 0;
        }
    }
}