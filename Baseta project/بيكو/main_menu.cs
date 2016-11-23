using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace بيكو
{
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          try
            {presentation_layer.اداره_العملاء cust = new presentation_layer.اداره_العملاء();
            cust.ShowDialog();}
              catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.اداره_الموردين sup = new presentation_layer.اداره_الموردين();
                sup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {   presentation_layer.اداره_المندوبين sal = new presentation_layer.اداره_المندوبين();
            sal.ShowDialog(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { try
        {  presentation_layer.اداره_المواد_الخام pro = new presentation_layer.اداره_المواد_الخام();
            pro.ShowDialog();}
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { presentation_layer.اداره_المنتجات pro = new presentation_layer.اداره_المنتجات();
            pro.ShowDialog(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.جميع_فواتير_البيع a = new presentation_layer.جميع_فواتير_البيع();
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "منتجات منتهيه")
                {
                    Properties.Settings.Default.inquiry = 0;
                    Properties.Settings.Default.inqury_type = "0";
                    presentation_layer.استعلامات qur = new presentation_layer.استعلامات();
                    qur.ShowDialog();
                }
                else if (comboBox1.Text == "منتجات اوشكت ع الانتهاء")
                {
                    Properties.Settings.Default.inquiry = 10;
                    Properties.Settings.Default.inqury_type = "0";
                    presentation_layer.استعلامات qur = new presentation_layer.استعلامات();
                    qur.ShowDialog();
                }
                else if (comboBox1.Text == "مواد خام منتهيه")
                {
                    Properties.Settings.Default.inquiry = 0;
                    Properties.Settings.Default.inqury_type = "1";
                    presentation_layer.استعلامات qur = new presentation_layer.استعلامات();
                    qur.ShowDialog();
                }
                else if (comboBox1.Text == "مواد الخام اوشكت علي الانتهاء")
                {
                    Properties.Settings.Default.inquiry = 10;
                    Properties.Settings.Default.inqury_type = "1";
                    presentation_layer.استعلامات qur = new presentation_layer.استعلامات();
                    qur.ShowDialog();
                }
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.كل_المنتجات ex = new presentation_layer.كل_المنتجات();
                ex.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.التقارير re = new presentation_layer.التقارير();
                re.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.المشتريات ee = new presentation_layer.المشتريات();
                ee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try { presentation_layer.مصروفات ex = new presentation_layer.مصروفات();
            ex.ShowDialog(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try {  presentation_layer.المديونات d = new presentation_layer.المديونات();
            d.ShowDialog(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try {     presentation_layer.تحصيل_مديونيات_خارجيه a = new presentation_layer.تحصيل_مديونيات_خارجيه();
            a.ShowDialog(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.فواتير_البيع a = new presentation_layer.فواتير_البيع();
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            presentation_layer.اعدادات_السيرفر se = new presentation_layer.اعدادات_السيرفر();
            se.ShowDialog();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            presentation_layer.login log = new presentation_layer.login();
            log.ShowDialog();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            presentation_layer.المرتجعات back = new presentation_layer.المرتجعات();
            back.ShowDialog();
        }
    }
}
