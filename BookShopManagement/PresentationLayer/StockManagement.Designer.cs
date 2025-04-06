namespace PresentationLayer
{
    partial class StockManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtStockID = new System.Windows.Forms.TextBox();
            this.lbStockID = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbBookName = new System.Windows.Forms.Label();
            this.lbBookID = new System.Windows.Forms.Label();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnEntryBook = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAccout = new System.Windows.Forms.Button();
            this.btnCustomerManage = new System.Windows.Forms.Button();
            this.btnBookManage = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnStaffInterface = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStockID
            // 
            this.txtStockID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStockID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockID.Location = new System.Drawing.Point(240, 40);
            this.txtStockID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStockID.Name = "txtStockID";
            this.txtStockID.Size = new System.Drawing.Size(236, 39);
            this.txtStockID.TabIndex = 23;
            // 
            // lbStockID
            // 
            this.lbStockID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbStockID.AutoSize = true;
            this.lbStockID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStockID.Location = new System.Drawing.Point(36, 43);
            this.lbStockID.Name = "lbStockID";
            this.lbStockID.Size = new System.Drawing.Size(112, 32);
            this.lbStockID.TabIndex = 22;
            this.lbStockID.Text = "StockID";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.Location = new System.Drawing.Point(240, 290);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(236, 39);
            this.txtAuthor.TabIndex = 18;
            // 
            // lbAuthor
            // 
            this.lbAuthor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthor.Location = new System.Drawing.Point(36, 293);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(107, 32);
            this.lbAuthor.TabIndex = 17;
            this.lbAuthor.Text = "Tác giả";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.Location = new System.Drawing.Point(91, 542);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(289, 52);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // cbxCategory
            // 
            this.cbxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(240, 226);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(236, 40);
            this.cbxCategory.TabIndex = 10;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(240, 422);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(236, 39);
            this.txtQuantity.TabIndex = 9;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(240, 352);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(236, 39);
            this.txtPrice.TabIndex = 8;
            // 
            // txtBookName
            // 
            this.txtBookName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookName.Location = new System.Drawing.Point(240, 164);
            this.txtBookName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(236, 39);
            this.txtBookName.TabIndex = 7;
            // 
            // txtBookID
            // 
            this.txtBookID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookID.Location = new System.Drawing.Point(240, 103);
            this.txtBookID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(236, 39);
            this.txtBookID.TabIndex = 6;
            // 
            // lbQuantity
            // 
            this.lbQuantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(36, 425);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(116, 32);
            this.lbQuantity.TabIndex = 5;
            this.lbQuantity.Text = "Tồn kho";
            // 
            // lbCategory
            // 
            this.lbCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCategory.AutoSize = true;
            this.lbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategory.Location = new System.Drawing.Point(36, 230);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(116, 32);
            this.lbCategory.TabIndex = 4;
            this.lbCategory.Text = "Thể loại";
            // 
            // lbPrice
            // 
            this.lbPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(36, 356);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(114, 32);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "Giá bán";
            // 
            // lbBookName
            // 
            this.lbBookName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbBookName.AutoSize = true;
            this.lbBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookName.Location = new System.Drawing.Point(36, 168);
            this.lbBookName.Name = "lbBookName";
            this.lbBookName.Size = new System.Drawing.Size(63, 32);
            this.lbBookName.TabIndex = 2;
            this.lbBookName.Text = "Tên";
            // 
            // lbBookID
            // 
            this.lbBookID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbBookID.AutoSize = true;
            this.lbBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookID.Location = new System.Drawing.Point(36, 106);
            this.lbBookID.Name = "lbBookID";
            this.lbBookID.Size = new System.Drawing.Size(106, 32);
            this.lbBookID.TabIndex = 0;
            this.lbBookID.Text = "BookID";
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBooks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBooks.ColumnHeadersHeight = 29;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBooks.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBooks.Location = new System.Drawing.Point(3, 131);
            this.dataGridViewBooks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.RowTemplate.Height = 24;
            this.dataGridViewBooks.Size = new System.Drawing.Size(931, 716);
            this.dataGridViewBooks.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(315, 30);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(198, 52);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(-18, 36);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(303, 39);
            this.txtSearch.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnUpdateBook);
            this.panel1.Controls.Add(this.btnDeleteBook);
            this.panel1.Controls.Add(this.btnEntryBook);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 119);
            this.panel1.TabIndex = 0;
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateBook.BackColor = System.Drawing.Color.Blue;
            this.btnUpdateBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateBook.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateBook.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateBook.Location = new System.Drawing.Point(92, 30);
            this.btnUpdateBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(231, 54);
            this.btnUpdateBook.TabIndex = 2;
            this.btnUpdateBook.Text = "Sửa sách";
            this.btnUpdateBook.UseVisualStyleBackColor = false;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteBook.BackColor = System.Drawing.Color.Red;
            this.btnDeleteBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteBook.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBook.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteBook.Location = new System.Drawing.Point(567, 30);
            this.btnDeleteBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(231, 54);
            this.btnDeleteBook.TabIndex = 1;
            this.btnDeleteBook.Text = "Xóa sách";
            this.btnDeleteBook.UseVisualStyleBackColor = false;
            // 
            // btnEntryBook
            // 
            this.btnEntryBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEntryBook.BackColor = System.Drawing.Color.Blue;
            this.btnEntryBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEntryBook.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntryBook.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEntryBook.Location = new System.Drawing.Point(330, 30);
            this.btnEntryBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEntryBook.Name = "btnEntryBook";
            this.btnEntryBook.Size = new System.Drawing.Size(231, 54);
            this.btnEntryBook.TabIndex = 0;
            this.btnEntryBook.Text = "Nhập sách";
            this.btnEntryBook.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(940, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 119);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewBooks, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1442, 851);
            this.tableLayoutPanel1.TabIndex = 42;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtStockID);
            this.panel3.Controls.Add(this.lbStockID);
            this.panel3.Controls.Add(this.txtAuthor);
            this.panel3.Controls.Add(this.lbAuthor);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.cbxCategory);
            this.panel3.Controls.Add(this.txtQuantity);
            this.panel3.Controls.Add(this.txtPrice);
            this.panel3.Controls.Add(this.txtBookName);
            this.panel3.Controls.Add(this.txtBookID);
            this.panel3.Controls.Add(this.lbQuantity);
            this.panel3.Controls.Add(this.lbCategory);
            this.panel3.Controls.Add(this.lbPrice);
            this.panel3.Controls.Add(this.lbBookName);
            this.panel3.Controls.Add(this.lbBookID);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(940, 131);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(499, 716);
            this.panel3.TabIndex = 3;
            // 
            // btnAccout
            // 
            this.btnAccout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccout.BackColor = System.Drawing.Color.Black;
            this.btnAccout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccout.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccout.ForeColor = System.Drawing.Color.Transparent;
            this.btnAccout.Location = new System.Drawing.Point(1210, 851);
            this.btnAccout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccout.Name = "btnAccout";
            this.btnAccout.Size = new System.Drawing.Size(238, 89);
            this.btnAccout.TabIndex = 41;
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
            this.btnCustomerManage.Location = new System.Drawing.Point(693, 851);
            this.btnCustomerManage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCustomerManage.Name = "btnCustomerManage";
            this.btnCustomerManage.Size = new System.Drawing.Size(245, 89);
            this.btnCustomerManage.TabIndex = 40;
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
            this.btnBookManage.Location = new System.Drawing.Point(469, 851);
            this.btnBookManage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBookManage.Name = "btnBookManage";
            this.btnBookManage.Size = new System.Drawing.Size(206, 89);
            this.btnBookManage.TabIndex = 39;
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
            this.btnCheckOut.Location = new System.Drawing.Point(236, 851);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(226, 89);
            this.btnCheckOut.TabIndex = 38;
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
            this.btnStaffInterface.Location = new System.Drawing.Point(-7, 851);
            this.btnStaffInterface.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStaffInterface.Name = "btnStaffInterface";
            this.btnStaffInterface.Size = new System.Drawing.Size(233, 90);
            this.btnStaffInterface.TabIndex = 37;
            this.btnStaffInterface.Text = "Trang chủ";
            this.btnStaffInterface.UseVisualStyleBackColor = false;
            this.btnStaffInterface.Click += new System.EventHandler(this.btnStaffInterface_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 851);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1442, 90);
            this.label2.TabIndex = 36;
            // 
            // StockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 941);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnAccout);
            this.Controls.Add(this.btnCustomerManage);
            this.Controls.Add(this.btnBookManage);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnStaffInterface);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StockManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockManagement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtStockID;
        private System.Windows.Forms.Label lbStockID;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbBookName;
        private System.Windows.Forms.Label lbBookID;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdateBook;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnEntryBook;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAccout;
        private System.Windows.Forms.Button btnCustomerManage;
        private System.Windows.Forms.Button btnBookManage;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnStaffInterface;
        private System.Windows.Forms.Label label2;
    }
}