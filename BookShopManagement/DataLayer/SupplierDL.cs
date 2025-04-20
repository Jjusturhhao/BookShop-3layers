using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;
using System.Data;


namespace DataLayer
{
    public class SupplierDL:DataProvider
    {
        public List<Supplier> GetSuppliers()
        {
            string sql = "SELECT * FROM Suppliers";
            string id, name, address, email, phone;
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = reader[0].ToString();
                    name = reader[1].ToString();
                    address = reader[2].ToString();
                    email = reader[3].ToString();
                    phone = reader[4].ToString();
                    Supplier supplier = new Supplier(id, name, address, email, phone);
                    suppliers.Add(supplier);
                }
                reader.Close();
                return suppliers;
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

        public bool AddSupplier(Supplier supplier)
        {
            string sql = "INSERT INTO Suppliers VALUES (@id, @name, @address, @email, @phone)";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", supplier.ID);
            cmd.Parameters.AddWithValue("@name", supplier.Name);
            cmd.Parameters.AddWithValue("@address", supplier.Address);
            cmd.Parameters.AddWithValue("@email", supplier.Email);
            cmd.Parameters.AddWithValue("@phone", supplier.Phone);

            return MyExecuteNonQuery(cmd) > 0;
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            string sql = "UPDATE Suppliers SET Supplier_name = @name, Supplier_address = @address, Supplier_email = @email, Supplier_phone = @phone WHERE Supplier_ID = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", supplier.ID);
            cmd.Parameters.AddWithValue("@name", supplier.Name);
            cmd.Parameters.AddWithValue("@address", supplier.Address);
            cmd.Parameters.AddWithValue("@email", supplier.Email);
            cmd.Parameters.AddWithValue("@phone", supplier.Phone);

            return MyExecuteNonQuery(cmd) > 0;
        }

        public bool DeleteSupplier(string supplierID)
        {
            string sql = "DELETE FROM Suppliers WHERE Supplier_ID = @id";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", supplierID);
            return MyExecuteNonQuery(cmd) > 0;
        }

        public List<Supplier> SearchSuppliers(string keyword)
        {
            string sql = "SELECT * FROM Suppliers WHERE Supplier_ID LIKE @kw OR Supplier_name LIKE @kw";
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new Supplier(
                        reader["Supplier_ID"].ToString(),
                        reader["Supplier_name"].ToString(),
                        reader["Supplier_address"].ToString(),
                        reader["Supplier_email"].ToString(),
                        reader["Supplier_phone"].ToString()
                    ));
                }
                reader.Close();
                return suppliers;
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
