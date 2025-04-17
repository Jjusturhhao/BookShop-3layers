namespace PresentationLayer.UserControls
{
    partial class UCCart
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
            this.lbCart = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.panelCart = new System.Windows.Forms.Panel();
            this.flpCart = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lbTotalCost = new System.Windows.Forms.Label();
            this.panelCart.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCart
            // 
            this.lbCart.AutoSize = true;
            this.lbCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCart.ForeColor = System.Drawing.Color.Red;
            this.lbCart.Location = new System.Drawing.Point(33, 24);
            this.lbCart.Name = "lbCart";
            this.lbCart.Size = new System.Drawing.Size(145, 36);
            this.lbCart.TabIndex = 0;
            this.lbCart.Text = "Giỏ hàng";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(196, 24);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(189, 36);
            this.lbQuantity.TabIndex = 1;
            this.lbQuantity.Text = "(0 sản phẩm)";
            // 
            // panelCart
            // 
            this.panelCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCart.Controls.Add(this.flpCart);
            this.panelCart.Controls.Add(this.panel3);
            this.panelCart.Location = new System.Drawing.Point(50, 89);
            this.panelCart.Name = "panelCart";
            this.panelCart.Size = new System.Drawing.Size(1074, 579);
            this.panelCart.TabIndex = 2;
            // 
            // flpCart
            // 
            this.flpCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCart.AutoScroll = true;
            this.flpCart.BackColor = System.Drawing.Color.Ivory;
            this.flpCart.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCart.Location = new System.Drawing.Point(32, 28);
            this.flpCart.Name = "flpCart";
            this.flpCart.Size = new System.Drawing.Size(570, 517);
            this.flpCart.TabIndex = 3;
            this.flpCart.WrapContents = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Ivory;
            this.panel3.Controls.Add(this.btnOrder);
            this.panel3.Controls.Add(this.lbTotalCost);
            this.panel3.Location = new System.Drawing.Point(670, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(371, 517);
            this.panel3.TabIndex = 2;
            // 
            // btnOrder
            // 
            this.btnOrder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOrder.BackColor = System.Drawing.Color.Red;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOrder.Location = new System.Drawing.Point(97, 441);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(181, 54);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "Thanh toán";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lbTotalCost
            // 
            this.lbTotalCost.AutoSize = true;
            this.lbTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalCost.Location = new System.Drawing.Point(17, 21);
            this.lbTotalCost.Name = "lbTotalCost";
            this.lbTotalCost.Size = new System.Drawing.Size(126, 29);
            this.lbTotalCost.TabIndex = 0;
            this.lbTotalCost.Text = "Thành tiền";
            // 
            // UCCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCart);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbCart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCCart";
            this.Size = new System.Drawing.Size(1182, 729);
            this.Load += new System.EventHandler(this.UCCart_Load);
            this.panelCart.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCart;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.Panel panelCart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label lbTotalCost;
        private System.Windows.Forms.FlowLayoutPanel flpCart;
    }
}
