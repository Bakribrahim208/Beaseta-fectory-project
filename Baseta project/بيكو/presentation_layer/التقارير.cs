using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace بيكو.presentation_layer
{
    public partial class التقارير : Form
    {
        businiss_layer.products pro = new businiss_layer.products();
        public التقارير()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Reporting.كل_المنتجات reform = new Reporting.كل_المنتجات();
            Reporting.تقرير_كلالمنتجات report = new Reporting.تقرير_كلالمنتجات();
            report.SetDataSource(pro.ALL_products_for_print());
            reform.crystalReportViewer1.ReportSource = report;
            reform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reporting.كل_المنتجات reform = new Reporting.كل_المنتجات();
            Reporting.تقرير_كلالمنتجات report = new Reporting.تقرير_كلالمنتجات();
            report.SetDataSource(pro.ALL_products_for_print());
            reform.crystalReportViewer1.ReportSource = report;
            reform.ShowDialog();
        }
    }
}
