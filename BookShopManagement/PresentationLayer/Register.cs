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

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
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

                    // Thêm người dùng mới vào database
                    string insertQuery = "INSERT INTO Users (Name, Username, Password, Email, Role) " +
                                       "VALUES (@Name, @Username, @Password, @Email, 'Customer')";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Email", email);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.",
                                           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Đóng form đăng ký và quay lại form đăng nhập
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại! Vui lòng thử lại sau.",
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
