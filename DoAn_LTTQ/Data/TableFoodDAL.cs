using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Data
{
    public class TableFoodDAL
    {
        public static List<TableFood> GetAllTables()
        {
            List<TableFood> tables = new List<TableFood>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, Name, Status FROM TableFood";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TableFood table = new TableFood
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        tables.Add(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách bàn ăn: " + ex.Message);
            }
            return tables;
        }

        public static bool AddTable(TableFood table)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO TableFood (Name, Status) VALUES (@Name, @Status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", table.Name);
                    cmd.Parameters.AddWithValue("@Status", table.Status);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm bàn ăn: " + ex.Message);
            }
        }

        public static bool UpdateTable(int id, TableFood table)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE TableFood SET Name = @Name, Status = @Status WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", table.Name);
                    cmd.Parameters.AddWithValue("@Status", table.Status);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật bàn ăn: " + ex.Message);
            }
        }

        public static bool DeleteTable(int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM TableFood WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa bàn ăn: " + ex.Message);
            }
        }
    }
}
