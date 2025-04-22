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
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace PresentationLayer.UserControls
{
    public partial class UCIssue: UserControl
    {
        private StockBL stockBL;
        public UCIssue()
        {
            stockBL = new StockBL();
            InitializeComponent();
        }

        private void UCIssue_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                reportViewer1.LocalReport.ReportEmbeddedResource = "PresentationLayer.UserControls.rpxuatphieu.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = stockBL.GetStocks();
                reportViewer1.LocalReport.DataSources.Clear(); 
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
