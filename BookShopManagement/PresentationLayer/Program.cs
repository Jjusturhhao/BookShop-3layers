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

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                string username = loginForm.GetUsername();
                string password = loginForm.GetPassword();

                LoginBL loginBL = new LoginBL();
                string userRole = loginBL.GetUserRole(new Account(username, password));

                Form mainForm = null;
                if (userRole == "Admin")
                    mainForm = new Main(username);
                else if (userRole == "Staff")
                    mainForm = new Main(username);
                else if (userRole == "Customer")
                    mainForm = new Homepage(username);
                else
                    MessageBox.Show("Đăng nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (mainForm != null)
                {
                    // Đảm bảo form chính sẽ đóng hoàn toàn ứng dụng khi bị đóng
                    mainForm.FormClosed += (s, args) => Application.Exit();
                    Application.Run(mainForm);
                }
            }
        }
    }
}
