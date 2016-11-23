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
    public partial class تقرير_المشتريات : Form
    {
        businiss_layer.suppliers sup = new businiss_layer.suppliers();
        businiss_layer.category cat = new businiss_layer.category();
        businiss_layer.products pro = new businiss_layer.products();
        public تقرير_المشتريات()
        {
            InitializeComponent();

            comboBox1.DataSource = sup.All_sup();
            comboBox1.DisplayMember = "اسم المورد";
            comboBox1.ValueMember = "كود";

            comboBox2.DataSource = cat.All_Category();
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "id";

            comboBox3.DataSource = pro.ALL_products();
            comboBox3.DisplayMember = "اسم المنتج";
            comboBox3.ValueMember = "كود المنتج";

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void موردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
