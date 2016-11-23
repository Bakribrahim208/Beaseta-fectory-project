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
    public partial class اداره_المواد_الخام : Form
    {
        businiss_layer.products pro = new businiss_layer.products();
        DataTable dt = new DataTable();
        public اداره_المواد_الخام()
        {
            InitializeComponent();
            dt = pro.ALL_Org_products();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            اضافه_ماده_خام or = new اضافه_ماده_خام();
            or.ShowDialog();
            dt = pro.ALL_Org_products();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            button1.Text = "اضافه";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            presentation_layer.اضافه_ماده_خام org_pro = new اضافه_ماده_خام();
            org_pro.button1.Text = "تعديل";
                
            org_pro.txt_qun.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
            org_pro.txtname.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            org_pro.txtprice.Text=dataGridView1.CurrentRow.Cells[4].Value.ToString();
            org_pro.txt_total.Text=dataGridView1.CurrentRow.Cells[5].Value.ToString();
            org_pro.textBox1.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            org_pro.ShowDialog();
            org_pro.button1.Text = "اضافه";
            dt = pro.ALL_Org_products();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف هذا المنتج؟", "حذف منتج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pro.Delete_Org_product(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("تم المسح بنجاح");
                dt = pro.ALL_Org_products();
                dataGridView1.DataSource = dt;
            }
        }
    }
}
