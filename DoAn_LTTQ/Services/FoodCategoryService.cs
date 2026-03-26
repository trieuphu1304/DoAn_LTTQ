using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Services
{
    public class FoodCategoryService
    {
        public static List<FoodCategory> GetAllCategories()
        {
            List<FoodCategory> categories = new List<FoodCategory>();
            string query = "SELECT ID, Name FROM FoodCategory";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                categories.Add(new FoodCategory
                {
                    ID = (int)row["ID"],
                    Name = row["Name"].ToString()
                });
            }

            return categories;
        }
    }
}
