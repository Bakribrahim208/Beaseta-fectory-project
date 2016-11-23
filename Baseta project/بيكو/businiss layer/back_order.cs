using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class back_order
    {
        public void ADD_ORDER_DETAILS_back(int id_order , int id_product, int qte_, int  Amount_of_money)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            SqlParameter[] param = new SqlParameter[4];


            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;

            param[1] = new SqlParameter("@id_product", SqlDbType.Int);
            param[1].Value = id_product;

            param[2] = new SqlParameter("@qte_", SqlDbType.Int);
            param[2].Value = qte_;
            param[3] = new SqlParameter("@Amount_of_money", SqlDbType.Int);
            param[3].Value = Amount_of_money;
            dal.ExecuteCommand("ADD_ORDER_DETAILS_back", param);
            dal.close();

        }
        public void edite_order_when_back(int id,int total_before_discount, int tatal_money, int payed, int remain)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            SqlParameter[] param = new SqlParameter[5];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@total_before_discount", SqlDbType.Int);
            param[1].Value = total_before_discount;
            param[2] = new SqlParameter("@tatal_money", SqlDbType.Int);
            param[2].Value = tatal_money;
            param[3] = new SqlParameter("@payed", SqlDbType.Int);
            param[3].Value = payed;
            param[4] = new SqlParameter("@remain", SqlDbType.Int);
            param[4].Value = remain;
            dal.ExecuteCommand("edite_order_when_back", param);
            dal.close();

        }





        public void edite_ORDER_DETAILS_when_back(int id_order, int id_product, int qte_, string Amount_of_money, int old_qunt)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            SqlParameter[] param = new SqlParameter[5];
            
  

            param[0] = new SqlParameter("@id_order", SqlDbType.Int);
            param[0].Value = id_order;
            param[1] = new SqlParameter("@id_product", SqlDbType.Int);
            param[1].Value = id_product;
            param[2] = new SqlParameter("@qte_", SqlDbType.Int);
            param[2].Value = qte_;
            param[3] = new SqlParameter("@Amount_of_money", SqlDbType.VarChar,20);
            param[3].Value = Amount_of_money;
            param[4] = new SqlParameter("@old_qunt", SqlDbType.Int);
            param[4].Value = old_qunt;
            dal.ExecuteCommand("edite_ORDER_DETAILS_when_back", param);
            dal.close();

        }
    }
}
