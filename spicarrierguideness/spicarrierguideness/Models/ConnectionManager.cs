using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace spicarrierguideness.Models
{
    public class ConnectionManager
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-GSLQ1777\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;Trust Server Certificate=True");
        //public class because dataadapter and command both require that class obj, connection string


        public bool ExecuteInsertUpdateOrDelete(string command)
        {

            SqlCommand cmd = new SqlCommand(command, con);
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n > 0)
                return true;
            else
                return false;
        }
        //Make another method for Read Data
        public DataTable GetBulkRecord(string command)
        {
            SqlDataAdapter da = new SqlDataAdapter(command, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}