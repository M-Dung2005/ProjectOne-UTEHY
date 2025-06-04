using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Account
    {
        private readonly Database db = new Database();
        public bool CheckLogin(string username, string password, string quyen)
        {
            string query = "SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password AND QuyenHan = @quyen";
            SqlCommand cmd = new SqlCommand(query, db.conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@quyen", quyen);
            db.OpenDB();
            object result = cmd.ExecuteScalar();
            db.CloseDB();

            return result != null;
        }
    }
}
