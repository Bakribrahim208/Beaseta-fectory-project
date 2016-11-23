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
    public partial class اضافه_منتج : Form
    {
        businiss_layer.products prod = new businiss_layer.products();
        businiss_layer.category cat = new businiss_layer.category();
        DataTable dt = new DataTable();
        public اضافه_منتج()
        {
            InitializeComponent();
            comboBox2.DataSource = cat.All_Category();
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "تعديل")
            {
                prod._Edit_PRoduct(Convert.ToInt32(textBox1.Text), txt_name.Text, txt_qun.Text, comboBox1.SelectedItem.ToString(), txt_price.Text, txt_payd_price.Text, Convert.ToInt32(comboBox2.SelectedValue));
                MessageBox.Show("تم التعديل");
            }
            else
            {
                prod.ADD_PRoduct(txt_name.Text, txt_qun.Text, comboBox1.SelectedItem.ToString(), txt_price.Text, txt_payd_price.Text, Convert.ToInt32(comboBox2.SelectedValue));
                MessageBox.Show("تم الحفظ");
            }
          

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
