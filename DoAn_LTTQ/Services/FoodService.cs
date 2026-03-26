using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Services
{
    public class FoodService
    {
        public static List<Food> GetAllFoods()
        {
            List<Food> foods = new List<Food>();
            string query = "SELECT ID, Name, CategoryID, Price, ImagePath FROM Food";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                foods.Add(new Food
                {
                    ID = (int)row["ID"],
                    Name = row["Name"].ToString(),
                    CategoryID = (int)row["CategoryID"],
                    Price = (decimal)row["Price"],
                    ImagePath = row["ImagePath"].ToString()
                });
            }

            return foods;
        }

        public static List<Food> GetFoodByCategory(int categoryID)
        {
            List<Food> foods = new List<Food>();
            string query = "SELECT ID, Name, CategoryID, Price, ImagePath FROM Food WHERE CategoryID = @CategoryID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryID", categoryID)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                foods.Add(new Food
                {
                    ID = (int)row["ID"],
                    Name = row["Name"].ToString(),
                    CategoryID = (int)row["CategoryID"],
                    Price = (decimal)row["Price"],
                    ImagePath = row["ImagePath"].ToString()
                });
            }

            return foods;
        }

        public static Food GetFoodByID(int id)
        {
            string query = "SELECT ID, Name, CategoryID, Price, ImagePath FROM Food WHERE ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", id)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Food
                {
                    ID = (int)row["ID"],
                    Name = row["Name"].ToString(),
                    CategoryID = (int)row["CategoryID"],
                    Price = (decimal)row["Price"],
                    ImagePath = row["ImagePath"].ToString()
                };
            }

            return null;
        }
    }
}
