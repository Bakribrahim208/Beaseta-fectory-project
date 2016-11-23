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
    public partial class اضافه_عميل : Form
    {
        businiss_layer.category  cat=new businiss_layer.category();
        DataTable dt = new DataTable();
        public اضافه_عميل()
        {
            InitializeComponent();
            dt = cat.All_Category();
            dataGridView1.DataSource = dt;
            button1.Enabled = false;
        }
        public void clearTEXT()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            cat.ADD_PRoduct(textBox2.Text, textBox3.Text);
            MessageBox.Show("تمت الاضافه");
            dt = cat.All_Category();
            dataGridView1.DataSource = dt;
            clearTEXT();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            cat.edit_category(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);
            MessageBox.Show("تم التعديل");
            dt = cat.All_Category();
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف الصنف المحدد؟", "حذف صنف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cat.Delete_cat(Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("تم المسح");
                dt = cat.All_Category();
                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(cat.last_cat().Rows[0][0].ToString());
            button1.Enabled = true;
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reporting.كل_المنتجات_للصنف reform = new Reporting.كل_المنتجات_للصنف();
            Reporting.كل_منتجات_صنف_محدد report = new Reporting.كل_منتجات_صنف_محدد();
            report.SetDataSource(cat.ALL_products__incat_for_print(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)));
            reform.crystalReportViewer1.ReportSource = report;
            reform.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            presentation_layer.عرض_اصناف cata = new عرض_اصناف();
            Properties.Settings.Default.category_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            cata.ShowDialog();
        }
    }
}
