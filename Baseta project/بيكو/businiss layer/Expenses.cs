using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace بيكو.businiss_layer
{
    class Expenses
    {
        public void ADD_Expenses(string Administrator,string notes,int total,int payed,int remain,DateTime ex_date)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@Administrator", SqlDbType.VarChar, 50);
            param[0].Value = Administrator;

            param[1] = new SqlParameter("@notes", SqlDbType.VarChar, 50);
            param[1].Value = notes;

            param[2] = new SqlParameter("@total", SqlDbType.Int);
            param[2].Value = total;

            param[3] = new SqlParameter("@payed", SqlDbType.Int);
            param[3].Value = payed;

            param[4] = new SqlParameter("@remain", SqlDbType.VarChar, 25);
            param[4].Value = remain;

            param[5] = new SqlParameter("@ex_date", SqlDbType.Date);
            param[5].Value = ex_date;

     dal.ExecuteCommand("Add_expensivees", param);
            dal.close();

        }

        public void edit_expen(int id, int remain)
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];



            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@remain", SqlDbType.Int);
            param[1].Value = remain;

            dal.ExecuteCommand("edit_expen", param);
            dal.close();

        }
        public DataTable ALL_expen()
        {
            Data_acess_layer.DataAcess_layer dal = new Data_acess_layer.DataAcess_layer();
            dal.open();
            DataTable dt = new DataTable();
            dt = dal.select("ALL_expen", null);
            dal.close();
            return dt;
        }
    }
}
