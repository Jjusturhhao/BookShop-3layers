using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

using Microsoft.Reporting.WinForms;

namespace PresentationLayer.UserControls
{
    public partial class Issue: UserControl
    {
        private StockBL stockBL;
        private string date;
        private List<Stock> stocks;

        public Issue()
        {
            stockBL = new StockBL();
            InitializeComponent();
        }
        public void SetDate(DateTime selectedDate)
        {
            date = selectedDate.ToString("dd/MM/yyyy HH:mm:ss");
            LoadReport();
        }

        public void SetStockList(List<Stock> stockList)
        {
            stocks = stockList;
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                List<SupplierStock> SupplierStock = stockBL.GetSupplierStocks();
                List<BookCategoryStock> BookCategoryStock = stockBL.GetBookCategories();
                if (stocks != null && stocks.Count > 0)
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "PresentationLayer.Report1.rdlc";
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", stocks);
                    ReportDataSource supplierDataSource = new ReportDataSource("DataSet2", SupplierStock);
                    ReportDataSource BookCategorySource = new ReportDataSource("DataSet3", BookCategoryStock);
                    ReportParameter[] para = new ReportParameter[]
                    {
                new ReportParameter("pDate", date)
                    };
                    reportViewer1.LocalReport.SetParameters(para);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                    reportViewer1.LocalReport.DataSources.Add(supplierDataSource);
                    reportViewer1.LocalReport.DataSources.Add(BookCategorySource);
                    reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Đang tải phiếu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất phiếu: " + ex.ToString());
            }
        }
        private void ShowUserControl(UCStock uCStock)
        {
            panel1.Controls.Clear();
            uCStock.Dock = DockStyle.Fill;
            panel1.Controls.Add(uCStock);
            uCStock.BringToFront();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UCStock());
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
