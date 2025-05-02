namespace PresentationLayer.UserControls
{
    partial class UCPrintBill
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.lblChange = new System.Windows.Forms.TextBox();
            this.lblAmountPaid = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.TextBox();
            this.lblOrderID = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.TextBox();
            this.lblPaymentMethod = new System.Windows.Forms.TextBox();
            this.lblCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.TextBox();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picBarcode);
            this.panel1.Controls.Add(this.lblChange);
            this.panel1.Controls.Add(this.lblAmountPaid);
            this.panel1.Controls.Add(this.lblOrderDate);
            this.panel1.Controls.Add(this.lblEmployeeName);
            this.panel1.Controls.Add(this.lblOrderID);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Controls.Add(this.lblPaymentMethod);
            this.panel1.Controls.Add(this.lblCustomerPhone);
            this.panel1.Controls.Add(this.lblCustomerName);
            this.panel1.Controls.Add(this.dgvBook);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1409, 807);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 665);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ký Xác Nhận";
            // 
            // picBarcode
            // 
            this.picBarcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBarcode.Location = new System.Drawing.Point(1110, 94);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(134, 81);
            this.picBarcode.TabIndex = 12;
            this.picBarcode.TabStop = false;
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(1357, 820);
            this.lblChange.Name = "lblChange";
            this.lblChange.ReadOnly = true;
            this.lblChange.Size = new System.Drawing.Size(580, 35);
            this.lblChange.TabIndex = 11;
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaid.Location = new System.Drawing.Point(1357, 770);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.ReadOnly = true;
            this.lblAmountPaid.Size = new System.Drawing.Size(580, 35);
            this.lblAmountPaid.TabIndex = 10;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(1357, 88);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.ReadOnly = true;
            this.lblOrderDate.Size = new System.Drawing.Size(410, 32);
            this.lblOrderDate.TabIndex = 9;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(0, 140);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.ReadOnly = true;
            this.lblEmployeeName.Size = new System.Drawing.Size(348, 35);
            this.lblEmployeeName.TabIndex = 8;
            // 
            // lblOrderID
            // 
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(3, 88);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.ReadOnly = true;
            this.lblOrderID.Size = new System.Drawing.Size(345, 32);
            this.lblOrderID.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1409, 66);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "HOÁ ĐƠN THANH TOÁN";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(1357, 714);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.ReadOnly = true;
            this.lblTotalAmount.Size = new System.Drawing.Size(580, 35);
            this.lblTotalAmount.TabIndex = 3;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(1357, 661);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.ReadOnly = true;
            this.lblPaymentMethod.Size = new System.Drawing.Size(580, 35);
            this.lblPaymentMethod.TabIndex = 2;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPhone.Location = new System.Drawing.Point(0, 239);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.ReadOnly = true;
            this.lblCustomerPhone.Size = new System.Drawing.Size(348, 35);
            this.lblCustomerPhone.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(0, 186);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.ReadOnly = true;
            this.lblCustomerName.Size = new System.Drawing.Size(348, 35);
            this.lblCustomerName.TabIndex = 0;
            // 
            // dgvBook
            // 
            this.dgvBook.AllowUserToAddRows = false;
            this.dgvBook.AllowUserToDeleteRows = false;
            this.dgvBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBook.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBook.EnableHeadersVisualStyles = false;
            this.dgvBook.Location = new System.Drawing.Point(3, 302);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBook.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBook.RowHeadersVisible = false;
            this.dgvBook.RowHeadersWidth = 62;
            this.dgvBook.RowTemplate.Height = 28;
            this.dgvBook.Size = new System.Drawing.Size(1403, 332);
            this.dgvBook.TabIndex = 6;
            // 
            // InBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InBill";
            this.Size = new System.Drawing.Size(1409, 807);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox lblTotalAmount;
        private System.Windows.Forms.TextBox lblPaymentMethod;
        private System.Windows.Forms.TextBox lblCustomerPhone;
        private System.Windows.Forms.TextBox lblCustomerName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvBook;
        private System.Windows.Forms.TextBox lblEmployeeName;
        private System.Windows.Forms.TextBox lblOrderID;
        private System.Windows.Forms.TextBox lblOrderDate;
        private System.Windows.Forms.TextBox lblChange;
        private System.Windows.Forms.TextBox lblAmountPaid;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.Label label1;
    }
}
