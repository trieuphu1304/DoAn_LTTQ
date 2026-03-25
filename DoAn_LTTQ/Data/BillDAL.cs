using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Data
{
    public class BillDAL
    {
        public static List<Bill> GetAllBills()
        {
            List<Bill> bills = new List<Bill>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, DateCheckIn, DateCheckOut, TableID, Status, Discount, CustomerID FROM Bill";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Bill bill = new Bill
                        {
                            ID = (int)reader["ID"],
                            DateCheckIn = (DateTime)reader["DateCheckIn"],
                            DateCheckOut = reader["DateCheckOut"] != DBNull.Value ? (DateTime?)reader["DateCheckOut"] : null,
                            TableID = (int)reader["TableID"],
                            Status = (int)reader["Status"],
                            Discount = reader["Discount"] != DBNull.Value ? (int?)reader["Discount"] : null,
                            CustomerID = reader["CustomerID"] != DBNull.Value ? (int?)reader["CustomerID"] : null
                        };
                        bills.Add(bill);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách hóa đơn: " + ex.Message);
            }
            return bills;
        }

        public static List<Bill> GetBillsByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<Bill> bills = new List<Bill>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, DateCheckIn, DateCheckOut, TableID, Status, Discount, CustomerID FROM Bill WHERE DateCheckIn BETWEEN @FromDate AND @ToDate";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.AddDays(1));
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Bill bill = new Bill
                        {
                            ID = (int)reader["ID"],
                            DateCheckIn = (DateTime)reader["DateCheckIn"],
                            DateCheckOut = reader["DateCheckOut"] != DBNull.Value ? (DateTime?)reader["DateCheckOut"] : null,
                            TableID = (int)reader["TableID"],
                            Status = (int)reader["Status"],
                            Discount = reader["Discount"] != DBNull.Value ? (int?)reader["Discount"] : null,
                            CustomerID = reader["CustomerID"] != DBNull.Value ? (int?)reader["CustomerID"] : null
                        };
                        bills.Add(bill);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách hóa đơn theo ngày: " + ex.Message);
            }
            return bills;
        }

        public static bool AddBill(Bill bill)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Bill (DateCheckIn, DateCheckOut, TableID, Status, Discount, CustomerID) VALUES (@DateCheckIn, @DateCheckOut, @TableID, @Status, @Discount, @CustomerID)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@DateCheckIn", bill.DateCheckIn);
                    cmd.Parameters.AddWithValue("@DateCheckOut", bill.DateCheckOut ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TableID", bill.TableID);
                    cmd.Parameters.AddWithValue("@Status", bill.Status);
                    cmd.Parameters.AddWithValue("@Discount", bill.Discount ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerID", bill.CustomerID ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm hóa đơn: " + ex.Message);
            }
        }

        public static bool UpdateBill(int id, Bill bill)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Bill SET DateCheckIn = @DateCheckIn, DateCheckOut = @DateCheckOut, TableID = @TableID, Status = @Status, Discount = @Discount, CustomerID = @CustomerID WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@DateCheckIn", bill.DateCheckIn);
                    cmd.Parameters.AddWithValue("@DateCheckOut", bill.DateCheckOut ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TableID", bill.TableID);
                    cmd.Parameters.AddWithValue("@Status", bill.Status);
                    cmd.Parameters.AddWithValue("@Discount", bill.Discount ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerID", bill.CustomerID ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật hóa đơn: " + ex.Message);
            }
        }

        public static bool DeleteBill(int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Bill WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa hóa đơn: " + ex.Message);
            }
        }
    }
}
