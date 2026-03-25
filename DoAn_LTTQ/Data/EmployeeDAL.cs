using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DoAn_LTTQ.Models;

namespace DoAn_LTTQ.Data
{
    public class EmployeeDAL
    {
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ID, Name, Phone, Position, Salary, Avatar FROM Employee";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Position = reader["Position"].ToString(),
                            Salary = (float)reader["Salary"],
                            Avatar = reader["Avatar"] != System.DBNull.Value ? reader["Avatar"].ToString() : ""
                        };
                        employees.Add(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách nhân viên: " + ex.Message);
            }
            return employees;
        }

        public static bool AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Employee (Name, Phone, Position, Salary, Avatar) VALUES (@Name, @Phone, @Position, @Salary, @Avatar)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Phone", employee.Phone);
                    cmd.Parameters.AddWithValue("@Position", employee.Position);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@Avatar", employee.Avatar ?? "");

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm nhân viên: " + ex.Message);
            }
        }

        public static bool UpdateEmployee(int id, Employee employee)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Employee SET Name = @Name, Phone = @Phone, Position = @Position, Salary = @Salary, Avatar = @Avatar WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Phone", employee.Phone);
                    cmd.Parameters.AddWithValue("@Position", employee.Position);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@Avatar", employee.Avatar ?? "");

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật nhân viên: " + ex.Message);
            }
        }

        public static bool DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Employee WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa nhân viên: " + ex.Message);
            }
        }
    }
}
