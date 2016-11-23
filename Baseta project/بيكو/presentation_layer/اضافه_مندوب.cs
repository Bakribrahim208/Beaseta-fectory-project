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
    public partial class اضافه_مندوب : Form
    {
        businiss_layer.sales sal = new businiss_layer.sales();
        public اضافه_مندوب()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "اضافه ")
            {
                sal.Add_sales(textBox2.Text, textBox3.Text, textBox4.Text);
                MessageBox.Show("تم الحفظ");
            }
            else
            {
                sal.Edit_sales(Convert.ToInt32( textBox1.Text),textBox2.Text,textBox3.Text, textBox4.Text);
                MessageBox.Show("تم التعديل");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
