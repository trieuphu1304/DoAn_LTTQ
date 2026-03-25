using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Data
{
    public class FoodDAL
    {
        public static List<Food> GetAllFoods()
        {
            List<Food> foods = new List<Food>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, Name, CategoryID, Price, ImagePath FROM Food";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Food food = new Food
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            CategoryID = (int)reader["CategoryID"],
                            Price = reader["Price"] != DBNull.Value ? Convert.ToSingle(reader["Price"]) : 0f,
                            ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : ""
                        };
                        foods.Add(food);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách món ăn: " + ex.Message);
            }
            return foods;
        }

        public static List<Food> GetFoodsByCategory(int categoryID)
        {
            List<Food> foods = new List<Food>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, Name, CategoryID, Price, ImagePath FROM Food WHERE CategoryID = @CategoryID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Food food = new Food
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            CategoryID = (int)reader["CategoryID"],
                            Price = reader["Price"] != DBNull.Value ? Convert.ToSingle(reader["Price"]) : 0f,
                            ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : ""
                        };
                        foods.Add(food);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách món ăn theo danh mục: " + ex.Message);
            }
            return foods;
        }

        public static bool AddFood(Food food)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Food (Name, CategoryID, Price, ImagePath) VALUES (@Name, @CategoryID, @Price, @ImagePath)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Name", food.Name);
                    cmd.Parameters.AddWithValue("@CategoryID", food.CategoryID);
                    cmd.Parameters.AddWithValue("@Price", food.Price);
                    cmd.Parameters.AddWithValue("@ImagePath", food.ImagePath ?? "");

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm món ăn: " + ex.Message);
            }
        }

        public static bool UpdateFood(int id, Food food)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Food SET Name = @Name, CategoryID = @CategoryID, Price = @Price, ImagePath = @ImagePath WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", food.Name);
                    cmd.Parameters.AddWithValue("@CategoryID", food.CategoryID);
                    cmd.Parameters.AddWithValue("@Price", food.Price);
                    cmd.Parameters.AddWithValue("@ImagePath", food.ImagePath ?? "");

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật món ăn: " + ex.Message);
            }
        }

        public static bool DeleteFood(int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Food WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa món ăn: " + ex.Message);
            }
        }
    }
}
