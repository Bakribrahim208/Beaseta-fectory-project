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
    public partial class اداره_المنتجات : Form
    {
        businiss_layer.products pro = new businiss_layer.products();
        DataTable dt = new DataTable();
        public اداره_المنتجات()
        {
            InitializeComponent();
            try { dt = pro.ALL_products();
            dataGridView1.DataSource = dt; }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           


        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                اضافه_منتج proo = new اضافه_منتج();
                proo.ShowDialog();
                dt = pro.ALL_products();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                    presentation_layer.اضافه_منتج ad = new اضافه_منتج();
            ad.button1.Text = "تعديل";
            ad.txt_name.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ad.txt_price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ad.txt_payd_price.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            ad.txt_qun.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            ad.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ad.ShowDialog();
            dt = pro.ALL_products();
            dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);
            }
          
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { if (MessageBox.Show("هل تريد حذف هذا المنتج؟", "حذف منتج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pro.Delete_product(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("تم المسح بنجاح");
                dt = pro.ALL_products();
                dataGridView1.DataSource = dt;
            }}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Reporting.كل_المنتجات reform = new Reporting.كل_المنتجات();
                Reporting.تقرير_كلالمنتجات report = new Reporting.تقرير_كلالمنتجات();
                report.SetDataSource(pro.ALL_products_for_print());
                reform.crystalReportViewer1.ReportSource = report;
                reform.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
