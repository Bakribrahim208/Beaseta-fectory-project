using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Diagnostics;

namespace بيكو.presentation_layer
{
    public partial class جميع_فواتير_البيع : Form
    {
        businiss_layer.orderes_and_exchanges or = new businiss_layer.orderes_and_exchanges();
        DataTable dt = new DataTable();
        public جميع_فواتير_البيع()
        {
            InitializeComponent();
            //CultureInfo cf = new CultureInfo("en-GB");
            //string e = "3";
            //Thread.CurrentThread.CurrentCulture = cf;
           
            //string da = "3-"+e+"-2016";
            //DateTime ddd = DateTime.Parse(da);
             dt = or.ALL_orderes();
            dataGridView1.DataSource = dt;
            total_price();

         }

         

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = new DataTable();
            dtt=   or.ALL_orderes_bound_by_date(Convert.ToDateTime( dateTimePicker1.Value.ToShortDateString()),Convert.ToDateTime( dateTimePicker2.Value.ToShortDateString()));
            dataGridView1.DataSource = dtt;
            total_price();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);

            }
        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = new DataTable();
                if (comboBox1.Text == "فواتير اليوم")
                {

                    dtt = or.ALL_orderes_bound_by_date(DateTime.Today, DateTime.Today);
                    dataGridView1.DataSource = dtt;
                    total_price();

                }
                else if (comboBox1.Text == "هذا الشهر ")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);
                    string month = "2016", year = "1";
                    month = start.Month.ToString();
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "28-" + month+"-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime( ddd.ToShortDateString()),Convert.ToDateTime( end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "هذا العام")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);
                    string month = "1", year = "2016";
                    //month = start.Month.ToString();
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    month = "12";
                    s = "31-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "يناير ")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);
                    string month = "1", year = "2016";
                    //month = start.Month.ToString();
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "31-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "فبراير")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "2", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "28-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "مارس ")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "3", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "31-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "ابريل ")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "4", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "30-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "مايو")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "5", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "31-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "يونيه")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "6", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "30-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "يوليو")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "7", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "31-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "اعسطس")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "8", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "31-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "سبتمبر")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "9", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "30-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "اكتوبر")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "10", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "31-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "نوفمبر")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "11", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "30-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                else if (comboBox1.Text == "ديسمبر")
                {
                    string s = DateTime.Today.ToString();
                    DateTime start = Convert.ToDateTime(s);

                    string month = "12", year = "2016";
                    year = start.Year.ToString();
                    CultureInfo cf = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = cf;
                    s = "1-" + month + "-" + year;
                    DateTime ddd = DateTime.Parse(s);
                    s = "31-" + month + "-" + year;
                    DateTime end = DateTime.Parse(s);
                    dtt = or.ALL_orderes_bound_by_date(Convert.ToDateTime(ddd.ToShortDateString()), Convert.ToDateTime(end.ToShortDateString()));
                    dataGridView1.DataSource = dtt;
                    total_price();
                }
                 
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void total_price()
        {
            double d = 0, d1 = 0, d2 = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                  d  += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                  d1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                  d2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
            }
            total.Text = d.ToString();
            payed.Text = d1.ToString();
            remain.Text = d2.ToString();
            count.Text =Convert.ToString( dataGridView1.Rows.Count-1);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable r = new DataTable();
                r = or.search_orderes(textBox1.Text);
                dataGridView1.DataSource = r;
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);

            }
         
        }
         private void button2_Click(object sender, EventArgs e)
        {
 
            presentation_layer.عرض_تفاصيل_الفاتوره_محدده show = new عرض_تفاصيل_الفاتوره_محدده();
            
            Properties.Settings.Default.Order_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
             show.ShowDialog();
        }

         private void button3_Click(object sender, EventArgs e)
         {
             try
             {
                 Reporting.طباعه_فاتوره_فورم reform = new Reporting.طباعه_فاتوره_فورم();
                 Reporting.طباعه_فاوره report = new Reporting.طباعه_فاوره();
                 report.SetDataSource(or.Get_order_detials_for_print(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)));
                 reform.crystalReportViewer1.ReportSource = report;
                 reform.ShowDialog();
             }catch(Exception ex )
             {
                 MessageBox.Show(ex.Message);
             }
         }

        
    }
}
 