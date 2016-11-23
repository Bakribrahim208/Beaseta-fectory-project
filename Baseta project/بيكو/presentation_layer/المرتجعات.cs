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
    public partial class المرتجعات : Form
    {
        businiss_layer.orderes_and_exchanges or = new businiss_layer.orderes_and_exchanges();
        businiss_layer.back_order back = new businiss_layer.back_order();
        businiss_layer.SAFE safe = new businiss_layer.SAFE();
        int payed=0,
            remain = 0;
        int total_back = 0 
            ,total_order=0;
        int discount = 0;
        int safe_remain = 0;
        public المرتجعات()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try {
            DataTable d = new DataTable();
            d = or.Get_order_detials_back(Convert.ToInt32(textBox1.Text));
               
           dataGridView1.DataSource = d;
           dataGridView1.Columns[5].Visible = false;
           dataGridView1.Columns[6].Visible = false;
           dataGridView1.Columns[7].Visible = false;
           payed = Convert.ToInt32(dataGridView1.Rows[0].Cells[5].Value.ToString());
           remain = Convert.ToInt32(dataGridView1.Rows[0].Cells[6].Value.ToString());
           discount = Convert.ToInt32(dataGridView1.Rows[0].Cells[7].Value.ToString());
           textBox3.Text = payed.ToString();
           textBox4.Text = remain.ToString() ;
           DataTable TD = new DataTable();
           TD = or.Get_order_detials_back(Convert.ToInt32(textBox1.Text));
           dataGridView4.DataSource = TD;

            }
            catch (Exception ex)
            {
                MessageBox.Show("لا يوجد طلب بهذا الرقم");
            }

         }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
         //   dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToUInt16(dataGridView1.CurrentCell.Value) * 2);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_qan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_qan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void txt_back_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void txt_back_KeyUp(object sender, KeyEventArgs e)
        {

           

        }

        private void txt_back_KeyPress(object sender, KeyPressEventArgs e)
        {
            char seperator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != seperator)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {  
          
                
            try{
            for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
            {
                back.ADD_ORDER_DETAILS_back(Convert.ToInt32(textBox1.Text), Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value),
                    Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value)*-1, Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value));
                total_back += Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
                back.edite_ORDER_DETAILS_when_back(Convert.ToInt32(textBox1.Text), Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                   Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                   (dataGridView1.Rows[i].Cells[4].Value.ToString()),
                   Convert.ToInt32(dataGridView4.Rows[i].Cells[3].Value.ToString()));//edite order_detials


            }
          
            total_order = Convert.ToInt32(txt_tot.Text);
            total_order = total_order - (total_order *(discount/100));//tottal order Total - (Total * (Discont / 100));

            
            if(remain==0)
            {
                //payed = payed +total_back;
                payed = payed ;
                safe_remain = 0;
            }
            else{

                if (remain > total_back){
                    remain = remain - total_back;
                    safe_remain = total_back;

                }
                else { remain = 0;
                safe_remain = remain;
                }
                   
                

            }
            back.edite_order_when_back(Convert.ToInt32(textBox1.Text)//edite order table
                ,Convert.ToInt32(txt_tot.Text)
                , total_order, payed, remain);

            //safe updated
            DataTable dT = new DataTable();
            dT = safe.laST_ROW_IN_SAFE();
            dataGridView3.DataSource = dT;
            // int money = Convert.ToInt32(dataGridView3.Rows[0].Cells[1].Value) + Convert.ToInt32(Payed_money.Text);
            int sales = Convert.ToInt32(dataGridView3.Rows[0].Cells[2].Value) - total_back;
            safe_remain = Convert.ToInt32(dataGridView3.Rows[0].Cells[3].Value) - safe_remain;
            safe.UPdate_safe(
                Convert.ToInt32(dataGridView3.Rows[0].Cells[1].Value),
                sales
                ,safe_remain
                , Convert.ToInt32(dataGridView3.Rows[0].Cells[4].Value)
                , Convert.ToInt32(dataGridView3.Rows[0].Cells[5].Value)
                , Convert.ToInt32(dataGridView3.Rows[0].Cells[6].Value));
            payed = 0;
            remain = 0;
            total_back = 0;
            total_order = 0;
            total_back = 0;
            MessageBox.Show("done");}
            catch(Exception ex){
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txt_back.Text) > Convert.ToInt32(txt_qan.Text))
                {
                    MessageBox.Show("الكميه المرتجعه اكبر من المشتريه!");
                    txt_back.Clear();
                }
                else
                {
                    if (txt_back.Text == string.Empty)
                    {
                        txt_back.Text = "0";
                    }
                    //calculate the new qantity and total price in it in the order
                    dataGridView1.CurrentRow.Cells[3].Value = Convert.ToString(Convert.ToInt32(txt_qan.Text) - Convert.ToInt32(txt_back.Text));
                    dataGridView1.CurrentRow.Cells[4].Value = Convert.ToString(Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value) * Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value));
                    int d = 0;
                    for (int j = 0; j < dataGridView1.Rows.Count; j++) //total_order money
                    {
                    
                        d += Convert.ToInt32(dataGridView1.Rows[j].Cells[4].Value);
                    }
                    txt_tot.Text = d.ToString();
                   
                    string[] row = new string[] 
                    { textBox1.Text, dataGridView1.CurrentRow.Cells[0].Value.ToString(), txt_back.Text, (Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString()) * Convert.ToInt32(txt_back.Text)).ToString() };
                    dataGridView2.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txt_back_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
