namespace PresentationLayer.UserControls
{
    partial class UCBookDetail
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.btnAddCart = new System.Windows.Forms.Button();
            this.lbPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImage.Location = new System.Drawing.Point(48, 218);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(208, 235);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 54;
            this.pictureBoxImage.TabStop = false;
            // 
            // lbQuantity
            // 
            this.lbQuantity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(281, 298);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(225, 38);
            this.lbQuantity.TabIndex = 53;
            this.lbQuantity.Text = "Số lượng còn: ";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBack.Location = new System.Drawing.Point(288, 559);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(542, 57);
            this.btnBack.TabIndex = 52;
            this.btnBack.Text = "Tiếp tục mua";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbCategory
            // 
            this.lbCategory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbCategory.AutoSize = true;
            this.lbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategory.Location = new System.Drawing.Point(281, 242);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(141, 38);
            this.lbCategory.TabIndex = 49;
            this.lbCategory.Text = "Thể loại:";
            // 
            // lbName
            // 
            this.lbName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(280, 65);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(192, 46);
            this.lbName.TabIndex = 46;
            this.lbName.Text = "Tên sách";
            // 
            // lbAuthor
            // 
            this.lbAuthor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthor.Location = new System.Drawing.Point(281, 184);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(133, 38);
            this.lbAuthor.TabIndex = 47;
            this.lbAuthor.Text = "Tác giả:";
            // 
            // btnAddCart
            // 
            this.btnAddCart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddCart.BackColor = System.Drawing.Color.Red;
            this.btnAddCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCart.ForeColor = System.Drawing.Color.White;
            this.btnAddCart.Location = new System.Drawing.Point(288, 469);
            this.btnAddCart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddCart.Name = "btnAddCart";
            this.btnAddCart.Size = new System.Drawing.Size(542, 71);
            this.btnAddCart.TabIndex = 50;
            this.btnAddCart.Text = "Thêm vào giỏ";
            this.btnAddCart.UseVisualStyleBackColor = false;
            this.btnAddCart.Click += new System.EventHandler(this.btnAddCart_Click);
            // 
            // lbPrice
            // 
            this.lbPrice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.Red;
            this.lbPrice.Location = new System.Drawing.Point(280, 371);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(149, 40);
            this.lbPrice.TabIndex = 48;
            this.lbPrice.Text = "Giá tiền";
            // 
            // UCBookDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbCategory);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbAuthor);
            this.Controls.Add(this.btnAddCart);
            this.Controls.Add(this.lbPrice);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCBookDetail";
            this.Size = new System.Drawing.Size(1177, 678);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.Button btnAddCart;
        private System.Windows.Forms.Label lbPrice;
    }
}
