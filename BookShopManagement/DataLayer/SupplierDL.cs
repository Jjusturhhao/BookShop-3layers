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
    }
}
