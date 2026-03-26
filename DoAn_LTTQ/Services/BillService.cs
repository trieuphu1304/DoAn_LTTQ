using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Services
{
    public class BillService
    {
        public static int CreateBill(int tableID, int? customerID = null)
        {
            string query = "INSERT INTO Bill (DateCheckIn, TableID, Status, Discount, CustomerID) " +
                          "VALUES (GETDATE(), @TableID, 0, 0, @CustomerID); " +
                          "SELECT SCOPE_IDENTITY()";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TableID", tableID),
                new SqlParameter("@CustomerID", customerID ?? (object)DBNull.Value)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            if (result != null && int.TryParse(result.ToString(), out int billID))
            {
                return billID;
            }

            return -1;
        }

        public static bool AddBillInfo(int billID, int foodID, int count)
        {
            string query = "INSERT INTO BillInfo (BillID, FoodID, Count) VALUES (@BillID, @FoodID, @Count)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillID", billID),
                new SqlParameter("@FoodID", foodID),
                new SqlParameter("@Count", count)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public static Bill GetBillByID(int billID)
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

        public static List<BillInfo> GetBillInfoByBillID(int billID)
        {
            List<BillInfo> billInfos = new List<BillInfo>();
            string query = "SELECT ID, BillID, FoodID, Count FROM BillInfo WHERE BillID = @BillID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillID", billID)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                billInfos.Add(new BillInfo
                {
                    ID = (int)row["ID"],
                    BillID = (int)row["BillID"],
                    FoodID = (int)row["FoodID"],
                    Count = (int)row["Count"]
                });
            }

            return billInfos;
        }

        public static DataTable GetBillInfoWithFoodByBillID(int billID)
        {
            string query = @"SELECT f.Name as FoodName, f.Price, bi.Count, (f.Price * bi.Count) as Total
                           FROM BillInfo bi 
                           JOIN Food f ON bi.FoodID = f.ID 
                           WHERE bi.BillID = @BillID
                           ORDER BY f.Name";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillID", billID)
            };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public static int GetBillIDByTable(int tableID)
        {
            string query = "SELECT TOP 1 ID FROM Bill WHERE TableID = @TableID AND Status = 0 ORDER BY DateCheckIn DESC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TableID", tableID)
            };
            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            if (result != null && int.TryParse(result.ToString(), out int billID))
            {
                return billID;
            }
            return -1;
        }

        public static decimal GetBillTotal(int billID)
        {
            string query = @"SELECT SUM(bi.Count * f.Price) as Total 
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

        public static bool CloseBill(int billID)
        {
            string query = "UPDATE Bill SET DateCheckOut = GETDATE(), Status = 1 WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", billID)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public static bool DeleteBill(int billID)
        {
            string query = "DELETE FROM BillInfo WHERE BillID = @BillID; DELETE FROM Bill WHERE ID = @BillID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BillID", billID)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
