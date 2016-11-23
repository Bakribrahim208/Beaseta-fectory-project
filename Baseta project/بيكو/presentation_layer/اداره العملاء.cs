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
    public partial class اداره_العملاء : Form
    {
        public int sale_ID = 1;
        businiss_layer.Custmor cust = new businiss_layer.Custmor();
        DataTable dt = new DataTable();
        businiss_layer.sales sal = new businiss_layer.sales();
        public اداره_العملاء()
        {
            InitializeComponent();
            try {  dt = sal.All_sales();
            comboBox1.Items.Add("بيع مباشر");
            comboBox1.DataSource = sal.All_sales();
            comboBox1.DisplayMember = "اسم المندوب";
            comboBox1.ValueMember = "كود المندوب";
            dt = cust.All_Custmor();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
 cust.ADD_PRoduct(txtname.Text, txtphone.Text, txt_total_money.Text, txt_payed_money.Text, txt_remain_money.Text, comboBox1.SelectedText);
            MessageBox.Show("تم الاضافه");
            dt = cust.All_Custmor();
            dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {  if (MessageBox.Show("هل تريد حذف هذا العميل ", "حذف عميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.Delete_User(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dt = cust.All_Custmor();
                dataGridView1.DataSource = dt;
            }}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void اداره_العملاء_Load(object sender, EventArgs e)
        {

        }
  
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedText == "بيع مباشر")
            //{
            //    sale_ID = 1;
            //}
            //else
            //sale_ID = Convert.ToInt32(sal.one_sales(comboBox1.SelectedText).Rows[0][0].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
