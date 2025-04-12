﻿namespace PresentationLayer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel = new System.Windows.Forms.Panel();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnStaffInterface = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.MistyRose;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.btnSupplier);
            this.panel.Controls.Add(this.btnOrder);
            this.panel.Controls.Add(this.btnInfo);
            this.panel.Controls.Add(this.btnStock);
            this.panel.Controls.Add(this.btnBook);
            this.panel.Controls.Add(this.btnCheckout);
            this.panel.Controls.Add(this.btnStaffInterface);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 536);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1367, 94);
            this.panel.TabIndex = 62;
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSupplier.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSupplier.Location = new System.Drawing.Point(984, -4);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(0);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(220, 95);
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.Text = "Nhà cung cấp";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnOrder.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOrder.Location = new System.Drawing.Point(775, -4);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(220, 95);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "Đơn hàng";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInfo.BackgroundImage")));
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInfo.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInfo.Location = new System.Drawing.Point(1204, -4);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(161, 96);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStock.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStock.Location = new System.Drawing.Point(610, -4);
            this.btnStock.Margin = new System.Windows.Forms.Padding(0);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(176, 96);
            this.btnStock.TabIndex = 3;
            this.btnStock.Text = "Kho";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBook.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBook.Location = new System.Drawing.Point(428, -4);
            this.btnBook.Margin = new System.Windows.Forms.Padding(0);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(192, 96);
            this.btnBook.TabIndex = 2;
            this.btnBook.Text = "Sách";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCheckout.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCheckout.Location = new System.Drawing.Point(219, -4);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(0);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(213, 96);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "Bán hàng";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnStaffInterface
            // 
            this.btnStaffInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStaffInterface.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffInterface.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStaffInterface.Location = new System.Drawing.Point(-1, -6);
            this.btnStaffInterface.Margin = new System.Windows.Forms.Padding(0);
            this.btnStaffInterface.Name = "btnStaffInterface";
            this.btnStaffInterface.Size = new System.Drawing.Size(230, 98);
            this.btnStaffInterface.TabIndex = 0;
            this.btnStaffInterface.Text = "Trang chủ";
            this.btnStaffInterface.UseVisualStyleBackColor = false;
            this.btnStaffInterface.Click += new System.EventHandler(this.btnStaffInterface_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1367, 536);
            this.panelContainer.TabIndex = 63;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 630);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnStaffInterface;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnSupplier;
    }
}