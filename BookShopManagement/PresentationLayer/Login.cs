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
    public partial class Login : Form
    {
        private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BookStoreManagement;Integrated Security=True;TrustServerCertificate=True");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        public string GetUsername()
        {
            return txtUsername.Text.Trim();
        }
        public string GetPassword()
        {
            return txtPassword.Text.Trim();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = GetUsername();
            string password = GetPassword();

            string role = AuthenticateUser(username, password); // Kiểm tra tài khoản

            if (role == "Admin")
            {
                MessageBox.Show("Đăng nhập thành công! Chào mừng Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (role == "Staff")
            {
                MessageBox.Show("Đăng nhập thành công! Chào mừng Staff!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (role == "Customer")
            {
                MessageBox.Show("Đăng nhập thành công! Chào mừng khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string AuthenticateUser(string username, string password)
        {
            string role = null; // Mặc định là null nếu không tìm thấy user

            try
            {
                con.Open();
                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // Kiểm tra trực tiếp mật khẩu

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        role = result.ToString(); // Lấy Role của user
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return role; // Trả về vai trò của người dùng (Admin, Customer hoặc null)
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog(); // Mở form đăng ký
        }
    }
}
