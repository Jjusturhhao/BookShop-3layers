using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer.UserControls
{
    public partial class UCInfo : UserControl
    {
        private InfoBL infoBL;
        private string currentUsername; // Username của user đang đăng nhập
        public UCInfo(string username)
        {
            InitializeComponent();
            infoBL = new InfoBL();
            currentUsername = username;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            Info info = infoBL.GetUserInfo(currentUsername);

            if (info != null)
            {
                txtName.Text = info.Name;
                txtUsername.Text = info.Username;
                txtAddress.Text = info.Address;
                txtPhone.Text = info.Phone;
                txtEmail.Text = info.Email;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Info updatedInfo = new Info(
                    txtUsername.Text,
                    txtName.Text,
                    "", // Password không đổi
                    txtAddress.Text,
                    txtPhone.Text,
                    txtEmail.Text
                );

                bool result = infoBL.UpdateUserInfo(updatedInfo);

                if (result)
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
                else
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        public bool checkPassword()
        {
            if (txtOldPass.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập mật khẩu");
                txtOldPass.Focus();
                return false;
            }
            if (txtNewPass.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập mật khẩu mới");
                txtNewPass.Focus();
                return false;
            }
            if (txtConfirmNewPass.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập xác nhận mật khẩu");
                txtConfirmNewPass.Focus();
                return false;
            }
            return true;
        }

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            if (!checkPassword())
                return;

            string oldpass = txtOldPass.Text.Trim();
            string newpass = txtNewPass.Text.Trim();
            string confirmpass = txtConfirmNewPass.Text.Trim();

            if (!infoBL.CheckCurrentPassword(currentUsername, oldpass))
            {
                MessageBox.Show("Sai mật khẩu cũ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPass.Focus();
                return;
            }

            if (newpass != confirmpass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmNewPass.Focus();
                return;
            }

            // Tiến hành đổi mật khẩu
            bool result = infoBL.ChangePassword(currentUsername, newpass);
            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPass.Text = "";
                txtNewPass.Text = "";
                txtConfirmNewPass.Text = "";
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}