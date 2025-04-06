namespace PresentationLayer
{
    partial class StaffInterface
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
            this.lbPage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccout = new System.Windows.Forms.Button();
            this.btnCustomerManage = new System.Windows.Forms.Button();
            this.btnBookManage = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnStaffInterface = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.flowLayoutPanelBooks.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPage
            // 
            this.lbPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPage.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPage.Location = new System.Drawing.Point(62, 100);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(59, 48);
            this.lbPage.TabIndex = 47;
            this.lbPage.Text = "Page";
            this.lbPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Turquoise;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbPage);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtCategory);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtBookName);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1405, 168);
            this.panel2.TabIndex = 52;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(128, 100);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(46, 49);
            this.btnNext.TabIndex = 46;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(9, 100);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(46, 49);
            this.btnPrevious.TabIndex = 45;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.Location = new System.Drawing.Point(1038, 81);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(213, 56);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnApply.Location = new System.Drawing.Point(795, 81);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(236, 56);
            this.btnApply.TabIndex = 16;
            this.btnApply.Text = "Áp dụng";
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(202, 81);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(300, 56);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCategory.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Location = new System.Drawing.Point(855, 21);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(460, 40);
            this.txtCategory.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(698, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 33);
            this.label9.TabIndex = 13;
            this.label9.Text = "Thể loại";
            // 
            // txtBookName
            // 
            this.txtBookName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookName.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookName.Location = new System.Drawing.Point(279, 22);
            this.txtBookName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(330, 39);
            this.txtBookName.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(110, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 33);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tên sách";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 687);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1405, 89);
            this.label2.TabIndex = 46;
            // 
            // flowLayoutPanelBooks
            // 
            this.flowLayoutPanelBooks.AutoScroll = true;
            this.flowLayoutPanelBooks.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanelBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelBooks.Location = new System.Drawing.Point(0, 168);
            this.flowLayoutPanelBooks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelBooks.Name = "flowLayoutPanelBooks";
            this.flowLayoutPanelBooks.Size = new System.Drawing.Size(1405, 519);
            this.flowLayoutPanelBooks.TabIndex = 53;
            // 
            // btnAccout
            // 
            this.btnAccout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccout.BackColor = System.Drawing.Color.Black;
            this.btnAccout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccout.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccout.ForeColor = System.Drawing.Color.Transparent;
            this.btnAccout.Location = new System.Drawing.Point(1167, 688);
            this.btnAccout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccout.Name = "btnAccout";
            this.btnAccout.Size = new System.Drawing.Size(238, 89);
            this.btnAccout.TabIndex = 58;
            this.btnAccout.Text = "Tài khoản";
            this.btnAccout.UseVisualStyleBackColor = false;
            this.btnAccout.Click += new System.EventHandler(this.btnAccout_Click);
            // 
            // btnCustomerManage
            // 
            this.btnCustomerManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCustomerManage.BackColor = System.Drawing.Color.Black;
            this.btnCustomerManage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerManage.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerManage.ForeColor = System.Drawing.Color.Transparent;
            this.btnCustomerManage.Location = new System.Drawing.Point(701, 688);
            this.btnCustomerManage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCustomerManage.Name = "btnCustomerManage";
            this.btnCustomerManage.Size = new System.Drawing.Size(245, 89);
            this.btnCustomerManage.TabIndex = 57;
            this.btnCustomerManage.Text = "Khách hàng";
            this.btnCustomerManage.UseVisualStyleBackColor = false;
            this.btnCustomerManage.Click += new System.EventHandler(this.btnCustomerManage_Click);
            // 
            // btnBookManage
            // 
            this.btnBookManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBookManage.BackColor = System.Drawing.Color.Black;
            this.btnBookManage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBookManage.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookManage.ForeColor = System.Drawing.Color.Transparent;
            this.btnBookManage.Location = new System.Drawing.Point(477, 688);
            this.btnBookManage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBookManage.Name = "btnBookManage";
            this.btnBookManage.Size = new System.Drawing.Size(206, 89);
            this.btnBookManage.TabIndex = 56;
            this.btnBookManage.Text = "Sách";
            this.btnBookManage.UseVisualStyleBackColor = false;
            this.btnBookManage.Click += new System.EventHandler(this.btnBookManage_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckOut.BackColor = System.Drawing.Color.Black;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckOut.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.Transparent;
            this.btnCheckOut.Location = new System.Drawing.Point(244, 688);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(226, 89);
            this.btnCheckOut.TabIndex = 55;
            this.btnCheckOut.Text = "Bán hàng";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnStaffInterface
            // 
            this.btnStaffInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStaffInterface.BackColor = System.Drawing.Color.Black;
            this.btnStaffInterface.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStaffInterface.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffInterface.ForeColor = System.Drawing.Color.Transparent;
            this.btnStaffInterface.Location = new System.Drawing.Point(1, 688);
            this.btnStaffInterface.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStaffInterface.Name = "btnStaffInterface";
            this.btnStaffInterface.Size = new System.Drawing.Size(233, 90);
            this.btnStaffInterface.TabIndex = 54;
            this.btnStaffInterface.Text = "Trang chủ";
            this.btnStaffInterface.UseVisualStyleBackColor = false;
            this.btnStaffInterface.Click += new System.EventHandler(this.btnStaffInterface_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // StaffInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 776);
            this.Controls.Add(this.btnAccout);
            this.Controls.Add(this.btnCustomerManage);
            this.Controls.Add(this.btnBookManage);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnStaffInterface);
            this.Controls.Add(this.flowLayoutPanelBooks);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StaffInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "StaffInterface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StaffInterface_FormClosing);
            this.Load += new System.EventHandler(this.StaffInterface_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanelBooks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox txtCategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBooks;
        private System.Windows.Forms.Button btnAccout;
        private System.Windows.Forms.Button btnCustomerManage;
        private System.Windows.Forms.Button btnBookManage;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnStaffInterface;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}