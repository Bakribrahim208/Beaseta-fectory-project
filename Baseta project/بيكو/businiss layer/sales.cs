using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class sales
    {
        public void Add_sales(string Sup_name, string sup_phone, string Sup_gov)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];


            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 25);
            param[0].Value = Sup_name;

            param[1] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[1].Value = sup_phone;

            param[2] = new SqlParameter("@Car_num", SqlDbType.VarChar, 50);
            param[2].Value = Sup_gov;
            dal.ExecuteCommand("Add_sales", param);
            dal.close();

        }
        public void Edit_sales(int id, string Sup_name, string sup_phone, string Sup_gov)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@name", SqlDbType.VarChar, 25);
            param[1].Value = Sup_name;

            param[2] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[2].Value = sup_phone;

            param[3] = new SqlParameter("@Car_num", SqlDbType.VarChar, 50);
            param[3].Value = Sup_gov;
            dal.ExecuteCommand("Edit_sales", param);
            dal.close();

        }
        public DataTable All_sales()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("All_sales", null);
            dal.close();
            return dt;
        }
        public DataTable select_sales_from_order()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("select_sales_from_order", null);
            dal.close();
            return dt;
        }
        public DataTable one_sales(string name)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = name;
            DataTable dt = new DataTable();
            dt = dal.select("Selaes_id", param);
            dal.close();
            return dt;
        }
        public void Delete_Sales(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dal.ExecuteCommand("Delete_Sales", param);
            dal.close();

        }

    }
}
