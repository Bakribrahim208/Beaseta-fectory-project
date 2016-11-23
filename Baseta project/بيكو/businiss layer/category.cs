using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class category
    {


        public DataTable All_Category()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_catogory", null);
            dal.close();
            return dt;
        }
        public DataTable ALL_products__incat_for_print(int Id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = Id;
            DataTable dt = new DataTable();
            dt = dal.select("ALL_products__incat_for_print", param);
            dal.close();
            return dt;
        }
        public DataTable last_cat()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("GET_LAST_cat", null);
            dal.close();
            return dt;
        }
        public void ADD_PRoduct(string cat_name, string Cat_desc)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];


            param[0] = new SqlParameter("@cat_name", SqlDbType.VarChar, 25);
            param[0].Value = cat_name;

            param[1] = new SqlParameter("@Cat_desc", SqlDbType.VarChar, 50);
            param[1].Value = Cat_desc;
 
     ;
     dal.ExecuteCommand("Add_catogory", param);
            dal.close();

        }
        public void edit_category(int id, string cat_name, string Cat_desc)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            param[1] = new SqlParameter("@cat_name", SqlDbType.VarChar, 25);
            param[1].Value = cat_name;

            param[2] = new SqlParameter("@Cat_desc", SqlDbType.VarChar, 50);
            param[2].Value = Cat_desc;

            ;
            dal.ExecuteCommand("Edit_catogory", param);
            dal.close();

        }

        public void Delete_cat(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dal.ExecuteCommand("Delete_catogory", param);
            dal.close();

        }

    }
}
