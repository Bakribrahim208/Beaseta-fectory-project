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
    public partial class اداره_الموردين : Form
    {
        businiss_layer.suppliers supp = new businiss_layer.suppliers();
        DataTable dt = new DataTable();
        public اداره_الموردين()
        {
            InitializeComponent();
            dt = supp.All_sup();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            اضافه_مورد sup = new اضافه_مورد();
            sup.ShowDialog();
            dt = supp.All_sup();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف هذا العميل ", "حذف عميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                supp.Delete_sup(Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("تم المسح");
                dt = supp.All_sup();
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            اضافه_مورد sup = new اضافه_مورد();
            sup.button1.Text = "تعديل";
            sup.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            sup.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            sup.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            sup.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            sup.ShowDialog();
            dt = supp.All_sup();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
