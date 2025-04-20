using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FormQR : Form
    {
        public bool IsConfirmed { get; private set; } = false;
        public FormQR(string method = "Chuyển khoản ngân hàng")
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Width = 300;
            this.Height = 380;

            // Label hướng dẫn
            Label lbl = new Label();
            lbl.Text = $"Hãy chuyển khoản bằng {method} vào QR bên dưới nhé";
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Top;
            lbl.Height = 50;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // PictureBox hiển thị ảnh QR
            PictureBox pic = new PictureBox();
            pic.Image = Image.FromFile("Resources/qrbanking.jpg"); // Đường dẫn phải đúng
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Dock = DockStyle.Fill;

            // Panel bọc nút Đã xong để đệm khoảng cách
            Panel panelBottom = new Panel();
            panelBottom.Height = 50; // Cho thêm padding dưới
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Padding = new Padding(0, 5, 0, 10); // Trên 5, dưới 10

            // Nút "Đã xong"
            Button btnDone = new Button();
            btnDone.Text = "Đã xong";
            btnDone.Dock = DockStyle.Fill;
            btnDone.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDone.BackColor = Color.LightGreen;
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.Click += (s, e) =>
            {
                IsConfirmed = true;
                this.Close();
            };

            // Add nút vào panel
            panelBottom.Controls.Add(btnDone);

            // Button "X" để đóng
            Button btnClose = new Button();
            btnClose.Text = "X";
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.Size = new Size(30, 30);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.Red;
            btnClose.Cursor = Cursors.Hand;

            // Panel chứa nút X
            Panel panelTop = new Panel();
            panelTop.Height = 35;
            panelTop.Dock = DockStyle.Top;
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnClose);
            btnClose.Location = new Point(panelTop.Width - btnClose.Width - 5, 5);
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Event đóng Form
            btnClose.Click += (s, e) => this.Close();

            // ⚠️ Thứ tự Add rất quan trọng
            this.Controls.Add(panelBottom);     // Bottom
            this.Controls.Add(pic);         // Fill
            this.Controls.Add(lbl);         // Top
            this.Controls.Add(panelTop);    // Top (nút X)
            this.TopMost = true;
        }
    }
}
