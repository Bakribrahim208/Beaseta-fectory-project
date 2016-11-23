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
    public partial class عرض_اصناف : Form
    {
        businiss_layer.category cat = new businiss_layer.category();
        DataTable dt = new DataTable();
        public عرض_اصناف()
        {
            InitializeComponent();
            dt = cat.ALL_products__incat_for_print(Properties.Settings.Default.category_id);
            dataGridView1.DataSource = dt;
        }
    }
}
