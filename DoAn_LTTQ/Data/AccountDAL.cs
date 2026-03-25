using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Data
{
    public class AccountDAL
    {
        public static List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT UserName, DisplayName, Password, Type, EmployeeID FROM Account";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Account account = new Account
                        {
                            UserName = reader["UserName"].ToString(),
                            DisplayName = reader["DisplayName"].ToString(),
                            Password = reader["Password"].ToString(),
                            Type = reader["Type"] != DBNull.Value ? (int)reader["Type"] : 0,
                            EmployeeID = reader["EmployeeID"] != DBNull.Value ? (int?)reader["EmployeeID"] : null
                        };
                        accounts.Add(account);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách tài khoản: " + ex.Message);
            }
            return accounts;
        }

        public static bool AddAccount(Account account)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Account (UserName, DisplayName, Password, Type, EmployeeID) VALUES (@UserName, @DisplayName, @Password, @Type, @EmployeeID)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@UserName", account.UserName);
                    cmd.Parameters.AddWithValue("@DisplayName", account.DisplayName);
                    cmd.Parameters.AddWithValue("@Password", account.Password);
                    cmd.Parameters.AddWithValue("@Type", account.Type);
                    cmd.Parameters.AddWithValue("@EmployeeID", account.EmployeeID ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm tài khoản: " + ex.Message);
            }
        }

        public static bool UpdateAccount(string oldUserName, Account account)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Account SET UserName = @UserName, DisplayName = @DisplayName, Password = @Password, Type = @Type, EmployeeID = @EmployeeID WHERE UserName = @OldUserName";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@OldUserName", oldUserName);
                    cmd.Parameters.AddWithValue("@UserName", account.UserName);
                    cmd.Parameters.AddWithValue("@DisplayName", account.DisplayName);
                    cmd.Parameters.AddWithValue("@Password", account.Password);
                    cmd.Parameters.AddWithValue("@Type", account.Type);
                    cmd.Parameters.AddWithValue("@EmployeeID", account.EmployeeID ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật tài khoản: " + ex.Message);
            }
        }

        public static bool DeleteAccount(string userName)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Account WHERE UserName = @UserName";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa tài khoản: " + ex.Message);
            }
        }
    }
}
