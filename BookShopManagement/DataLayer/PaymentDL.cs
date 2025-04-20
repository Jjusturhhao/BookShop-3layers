using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class PaymentDL : DataProvider
    {
        public string GeneratePaymentID()
        {
            string newPaymentId = string.Empty;
            string sql = "SELECT MAX(CAST(SUBSTRING(Payment_ID, 4, LEN(Payment_ID) - 3) AS INT)) FROM Payments  ";
            int nextPaymentId = 1; // Mặc định nếu chưa có Payment nào
            try
            {
                Connect();
                using (SqlCommand getMaxPaymentIDCmd = new SqlCommand(sql, cn))
                {
                    object maxIdObj = getMaxPaymentIDCmd.ExecuteScalar();
                    if (maxIdObj != DBNull.Value) // Nếu có dữ liệu trong DB
                    {
                        nextPaymentId = Convert.ToInt32(maxIdObj) + 1; // Lấy số lớn nhất + 1
                    }
                }
                newPaymentId = "PAY" + nextPaymentId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return newPaymentId;
        }

        public bool InsertPayment(string paymentID, string billID, string cusphone, string paymentMethod, string transactionCode, DateTime? paymentDate, int totalCost)
        {
            string query = @"
                INSERT INTO Payments (Payment_ID, Bill_ID, PhoneNumber, Payment_Method, Transaction_Code, Payment_Date, Total_Cost)
                VALUES (@PaymentID, @BillID, @PhoneNumber, @PaymentMethod, @TransactionCode, @PaymentDate, @TotalCost)";

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                    cmd.Parameters.AddWithValue("@BillID", billID);
                    cmd.Parameters.AddWithValue("@PhoneNumber", cusphone);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@TransactionCode", (object)transactionCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PaymentDate", (object)paymentDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalCost", totalCost);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
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
        public Payment GetPaymentByBillID(string billID)
        {
            string query = @"
                SELECT Payment_ID, Bill_ID, PhoneNumber, Payment_Method, Transaction_Code, Payment_Date, Total_Cost
                FROM Payments
                WHERE Bill_ID = @BillID";

            Payment payment = null;

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@BillID", billID);

                    // Thực thi truy vấn và lấy kết quả
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            payment = new Payment(
                                reader["Payment_ID"].ToString(),
                                reader["Bill_ID"].ToString(),
                                reader["PhoneNumber"].ToString(),
                                reader["Payment_Method"].ToString(),
                                reader["Transaction_Code"].ToString(),
                                reader["Payment_Date"] as DateTime?,
                                Convert.ToInt32(reader["Total_Cost"])
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy Payment từ Bill_ID: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return payment;
        }

    }
}
