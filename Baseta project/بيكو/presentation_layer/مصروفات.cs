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
    public partial class مصروفات : Form
    {
        businiss_layer.Expenses ex = new businiss_layer.Expenses();
        businiss_layer.SAFE safe = new businiss_layer.SAFE();
        public مصروفات()
        {
            InitializeComponent();
        }

        private void cmb_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_unit.Text == "آجل")
            {
                txt_payed.Enabled = true;
                txt_remain.Enabled = true;
            }
            else {
                 txt_payed.Enabled = false;
                 txt_remain.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dT = new DataTable();
                dT = safe.laST_ROW_IN_SAFE();
                dataGridView1.DataSource = dT;
                
                if (txt_admin.Text != string.Empty && txt_notes.Text != string.Empty && txt_total.Text != string.Empty)
                {
                    if (Convert.ToInt32(txt_payed.Text) > Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value))
                    {
                        MessageBox.Show(" !الخزنه لا تحتوي علي المبلغ هذا");
                        return;
                    }
                    else
                    {
                        int money = Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value) - Convert.ToInt32(txt_payed.Text);
                        int exep = Convert.ToInt32(dataGridView1.Rows[0].Cells[6].Value) + Convert.ToInt32(txt_total.Text);
                        int dept = Convert.ToInt32(dataGridView1.Rows[0].Cells[5].Value) + Convert.ToInt32(txt_remain.Text);
                        safe.UPdate_safe(money, Convert.ToInt32(dataGridView1.Rows[0].Cells[2].Value),
                          Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value), Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value)
                          , dept, exep);
                        if (cmb_unit.Text == "نقدي")
                        {

                            ex.ADD_Expenses(txt_admin.Text, txt_notes.Text, Convert.ToInt32(txt_total.Text)
                                , Convert.ToInt32(txt_total.Text), Convert.ToInt32(txt_remain.Text), dateTimePicker1.Value);
                            MessageBox.Show("done");
                        }
                        else
                        {
                            ex.ADD_Expenses(txt_admin.Text, txt_notes.Text, Convert.ToInt32(txt_total.Text)
                                , Convert.ToInt32(txt_payed.Text), Convert.ToInt32(txt_remain.Text), dateTimePicker1.Value);
                            MessageBox.Show("done");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("الحقول فارغه ادخل قيم ");
                    return;
                }
                  
               
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_payed_KeyUp(object sender, KeyEventArgs e)
        {
            try { txt_remain.Text = Convert.ToString(Convert.ToInt32(txt_total.Text) - Convert.ToInt32(txt_payed.Text)); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
