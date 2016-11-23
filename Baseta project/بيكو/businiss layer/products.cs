using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class products
    {
        public void ADD_PRoduct(string name, string qun, string unit, string pric, string pay_price, int cat_id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@qun", SqlDbType.VarChar, 50);
            param[1].Value = qun;

            param[2] = new SqlParameter("@unit", SqlDbType.VarChar, 25);
            param[2].Value = unit;

            param[3] = new SqlParameter("@pric", SqlDbType.VarChar, 25);
            param[3].Value = pric;

            param[4] = new SqlParameter("@pay_price", SqlDbType.VarChar, 25);
            param[4].Value = pay_price;

            param[5] = new SqlParameter("@cat_id", SqlDbType.Int);
            param[5].Value = cat_id
     ;
            dal.ExecuteCommand("Add_products", param);
            dal.close();

        }

        public void   _Edit_PRoduct(int id, string name, string qun, string unit, string pric, string pay_price, int cat_id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
     
            param[1] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[1].Value = name;

            param[2] = new SqlParameter("@qun", SqlDbType.VarChar, 50);
            param[2].Value = qun;

            param[3] = new SqlParameter("@unit", SqlDbType.VarChar, 25);
            param[3].Value = unit;

            param[4] = new SqlParameter("@pric", SqlDbType.VarChar, 25);
            param[4].Value = pric;

            param[5] = new SqlParameter("@pay_price", SqlDbType.VarChar, 25);
            param[5].Value = pay_price;

            param[6] = new SqlParameter("@cat_id", SqlDbType.Int);
            param[6].Value = cat_id
     ;
            dal.ExecuteCommand("Edit_products", param);
            dal.close();

        }
        public DataTable ALL_products()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_products", null);
            dal.close();
            return dt;
        }
        public DataTable show_products(int qun)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@qun", SqlDbType.Int);
            param[0].Value = qun;
            DataTable dt = new DataTable();
            dt = dal.select("products", param);
            dal.close();
            return dt;
        }
        public DataTable show_ex_products(int qun)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@qun", SqlDbType.Int);
            param[0].Value = qun;
            DataTable dt = new DataTable();
            dt = dal.select("ex-products", param);
            dal.close();
            return dt;
        }
        public DataTable ALL_products_for_print()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_products_for_print", null);
            dal.close();
            return dt;
        }
        public DataTable one_products(int id )
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dt = dal.select("one_products", param);
            dal.close();
            return dt;
        }
        public void Delete_product(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dal.ExecuteCommand("Delete_products", param);
            dal.close();

        }
        //---------------- مواد الخام-----------
        public void ADD__Org_PRoduct(string name, string qun, string unit, string pric, string pay_price, int sup_id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@qun", SqlDbType.VarChar, 50);
            param[1].Value = qun;

            param[2] = new SqlParameter("@unit", SqlDbType.VarChar, 25);
            param[2].Value = unit;

            param[3] = new SqlParameter("@pric", SqlDbType.VarChar, 25);
            param[3].Value = pric;

            param[4] = new SqlParameter("@pay_price", SqlDbType.VarChar, 25);
            param[4].Value = pay_price;

            param[5] = new SqlParameter("@sup_id", SqlDbType.Int);
            param[5].Value = sup_id
     ;
            dal.ExecuteCommand("Add_oraginal_products", param);
            dal.close();

        }
        public void _Edit__Org_PRoduct(int id, string name, string qun, string unit, string pric, string pay_price, int sup_id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[1].Value = name;

            param[2] = new SqlParameter("@qun", SqlDbType.VarChar, 50);
            param[2].Value = qun;

            param[3] = new SqlParameter("@unit", SqlDbType.VarChar, 25);
            param[3].Value = unit;

            param[4] = new SqlParameter("@pric", SqlDbType.VarChar, 25);
            param[4].Value = pric;

            param[5] = new SqlParameter("@pay_price", SqlDbType.VarChar, 25);
            param[5].Value = pay_price;

            param[6] = new SqlParameter("@sup_id", SqlDbType.Int);
            param[6].Value = sup_id
     ;
            dal.ExecuteCommand("Edit_oraginal_products", param);
            dal.close();

        }
        public DataTable ALL_Org_products()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_org_products", null);
            dal.close();
            return dt;
        }
        public void Delete_Org_product(int id)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            dal.ExecuteCommand("Delete_org_products", param);
            dal.close();

        }
        public DataTable ALL_suppliers()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_suppliers", null);
            dal.close();
            return dt;
        }
    }
}
