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
    public partial class استعلامات : Form
    {
        businiss_layer.products pro = new businiss_layer.products();
        DataTable dt = new DataTable();
        public استعلامات()
        {
            InitializeComponent();
            if( Properties.Settings.Default.inqury_type =="0"){
            dt = pro.show_products(Properties.Settings.Default.inquiry);
            dataGridView1.DataSource = dt;
            }
            else 
            {
                  dt = pro.show_ex_products(Properties.Settings.Default.inquiry);
            dataGridView1.DataSource = dt;
            }
            
        }
    }
}

