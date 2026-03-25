using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Data
{
    public class CustomerDAL
    {
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, Name, Phone, Address, Points FROM Customer";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer cust = new Customer
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"] != System.DBNull.Value ? reader["Address"].ToString() : "",
                            Points = (int)reader["Points"]
                        };
                        customers.Add(cust);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách khách hàng: " + ex.Message);
            }
            return customers;
        }

        public static bool AddCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Customer (Name, Phone, Address, Points) VALUES (@Name, @Phone, @Address, @Points)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Address", customer.Address ?? "");
                    cmd.Parameters.AddWithValue("@Points", customer.Points);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm khách hàng: " + ex.Message);
            }
        }

        public static bool UpdateCustomer(int id, Customer customer)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Customer SET Name = @Name, Phone = @Phone, Address = @Address, Points = @Points WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Address", customer.Address ?? "");
                    cmd.Parameters.AddWithValue("@Points", customer.Points);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật khách hàng: " + ex.Message);
            }
        }

        public static bool DeleteCustomer(int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Customer WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa khách hàng: " + ex.Message);
            }
        }

        public static Customer GetCustomerByPhone(string phone)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, Name, Phone, Address, Points FROM Customer WHERE Phone = @Phone";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Customer
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Address = reader["Address"] != System.DBNull.Value ? reader["Address"].ToString() : "",
                            Points = (int)reader["Points"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy khách hàng: " + ex.Message);
            }
            return null;
        }
    }
}
