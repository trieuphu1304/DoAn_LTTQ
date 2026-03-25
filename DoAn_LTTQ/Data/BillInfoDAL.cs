using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Data
{
    public class BillInfoDAL
    {
        public static List<BillInfo> GetBillInfoByBillID(int billID)
        {
            List<BillInfo> billInfos = new List<BillInfo>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, BillID, FoodID, Count FROM BillInfo WHERE BillID = @BillID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BillID", billID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BillInfo billInfo = new BillInfo
                        {
                            ID = (int)reader["ID"],
                            BillID = (int)reader["BillID"],
                            FoodID = (int)reader["FoodID"],
                            Count = (int)reader["Count"]
                        };
                        billInfos.Add(billInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy chi tiết hóa đơn: " + ex.Message);
            }
            return billInfos;
        }

        public static bool AddBillInfo(BillInfo billInfo)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO BillInfo (BillID, FoodID, Count) VALUES (@BillID, @FoodID, @Count)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@BillID", billInfo.BillID);
                    cmd.Parameters.AddWithValue("@FoodID", billInfo.FoodID);
                    cmd.Parameters.AddWithValue("@Count", billInfo.Count);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm chi tiết hóa đơn: " + ex.Message);
            }
        }

        public static bool UpdateBillInfo(int id, BillInfo billInfo)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE BillInfo SET BillID = @BillID, FoodID = @FoodID, Count = @Count WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@BillID", billInfo.BillID);
                    cmd.Parameters.AddWithValue("@FoodID", billInfo.FoodID);
                    cmd.Parameters.AddWithValue("@Count", billInfo.Count);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật chi tiết hóa đơn: " + ex.Message);
            }
        }

        public static bool DeleteBillInfo(int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM BillInfo WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa chi tiết hóa đơn: " + ex.Message);
            }
        }

        public static bool DeleteBillInfoByBillID(int billID)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM BillInfo WHERE BillID = @BillID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BillID", billID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}
