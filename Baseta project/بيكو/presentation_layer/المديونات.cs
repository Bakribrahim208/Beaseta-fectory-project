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
    public partial class المديونات : Form
    {
        businiss_layer.suppliers sup = new businiss_layer.suppliers();
        businiss_layer.Expenses ex = new businiss_layer.Expenses();
        businiss_layer.SAFE safe = new businiss_layer.SAFE();
        DataTable dT = new DataTable();
        int id;
        int type;

        DataTable dt = new DataTable();
        public المديونات()
        {
            InitializeComponent();
            try
            { dataGridView1.Rows.Clear();
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
            dt = sup.ALL_sup_remain_money();
            if(dt.Rows.Count<1)
            {
                MessageBox.Show("لا توجد ديون للموردين");
            }
            
            dataGridView1.DataSource = dt;
            type = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dt = ex.ALL_expen();
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("لا توجد ديون للمصروفات");
            }

             dataGridView1.DataSource = dt;
             type = 1;
        }

        

        
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtshoud.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                id =Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value );
            }
            catch(Exception ex )
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
                        MessageBox.Show("القيمه اكبر من المطلوب سدادها او لا يوجد مال كافي");
                        textBox2.Clear();
                    }
                    else
                    {
                        int money = Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value) - Convert.ToInt32(textBox2.Text);
                        int dept = Convert.ToInt32(dataGridView2.Rows[0].Cells[5].Value) - Convert.ToInt32(textBox2.Text);
                        safe.UPdate_safe(money, Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value)
                             , Convert.ToInt32(dataGridView2.Rows[0].Cells[3].Value), Convert.ToInt32(dataGridView2.Rows[0].Cells[4].Value), dept, Convert.ToInt32(dataGridView2.Rows[0].Cells[6].Value));
                        if (type == 1)
                        {
                            ex.edit_expen(id, (Convert.ToInt32(txtshoud.Text) - Convert.ToInt32(textBox2.Text)));
                            dt = ex.ALL_expen();
                        }
                        else
                        {
                            sup.edit_supplly_remain_money(id, (Convert.ToInt32(txtshoud.Text) - Convert.ToInt32(textBox2.Text)));
                            dt = sup.ALL_sup_remain_money();

                        }
                        MessageBox.Show(" تم خصم المبلغ من الخزنه");
                        dataGridView1.DataSource = dt;

                        dT = safe.laST_ROW_IN_SAFE();
                        dataGridView2.DataSource = dT;
                        textBox2.Clear();
                        txt_safe.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                    }

                }
            }
            catch(Exception ex ){
                MessageBox.Show(ex.Message);
            }
        }
    }
}
