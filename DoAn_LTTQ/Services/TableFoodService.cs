using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Services
{
    public class TableFoodService
    {
        public static List<TableFood> GetAllTables()
        {
            List<TableFood> tables = new List<TableFood>();
            string query = @"SELECT 
                t.ID, 
                t.Name, 
                t.Status,
                ISNULL(COUNT(DISTINCT bi.ID), 0) as DishCount,
                ISNULL(COUNT(DISTINCT b.ID), 0) as CustomerCount,
                ISNULL(SUM(bi.Count * f.Price), 0) as Total
            FROM TableFood t
            LEFT JOIN Bill b ON t.ID = b.TableID AND b.Status = 0
            LEFT JOIN BillInfo bi ON b.ID = bi.BillID
            LEFT JOIN Food f ON bi.FoodID = f.ID
            GROUP BY t.ID, t.Name, t.Status";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                tables.Add(new TableFood
                {
                    ID = (int)row["ID"],
                    Name = row["Name"].ToString(),
                    Status = row["Status"].ToString(),
                    DishCount = row["DishCount"] != DBNull.Value ? (int)row["DishCount"] : 0,
                    CustomerCount = row["CustomerCount"] != DBNull.Value ? (int)row["CustomerCount"] : 0,
                    Total = row["Total"] != DBNull.Value ? (decimal)row["Total"] : 0
                });
            }

            return tables;
        }

        public static TableFood GetTableByID(int id)
        {
            string query = "SELECT ID, Name, Status FROM TableFood WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new TableFood
                {
                    ID = (int)row["ID"],
                    Name = row["Name"].ToString(),
                    Status = row["Status"].ToString()
                };
            }

            return null;
        }

        public static bool UpdateTableStatus(int tableID, string status)
        {
            string query = "UPDATE TableFood SET Status = @Status WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status),
                new SqlParameter("@ID", tableID)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}
