namespace PresentationLayer.UserControls
{
    partial class UCHomepage
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.flowLayoutPanelBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.pnPage = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            this.pnPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Controls.Add(this.flowLayoutPanelBooks);
            this.panelContainer.Controls.Add(this.pnPage);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1180, 702);
            this.panelContainer.TabIndex = 29;
            // 
            // flowLayoutPanelBooks
            // 
            this.flowLayoutPanelBooks.AutoScroll = true;
            this.flowLayoutPanelBooks.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelBooks.Location = new System.Drawing.Point(0, 68);
            this.flowLayoutPanelBooks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelBooks.Name = "flowLayoutPanelBooks";
            this.flowLayoutPanelBooks.Size = new System.Drawing.Size(1180, 634);
            this.flowLayoutPanelBooks.TabIndex = 30;
            // 
            // pnPage
            // 
            this.pnPage.Controls.Add(this.btnSearch);
            this.pnPage.Controls.Add(this.txtSearch);
            this.pnPage.Controls.Add(this.lbPage);
            this.pnPage.Controls.Add(this.btnNext);
            this.pnPage.Controls.Add(this.btnPrevious);
            this.pnPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnPage.Location = new System.Drawing.Point(0, 0);
            this.pnPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnPage.Name = "pnPage";
            this.pnPage.Size = new System.Drawing.Size(1180, 68);
            this.pnPage.TabIndex = 29;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1015, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(148, 49);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.MistyRose;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(339, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(669, 44);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbPage
            // 
            this.lbPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPage.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPage.Location = new System.Drawing.Point(82, 9);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(59, 48);
            this.lbPage.TabIndex = 26;
            this.lbPage.Text = "Page";
            this.lbPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(148, 9);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(46, 49);
            this.btnNext.TabIndex = 25;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(29, 9);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(46, 49);
            this.btnPrevious.TabIndex = 24;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // UCHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCHomepage";
            this.Size = new System.Drawing.Size(1180, 702);
            this.panelContainer.ResumeLayout(false);
            this.pnPage.ResumeLayout(false);
            this.pnPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel pnPage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBooks;
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
