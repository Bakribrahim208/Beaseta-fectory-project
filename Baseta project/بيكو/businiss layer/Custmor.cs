using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class Custmor
    {

        public void ADD_PRoduct(string cust_name, string tel, string Total_money, string payed_money, string remaining_amount,string   sales_id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];


            param[0] = new SqlParameter("@cust_name", SqlDbType.VarChar, 50);
            param[0].Value = cust_name;

            param[1] = new SqlParameter("@tel", SqlDbType.VarChar, 50);
            param[1].Value = tel;

            param[2] = new SqlParameter("@Total_money", SqlDbType.VarChar, 25);
            param[2].Value = Total_money;

            param[3] = new SqlParameter("@payed_money", SqlDbType.VarChar, 25);
            param[3].Value = payed_money;

            param[4] = new SqlParameter("@remaining_amount", SqlDbType.VarChar, 25);
            param[4].Value = remaining_amount;

            param[5] = new SqlParameter("@sales_id", SqlDbType.VarChar,50);
            param[5].Value = sales_id
     ;
                 dal.ExecuteCommand("Add_custmor", param);
            dal.close();

        }


        public void EDITE_CUSTOMER(int id_custmor, string @firstname, string @lastname, string @tel, string @email, byte[] @image_customar)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];


            param[0] = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
            param[0].Value = @firstname;

            param[1] = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
            param[1].Value = @lastname;

            param[2] = new SqlParameter("@tel", SqlDbType.VarChar, 15);
            param[2].Value = @tel;

            param[3] = new SqlParameter("@email", SqlDbType.VarChar, 25);
            param[3].Value = @email;

            param[4] = new SqlParameter("@image_customar", SqlDbType.Image);
            param[4].Value = @image_customar;

            param[5] = new SqlParameter("@id_custmor", SqlDbType.Int );
            param[5].Value = id_custmor;


            dal.ExecuteCommand("EDITE_CUSTOMER", param);
            dal.close();

        }

        public void cus_money_update(int id, string total_money, string remain_money)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@total_money", SqlDbType.VarChar, 50);
            param[1].Value = total_money;

            param[2] = new SqlParameter("@remain_money", SqlDbType.VarChar, 15);
            param[2].Value = remain_money;
            dal.ExecuteCommand("cus_money_update", param);
            dal.close();
        }

        public void update_order_remain_money(int id, int remain_money)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@remain_money", SqlDbType.Int);
            param[1].Value = remain_money;
            dal.ExecuteCommand("update_order_remain_money", param);
            dal.close();
        }

        public DataTable All_Custmor()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("All_Custmorr", null);
            dal.close();
            return dt;
        }

        public void Delete_User(int  ID_cat)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int );
            param[0].Value = ID_cat;
            dal.ExecuteCommand("Delete_Custmor", param);
            dal.close();

        }

        public DataTable Search_User(string @search)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable(); 
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@search", SqlDbType.VarChar, 50);
            param[0].Value = @search;
            dt = dal.select("Search_User", param);
            dal.close();
            return dt;
        }
        public DataTable All_Category()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_catogory", null);
            dal.close();
            return dt;
        }


        public DataTable select_cus_from_order()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("select_cus_from_order", null);
            dal.close();
            return dt;
        }
        public DataTable cus_money(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt = dal.select("cus_money", param);
            dal.close();
            return dt;
        }


        public DataTable Get_reaminMoney_order(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            dt = dal.select("Get_reaminMoney_order", param);
            dal.close();
            return dt;
        }
    }
}
