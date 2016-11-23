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
    public partial class تحصيل_مديونيات_خارجيه : Form
    {
        businiss_layer.Custmor cus = new businiss_layer.Custmor();
        businiss_layer.sales sal = new businiss_layer.sales();
        businiss_layer.orderes_and_exchanges ord = new businiss_layer.orderes_and_exchanges();
        businiss_layer.SAFE safe = new businiss_layer.SAFE();
        DataTable dT = new DataTable();
        DataTable dt = new DataTable();
        int type;
        public int payed;
        public تحصيل_مديونيات_خارجيه()
        {
            InitializeComponent();
            try
            {
                dataGridView1.Rows.Clear();
                dT = safe.laST_ROW_IN_SAFE();
                dataGridView2.DataSource = dT;
                txt_safe.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
                dt = cus.select_cus_from_order();
                dataGridView1.DataSource = dt;
                type = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                 
                type = 1;
                dt = sal.select_sales_from_order();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int id;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtshoud.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[10].Value);
                payed =Convert.ToInt32( dataGridView1.CurrentRow.Cells[6].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == string.Empty && txt_name.Text == string.Empty)
                {
                    MessageBox.Show("ادخل قيمه");
                }
                else
                {
                    if (Convert.ToInt32(textBox2.Text) > Convert.ToInt32(txtshoud.Text))
                    {
                        MessageBox.Show("القيمه اكبر من المطلوب سدادها ");
                        textBox2.Clear();
                    }
                    else
                    {
                        int money = Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value) + Convert.ToInt32(textBox2.Text);
                        int dept = Convert.ToInt32(dataGridView2.Rows[0].Cells[4].Value) - Convert.ToInt32(textBox2.Text);
                        safe.UPdate_safe(money, Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value)
                            , Convert.ToInt32(dataGridView2.Rows[0].Cells[3].Value), dept, Convert.ToInt32(dataGridView2.Rows[0].Cells[5].Value), Convert.ToInt32(dataGridView2.Rows[0].Cells[6].Value));
                        payed = payed + Convert.ToInt32(textBox2.Text);
                        ord.update_order_sales_money(id, (Convert.ToInt32(txtshoud.Text) - Convert.ToInt32(textBox2.Text)), payed);
                        MessageBox.Show(" تم اضافه المبلغ الي الخزينه");
                        if (type ==0)
                        {
                            dt = cus.select_cus_from_order();
                        }
                        else
                            dt = sal.select_sales_from_order();
                        dataGridView1.DataSource = dt;
                        dT = safe.laST_ROW_IN_SAFE();
                        dataGridView2.DataSource = dT;
                        textBox2.Clear();
                        txt_safe.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                        textBox1.Text = id.ToString();
                    }
                    
                }
           } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
