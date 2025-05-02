using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using System.Windows.Forms.DataVisualization.Charting;
using BusinessLayer;


namespace PresentationLayer.UserControls
{
    public partial class UCStatistics : UserControl
    {
        private StatisticsBL statisticsBL;
        public UCStatistics()
        {
            InitializeComponent();
            statisticsBL = new StatisticsBL();
            LoadMonthYear();
        }

        private void LoadMonthYear()
        {
            // Load tháng
            cbxMonth2.Items.Clear();
            cbxMonth3.Items.Clear();
            for (int month = 1; month <= 12; month++)
            {
                cbxMonth2.Items.Add(month);
                cbxMonth3.Items.Add(month);
            }
            cbxMonth2.SelectedItem = DateTime.Now.Month;
            cbxMonth3.SelectedItem = DateTime.Now.Month;

            // Load năm
            cbxYear.Items.Clear();
            cbxYear2.Items.Clear();
            cbxYear3.Items.Clear();
            cbxYear4.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= currentYear - 10; year--)
            {
                cbxYear.Items.Add(year);
                cbxYear2.Items.Add(year);
                cbxYear3.Items.Add(year);
                cbxYear4.Items.Add(year);
            }

            // Default chọn tháng hiện tại, năm hiện tại
            cbxYear.SelectedItem = DateTime.Now.Year;
            cbxYear2.SelectedItem = DateTime.Now.Year;
            cbxYear3.SelectedItem = DateTime.Now.Year;
            cbxYear4.SelectedItem = DateTime.Now.Year;
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbxYear.SelectedItem == null) return;

            int selectedYear = (int)cbxYear.SelectedItem;
            List<MonthlyRevenue> revenues = statisticsBL.GetMonthlyRevenueByYear(selectedYear);

            chartRevenue.Series.Clear();
            Series series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = System.Drawing.Color.DarkBlue,
            };

            for (int month = 1; month <= 12; month++)
            {
                decimal revenue = 0;
                var found = revenues.Find(r => r.Month == month);
                if (found != null)
                    revenue = found.TotalRevenue;

                series.Points.AddXY(month, revenue);
                var point = series.Points[series.Points.Count - 1];
                point.Label = revenue.ToString("#,##0") + " đ";
                point.Font = new Font("Arial", 8, FontStyle.Bold);
                point.LabelForeColor = Color.Black;

            }
            chartRevenue.Series.Add(series);
            // Làm sạch trục X
            chartRevenue.ChartAreas[0].AxisX.Minimum = 1;
            chartRevenue.ChartAreas[0].AxisX.Maximum = 12;
            chartRevenue.ChartAreas[0].AxisX.Interval = 1;
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.Format = "#";

            // Cấu hình trục X và Y
            chartRevenue.ChartAreas[0].AxisX.Title = "Tháng";
            chartRevenue.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
        }

        private void btnViewTop5_Click(object sender, EventArgs e)
        {
            if (cbxYear2.SelectedItem == null) return; // Chỉ bắt buộc chọn Năm thôi, bỏ bắt buộc Tháng!

            int selectedYear = (int)cbxYear2.SelectedItem;
            int? selectedMonth = cbxMonth2.SelectedItem != null ? (int?)cbxMonth2.SelectedItem : null;

            List<TopSellingBook> top5Books = statisticsBL.GetTopSellingBooksByMonth(selectedYear, selectedMonth);

            chartTop5.Series.Clear();
            Series series = new Series("Top 5 bán chạy")
            {
                ChartType = SeriesChartType.Pie,
                BorderWidth = 1
            };

            double total = top5Books.Sum(b => b.TotalSold);

            foreach (var book in top5Books)
            {
                double percent = total == 0 ? 0 : (book.TotalSold / total) * 100;
                int pointIndex = series.Points.AddXY(book.Title, book.TotalSold);

                // Đặt label ngoài vòng tròn: Tên sách (Số lượng) - Phần trăm%
                series.Points[pointIndex].Label = $"{book.Title} ({book.TotalSold}) - {percent:0.#}%";
            }

            series["PieLabelStyle"] = "Outside";    // Label nằm ngoài
            series["PieLineColor"] = "Black";        // Mũi tên nối

            chartTop5.Series.Add(series);
        }

        private void btnCateRevenue_Click(object sender, EventArgs e)
        {
            if (cbxYear3.SelectedItem == null) return;

            int selectedYear = (int)cbxYear3.SelectedItem;
            int? selectedMonth = cbxMonth3.SelectedItem != null ? (int?)cbxMonth3.SelectedItem : null;
            List<CategoryRevenue> caterevenues = statisticsBL.GetCategoryRevenueByMonth(selectedYear, selectedMonth);

            chartCategoryRevenue.Series.Clear();
            chartCategoryRevenue.ChartAreas[0].AxisX.LabelStyle.Angle = 0; // Bỏ nghiêng
            chartCategoryRevenue.ChartAreas[0].AxisX.Interval = 1;
            chartCategoryRevenue.ChartAreas[0].AxisX.LabelStyle.Enabled = false; // Ẩn nhãn dưới trục X

            // Xóa grid line
            chartCategoryRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartCategoryRevenue.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            Series series = new Series("Doanh thu theo thể loại")
            {
                ChartType = SeriesChartType.Column,
                BorderWidth = 3,
                IsValueShownAsLabel = true
            };

            // Các màu cho từng thể loại
            Color[] colors = { Color.Salmon, Color.SeaGreen, Color.RoyalBlue, Color.Goldenrod, Color.MediumOrchid };

            int colorIndex = 0;
            foreach (var item in caterevenues)
            {
                string categoryName = item.CategoryName;
                decimal revenue = item.TotalRevenue;

                int pointIndex = series.Points.AddXY(categoryName, revenue);
                var point = series.Points[pointIndex];
                point.Color = colors[colorIndex % colors.Length];
                point.Label = revenue.ToString("#,##0") + " đ";
                point.Font = new Font("Arial", 8, FontStyle.Bold);
                point.LabelForeColor = Color.Black;
                colorIndex++;
            }

            // Làm cột rộng ra
            series["PointWidth"] = "0.6"; // từ 0 -> 1, càng lớn càng rộng

            chartCategoryRevenue.Series.Add(series);

            // Cấu hình trục
            chartCategoryRevenue.ChartAreas[0].AxisX.Title = "Thể loại sách";
            chartCategoryRevenue.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";

            // Gắn legend cho từng màu
            chartCategoryRevenue.Legends.Clear();
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.Title = "";
            chartCategoryRevenue.Legends.Add(legend);
            // Thêm custom legend items
            for (int i = 0; i < caterevenues.Count; i++)
            {
                LegendItem item = new LegendItem();
                item.Name = caterevenues[i].CategoryName;
                item.Color = colors[i % colors.Length];
                item.BorderColor = Color.Black;
                chartCategoryRevenue.Legends[0].CustomItems.Add(item);
            }
            series.IsVisibleInLegend = false;
            // Tính doanh thu cao nhất
            decimal maxRevenue = caterevenues.Max(c => c.TotalRevenue);

            // Cập nhật lại trục Y
            chartCategoryRevenue.ChartAreas[0].AxisY.Maximum = (double)(Math.Ceiling(maxRevenue / 50000m) * 50000m);
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            if (cbxYear4.SelectedItem == null) return;

            int selectedYear = (int)cbxYear4.SelectedItem;
            List<OrderQuantity> orderQuantities = statisticsBL.GetOrderQuantityByYear(selectedYear);

            chartOrderQuantity.Series.Clear();
            Series series = new Series("Số lượng đơn hàng")
            {
                ChartType = SeriesChartType.Column,
                BorderWidth = 3,
                Color = System.Drawing.Color.Chartreuse,
            };

            for (int month = 1; month <= 12; month++)
            {
                int quantityForMonth = 0;
                var found = orderQuantities.FirstOrDefault(q => q.Month == month);
                if (found != null)
                {
                    quantityForMonth = found.OrderCount;
                }

                series.Points.AddXY(month, quantityForMonth);

                var point = series.Points[series.Points.Count - 1];
                point.Label = quantityForMonth.ToString("#,##0");
                point.Font = new Font("Arial", 8, FontStyle.Bold);
                point.LabelForeColor = Color.Black;
            }

            chartOrderQuantity.Series.Add(series);
            chartOrderQuantity.ChartAreas[0].AxisX.Title = "Tháng";
            chartOrderQuantity.ChartAreas[0].AxisY.Title = "Số đơn hàng";
            chartOrderQuantity.ChartAreas[0].AxisY.Interval = 1;
            chartOrderQuantity.ChartAreas[0].AxisY.LabelStyle.Format = "#";

            // Chỉnh trục X và vùng vẽ
            chartOrderQuantity.ChartAreas[0].AxisX.Minimum = 0.5;
            chartOrderQuantity.ChartAreas[0].AxisX.Maximum = 12.5;
            chartOrderQuantity.ChartAreas[0].AxisX.Interval = 1;
            chartOrderQuantity.ChartAreas[0].AxisX.LabelStyle.Format = "#";
            chartOrderQuantity.ChartAreas[0].Position = new ElementPosition(5, 10, 90, 80);
            chartOrderQuantity.ChartAreas[0].InnerPlotPosition = new ElementPosition(10, 10, 80, 80);
        }
    }
}
