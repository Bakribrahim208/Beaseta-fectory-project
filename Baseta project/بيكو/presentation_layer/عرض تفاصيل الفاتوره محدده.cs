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
    public partial class عرض_تفاصيل_الفاتوره_محدده : Form
    {
        businiss_layer.orderes_and_exchanges or = new businiss_layer.orderes_and_exchanges();
        public int order_id;
        DataTable dt = new DataTable();
        public عرض_تفاصيل_الفاتوره_محدده()
        {
            InitializeComponent();
        //    MessageBox.Show(Properties.Settings.Default.Order_ID.ToString());
            dt = or.Get_order_detials(Properties.Settings.Default.Order_ID);
                           
            dataGridView1.DataSource = dt;
            textBox1.Text = Properties.Settings.Default.Order_ID.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int OR_ID = Convert.ToInt32(textBox1.Text);
            Reporting.طباعه_فاتوره_فورم reform = new Reporting.طباعه_فاتوره_فورم();
            Reporting.طباعه_فاوره report = new Reporting.طباعه_فاوره();
            report.SetDataSource(or.Get_order_detials_for_print(Properties.Settings.Default.Order_ID));
            reform.crystalReportViewer1.ReportSource = report;
            reform.ShowDialog();
        }
    }
}
