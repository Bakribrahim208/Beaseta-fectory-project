using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class orderes_and_exchanges
    {


        public void Add_Order(int cus_id, string cus_typ, DateTime order_date
            , string Sales_name, string order_desc, int payed_way_id
            , int total_pric, int discount, int total_after_discount, int payedmoney, int remain_money)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@cus_id", SqlDbType.Int);
            param[0].Value = cus_id;
            param[1] = new SqlParameter("@cus_type ", SqlDbType.VarChar, 20);
            param[1].Value = cus_typ;
            param[2] = new SqlParameter("@order_date", SqlDbType.DateTime);
            param[2].Value = order_date;
            param[3] = new SqlParameter("@Sales_name", SqlDbType.VarChar, 50);
            param[3].Value = Sales_name;
            param[4] = new SqlParameter("@order_desc ", SqlDbType.VarChar, 50);
            param[4].Value = order_desc;
            param[5] = new SqlParameter("@payed_way ", SqlDbType.Int);
            param[5].Value = payed_way_id;
            param[6] = new SqlParameter("@total_price", SqlDbType.Int);
            param[6].Value = total_pric;
            param[7] = new SqlParameter("@discount ", SqlDbType.Int);
            param[7].Value = discount;
            param[8] = new SqlParameter("@total_after_discountint", SqlDbType.Int);
            param[8].Value = total_after_discount; 
      
            param[9] = new SqlParameter("@payed_money", SqlDbType.Int);
            param[9].Value = payedmoney;
            param[10] = new SqlParameter("@remained_money", SqlDbType.Int);
            param[10].Value = remain_money; 
            dal.ExecuteCommand("Add_order", param);
            dal.close();
           

        }
        public void Add_exchange(  string  exchang_resp, string  reciever, DateTime exchange_date  )
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
             param[0] = new SqlParameter("@exchang_resp ", SqlDbType.VarChar, 20);
            param[0].Value = exchang_resp;
           
            param[1] = new SqlParameter("@reciever", SqlDbType.VarChar, 50);
            param[1].Value = reciever;
             param[2] = new SqlParameter("@dateTime", SqlDbType.DateTime);
            param[2].Value = exchange_date;
             
            dal.ExecuteCommand("add_exchange_per", param);
            dal.close();

        }
        public void Add_exchange_detials(int exchange_ID,int org_id,int qun)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@ex_ID", SqlDbType.Int);
            param[0].Value = exchange_ID;
            param[1] = new SqlParameter("@orgina_id", SqlDbType.Int);
            param[1].Value = org_id;
            param[2] = new SqlParameter("@qun", SqlDbType.Int);
            param[2].Value = qun;
            dal.ExecuteCommand("add_exchange_Detials", param);
            dal.close();

        }
        public DataTable GET_exchange_ORDER()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("GET_exhange_ORDER", null);
            dal.close();
            return dt;
        }
        public DataTable payed_way()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("payed_way", null);
            dal.close();
            return dt;
        }
        public void ADD_ORDER_DETAILS(int  id_product, int id_order, int qte_, string Amount_of_money)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            SqlParameter[] param = new SqlParameter[4];


            param[0] = new SqlParameter("@id_product ", SqlDbType.Int );
            param[0].Value = id_product;

            param[1] = new SqlParameter("@id_order", SqlDbType.Int);
            param[1].Value = id_order;

            param[2] = new SqlParameter("@qte_ ", SqlDbType.Int);
            param[2].Value = qte_;
            param[3] = new SqlParameter("@Amount_of_money  ", SqlDbType.VarChar, 50);
            param[3].Value = Amount_of_money;
             dal.ExecuteCommand("ADD_ORDER_DETAILS", param);
            dal.close();

        }
        public DataTable GET_LAST_ORDER()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("GET_LAST_ORDER", null);
            dal.close();
            return dt;
        }
        public DataTable ALL_orderes()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_orderes", null);
            dal.close();
            return dt;
        }
        public DataTable ALL_orderes_bound_by_date(DateTime start,DateTime end)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            SqlParameter[] param = new SqlParameter[2];
              

            param[0] = new SqlParameter("@start_date", SqlDbType.Date);
            param[0].Value = start;
            param[1] = new SqlParameter("@end_data", SqlDbType.Date);
            param[1].Value = end;

            DataTable dt = new DataTable();
            dt = dal.select("ALL_orderes_bound_by_date", param);
            dal.close();
            return dt;
        }

        public DataTable search_orderes(string search_word)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@word_search", SqlDbType.VarChar, 50);
            param[0].Value = search_word;

            dt = dal.select("SEARCH_ORDERES", param);
            dal.close();
            return dt;
        }
        public DataTable vertify_orgianl_qun(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            dt = dal.select("vertify_orgianl_qun", param);
            dal.close();
            return dt;
        }
        public DataTable Exchang_detials_forPrint(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id;
            dt = dal.select("Exchang_detials_forPrint", param);
            dal.close();
            return dt;
        }
        public DataTable Get_order_detials_back(int id_order)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;

            dt = dal.select("Get_order_detials_back", param);
            dal.close();
            return dt;
        }
        public DataTable Get_order_detials(int id_order)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;

            dt = dal.select("Get_order_detials", param);
            dal.close();
            return dt;
        }
        public DataTable Get_order_detials_for_print(int id_order)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;

            dt = dal.select("Get_order_detials_for_print", param);
            dal.close();
            return dt;
        }
        public void update_order_sales_money(int id, int remain, int payed)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@remain", SqlDbType.Int);
            param[1].Value = remain;
            param[2] = new SqlParameter("@payed", SqlDbType.Int);
            param[2].Value = payed;
            dal.ExecuteCommand("update_order_sales_money", param);
            dal.close();

        }

    }
}
