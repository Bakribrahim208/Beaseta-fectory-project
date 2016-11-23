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
    public partial class اضافه_مورد : Form
    {
        businiss_layer.suppliers sup = new businiss_layer.suppliers();
        public اضافه_مورد()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(sup.last_sup().Rows[0][0].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "اضافه ")
            {
            sup.Add_suppliers(textBox2.Text, textBox3.Text, textBox4.Text,0,0,0);
            MessageBox.Show("تم الحفظ"); 
            }
            else
            {
                sup.Edite_suppliers(Convert.ToInt32( textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text);
                MessageBox.Show("تم التعديل"); 
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
