using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class EmployeeDL : DataProvider
    {
        public List<Employee> GetEmployees()
        {
            string sql = "SELECT * FROM Users WHERE Role = 'Staff'";
            List<Employee> employees = new List<Employee>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    employees.Add(new Employee(
                        reader["User_ID"].ToString(),
                        reader["Name"].ToString(),
                        reader["Username"].ToString(),
                        reader["Password"].ToString(),
                        reader["Email"].ToString(),
                        reader["Address"].ToString(),
                        reader["PhoneNumber"].ToString()
                    ));
                }
                reader.Close();
                return employees;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public bool AddEmployee(Employee employee)
        {
            string sql = "INSERT INTO Users VALUES (@id, @name, @username, @password, @email, @address, @phone, @role)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", employee.ID);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@username", employee.Username);
            cmd.Parameters.AddWithValue("@password", employee.Password);
            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@address", employee.Address);
            cmd.Parameters.AddWithValue("@phone", employee.Phone);
            cmd.Parameters.AddWithValue("@role", "Staff");

            return MyExecuteNonQuery(cmd) > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            string sql = "UPDATE Users SET Name = @name, Username = @username, Password = @password, Email = @email, Address = @address, PhoneNumber = @phone WHERE User_ID = @id AND Role = 'Staff'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", employee.ID);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@username", employee.Username);
            cmd.Parameters.AddWithValue("@password", employee.Password);
            cmd.Parameters.AddWithValue("@email", employee.Email);
            cmd.Parameters.AddWithValue("@address", employee.Address);
            cmd.Parameters.AddWithValue("@phone", employee.Phone);

            return MyExecuteNonQuery(cmd) > 0;
        }

        public bool DeleteEmployee(string employeeID)
        {
            string sql = "DELETE FROM Users WHERE User_ID = @id AND Role = 'Staff'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", employeeID);
            return MyExecuteNonQuery(cmd) > 0;
        }

        public List<Employee> SearchEmployees(string keyword)
        {
            string sql = "SELECT * FROM Users WHERE Role = 'Staff' AND (User_ID LIKE @kw OR Name LIKE @kw)";
            List<Employee> employees = new List<Employee>();
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee(
                        reader["User_ID"].ToString(),
                        reader["Name"].ToString(),
                        reader["Username"].ToString(),
                        reader["Password"].ToString(),
                        reader["Email"].ToString(),
                        reader["Address"].ToString(),
                        reader["PhoneNumber"].ToString()
                    ));
                }
                reader.Close();
                return employees;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
