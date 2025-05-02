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
                Application.Restart();
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

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabEmployee)
            {
                if (tabEmployee.Controls.Count == 0)
                {
                    UCEmployee employeeUC = new UCEmployee();
                    employeeUC.Dock = DockStyle.Fill;
                    tabEmployee.Controls.Add(employeeUC);
                }
            }

            if (tabControlMain.SelectedTab == tabRule)
            {
                if (tabRule.Controls.Count == 0)
                {
                    UCRule ruleUC = new UCRule();
                    ruleUC.Dock = DockStyle.Fill;
                    tabRule.Controls.Add(ruleUC);
                }
            }

            else if (tabControlMain.SelectedTab == tabRevenue)
            {
                if (tabRevenue.Controls.Count == 0)
                {
                    UCStatistics statisticsUC = new UCStatistics();
                    statisticsUC.Dock = DockStyle.Fill;
                    tabRevenue.Controls.Add(statisticsUC);
                }
            }
        }
    }
}
