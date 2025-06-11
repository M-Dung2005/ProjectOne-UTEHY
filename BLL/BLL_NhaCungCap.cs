using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLL_NhaCungCap
    {
        private readonly Database db = new Database();

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
    }
}