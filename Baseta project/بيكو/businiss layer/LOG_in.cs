using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class LOG_in
    {
        public DataTable login(string username, string password)//we will get the values of username and password from form
        {

            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@username", SqlDbType.VarChar, 50);
            param[0].Value = username;
            param[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            param[1].Value = password;
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("log_in", param); //??? we should close connection or not????
            dal.close();
            return dt;
        }
    }
}
