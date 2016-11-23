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
    public partial class Main : Form
    {
        Color culoare = Color.FromArgb(20, 20, 20);
        Color culoare1 = Color.FromArgb(36, 36, 36);
        public Main()
        {
            InitializeComponent();


        }


       

        private void مصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.مصروفات x = new presentation_layer.مصروفات();
                x.MdiParent = this;
                x.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void اضافهعميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void المشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.مصروفات x = new presentation_layer.مصروفات();
                x.MdiParent = this;
                x.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.المشتريات aa = new presentation_layer.المشتريات();
                aa.MdiParent = this;
                aa.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.اداره_العملاء a = new presentation_layer.اداره_العملاء();
                a.MdiParent = this;
                a.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.اداره_الموردين s = new presentation_layer.اداره_الموردين();
                s.MdiParent = this;
                s.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.اضافه_مورد n = new presentation_layer.اضافه_مورد();

                n.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.اداره_المنتجات m = new presentation_layer.اداره_المنتجات();
                m.MdiParent = this;

                m.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.اضافه_منتج cat = new presentation_layer.اضافه_منتج();
                cat.MdiParent = this;

                cat.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                 presentation_layer.اضافه_عميل cat = new presentation_layer.اضافه_عميل();
                cat.MdiParent = this;
                cat.Show();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.المرتجعات cc = new presentation_layer.المرتجعات();
                cc.MdiParent = this;
                cc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void ديونموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.المديونات d = new presentation_layer.المديونات();
                d.MdiParent = this;
                d.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ديونالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.تحصيل_مديونيات_خارجيه w = new presentation_layer.تحصيل_مديونيات_خارجيه();
                w.MdiParent = this;
                w.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.فواتير_البيع ww = new presentation_layer.فواتير_البيع();
                ww.MdiParent = this;
                ww.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.اداره_العملاء www = new presentation_layer.اداره_العملاء();
                www.MdiParent = this;
                www.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void المرتجعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                presentation_layer.المرتجعات cc = new presentation_layer.المرتجعات();
                cc.MdiParent = this;
                cc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void النواقصToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void منتجاتمنتهيهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Properties.Settings.Default.inquiry = 0;
                Properties.Settings.Default.inqury_type = "0";
                presentation_layer.استعلامات qur = new presentation_layer.استعلامات();
  
                qur.MdiParent = this;
                qur.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void منتجاتاوشكتعليالانتهاءToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
            try
            {
                Properties.Settings.Default.inquiry = 10;
                Properties.Settings.Default.inqury_type = "0";
                presentation_layer.استعلامات qur = new presentation_layer.استعلامات();
                 qur.MdiParent = this;
                qur.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void موادخاممنتهيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.inquiry = 0;
                Properties.Settings.Default.inqury_type = "1";
                presentation_layer.استعلامات qur = new presentation_layer.استعلامات();
                qur.MdiParent = this;
                qur.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void موادخاماوشكتعليالانتهاءToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.inquiry = 10;
            Properties.Settings.Default.inqury_type = "1";
            presentation_layer.استعلامات qur = new presentation_layer.استعلامات();
            qur.ShowDialog();
        }
    }
}
