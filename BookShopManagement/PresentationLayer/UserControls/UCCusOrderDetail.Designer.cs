namespace PresentationLayer.UserControls
{
    partial class UCCusOrderDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbPayment = new System.Windows.Forms.Label();
            this.lbOrderID = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbInforCus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotalCost = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(28, 565);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(139, 62);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.NavajoWhite;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1124, 84);
            this.label1.TabIndex = 11;
            this.label1.Text = "CHI TIẾT ĐƠN HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.lbTotalCost);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Location = new System.Drawing.Point(76, 113);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(967, 435);
            this.panel4.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.flpDetails);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 356);
            this.panel1.TabIndex = 13;
            // 
            // flpDetails
            // 
            this.flpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpDetails.AutoScroll = true;
            this.flpDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDetails.Location = new System.Drawing.Point(54, 164);
            this.flpDetails.Name = "flpDetails";
            this.flpDetails.Size = new System.Drawing.Size(841, 167);
            this.flpDetails.TabIndex = 4;
            this.flpDetails.WrapContents = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbPayment);
            this.panel2.Controls.Add(this.lbOrderID);
            this.panel2.Location = new System.Drawing.Point(54, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 123);
            this.panel2.TabIndex = 3;
            // 
            // lbPayment
            // 
            this.lbPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPayment.Location = new System.Drawing.Point(0, 47);
            this.lbPayment.Name = "lbPayment";
            this.lbPayment.Size = new System.Drawing.Size(490, 74);
            this.lbPayment.TabIndex = 1;
            this.lbPayment.Text = "Phương thức thanh toán:";
            this.lbPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOrderID
            // 
            this.lbOrderID.BackColor = System.Drawing.Color.Gainsboro;
            this.lbOrderID.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderID.Location = new System.Drawing.Point(0, 0);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(490, 47);
            this.lbOrderID.TabIndex = 0;
            this.lbOrderID.Text = "Đơn hàng: ORDxxx";
            this.lbOrderID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbInforCus);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(565, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 123);
            this.panel3.TabIndex = 1;
            // 
            // lbInforCus
            // 
            this.lbInforCus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInforCus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInforCus.Location = new System.Drawing.Point(0, 47);
            this.lbInforCus.Name = "lbInforCus";
            this.lbInforCus.Size = new System.Drawing.Size(328, 74);
            this.lbInforCus.TabIndex = 1;
            this.lbInforCus.Text = "Tên - ĐT";
            this.lbInforCus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 47);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thông tin nhận hàng";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTotalCost
            // 
            this.lbTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalCost.AutoSize = true;
            this.lbTotalCost.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCost.ForeColor = System.Drawing.Color.Red;
            this.lbTotalCost.Location = new System.Drawing.Point(659, 374);
            this.lbTotalCost.Name = "lbTotalCost";
            this.lbTotalCost.Size = new System.Drawing.Size(231, 36);
            this.lbTotalCost.TabIndex = 14;
            this.lbTotalCost.Text = "Tổng đơn hàng";
            // 
            // UCCusOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Name = "UCCusOrderDetail";
            this.Size = new System.Drawing.Size(1124, 652);
            this.Load += new System.EventHandler(this.UCCusOrderDetail_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbTotalCost;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPayment;
        private System.Windows.Forms.Label lbOrderID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbInforCus;
        private System.Windows.Forms.Label label3;
    }
}
