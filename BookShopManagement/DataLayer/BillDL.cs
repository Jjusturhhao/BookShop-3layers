using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BillDL : DataProvider
    {
        public void SaveBill(string billID, string orderID, int totalCost)
        {
            string query = "INSERT INTO Bill_Generate (Bill_ID, Order_ID, Bill_Date, Total_Cost) " +
                           "VALUES (@Bill_ID, @Order_ID, GETDATE(), @Total_Cost)";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Bill_ID", billID);
                    cmd.Parameters.AddWithValue("@Order_ID", orderID);
                    cmd.Parameters.AddWithValue("@Total_Cost", totalCost);

                    cmd.ExecuteNonQuery();
                }
                            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public string GenerateBillID(string orderID)
        {
            return "BILL" + orderID;
        }
        public int CalculateTotalCost(string orderID)
        {
            int totalCost = 0;
            string query = "SELECT SUM(OD.PriceAtOrderTime * OD.Qty_sold)" +
                     "FROM OrderDetails OD " +
                     "WHERE OD.Order_ID = @Order_ID ";
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Order_ID", orderID);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        totalCost = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
            return totalCost;
        }

    }
}
