using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Project.BusinessLogicLayer;

namespace Project.DataAccessLayer
{
    class Sold_Records
    {

          SqlConnection con;
          public Sold_Records()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-AVRUC4C0;Initial Catalog=tech_shop_mgt;Integrated Security=True");
            //con.Open();

            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
        }

         public DataTable GetAllRecords()
         {
             con.Open();
             string query = string.Format("SELECT * FROM sold_records1");
             SqlCommand cmd = new SqlCommand(query, con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }

         public bool InsertItem(string date, string s_id, string product_id, string product_name, int invoice_no, int quantity, int unit, int total, int tprofit)
         {

             con.Open();
             string query = string.Format("INSERT INTO sold_records1(date,salesman_id,product_id,invoice_no,product_name,quantity,unit_price,total,profit) VALUES('{0}','{1}','{2}',{3},'{4}',{5},{6},{7},{8})", date,s_id,product_id,invoice_no,product_name, quantity, unit, total,tprofit);
             SqlCommand cmd = new SqlCommand(query, con);
             int rows = -1;
             rows = cmd.ExecuteNonQuery();
             if (rows >= 0)
             {
                 con.Close();
                 return true;
             }
             con.Close();
             return false;


         }




         public DataTable SearchDate(Sold_Item s)
         {

             con.Open();
             string query = string.Format("SELECT profit FROM sold_records1 WHERE date='{0}'", s.Date);
             SqlCommand cmd = new SqlCommand(query, con);
             //   SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             //   da.Fill(dt);
             SqlDataReader sdr;

             //cmd.CommandType = CommandType.Text;
             sdr = cmd.ExecuteReader();

             dt.Load(sdr);
             con.Close();
             return dt;


         }


         public DataTable SearchBwDate(Sold_Item s)
         {

             con.Open();
             string query = string.Format("SELECT profit FROM sold_records1 WHERE date between'"+s.Date+"' And '"+s.DateOne+"'");
             SqlCommand cmd = new SqlCommand(query, con);
             DataTable dt = new DataTable();
             SqlDataReader sdr;

             sdr = cmd.ExecuteReader();

             dt.Load(sdr);
             con.Close();
             return dt;


         }
    }
}
