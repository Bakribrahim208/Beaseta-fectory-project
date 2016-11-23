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
    public partial class المشتريات : Form
    {
        businiss_layer.products pro = new businiss_layer.products();
        businiss_layer.suppliers sup = new businiss_layer.suppliers();
        businiss_layer.SAFE safe = new businiss_layer.SAFE();
        public int ID_product;
        public المشتريات()
        {
            InitializeComponent();
            cmb_suppliers.DataSource = pro.ALL_suppliers();
            cmb_suppliers.DisplayMember = "اسم المورد";
            cmb_suppliers.ValueMember = "كود";
            ID_product = Convert.ToInt32(sup.last_GET__lastID_orgi_matrial().Rows[0][0].ToString());
            textBox1.Text = ID_product.ToString();
            total_money.Text = "0";
            payed_money.Text = "0";
            remained_money.Text = "0";
            button1.Enabled = false;
            button5.Enabled = false;
            

        }

        private void المشتريات_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
              
            try
            {

                if (txt_qun.Text == string.Empty)
                {
                    MessageBox.Show(" يجب ادخال قيمه في حقل الكميه ");
                }
                else
                {
                    pro.ADD__Org_PRoduct(txtname.Text, txt_qun.Text, Convert.ToString(cmb_unit.SelectedItem), txtprice.Text, txt_total.Text, Convert.ToInt32(cmb_suppliers.SelectedValue));
                    MessageBox.Show("تم الحفظ");

                    string[] row = new string[] {textBox1.Text, txtname.Text, cmb_unit.Text, txtprice.Text, txt_qun.Text, txt_total.Text, cmb_suppliers.Text };
                    dataGridView1.Rows.Add(row);
                    total_money.Text = Convert.ToString(Convert.ToDouble(total_money.Text) + Convert.ToDouble(txt_total.Text));
                    txt_qun.Clear();
                }
                txtname.Clear();
                txt_qun.Clear();
                txt_total.Clear();
                txtprice.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txt_qun_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txt_total.Text = Convert.ToString(Convert.ToInt32(txt_qun.Text) * Convert.ToInt32(txtprice.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
              
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    sup.ADD_supplieres_DETAILS(Convert.ToInt32(cmb_suppliers.SelectedValue), Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value));
                }
                if(payed_money.Text!=string.Empty)
                {
                    
                    DataTable dT = new DataTable();
                    dT = safe.laST_ROW_IN_SAFE();
                    dataGridView2.DataSource = dT;
                    if (Convert.ToInt32(payed_money.Text) > Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value))
                    {
                        MessageBox.Show(" !الخزنه لا تحتوي علي المبلغ هذا");
                        return;
                    }
                    else {
                        int money = Convert.ToInt32(dataGridView2.Rows[0].Cells[1].Value) - Convert.ToInt32(payed_money.Text);
                        int buyed = Convert.ToInt32(dataGridView2.Rows[0].Cells[3].Value) + Convert.ToInt32(total_money.Text);
                        int dept = Convert.ToInt32(dataGridView2.Rows[0].Cells[5].Value) + Convert.ToInt32(remained_money.Text);
                        safe.UPdate_safe(money, Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value), buyed, Convert.ToInt32(dataGridView2.Rows[0].Cells[4].Value), dept, Convert.ToInt32(dataGridView2.Rows[0].Cells[6].Value));
                        sup.Edit_supplier_money(Convert.ToInt32(cmb_suppliers.SelectedValue), Convert.ToInt32(total_money.Text), Convert.ToInt32(payed_money.Text), Convert.ToInt32(remained_money.Text));
                        MessageBox.Show("تم حفظ فاتوره الشراء");
                        button1.Enabled = true;
                        button5.Enabled = true;
                        dataGridView1.Rows.Clear();
                    }
                
                }
                else
                {
                    MessageBox.Show("يجب ادخال قيمه ف حقل المبلغ الدفوع ");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void payed_money_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                remained_money.Text = Convert.ToString(Convert.ToDouble(total_money.Text) - Convert.ToDouble(payed_money.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reporting.طباعه_فاتوره_فورم reform = new Reporting.طباعه_فاتوره_فورم();
            Reporting.فاتوره_شراء report = new Reporting.فاتوره_شراء();
            report.SetDataSource(sup.Get_supply_detials_for_print(Convert.ToInt32(cmb_suppliers.SelectedValue)));
            reform.crystalReportViewer1.ReportSource = report;
            reform.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.Rows[0].Cells[7].Value = total_money.Text;
                dataGridView1.Rows[0].Cells[9].Value = remained_money.Text;
                dataGridView1.Rows[0].Cells[8].Value = payed_money.Text;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("كود الماده الخام", typeof(string));
                dt.Columns.Add("اسم الماده", typeof(string));
                dt.Columns.Add("وحده الماده", typeof(string));
                dt.Columns.Add("سعر الوحده من الماده", typeof(string));
                dt.Columns.Add("الكميه المشتريه", typeof(string));
                dt.Columns.Add("المبلغ", typeof(string));
                dt.Columns.Add(" اسم المورد", typeof(string));
                dt.Columns.Add("المبلغ الكلي المستحق", typeof(string));
                dt.Columns.Add("المبلغ المدفوع", typeof(string));
                dt.Columns.Add("المبلغ المتبقي", typeof(string));
                string d = dataGridView1.Rows[0].Cells[7].Value.ToString(), dd = dataGridView1.Rows[0].Cells[8].Value.ToString(), ddd = dataGridView1.Rows[0].Cells[9].Value.ToString();
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {
                    dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value
                        , dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value
                        , dgv.Cells[6].Value, d, dd, ddd);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("Sample.xml");
                Reporting.طباعه_فاتوره_شراء_حاليه reform = new Reporting.طباعه_فاتوره_شراء_حاليه();
                Reporting.فاتوره_شراء_حاليه_ريبورت report = new Reporting.فاتوره_شراء_حاليه_ريبورت();
                report.SetDataSource(ds);
                reform.crystalReportViewer1.ReportSource = report;
                reform.ShowDialog();
               // MessageBox.Show("done");
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            txt_qun.Clear();
            txt_total.Clear();
            txtprice.Clear();
            txtname.Clear();
            total_money.Clear();
            remained_money.Clear();
            payed_money.Clear();
        }
    }
}
