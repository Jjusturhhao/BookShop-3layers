using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string userRole = null;
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                string username = loginForm.GetUsername();
                string password = loginForm.GetPassword();

                userRole = loginForm.AuthenticateUser(username, password);

                if (userRole == "Admin")
                {
                    Application.Run(new StaffInterface());
                }
                else if (userRole == "Staff")
                {
                    Application.Run(new StaffInterface());
                }
                else if (userRole == "Customer")
                {
                    Application.Run(new Homepage());
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
