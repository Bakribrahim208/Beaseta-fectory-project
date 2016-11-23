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
    public partial class فواتير_البيع : Form
    {
        businiss_layer.orderes_and_exchanges ord = new businiss_layer.orderes_and_exchanges();
        businiss_layer.products pro = new businiss_layer.products();
        businiss_layer.sales sal = new businiss_layer.sales();
        businiss_layer.Custmor cus = new businiss_layer.Custmor();
        businiss_layer.SAFE safe=new businiss_layer.SAFE();
        businiss_layer.category cat = new businiss_layer.category();
        DataTable dt = new DataTable();
        public int Cust_ID; 
        public string cus_type="";
         public فواتير_البيع()
        {
            InitializeComponent();
            try
            {
                dt = pro.ALL_products();
                comboBox2.DataSource = cat.All_Category();
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "id";
                //---------------------------
                comboBox3.DataSource = sal.All_sales();
                comboBox3.DisplayMember = "اسم المندوب";
                comboBox3.ValueMember = "كود المندوب";
                //-----------------------------
                comboBox4.DataSource = dt;
                comboBox4.DisplayMember = "اسم المنتج";
                comboBox4.ValueMember = "كود المنتج";


                cmb_custmor.DataSource = cus.All_Custmor();
                cmb_custmor.DisplayMember = "اسم العميل";
                cmb_custmor.ValueMember = "كود العميل";
                //------------------------------
                comboBox1.DataSource = ord.payed_way();
                comboBox1.DisplayMember = "طريقه الدفع";
                comboBox1.ValueMember = "كود الدفع";
                //----------------------------
                txt_price.ReadOnly = true;
                txtID.ReadOnly = true;
                txtname.ReadOnly = true;
                //txtqun.Clear();
                txtpric.ReadOnly = true;
                textBox3.Clear();
                textBox1.ReadOnly = true;
                remain_money.ReadOnly = true;
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

         public void cal_price()
         {try{
             double Price = Convert.ToDouble(txtpric.Text) * (Convert.ToDouble(txtqun.Text));
             if (txtpric.Text != string.Empty && txtqun.Text != string.Empty)
              txt_price.Text = Convert.ToString(Price);}
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         public void total_price()
         {
             try
             {
                 if (discount.Text != string.Empty)//&& //txtqun.Text != string.Empty)
                 {
                     double Total = Convert.ToDouble(textBox4.Text);
                     double Discont = Convert.ToDouble(discount.Text);
                     double total = Total - (Total * (Discont / 100));
                     tot.Text = total.ToString();
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         //public void clearTxt()
         //{
         //    txt_price.Clear();
         //    txtID.Clear();
         //    txtname.Clear();
         //    txtqun.Clear();
         //    txtpric.Clear();

         //}
        private void فواتير_البيع_Load(object sender, EventArgs e)
        {

        }

    //    public void  p()
    //{
       
    //    DataTable DTT = new DataTable();
    //    DTT = cus.Get_reaminMoney_order(Cust_ID);
    //    dataGridView5.DataSource = DTT;



    //    int REMAIN = Convert.ToInt32(remain_money.Text);
    //    int TOTAL = Convert.ToInt32(tot.Text);
    //    int PAYED = Convert.ToInt32(Payed_money.Text);

    //        dt = cus.cus_money(ID);
    //        dataGridView4.DataSource = dt;
    //        int t_total = Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value);//total
    //        int tr_remain = Convert.ToInt32(dataGridView4.Rows[0].Cells[1].Value);//remain
    //        int temp2;
    //   int temp = TOTAL - PAYED;
    //   if (temp > 0)
    //   {
    //       temp2 = t_total - temp;
    //       if (temp2 > 0)
    //       {
    //           REMAIN = 0; //put it in remain textbox
    //           remain_money.Text = "0";
    //           t_total = temp2;
    //           update in database
    //           cus.cus_money_update(Cust_ID, t_total.ToString(), tr_remain.ToString());

    //       }
    //       else
    //       {
    //           t_total = 0;
    //           temp2 *= -1;

    //           REMAIN += temp2;  // total remain custmor
    //           cus.cus_money_update(Cust_ID, t_total.ToString(), REMAIN.ToString());
    //           textbox of remain = temp2*-1
    //           remain_money.Text = "0";
    //       }


    //   }
    //   else if (temp < 0)
    //   {
    //       temp *= -1;
    //       if(tr_remain >0)
          
    //       {
    //           int i = tr_remain - temp;
    //           if (i > 0)
    //           {
    //               tr_remain -= i;

    //           }
    //           else
    //           {
    //               tr_remain = 0;
    //               t_total += i;
    //               cus.cus_money_update(ID, t_total.ToString(), tr_remain.ToString());

    //           }
    //           cus.cus_money_update(Cust_ID, t_total.ToString(), tr_remain.ToString());
    //           for (int j = 0; j < dataGridView5.Rows.Count; j++)
    //           {
    //               if (temp == 0)
    //               {
    //                   break;
    //               }
    //               else 
    //               {
    //                   if (temp >Convert.ToInt32(  dataGridView5.Rows[i].Cells[0].Value))
    //                {
    //                    temp -= Convert.ToInt32(dataGridView5.Rows[i].Cells[0].Value);
    //                      cus.update_order_remain_money(ID,0);
    //                }
    //                   else
    //                   {
    //                       dataGridView5.Rows[i].Cells[0].Value = Convert.ToString(Convert.ToInt32(dataGridView5.Rows[i].Cells[0].Value) - temp);
    //                       temp = 0;
    //                       cus.update_order_remain_money(Cust_ID, Convert.ToInt32(dataGridView5.Rows[i].Cells[0].Value));
    //                   }
                      
    //               }
    //           }
    //       }
    //       else if (temp == 0)
    //       {
    //           temp *=-1;
    //           t_total += temp;
    //           cus.cus_money_update(Cust_ID, t_total.ToString(), tr_remain.ToString());

    //       }
    //   }

    //}
        public void pp()
        {
            DataTable DTT = new DataTable();
            DTT = cus.Get_reaminMoney_order(Cust_ID);//متبقي الفاتوره
            dataGridView5.DataSource = DTT;
            DataTable DT = new DataTable();
            DT = cus.cus_money(Cust_ID); // الحساب والمتبقي للعميل
            dataGridView4.DataSource = DT;
            int t_total = Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value);//total
            int tr_remain = Convert.ToInt32(dataGridView4.Rows[0].Cells[1].Value);//remain
            int temp = Convert.ToInt32(tot.Text) - Convert.ToInt32(Payed_money.Text);
            if (temp < 0)
            {
             remain_money.Text = Convert.ToString(temp * -1);
             int te = t_total - tr_remain;
                if (te < 0)
                {
                    tr_remain = tr_remain + temp;
                    if (tr_remain < 0)
                    {
                        t_total = -tr_remain;
                        tr_remain = 0;

                    }

                }
                else
                {
                    t_total -= temp;

                }

            }
            else if (temp > 0)
            {
                remain_money.Text = Convert.ToString(temp);
                if (t_total == 0)
                {
                    tr_remain = tr_remain + temp;
                }
                else
                {
                    int re = t_total - temp;
                    if (re < 0)
                    {
                        t_total = 0;
                        tr_remain = -re;
                    }
                    else if (re > 0)
                    {
                        tr_remain = re;

                    }

                }
            }

            cus.cus_money_update(Cust_ID, t_total.ToString(), tr_remain.ToString());

        }
        private void button1_Click(object sender, EventArgs e)
        {
            pp();
            try
            {
               DataTable dT = new DataTable();
               dT = safe.laST_ROW_IN_SAFE();
               dataGridView2.DataSource = dT;
               int money = Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value) + Convert.ToInt32(Payed_money.Text);  
                int sales=Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value)+ Convert.ToInt32(tot.Text);
                 int Debt = Convert.ToInt32(dataGridView2.Rows[0].Cells[4].Value) + Convert.ToInt32(remain_money.Text);  
                  safe.UPdate_safe(money,sales, Convert.ToInt32(dataGridView2.Rows[0].Cells[3].Value),Debt,
                      Convert.ToInt32(dataGridView2.Rows[0].Cells[5].Value),Convert.ToInt32(dataGridView2.Rows[0].Cells[6].Value));
                
                ord.Add_Order(Cust_ID, 
                    cus_type,
                    Convert.ToDateTime(DateTime.Today.ToShortDateString())
                , Properties.Settings.Default.User_name, textBox2.Text, 
                Convert.ToInt32(comboBox1.SelectedValue)
                , Convert.ToInt32(textBox4.Text)
                , Convert.ToInt32(discount.Text),
                Convert.ToInt32(tot.Text), 
                Convert.ToInt32(Payed_money.Text),
                Convert.ToInt32(remain_money.Text));
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ord.ADD_ORDER_DETAILS(Convert.ToInt32(txtID.Text), Convert.ToInt32(textBox1.Text)
                        ,  Convert.ToInt32( dataGridView1.Rows[i].Cells[3].Value.ToString())
                        , dataGridView1.Rows[i].Cells[4].Value.ToString() );
                }
                MessageBox.Show("done");
                dt = pro.ALL_products();
                dataGridView2.DataSource = dt;
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button2_Click(sender, e);
        }
       
        

          

        private void cmb_products_Click(object sender, EventArgs e)
        {

            
           
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
                     //id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                     //name=  dataGridView2.CurrentRow.Cells[1].Value.ToString();

                     //price   = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                     //string[] row = new string[] { id, name, price };
                     //dataGridView1.Rows.Add(row);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
             

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        public int ID;
        public int qan;
        bool te = false;
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (!te)
                    te = true;  else{
            try
            {
                dt = pro.ALL_products();
                dataGridView2.DataSource = dt;
              
              
                ID = Convert.ToInt32(comboBox4.SelectedValue);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value) == ID)
                    {
                        if (Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value) > 0)
                        {
                            txtID.Text = Convert.ToString(dataGridView2.Rows[i].Cells[0].Value);
                            txtname.Text = Convert.ToString(dataGridView2.Rows[i].Cells[1].Value);
                            txtpric.Text = Convert.ToString(dataGridView2.Rows[i].Cells[3].Value);
                            qan = Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value); 
                            dt = pro.ALL_products();
                            dataGridView2.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("الكميه غير متاحه");
                            return;
                        }


                    }

                }
            }
          catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dt = pro.ALL_products();
            dataGridView2.DataSource = dt;


            }
        }

        private void txtqun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
           

        }
        public Boolean vertify_qun(DataGridView dg, int qun)
        {
            Boolean test = false;
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (qun == Convert.ToInt32(dg.Rows[i].Cells[3].Value))
                {
                    test = true;
                    return test;
                }
                else
                    test = false;
            }
            return test;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = 0;
                if (!vertify_qun(dataGridView1, Convert.ToInt32(txtqun.Text)))
                {
                    string[] row = new string[] { txtID.Text, txtname.Text, txtpric.Text, txtqun.Text, txt_price.Text };
                    dataGridView1.Rows.Add(row);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        temp += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    }
                    textBox4.Text = temp.ToString();
                }
                else {
                    txtqun.Clear();
                    MessageBox.Show("هذا الصنف موجود مسبقا بنفس الكميه ");}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtqun_KeyUp(object sender, KeyEventArgs e)
        {
            if(Convert.ToInt32(txtqun.Text)>qan)
            {
                    MessageBox.Show(" يوجد ف المخزن "+qan +"فقط" );
                    txtqun.Clear();
                    txtID.Clear();
                    txtpric.Clear();
                    txtname.Clear();

                    return;
            }
            else
            cal_price();
           
             //clearTxt();
        }

        private void discount_KeyUp(object sender, KeyEventArgs e)
        {
            total_price();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtqun_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_custmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = cmb_custmor.Text;
            Cust_ID = Convert.ToInt32(cmb_custmor.SelectedValue);
            cus_type = "عميل";
         }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cust_ID = Convert.ToInt32(comboBox3.SelectedValue);

            textBox3.Text = comboBox3.Text;
            cus_type = "مندوب";


         }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(ord.GET_LAST_ORDER().Rows[0][0].ToString()); //last id in the table

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_price.Clear();
              txtID.Clear();
                txtname.Clear();
               txtqun.Clear();
               txtpric.Clear();
              // textBox1.Clear();
               textBox2.Clear();
               textBox3.Clear();
               textBox4.Clear();
               //textBox5.Clear();
               tot.Clear();
               Payed_money.Text = "0";
               remain_money.Text = "0";
               dataGridView1.Rows.Clear();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.Text == "نقدا")
            //{
            //    Payed_money.ReadOnly=true;
            //    Payed_money.Text = tot.Text;
            //}
            //else
            //{
            //    Payed_money.ReadOnly = false;
            //    //remain_money.ReadOnly = false;
            //}
            

        }

        private void Payed_money_KeyUp(object sender, KeyEventArgs e)
        {
            if (tot.Text != string.Empty && Payed_money.Text != string.Empty /*&& Convert.ToDouble(tot.Text) >= Convert.ToDouble(Payed_money.Text)*/)
            {
                double temp = Convert.ToDouble(tot.Text) - Convert.ToDouble(Payed_money.Text);
                remain_money.Text = temp.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                int OR_ID = Convert.ToInt32(textBox1.Text);
                Reporting.طباعه_فاتوره_فورم reform = new Reporting.طباعه_فاتوره_فورم();
                Reporting.طباعه_فاوره report = new Reporting.طباعه_فاوره();
                report.SetDataSource(ord.Get_order_detials_for_print(OR_ID));
                reform.crystalReportViewer1.ReportSource = report;
                reform.ShowDialog();
            }
            else
                MessageBox.Show("حقل رقم الفاتور فارغ");
           
        }
        bool tr = false;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tr)
                tr = true;
            else
            { 
            try
            {
                comboBox4.DataSource = cat.ALL_products__incat_for_print(Convert.ToInt32(comboBox2.SelectedValue));
                comboBox4.DisplayMember = "اسم المنتج";
                comboBox4.ValueMember = "كود المنتج";
                txtID.Clear();
                txtpric.Clear();
                txtname.Clear();

            }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }}
        }
        
    }
}
 