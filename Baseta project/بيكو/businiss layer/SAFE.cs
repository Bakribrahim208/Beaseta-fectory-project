using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class SAFE
    {
        public DataTable laST_ROW_IN_SAFE()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("laST_ROW_IN_SAFE", null);
            dal.close();
            return dt;
        } //اخر صف ف الجدول

        public DataTable vertify_money() //جلب الفلوس الفعيله لعميله الصرف 
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("vertify_money", null);
            dal.close();
            return dt;
        } //اخر صف ف ا
        public void UPdate_safe(int realy_money, int sales_money, int buyed_money, int Debt_moneyt, int remain_for_pepole, int expenes_money)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];

               param[0] = new SqlParameter("@realy_money",  SqlDbType.Int); // فلوس الفعليه
            param[0].Value = realy_money;
          param[1] = new SqlParameter("@sales_money",  SqlDbType.Int);//المبيعات
            param[1].Value = sales_money;

            param[2] = new SqlParameter("@buyed_money", SqlDbType.Int);//الشراء
            param[2].Value = buyed_money;

            param[3] = new SqlParameter("@Debt_money", SqlDbType.Int);// مبالغ المدينونيين لصاحب المصنع 
            param[3].Value = Debt_moneyt;

            param[4] = new SqlParameter("@remain_for_pepole", SqlDbType.Int);//مبالغ الدائنين اللي صاحب امصنع مدين ليهم
            param[4].Value = remain_for_pepole;

            param[5] = new SqlParameter("@expenes_money", SqlDbType.Int);//المصروفات الاضافيه
            param[5].Value = expenes_money;


            dal.ExecuteCommand("UPdate_safe", param);
            dal.close();

        }
    }
}
