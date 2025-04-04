using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login loginForm = new Login();

            // ✅ Chỉ mở Login Form một lần
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                string username = loginForm.GetUsername();
                string password = loginForm.GetPassword();

                // ✅ Sử dụng Business Layer để kiểm tra tài khoản
                LoginBL loginBL = new LoginBL();
                string userRole = loginBL.GetUserRole(new Account(username, password));

                // ✅ Điều hướng theo vai trò
                Form nextForm = null;
                if (userRole == "Admin")
                    nextForm = new StaffInterface();
                else if (userRole == "Staff")
                    nextForm = new StaffInterface();
                else if (userRole == "Customer")
                    nextForm = new Homepage();
                else
                    MessageBox.Show("Đăng nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // ✅ Nếu có form tiếp theo, chạy nó
                if (nextForm != null)
                    Application.Run(nextForm);
            }
        }
    }
}
