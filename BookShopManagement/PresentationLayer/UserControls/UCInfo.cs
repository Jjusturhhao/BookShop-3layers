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
    }
}