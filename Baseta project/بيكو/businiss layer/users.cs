using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.Data_acess_layer
{
    class users
    {

        public void ADD_USER(string Username, string password, string usertype, string FullName)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[4];


            param[0] = new SqlParameter("@Username", SqlDbType.VarChar, 50);
            param[0].Value = Username;

            param[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            param[1].Value = password;

            param[2] = new SqlParameter("@usertype", SqlDbType.VarChar, 15);
            param[2].Value = usertype;

            param[3] = new SqlParameter("@FullName", SqlDbType.VarChar, 25);
            param[3].Value = FullName;


            dal.ExecuteCommand("ADDق_USER", param);
            dal.close();

        }
        public DataTable search_useres(string search_word)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();

            dal.open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@search", SqlDbType.VarChar, 50);
            param[0].Value = search_word;

            dt = dal.select("Searchh_User", param);
            dal.close();
            return dt;
        }
        public void Edit_USER(string Username, string password, string usertype, string FullName)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[4];


            param[0] = new SqlParameter("@Username", SqlDbType.VarChar, 50);
            param[0].Value = Username;

            param[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            param[1].Value = password;

            param[2] = new SqlParameter("@usertype", SqlDbType.VarChar, 50);
            param[2].Value = usertype;

            param[3] = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
            param[3].Value = FullName;


            dal.ExecuteCommand("Editt_USER", param);
            dal.close();

        }

        public void Delete_user(string Username)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];


            param[0] = new SqlParameter("@username", SqlDbType.VarChar, 50);
            param[0].Value = Username;
            dal.ExecuteCommand("Deletee_User", param);
            dal.close();

        }

    }
}
