using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Services
{
    public class BillHistoryService
    {
        public static DataTable GetAllBills()
        {
            string query = @"
                SELECT 
                    b.ID, 
                    tf.Name AS TableName,
                    b.DateCheckIn,
                    b.DateCheckOut,
                    SUM(bi.Count * f.Price) AS Total,
                    b.Status
                FROM Bill b
                LEFT JOIN TableFood tf ON b.TableID = tf.ID
                LEFT JOIN BillInfo bi ON b.ID = bi.BillID
                LEFT JOIN Food f ON bi.FoodID = f.ID
                GROUP BY b.ID, tf.Name, b.DateCheckIn, b.DateCheckOut, b.Status
                ORDER BY b.DateCheckIn DESC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        public static DataTable GetBillsByDate(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT 
                    b.ID, 
                    tf.Name AS TableName,
                    b.DateCheckIn,
                    b.DateCheckOut,
                    SUM(bi.Count * f.Price) AS Total,
                    b.Status
                FROM Bill b
                LEFT JOIN TableFood tf ON b.TableID = tf.ID
                LEFT JOIN BillInfo bi ON b.ID = bi.BillID
                LEFT JOIN Food f ON bi.FoodID = f.ID
                WHERE b.DateCheckIn >= @FromDate AND b.DateCheckIn <= @ToDate
                GROUP BY b.ID, tf.Name, b.DateCheckIn, b.DateCheckOut, b.Status
                ORDER BY b.DateCheckIn DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate.AddDays(1))
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public static DataTable GetBillDetailsById(int billID)
        {
            string query = @"
                SELECT 
                    bi.ID,
                    f.Name AS FoodName,
                    bi.Count,
                    f.Price,
                    (bi.Count * f.Price) AS SubTotal
                FROM BillInfo bi
                JOIN Food f ON bi.FoodID = f.ID
                WHERE bi.BillID = @BillID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillID", billID)
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public static Bill GetBillById(int billID)
        {
            string query = "SELECT ID, DateCheckIn, DateCheckOut, TableID, Status, Discount, CustomerID FROM Bill WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", billID)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Bill
                {
                    ID = (int)row["ID"],
                    DateCheckIn = (DateTime)row["DateCheckIn"],
                    DateCheckOut = row["DateCheckOut"] != DBNull.Value ? (DateTime?)row["DateCheckOut"] : null,
                    TableID = (int)row["TableID"],
                    Status = (int)row["Status"],
                    Discount = row["Discount"] != DBNull.Value ? (int)row["Discount"] : 0,
                    CustomerID = row["CustomerID"] != DBNull.Value ? (int?)row["CustomerID"] : null
                };
            }

            return null;
        }

        public static decimal GetBillTotal(int billID)
        {
            string query = @"
                SELECT SUM(bi.Count * f.Price) as Total 
                FROM BillInfo bi 
                JOIN Food f ON bi.FoodID = f.ID 
                WHERE bi.BillID = @BillID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillID", billID)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            if (result != null && result != DBNull.Value)
            {
                return (decimal)result;
            }

            return 0;
        }
    }
}
