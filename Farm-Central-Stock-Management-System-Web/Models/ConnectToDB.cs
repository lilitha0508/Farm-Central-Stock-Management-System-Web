using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Farm_Central_Stock_Management_System_Web.Models
{
    public class ConnectToDB
    {

        private SqlConnection Connect;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter adaptar;
        private string conString;

        /// <summary>
        /// Default Constructor
        /// </summary>
        //------------------------------------------------------------------------------------------------------------------------------
        public ConnectToDB()
        {
            conString = "metadata=res://*/Models.FarmCentralDBModel.csdl|res://*/Models.FarmCentralDBModel.ssdl|res://*/Models.FarmCentralDBModel.msl;provider=System.Data.SqlClient;provider connection string=\"data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\FarmCentralDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework\"";
            Connect = new SqlConnection(conString);
            cmd = new SqlCommand();
            cmd.Connection = Connect;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //------------------------------------------------------------------------------------------------------------------------------
        public DataTable GetData(string Query)
        {
            dt = new DataTable();   
            adaptar = new SqlDataAdapter(Query, conString);
            adaptar.Fill(dt);
            return dt; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        //------------------------------------------------------------------------------------------------------------------------------
        public int SetData(string Query)
        {
            int count = 0;
            if(Connect.State == ConnectionState.Closed)
            {
                Connect.Open();
            }
            cmd.CommandText = Query;
            count = cmd.ExecuteNonQuery();
            Connect.Close();
            return count;
        }
    }
}
//-------------------------------------------------------- EnD Of FiLe --------------------------------------------------------------------