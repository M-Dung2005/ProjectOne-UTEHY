// File mới: BLL/BLL_LoaiHang.cs
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLL_LoaiHang
    {
        private readonly Database db = new Database();

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
    }
}