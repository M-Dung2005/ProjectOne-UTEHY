using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;

public partial class Database
{
    private readonly string connectionString = "Data Source=DESKTOP-LO7A6QH\\SQLEXPRESS;Initial Catalog=QuanLySieuThi;Integrated Security=True;";
    public SqlConnection conn;

    public Database()
    {
        conn = new SqlConnection(connectionString);
    }

    public void OpenDB()
    {
        conn.Open();
    }

    public void CloseDB()
    {
        conn.Close();
    }


}
