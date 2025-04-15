namespace PresentationLayer
{
    partial class AdminInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabHomepage = new System.Windows.Forms.TabPage();
            this.tabEmployee = new System.Windows.Forms.TabPage();
            this.tabChart = new System.Windows.Forms.TabPage();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.tabInfoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiChangeInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain.SuspendLayout();
            this.tabInfoMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabHomepage);
            this.tabControlMain.Controls.Add(this.tabEmployee);
            this.tabControlMain.Controls.Add(this.tabChart);
            this.tabControlMain.Controls.Add(this.tabInfo);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1001, 599);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControlMain_MouseDown);
            // 
            // tabHomepage
            // 
            this.tabHomepage.Location = new System.Drawing.Point(4, 29);
            this.tabHomepage.Name = "tabHomepage";
            this.tabHomepage.Padding = new System.Windows.Forms.Padding(3);
            this.tabHomepage.Size = new System.Drawing.Size(993, 566);
            this.tabHomepage.TabIndex = 0;
            this.tabHomepage.Text = "Trang chủ";
            this.tabHomepage.UseVisualStyleBackColor = true;
            // 
            // tabEmployee
            // 
            this.tabEmployee.Location = new System.Drawing.Point(4, 29);
            this.tabEmployee.Name = "tabEmployee";
            this.tabEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployee.Size = new System.Drawing.Size(993, 566);
            this.tabEmployee.TabIndex = 1;
            this.tabEmployee.Text = "Quản lý nhân viên";
            this.tabEmployee.UseVisualStyleBackColor = true;
            // 
            // tabChart
            // 
            this.tabChart.Location = new System.Drawing.Point(4, 29);
            this.tabChart.Name = "tabChart";
            this.tabChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabChart.Size = new System.Drawing.Size(993, 566);
            this.tabChart.TabIndex = 2;
            this.tabChart.Text = "Báo cáo - Thống kê";
            this.tabChart.UseVisualStyleBackColor = true;
            // 
            // tabInfo
            // 
            this.tabInfo.Location = new System.Drawing.Point(4, 29);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(993, 566);
            this.tabInfo.TabIndex = 3;
            this.tabInfo.Text = "Cá nhân";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // tabInfoMenu
            // 
            this.tabInfoMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tabInfoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChangeInfo,
            this.tsmiLogout});
            this.tabInfoMenu.Name = "contextMenuStrip1";
            this.tabInfoMenu.Size = new System.Drawing.Size(191, 68);
            // 
            // tsmiChangeInfo
            // 
            this.tsmiChangeInfo.Name = "tsmiChangeInfo";
            this.tsmiChangeInfo.Size = new System.Drawing.Size(240, 32);
            this.tsmiChangeInfo.Text = "Đổi thông tin";
            this.tsmiChangeInfo.Click += new System.EventHandler(this.tsmiChangeInfo_Click);
            // 
            // tsmiLogout
            // 
            this.tsmiLogout.Name = "tsmiLogout";
            this.tsmiLogout.Size = new System.Drawing.Size(240, 32);
            this.tsmiLogout.Text = "Đăng xuất";
            this.tsmiLogout.Click += new System.EventHandler(this.tsmiLogout_Click);
            // 
            // AdminInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 599);
            this.Controls.Add(this.tabControlMain);
            this.Name = "AdminInterface";
            this.Text = "AdminInterface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminInterface_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabInfoMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabHomepage;
        private System.Windows.Forms.TabPage tabEmployee;
        private System.Windows.Forms.TabPage tabChart;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.ContextMenuStrip tabInfoMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogout;
    }
}