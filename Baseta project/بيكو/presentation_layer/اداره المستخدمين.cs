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
    public partial class اداره_المستخدمين : Form
    {
        Data_acess_layer.users use = new Data_acess_layer.users();
        public اداره_المستخدمين()
        {
            InitializeComponent();
            dataGridView1.DataSource = use.search_useres("");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            اضافه_مستخدم Add_user = new اضافه_مستخدم();
            Add_user.savebtn.Text = "حفظ المستخدم";
            Add_user.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            اضافه_مستخدم Add_user = new اضافه_مستخدم();
            Add_user.Text = "تعديل المستخدم ";
              Add_user.savebtn.Text = "تعديل مستخدم";
              Add_user.fullname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
              Add_user.password.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
              Add_user.confirmpass.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
              Add_user.username.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
              Add_user.comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

              Add_user.ShowDialog();
              dataGridView1.DataSource = use.search_useres("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
if (MessageBox.Show("هل تريد حذف المستخد المحدد ", "حذف مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                use.Delete_user(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تم مسح المستخدم ", "حذف مستخدم");
                dataGridView1.DataSource = use.search_useres("");

            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }
    }
}
