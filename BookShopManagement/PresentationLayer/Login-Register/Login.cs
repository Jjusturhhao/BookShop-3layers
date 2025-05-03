using BusinessLayer;
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
using BusinessLayer;
using TransferObject;
using System.Data.SqlClient;
namespace PresentationLayer
{
    public partial class Login : Form
    {
        private LoginBL loginBL;
        public Login()
        {
            InitializeComponent();
            loginBL = new LoginBL();
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
            Account acc = new Account(username, password);

            // 👉 Kiểm tra tài khoản bị vô hiệu hóa TRƯỚC
            if (loginBL.IsAccountDeactivated(username))
            {
                MessageBox.Show("Tài khoản đã bị vô hiệu hóa!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 👉 Sau khi biết tài khoản còn hoạt động thì mới kiểm tra đúng sai
            string role = loginBL.GetUserRole(acc);

            if (role != null)
            {
                string welcomeName = loginBL.GetName(username);
                string message = "";

                switch (role)
                {
                    case "Admin":
                        message = $"Đăng nhập thành công! Chào mừng Admin {welcomeName}!";
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;

                    case "Staff":
                        message = $"Đăng nhập thành công! Chào mừng Staff {welcomeName}!";
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;

                    case "Customer":
                        message = $"Đăng nhập thành công! Chào mừng quý khách {welcomeName}!";
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        CusInterface homepage = new CusInterface(username);
                        this.Hide();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog(); // Mở form đăng ký
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '●';
            }
        }
    }
}
