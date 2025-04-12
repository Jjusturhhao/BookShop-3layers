namespace PresentationLayer.UserControls
{
    partial class UCCheckout
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
            this.lbHello = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelLoadBook = new System.Windows.Forms.Panel();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.panel = new System.Windows.Forms.Panel();
            this.btnChoose = new System.Windows.Forms.Button();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelOrderDetail = new System.Windows.Forms.Panel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerateBill = new System.Windows.Forms.Button();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.txtTotalPaid = new System.Windows.Forms.TextBox();
            this.txtTotalBill = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelCusInfo = new System.Windows.Forms.Panel();
            this.txtCusPhone = new System.Windows.Forms.TextBox();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSort = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbxCategories = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelLoadBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.panelOrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelCusInfo.SuspendLayout();
            this.panelSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHello
            // 
            this.lbHello.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbHello.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbHello.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbHello.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHello.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbHello.Location = new System.Drawing.Point(0, 0);
            this.lbHello.Name = "lbHello";
            this.lbHello.Size = new System.Drawing.Size(1351, 92);
            this.lbHello.TabIndex = 54;
            this.lbHello.Text = "Xin chào";
            this.lbHello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.57895F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.42105F));
            this.tableLayoutPanel1.Controls.Add(this.panelLoadBook, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelOrderDetail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelCusInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelSort, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 92);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.19048F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1351, 899);
            this.tableLayoutPanel1.TabIndex = 63;
            // 
            // panelLoadBook
            // 
            this.panelLoadBook.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLoadBook.Controls.Add(this.dgvBooks);
            this.panelLoadBook.Controls.Add(this.panel);
            this.panelLoadBook.Controls.Add(this.label7);
            this.panelLoadBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoadBook.Location = new System.Drawing.Point(632, 217);
            this.panelLoadBook.Name = "panelLoadBook";
            this.panelLoadBook.Size = new System.Drawing.Size(716, 679);
            this.panelLoadBook.TabIndex = 4;
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.Location = new System.Drawing.Point(0, 35);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 51;
            this.dgvBooks.RowTemplate.Height = 24;
            this.dgvBooks.Size = new System.Drawing.Size(712, 581);
            this.dgvBooks.TabIndex = 7;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnChoose);
            this.panel.Controls.Add(this.numericUpDownQuantity);
            this.panel.Controls.Add(this.label2);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 616);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(712, 59);
            this.panel.TabIndex = 6;
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChoose.BackColor = System.Drawing.Color.Lime;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChoose.Location = new System.Drawing.Point(486, 12);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(105, 32);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "Chọn";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQuantity.Location = new System.Drawing.Point(247, 15);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 30);
            this.numericUpDownQuantity.TabIndex = 1;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số lượng";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(712, 35);
            this.label7.TabIndex = 4;
            this.label7.Text = "DANH SÁCH SẢN PHẨM";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelOrderDetail
            // 
            this.panelOrderDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOrderDetail.Controls.Add(this.dgvDetails);
            this.panelOrderDetail.Controls.Add(this.panel3);
            this.panelOrderDetail.Controls.Add(this.label6);
            this.panelOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrderDetail.Location = new System.Drawing.Point(3, 217);
            this.panelOrderDetail.Name = "panelOrderDetail";
            this.panelOrderDetail.Size = new System.Drawing.Size(623, 679);
            this.panelOrderDetail.TabIndex = 3;
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 35);
            this.dgvDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 62;
            this.dgvDetails.RowTemplate.Height = 28;
            this.dgvDetails.Size = new System.Drawing.Size(619, 465);
            this.dgvDetails.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnChange);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnGenerateBill);
            this.panel3.Controls.Add(this.txtChange);
            this.panel3.Controls.Add(this.txtTotalPaid);
            this.panel3.Controls.Add(this.txtTotalBill);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 500);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 175);
            this.panel3.TabIndex = 4;
            // 
            // btnChange
            // 
            this.btnChange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChange.BackColor = System.Drawing.Color.Lime;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChange.Location = new System.Drawing.Point(517, 50);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(87, 30);
            this.btnChange.TabIndex = 11;
            this.btnChange.Text = "OK";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(339, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(149, 34);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerateBill.BackColor = System.Drawing.Color.Blue;
            this.btnGenerateBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenerateBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBill.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerateBill.Location = new System.Drawing.Point(146, 128);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(175, 34);
            this.btnGenerateBill.TabIndex = 9;
            this.btnGenerateBill.Text = "Thanh toán";
            this.btnGenerateBill.UseVisualStyleBackColor = false;
            // 
            // txtChange
            // 
            this.txtChange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChange.Location = new System.Drawing.Point(304, 90);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(207, 30);
            this.txtChange.TabIndex = 6;
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaid.Location = new System.Drawing.Point(304, 50);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.Size = new System.Drawing.Size(207, 30);
            this.txtTotalPaid.TabIndex = 5;
            this.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBill.Location = new System.Drawing.Point(304, 10);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.Size = new System.Drawing.Size(207, 30);
            this.txtTotalBill.TabIndex = 4;
            this.txtTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(50, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 25);
            this.label12.TabIndex = 3;
            this.label12.Text = "Tiền thừa";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(50, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 25);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tiền khách trả";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(50, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 25);
            this.label10.TabIndex = 1;
            this.label10.Text = "Tổng hóa đơn";
            // 
            // label6
            // 
            this.label6.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(619, 35);
            this.label6.TabIndex = 3;
            this.label6.Text = "THÔNG TIN HÓA ĐƠN";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCusInfo
            // 
            this.panelCusInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCusInfo.Controls.Add(this.txtCusPhone);
            this.panelCusInfo.Controls.Add(this.txtCusName);
            this.panelCusInfo.Controls.Add(this.label4);
            this.panelCusInfo.Controls.Add(this.label3);
            this.panelCusInfo.Controls.Add(this.label1);
            this.panelCusInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCusInfo.Location = new System.Drawing.Point(3, 3);
            this.panelCusInfo.Name = "panelCusInfo";
            this.panelCusInfo.Size = new System.Drawing.Size(623, 208);
            this.panelCusInfo.TabIndex = 1;
            // 
            // txtCusPhone
            // 
            this.txtCusPhone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCusPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusPhone.Location = new System.Drawing.Point(230, 122);
            this.txtCusPhone.Name = "txtCusPhone";
            this.txtCusPhone.Size = new System.Drawing.Size(340, 30);
            this.txtCusPhone.TabIndex = 4;
            // 
            // txtCusName
            // 
            this.txtCusName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusName.Location = new System.Drawing.Point(230, 75);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(340, 30);
            this.txtCusName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(620, 35);
            this.label4.TabIndex = 2;
            this.label4.Text = "THÔNG TIN KHÁCH HÀNG";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số điện thoại";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên";
            // 
            // panelSort
            // 
            this.panelSort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSort.Controls.Add(this.btnReset);
            this.panelSort.Controls.Add(this.btnApply);
            this.panelSort.Controls.Add(this.btnSearch);
            this.panelSort.Controls.Add(this.cbxCategories);
            this.panelSort.Controls.Add(this.label9);
            this.panelSort.Controls.Add(this.txtNameSearch);
            this.panelSort.Controls.Add(this.label8);
            this.panelSort.Controls.Add(this.label5);
            this.panelSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSort.Location = new System.Drawing.Point(632, 3);
            this.panelSort.Name = "panelSort";
            this.panelSort.Size = new System.Drawing.Size(716, 208);
            this.panelSort.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.Tomato;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReset.Location = new System.Drawing.Point(507, 120);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(164, 34);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.Tomato;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnApply.Location = new System.Drawing.Point(313, 120);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(185, 34);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Áp dụng";
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Tomato;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(59, 120);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(236, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbxCategories
            // 
            this.cbxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCategories.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategories.FormattingEnabled = true;
            this.cbxCategories.Location = new System.Drawing.Point(313, 83);
            this.cbxCategories.Name = "cbxCategories";
            this.cbxCategories.Size = new System.Drawing.Size(359, 31);
            this.cbxCategories.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(307, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Thể loại";
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSearch.Location = new System.Drawing.Point(59, 84);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(237, 30);
            this.txtNameSearch.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Tên sách";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(712, 35);
            this.label5.TabIndex = 3;
            this.label5.Text = "BỘ LỌC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbHello);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCCheckout";
            this.Size = new System.Drawing.Size(1351, 991);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelLoadBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.panelOrderDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelCusInfo.ResumeLayout(false);
            this.panelCusInfo.PerformLayout();
            this.panelSort.ResumeLayout(false);
            this.panelSort.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbHello;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelCusInfo;
        private System.Windows.Forms.TextBox txtCusPhone;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSort;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxCategories;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelOrderDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.TextBox txtTotalPaid;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Panel panelLoadBook;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnChange;
    }
}
