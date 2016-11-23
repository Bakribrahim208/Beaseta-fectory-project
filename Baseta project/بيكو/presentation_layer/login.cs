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
    public partial class login : Form
    {
        businiss_layer.LOG_in log=new businiss_layer.LOG_in();
        public login()
        {
            InitializeComponent();
        }

        private void closebut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logbut_Click(object sender, EventArgs e)
        {
            try { 
            DataTable dt = new DataTable();
            dt = log.login(usernamrtxt.Text, passtxt.Text);
            if (dt.Rows.Count > 0)
            {
               // MessageBox.Show("Log in success ^_^ ", "Login ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //passtxt.Clear();
                //usernamrtxt.Clear();
          
                this.Close();
                Properties.Settings.Default.User_name = usernamrtxt.Text;
            }
            else
                MessageBox.Show("خطا ف  اسم المستخدم او كلمه المرور", "failed ", MessageBoxButtons.OK, MessageBoxIcon.Information);}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                passtxt.PasswordChar = (char)0;

            }
            else
                passtxt.PasswordChar = '*';
        }

        }
    
}
