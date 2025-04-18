﻿namespace PresentationLayer.UserControls
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.StockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbxSupplier = new System.Windows.Forms.ComboBox();
            this.dtpk = new System.Windows.Forms.DateTimePicker();
            this.lbImportDate = new System.Windows.Forms.Label();
            this.txtStockID = new System.Windows.Forms.TextBox();
            this.lbStockID = new System.Windows.Forms.Label();
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
            this.btnDeleteBook = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1162, 780);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(628, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(531, 99);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 95);
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
            this.panel1.Size = new System.Drawing.Size(619, 99);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.BackColor = System.Drawing.Color.Tomato;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(368, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(176, 42);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(72, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 34);
            this.txtSearch.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvStock);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 105);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 673);
            this.panel3.TabIndex = 2;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToOrderColumns = true;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockID,
            this.Supplier_ID,
            this.BookID,
            this.CategoryID,
            this.BookName,
            this.ImportDate,
            this.Quantity});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Location = new System.Drawing.Point(0, 0);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersWidth = 51;
            this.dgvStock.RowTemplate.Height = 24;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(619, 673);
            this.dgvStock.TabIndex = 3;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            // 
            // StockID
            // 
            this.StockID.DataPropertyName = "StockID";
            this.StockID.HeaderText = "Mã Kho";
            this.StockID.MinimumWidth = 8;
            this.StockID.Name = "StockID";
            this.StockID.ReadOnly = true;
            this.StockID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StockID.Visible = false;
            // 
            // Supplier_ID
            // 
            this.Supplier_ID.DataPropertyName = "Supplier_ID";
            this.Supplier_ID.HeaderText = "Tên nhà cung cấp";
            this.Supplier_ID.MinimumWidth = 8;
            this.Supplier_ID.Name = "Supplier_ID";
            this.Supplier_ID.ReadOnly = true;
            this.Supplier_ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BookID
            // 
            this.BookID.DataPropertyName = "BookID";
            this.BookID.HeaderText = "Mã Sách";
            this.BookID.MinimumWidth = 8;
            this.BookID.Name = "BookID";
            this.BookID.ReadOnly = true;
            this.BookID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BookID.Visible = false;
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
            this.panel4.Location = new System.Drawing.Point(628, 105);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(531, 673);
            this.panel4.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.Controls.Add(this.cbxSupplier);
            this.panel6.Controls.Add(this.dtpk);
            this.panel6.Controls.Add(this.lbImportDate);
            this.panel6.Controls.Add(this.txtStockID);
            this.panel6.Controls.Add(this.lbStockID);
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
            this.panel6.Size = new System.Drawing.Size(531, 550);
            this.panel6.TabIndex = 1;
            // 
            // cbxSupplier
            // 
            this.cbxSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSupplier.FormattingEnabled = true;
            this.cbxSupplier.Location = new System.Drawing.Point(223, 372);
            this.cbxSupplier.Name = "cbxSupplier";
            this.cbxSupplier.Size = new System.Drawing.Size(273, 37);
            this.cbxSupplier.TabIndex = 41;
            // 
            // dtpk
            // 
            this.dtpk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk.Location = new System.Drawing.Point(223, 315);
            this.dtpk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpk.Name = "dtpk";
            this.dtpk.Size = new System.Drawing.Size(273, 34);
            this.dtpk.TabIndex = 40;
            // 
            // lbImportDate
            // 
            this.lbImportDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbImportDate.AutoSize = true;
            this.lbImportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImportDate.Location = new System.Drawing.Point(41, 319);
            this.lbImportDate.Name = "lbImportDate";
            this.lbImportDate.Size = new System.Drawing.Size(128, 29);
            this.lbImportDate.TabIndex = 38;
            this.lbImportDate.Text = "Ngày nhập";
            // 
            // txtStockID
            // 
            this.txtStockID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStockID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockID.Location = new System.Drawing.Point(223, 84);
            this.txtStockID.Name = "txtStockID";
            this.txtStockID.Size = new System.Drawing.Size(273, 34);
            this.txtStockID.TabIndex = 37;
            // 
            // lbStockID
            // 
            this.lbStockID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbStockID.AutoSize = true;
            this.lbStockID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStockID.Location = new System.Drawing.Point(41, 87);
            this.lbStockID.Name = "lbStockID";
            this.lbStockID.Size = new System.Drawing.Size(91, 29);
            this.lbStockID.TabIndex = 36;
            this.lbStockID.Text = "Mã kho";
            // 
            // lbSupplier
            // 
            this.lbSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSupplier.AutoSize = true;
            this.lbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSupplier.Location = new System.Drawing.Point(41, 377);
            this.lbSupplier.Name = "lbSupplier";
            this.lbSupplier.Size = new System.Drawing.Size(160, 29);
            this.lbSupplier.TabIndex = 34;
            this.lbSupplier.Text = "Nhà cung cấp";
            // 
            // cbxCategory
            // 
            this.cbxCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(223, 255);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(273, 37);
            this.cbxCategory.TabIndex = 31;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(223, 432);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(273, 34);
            this.txtQuantity.TabIndex = 30;
            // 
            // txtBookName
            // 
            this.txtBookName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookName.Location = new System.Drawing.Point(223, 198);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(273, 34);
            this.txtBookName.TabIndex = 29;
            // 
            // txtBookID
            // 
            this.txtBookID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookID.Location = new System.Drawing.Point(223, 141);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(273, 34);
            this.txtBookID.TabIndex = 28;
            // 
            // lbQuantity
            // 
            this.lbQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(41, 435);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(101, 29);
            this.lbQuantity.TabIndex = 27;
            this.lbQuantity.Text = "Tồn kho";
            // 
            // lbCategory
            // 
            this.lbCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCategory.AutoSize = true;
            this.lbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategory.Location = new System.Drawing.Point(41, 261);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(101, 29);
            this.lbCategory.TabIndex = 26;
            this.lbCategory.Text = "Thể loại";
            // 
            // lbBookName
            // 
            this.lbBookName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbBookName.AutoSize = true;
            this.lbBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookName.Location = new System.Drawing.Point(41, 203);
            this.lbBookName.Name = "lbBookName";
            this.lbBookName.Size = new System.Drawing.Size(56, 29);
            this.lbBookName.TabIndex = 25;
            this.lbBookName.Text = "Tên";
            // 
            // lbBookID
            // 
            this.lbBookID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbBookID.AutoSize = true;
            this.lbBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookID.Location = new System.Drawing.Point(41, 145);
            this.lbBookID.Name = "lbBookID";
            this.lbBookID.Size = new System.Drawing.Size(102, 29);
            this.lbBookID.TabIndex = 24;
            this.lbBookID.Text = "Mã sách";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnGIN);
            this.panel5.Controls.Add(this.btnReset);
            this.panel5.Controls.Add(this.btnUpdateBook);
            this.panel5.Controls.Add(this.btnDeleteBook);
            this.panel5.Controls.Add(this.btnAddBook);
            this.panel5.Controls.Add(this.btnRefresh);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 550);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(531, 123);
            this.panel5.TabIndex = 0;
            // 
            // btnGIN
            // 
            this.btnGIN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGIN.BackColor = System.Drawing.Color.Lime;
            this.btnGIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGIN.ForeColor = System.Drawing.Color.White;
            this.btnGIN.Location = new System.Drawing.Point(360, 21);
            this.btnGIN.Name = "btnGIN";
            this.btnGIN.Size = new System.Drawing.Size(163, 39);
            this.btnGIN.TabIndex = 22;
            this.btnGIN.Text = "Xuất phiếu";
            this.btnGIN.UseVisualStyleBackColor = false;
            this.btnGIN.Click += new System.EventHandler(this.btnGIN_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(360, 66);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(163, 39);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdateBook
            // 
            this.btnUpdateBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateBook.BackColor = System.Drawing.Color.Red;
            this.btnUpdateBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateBook.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateBook.ForeColor = System.Drawing.Color.White;
            this.btnUpdateBook.Location = new System.Drawing.Point(7, 21);
            this.btnUpdateBook.Name = "btnUpdateBook";
            this.btnUpdateBook.Size = new System.Drawing.Size(173, 39);
            this.btnUpdateBook.TabIndex = 19;
            this.btnUpdateBook.Text = "Cập nhật";
            this.btnUpdateBook.UseVisualStyleBackColor = false;
            this.btnUpdateBook.Click += new System.EventHandler(this.btnUpdateBook_Click);
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteBook.BackColor = System.Drawing.Color.Red;
            this.btnDeleteBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteBook.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBook.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBook.Location = new System.Drawing.Point(103, 66);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(173, 39);
            this.btnDeleteBook.TabIndex = 18;
            this.btnDeleteBook.Text = "Xóa sách";
            this.btnDeleteBook.UseVisualStyleBackColor = false;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddBook.BackColor = System.Drawing.Color.Red;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddBook.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.Location = new System.Drawing.Point(186, 21);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(168, 39);
            this.btnAddBook.TabIndex = 17;
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
            this.btnRefresh.Location = new System.Drawing.Point(59, 504);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(257, 42);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // UCStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCStock";
            this.Size = new System.Drawing.Size(1162, 780);
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
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dtpk;
        private System.Windows.Forms.Label lbImportDate;
        private System.Windows.Forms.TextBox txtStockID;
        private System.Windows.Forms.Label lbStockID;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn StockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Button btnGIN;
    }
}
