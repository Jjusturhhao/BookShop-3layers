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


namespace PresentationLayer
{
    public partial class Register : Form
    {
        private RegisterBL registerBL;

        public Register()
        {
            InitializeComponent();
            registerBL = new RegisterBL();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            // Kiểm tra đầu vào cơ bản
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

            // Kiểm tra tồn tại
            if (registerBL.IsUsernameExist(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại! Vui lòng chọn tên đăng nhập khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (registerBL.IsEmailExist(email))
            {
                MessageBox.Show("Email này đã được sử dụng! Vui lòng sử dụng email khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (registerBL.IsPhoneExist(phone))
            {
                MessageBox.Show("Số điện thoại này đã được sử dụng! Vui lòng sử dụng số khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng Info và đăng ký
            Info newUser = new Info
            {
                User_ID = registerBL.GenerateUserId(),
                Name = name,
                Username = username,
                Pass = password,
                Email = email,
                Address = address,
                Phone = phone,
                Role = "Customer"
            };

            bool isSuccess = registerBL.RegisterNewUser(newUser);

            if (isSuccess)
            {
                MessageBox.Show("Đăng ký thành công! Hãy tiến hành đăng nhập!", "Chúc mừng", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
