using PresentationLayer.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class AdminInterface : Form
    {
        private string username;

        public AdminInterface(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void AdminInterface_Load(object sender, EventArgs e)
        {
            UCHomepage homeUC = new UCHomepage(null, null);
            homeUC.Dock = DockStyle.Fill;
            tabHomepage.Controls.Add(homeUC);
            homeUC.BringToFront(); // đảm bảo nó hiển thị

        }

        private void tsmiChangeInfo_Click(object sender, EventArgs e)
        {
            // Hiện UCInfo lên
            UCInfo infoUC = new UCInfo(username); // nếu có truyền username
            infoUC.Dock = DockStyle.Fill;
            tabControlMain.TabPages["tabInfo"].Controls.Clear();
            tabControlMain.TabPages["tabInfo"].Controls.Add(infoUC);
        }


        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login loginForm = new Login();
                loginForm.Show();
            }
        }

        private void tabControlMain_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControlMain.TabCount; i++)
            {
                if (tabControlMain.GetTabRect(i).Contains(e.Location))
                {
                    // Giả sử TabPage "Cá nhân" là cái muốn show menu
                    if (tabControlMain.TabPages[i].Text == "Cá nhân")
                    {
                        if (e.Button == MouseButtons.Left) // hoặc Right nếu muốn phải chuột
                        {
                            tabInfoMenu.Show(tabControlMain, e.Location); // tabInfoMenu là ContextMenuStrip
                        }
                        break;
                    }
                }
            }
        }
    }
}
