using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class suppliers
    {
        public void Add_suppliers(string Sup_name, string sup_phone,string Sup_gov ,float total_money,float payed,float remain)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];


            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 25);
            param[0].Value = Sup_name;

            param[1] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[1].Value = sup_phone;
             
              param[2] = new SqlParameter("@gavarment", SqlDbType.VarChar, 50);
              param[2].Value = Sup_gov;


              param[3] = new SqlParameter("@total_money", SqlDbType.Float);
              param[3].Value = total_money;

              param[4] = new SqlParameter("@payed_money", SqlDbType.Float);
              param[4].Value = payed;

              param[5] = new SqlParameter("@remained_money", SqlDbType.Float);
              param[5].Value = remain;
            dal.ExecuteCommand("Add_supplier", param);
            dal.close();

        }
        public void edit_supplly_remain_money(int id, int remain)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];



            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@remain", SqlDbType.Int);
            param[1].Value = remain;

            dal.ExecuteCommand("edit_supplly_remain_money", param);
            dal.close();

        }
        public void ADD_supplieres_DETAILS(int Id_supplieres, int id_product, int qte_, float Amount_of_money)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            SqlParameter[] param = new SqlParameter[4];


            param[0] = new SqlParameter("@id_supplieres", SqlDbType.Int);
            param[0].Value = Id_supplieres;

            param[1] = new SqlParameter("@id_product", SqlDbType.Int);
            param[1].Value = id_product;

            param[2] = new SqlParameter("@qte_ ", SqlDbType.Int);
            param[2].Value = qte_;
            param[3] = new SqlParameter("@Amount_of_money  ", SqlDbType.VarChar, 50);
            param[3].Value = Amount_of_money;
            dal.ExecuteCommand("Add_supplier_details", param);
            dal.close();

        }
        public void Edit_supplier_money(int id, int total_mone, int payed_money, int remained_money)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id_spplier", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@total_money", SqlDbType.Int);
            param[1].Value = total_mone;

            param[2] = new SqlParameter("@payed_money", SqlDbType.Int);
            param[2].Value = payed_money;

            param[3] = new SqlParameter("@remained_money", SqlDbType.Int);
            param[3].Value = remained_money;
            dal.ExecuteCommand("Edit_supplier_money", param);
            dal.close();

        }
        public void Edite_suppliers(int id, string Sup_name, string sup_phone, string Sup_gov)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id", SqlDbType.Int );
            param[0].Value = id;

            param[ 1] = new SqlParameter("@name", SqlDbType.VarChar, 25);
            param[1].Value = Sup_name;

            param[2] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[2].Value = sup_phone;

            param[3] = new SqlParameter("@gavarment", SqlDbType.VarChar, 50);
            param[3].Value = Sup_gov;
            dal.ExecuteCommand("Edit_supplier", param);
            dal.close();

        }
        public DataTable last_sup()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("GET_LAST_sup", null);
            dal.close();
            return dt;
        }
        public DataTable Get_supply_detials_for_print(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id_suplly", SqlDbType.Int);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt = dal.select("Get_supply_detials_for_print", param);
            dal.close();
            return dt;
        }
        public DataTable last_GET__lastID_orgi_matrial()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("GET__lastID_orgi_matrial", null);
            dal.close();
            return dt;
        }
        public void Delete_sup(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dal.ExecuteCommand("Delete_sup", param);
            dal.close();

        }
        public DataTable All_sup()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_sup", null);
            dal.close();
            return dt;
        }

        public DataTable ALL_sup_remain_money()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_sup_remain_money", null);
            dal.close();
            return dt;
        }
    }
}
