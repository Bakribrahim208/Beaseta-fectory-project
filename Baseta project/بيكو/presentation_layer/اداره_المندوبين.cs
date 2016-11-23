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
    public partial class اداره_المندوبين : Form
    {
        businiss_layer.sales sales = new businiss_layer.sales();
        DataTable dt = new DataTable();
        public اداره_المندوبين()
        {
            InitializeComponent();
            dt = sales.All_sales();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {  اضافه_مندوب sal = new اضافه_مندوب();
            sal.ShowDialog();
            dt = sales.All_sales();
            dataGridView1.DataSource = dt;}
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void اداره_المندوبين_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
اضافه_مندوب sal = new اضافه_مندوب();
            sal.button1.Text = "تعديل";
            sal.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            sal.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            sal.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            sal.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            sal.ShowDialog();
            dt = sales.All_sales();
            dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
 if (MessageBox.Show("هل تريد مسح المندوب المحدد؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sales.Delete_Sales(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("تم المسح بنجاح");
            }
            dt = sales.All_sales();
            dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }
    }
}
