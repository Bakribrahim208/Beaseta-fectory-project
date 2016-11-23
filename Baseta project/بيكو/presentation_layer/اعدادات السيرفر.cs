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
    public partial class اعدادات_السيرفر : Form
    {
        public اعدادات_السيرفر()
        {
            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.server;
            textBox2.Text = Properties.Settings.Default.database;
            if (Properties.Settings.Default.mode == "SQl")
            {
                radioButton2.Checked = true;
                textBox3.Text = Properties.Settings.Default.id;
                textBox4.Text = Properties.Settings.Default.password;
            }
            else
            {
                radioButton1.Checked = true;
                textBox3.Clear();
                textBox4.Clear();
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;


            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.server = textBox1.Text;
            Properties.Settings.Default.database = textBox2.Text;
            Properties.Settings.Default.mode = radioButton2.Checked == true ? "SQL" : "Windows";
            Properties.Settings.Default.id = textBox3.Text;
            Properties.Settings.Default.password = textBox4.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم حفظ اعدادات السيرفر بنجاح", "اعدادت السيرفر ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
