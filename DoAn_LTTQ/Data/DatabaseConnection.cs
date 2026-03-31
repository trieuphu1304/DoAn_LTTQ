using System;
using System.Data.SqlClient;

namespace DoAn_LTTQ.Data
{
    public class DatabaseConnection
    {
        private static string connectionString = "Server=DESKTOP-LP7ESLP;Database=QuanLyNhaHang;User Id=sa;Password=123456;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
