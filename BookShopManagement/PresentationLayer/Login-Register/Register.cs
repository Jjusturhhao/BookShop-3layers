using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Register : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");

        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            {
                string name = txtName.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                string phone = txtPhoneNumber.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(address) || string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    con.Open();

                    // Kiểm tra username đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại! Vui lòng chọn tên đăng nhập khác.",
                                           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Kiểm tra email đã tồn tại chưa
                    string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (SqlCommand checkEmailCmd = new SqlCommand(checkEmailQuery, con))
                    {
                        checkEmailCmd.Parameters.AddWithValue("@Email", email);
                        int emailCount = (int)checkEmailCmd.ExecuteScalar();

                        if (emailCount > 0)
                        {
                            MessageBox.Show("Email này đã được sử dụng! Vui lòng sử dụng email khác.",
                                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Kiểm tra số điện thoại đã tồn tại chưa
                    string checkPhoneQuery = "SELECT COUNT(*) FROM Users WHERE PhoneNumber = @PhoneNumber";
                    using (SqlCommand checkPhoneCmd = new SqlCommand(checkPhoneQuery, con))
                    {
                        checkPhoneCmd.Parameters.AddWithValue("@PhoneNumber", phone);
                        int emailCount = (int)checkPhoneCmd.ExecuteScalar();

                        if (emailCount > 0)
                        {
                            MessageBox.Show("Số điện thoại này đã được sử dụng! Vui lòng sử dụng số điện thoại khác.",
                                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Lấy User_ID lớn nhất có trong database và tạo User_ID mới
                    string getMaxUserIdQuery = "SELECT MAX(CAST(SUBSTRING(User_ID, 2, LEN(User_ID) - 1) AS INT)) FROM Users WHERE User_ID LIKE 'C%'";
                    int nextUserId = 1; // Mặc định nếu chưa có User nào thì bắt đầu từ C1

                    using (SqlCommand getMaxUserIdCmd = new SqlCommand(getMaxUserIdQuery, con))
                    {
                        object maxIdObj = getMaxUserIdCmd.ExecuteScalar();
                        if (maxIdObj != DBNull.Value) // Nếu có dữ liệu trong DB
                        {
                            nextUserId = Convert.ToInt32(maxIdObj) + 1; // Lấy số lớn nhất + 1
                        }
                    }

                    // Tạo User_ID mới
                    string newUserId = "C" + nextUserId;


                    // Thêm người dùng mới vào database
                    string insertQuery = "INSERT INTO Users (User_ID, Name, Username, Password, Email, Address, PhoneNumber, Role) " +
                      "VALUES (@User_ID, @Name, @Username, @Password, @Email, @Address, @PhoneNumber, 'Customer')";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@User_ID", newUserId);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phone);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Đăng ký thành công! Hãy tiến hành đăng nhập!",
                                            "Chúc mừng", MessageBoxButtons.OK);

                            // Đóng form đăng ký và quay lại form đăng nhập
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại! Vui lòng thử lại.",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
