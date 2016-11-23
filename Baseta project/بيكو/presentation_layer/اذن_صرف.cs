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
    public partial class كل_المنتجات : Form
    {
        public int ID;
        businiss_layer.products pro = new businiss_layer.products();
        businiss_layer.orderes_and_exchanges ex = new businiss_layer.orderes_and_exchanges();
        public كل_المنتجات()
        {
            InitializeComponent();

            cmb_material.DataSource =pro.ALL_Org_products();
            cmb_material.DisplayMember = "اسم الماده";
            cmb_material.ValueMember = "كودالماده";
            button5.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = false;

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
                    int Id=Convert.ToInt32(cmb_material.SelectedValue);
                    int ver=Convert.ToInt32(ex.vertify_orgianl_qun(Id).Rows[0][0].ToString());
                    if (ver >Convert.ToInt32(txt_qun.Text))
                    {
                        string[] row = new string[] {cmb_material.SelectedValue.ToString(),
                                        cmb_material.Text,txt_exchang.Text,txt_reciever.Text
                                          ,dateTimePicker1.Value.ToShortDateString(),txt_qun.Text};
                        dataGridView1.Rows.Add(row);
                        txt_qun.Clear();
                    }
                    else
                    {
                        MessageBox.Show("الكميه غير متوفره الكميه المتوفره هي "+ver);
                        txt_qun.Clear();
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void txt_qun_Leave(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    ex.Add_exchange_detials(ID, Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)
                        , Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value));

                }
                MessageBox.Show("تم حفظ اذن الصرف");
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_exchang.Text == string.Empty && txt_reciever.Text == string.Empty)
                {
                    MessageBox.Show("ادخل معلومات المسئول والمستلم");
                    return;
                }
                else {
                    ex.Add_exchange(txt_exchang.Text, txt_reciever.Text, dateTimePicker1.Value);
                    ID = Convert.ToInt32(ex.GET_exchange_ORDER().Rows[0][0].ToString())-1;
                    button5.Enabled = true;
                    button4.Enabled = true;
                    button3.Enabled = true;
                }
                MessageBox.Show("تم حفظ اذن الصرف "+ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_exchang.Clear();
            txt_id.Clear();
            txt_qun.Clear();
            txt_reciever.Clear();
            dataGridView1.Rows.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Reporting.طباعه_اذن_الصرف_فورم reform = new Reporting.طباعه_اذن_الصرف_فورم();
                Reporting.اذن_الصرف_تقرير report = new Reporting.اذن_الصرف_تقرير();
                report.SetDataSource(ex.Exchang_detials_forPrint(ID));
                reform.crystalReportViewer1.ReportSource = report;
                reform.ShowDialog();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
