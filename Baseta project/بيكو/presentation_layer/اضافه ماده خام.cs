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
    public partial class اضافه_ماده_خام : Form
    {
        businiss_layer.products pro = new businiss_layer.products();
        public اضافه_ماده_خام()
        {
            InitializeComponent(); 
            cmb_suppliers.DataSource = pro.ALL_suppliers();
            cmb_suppliers.DisplayMember = "اسم المورد";
            cmb_suppliers.ValueMember = "كود";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "اضافه")
            {
                pro.ADD__Org_PRoduct(txtname.Text, txt_qun.Text, Convert.ToString( cmb_unit.SelectedItem), txtprice.Text, txt_total.Text, Convert.ToInt32(cmb_suppliers.SelectedValue));
                MessageBox.Show("تم الحفظ");
            }
            else
            {
                pro._Edit__Org_PRoduct(Convert.ToInt32(textBox1.Text), txtname.Text, txt_qun.Text,Convert.ToString( cmb_unit.SelectedItem), txtprice.Text, txt_total.Text, Convert.ToInt32(cmb_suppliers.SelectedValue));
                MessageBox.Show("تم التعديل");

            }
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_qun_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPayed_price_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txt_qun_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txt_total.Text = Convert.ToString(Convert.ToInt32(txt_qun.Text) * Convert.ToInt32(txtprice.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }
    }
}
