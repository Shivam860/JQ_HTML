using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using Newtonsoft.Json;

namespace JQ_HTML
{
    /// <summary>
    /// Summary description for Reg
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Reg : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

        [WebMethod]
        public void Insert(String A, String B, String C)
        {
            con.Open();
            SqlCommand com = new SqlCommand("procuser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "insert");
            com.Parameters.AddWithValue("@u_name", A);
            com.Parameters.AddWithValue("@u_email", B);
            com.Parameters.AddWithValue("@u_password", C);
            com.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public string Get()
        {
            string pp = "";
            con.Open();
            SqlCommand com = new SqlCommand("procuser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "display");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            pp = JsonConvert.SerializeObject(dt);
            return pp;
        }

        [WebMethod]
        public void Delete(String A)
        {
            con.Open();
            SqlCommand com = new SqlCommand("procuser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "delete");
            com.Parameters.AddWithValue("@u_id", A);
            com.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public string Edit(String A)
        {
            string pp = "";
            con.Open();
            SqlCommand com = new SqlCommand("procuser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "edit");
            com.Parameters.AddWithValue("@u_id", A);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            pp = JsonConvert.SerializeObject(dt);
            return pp;
        }

        [WebMethod]
        public void Update(String A, String B, String C, String D)
        {
            con.Open();
            SqlCommand com = new SqlCommand("procuser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@action", "update");
            com.Parameters.AddWithValue("@u_id", D);
            com.Parameters.AddWithValue("@u_name", A);
            com.Parameters.AddWithValue("@u_email", B);
            com.Parameters.AddWithValue("@u_password", C);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
