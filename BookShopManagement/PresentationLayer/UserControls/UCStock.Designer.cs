namespace PresentationLayer.UserControls
{
    partial class UCStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSupplier = new System.Windows.Forms.ComboBox();
            this.dtpkImportDate = new System.Windows.Forms.DateTimePicker();
            this.lbImportDate = new System.Windows.Forms.Label();
            this.lbSupplier = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbBookName = new System.Windows.Forms.Label();
            this.lbBookID = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnGIN = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdateBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.86381F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.13619F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1599, 1070);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(864, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(732, 138);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(728, 134);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý kho sách";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(855, 138);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.Tomato;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(493, 40);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(198, 52);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(160, 47);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(303, 39);
            this.txtSearch.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvStock);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 144);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(855, 924);
            this.panel3.TabIndex = 2;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToOrderColumns = true;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookID,
            this.SupplierID,
            this.CategoryID,
            this.BookName,
            this.ImportDate,
            this.Quantity});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Location = new System.Drawing.Point(0, 0);
            this.dgvStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersWidth = 51;
            this.dgvStock.RowTemplate.Height = 24;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(855, 924);
            this.dgvStock.TabIndex = 3;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            // 
            // BookID
            // 
            this.BookID.DataPropertyName = "BookID";
            this.BookID.HeaderText = "Mã Sách";
            this.BookID.MinimumWidth = 8;
            this.BookID.Name = "BookID";
            this.BookID.ReadOnly = true;
            this.BookID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // SupplierID
            // 
            this.SupplierID.DataPropertyName = "SupplierID";
            this.SupplierID.HeaderText = "Tên nhà cung cấp";
            this.SupplierID.MinimumWidth = 8;
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            this.SupplierID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CategoryID
            // 
            this.CategoryID.DataPropertyName = "CategoryID";
            this.CategoryID.HeaderText = "Thể loại";
            this.CategoryID.MinimumWidth = 8;
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.ReadOnly = true;
            this.CategoryID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BookName
            // 
            this.BookName.DataPropertyName = "BookName";
            this.BookName.HeaderText = "Tên Sách";
            this.BookName.MinimumWidth = 8;
            this.BookName.Name = "BookName";
            this.BookName.ReadOnly = true;
            this.BookName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ImportDate
            // 
            this.ImportDate.DataPropertyName = "ImportDate";
            this.ImportDate.HeaderText = "Ngày Nhập Kho";
            this.ImportDate.MinimumWidth = 8;
            this.ImportDate.Name = "ImportDate";
            this.ImportDate.ReadOnly = true;
            this.ImportDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Số Lượng";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(864, 144);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(732, 924);
            this.panel4.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.btnAddCategory);
            this.panel6.Controls.Add(this.txtSL);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.cbxSupplier);
            this.panel6.Controls.Add(this.dtpkImportDate);
            this.panel6.Controls.Add(this.lbImportDate);
            this.panel6.Controls.Add(this.lbSupplier);
            this.panel6.Controls.Add(this.cbxCategory);
            this.panel6.Controls.Add(this.txtQuantity);
            this.panel6.Controls.Add(this.txtBookName);
            this.panel6.Controls.Add(this.txtBookID);
            this.panel6.Controls.Add(this.lbQuantity);
            this.panel6.Controls.Add(this.lbCategory);
            this.panel6.Controls.Add(this.lbBookName);
            this.panel6.Controls.Add(this.lbBookID);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(732, 771);
            this.panel6.TabIndex = 1;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.Location = new System.Drawing.Point(315, 298);
            this.btnAddCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(238, 40);
            this.btnAddCategory.TabIndex = 47;
            this.btnAddCategory.Text = "Thêm danh mục";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // txtSL
            // 
            this.txtSL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.Location = new System.Drawing.Point(264, 597);
            this.txtSL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(307, 39);
            this.txtSL.TabIndex = 6;
            this.txtSL.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 597);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 32);
            this.label2.TabIndex = 42;
            this.label2.Text = "Số lượng nhập";
            this.label2.Visible = false;
            // 
            // cbxSupplier
            // 
            this.cbxSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSupplier.Enabled = false;
            this.cbxSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSupplier.FormattingEnabled = true;
            this.cbxSupplier.Location = new System.Drawing.Point(264, 443);
            this.cbxSupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxSupplier.Name = "cbxSupplier";
            this.cbxSupplier.Size = new System.Drawing.Size(307, 40);
            this.cbxSupplier.TabIndex = 4;
            // 
            // dtpkImportDate
            // 
            this.dtpkImportDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpkImportDate.Enabled = false;
            this.dtpkImportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkImportDate.Location = new System.Drawing.Point(264, 374);
            this.dtpkImportDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpkImportDate.Name = "dtpkImportDate";
            this.dtpkImportDate.Size = new System.Drawing.Size(307, 39);
            this.dtpkImportDate.TabIndex = 3;
            // 
            // lbImportDate
            // 
            this.lbImportDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbImportDate.AutoSize = true;
            this.lbImportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImportDate.Location = new System.Drawing.Point(47, 379);
            this.lbImportDate.Name = "lbImportDate";
            this.lbImportDate.Size = new System.Drawing.Size(151, 32);
            this.lbImportDate.TabIndex = 38;
            this.lbImportDate.Text = "Ngày nhập";
            // 
            // lbSupplier
            // 
            this.lbSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSupplier.AutoSize = true;
            this.lbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSupplier.Location = new System.Drawing.Point(47, 451);
            this.lbSupplier.Name = "lbSupplier";
            this.lbSupplier.Size = new System.Drawing.Size(188, 32);
            this.lbSupplier.TabIndex = 34;
            this.lbSupplier.Text = "Nhà cung cấp";
            // 
            // cbxCategory
            // 
            this.cbxCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.Enabled = false;
            this.cbxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(264, 252);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(307, 40);
            this.cbxCategory.TabIndex = 2;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(264, 521);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(307, 39);
            this.txtQuantity.TabIndex = 5;
            // 
            // txtBookName
            // 
            this.txtBookName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookName.Location = new System.Drawing.Point(264, 185);
            this.txtBookName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.ReadOnly = true;
            this.txtBookName.Size = new System.Drawing.Size(307, 39);
            this.txtBookName.TabIndex = 1;
            // 
            // txtBookID
            // 
            this.txtBookID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookID.Enabled = false;
            this.txtBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookID.Location = new System.Drawing.Point(264, 112);
            this.txtBookID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.ReadOnly = true;
            this.txtBookID.Size = new System.Drawing.Size(307, 39);
            this.txtBookID.TabIndex = 0;
            // 
            // lbQuantity
            // 
            this.lbQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(47, 524);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(116, 32);
            this.lbQuantity.TabIndex = 27;
            this.lbQuantity.Text = "Tồn kho";
            // 
            // lbCategory
            // 
            this.lbCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCategory.AutoSize = true;
            this.lbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategory.Location = new System.Drawing.Point(47, 260);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(116, 32);
            this.lbCategory.TabIndex = 26;
            this.lbCategory.Text = "Thể loại";
            // 
            // lbBookName
            // 
            this.lbBookName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbBookName.AutoSize = true;
            this.lbBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookName.Location = new System.Drawing.Point(47, 188);
            this.lbBookName.Name = "lbBookName";
            this.lbBookName.Size = new System.Drawing.Size(63, 32);
            this.lbBookName.TabIndex = 25;
            this.lbBookName.Text = "Tên";
            // 
            // lbBookID
            // 
            this.lbBookID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbBookID.AutoSize = true;
            this.lbBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookID.Location = new System.Drawing.Point(47, 115);
            this.lbBookID.Name = "lbBookID";
            this.lbBookID.Size = new System.Drawing.Size(120, 32);
            this.lbBookID.TabIndex = 24;
            this.lbBookID.Text = "Mã sách";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnGIN);
            this.panel5.Controls.Add(this.btnReset);
            this.panel5.Controls.Add(this.btnUpdateBook);
            this.panel5.Controls.Add(this.btnAddBook);
            this.panel5.Controls.Add(this.btnRefresh);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 771);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(732, 153);
            this.panel5.TabIndex = 0;
            // 
            // btnGIN
            // 
            this.btnGIN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGIN.BackColor = System.Drawing.Color.Lime;
            this.btnGIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGIN.ForeColor = System.Drawing.Color.White;
            this.btnGIN.Location = new System.Drawing.Point(160, 98);
            this.btnGIN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGIN.Name = "btnGIN";
            this.btnGIN.Size = new System.Drawing.Size(195, 49);
            this.btnGIN.TabIndex = 2;
            this.btnGIN.Text = "Xuất phiếu";
            this.btnGIN.UseVisualStyleBackColor = false;
            this.btnGIN.Click += new System.EventHandler(this.btnGIN_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.BackColor = System.Drawing.Color.LightCoral;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(399, 98);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(195, 49);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateBook.BackColor = System.Drawing.Color.LightCoral;
            this.btnUpdateBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateBook.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateBook.ForeColor = System.Drawing.Color.White;
            this.btnUpdateBook.Location = new System.Drawing.Point(399, 21);
            this.btnUpdateBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(195, 49);
            this.btnUpdateBook.TabIndex = 1;
            this.btnUpdateBook.Text = "Cập nhật";
            this.btnUpdateBook.UseVisualStyleBackColor = false;
            this.btnUpdateBook.Click += new System.EventHandler(this.btnUpdateBook_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddBook.BackColor = System.Drawing.Color.LightCoral;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddBook.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.Location = new System.Drawing.Point(160, 21);
            this.btnAddBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(195, 49);
            this.btnAddBook.TabIndex = 0;
            this.btnAddBook.Text = "Thêm mới";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(134, 630);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(289, 52);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // UCStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCStock";
            this.Size = new System.Drawing.Size(1599, 1070);
            this.Load += new System.EventHandler(this.UCStock_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUpdateBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dtpkImportDate;
        private System.Windows.Forms.Label lbImportDate;
        private System.Windows.Forms.Label lbSupplier;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Label lbBookName;
        private System.Windows.Forms.Label lbBookID;
        private System.Windows.Forms.ComboBox cbxSupplier;
        private System.Windows.Forms.Button btnGIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddCategory;
    }
}
