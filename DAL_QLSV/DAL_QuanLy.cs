using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL_QLSV
{
    public class DAL_QuanLy
    {
        public SqlConnection getconnect()
        {
            return new SqlConnection(@"Data Source=ADMIN;Initial Catalog=DE4;Integrated Security=True");
        }
        public DataTable gettable(string srtsql)
        {
            SqlConnection conn = getconnect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(srtsql, conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd); 
            DataTable tb = new DataTable();
            dr.Fill(tb);
            conn.Close();
            dr.Dispose();
            return tb;
        }
        public void ExecuteNonQuery(string srtsql)
        {
            SqlConnection conn = getconnect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(srtsql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public string tencb(string srtsql)
        {
            SqlConnection conn = getconnect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(srtsql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string kq="";
            while(dr.Read())
            {
                kq=dr[0].ToString();
            }
            return kq;
        }
    }
}
