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
    class Product_DataAccess
    {
         SqlConnection con;
         public Product_DataAccess()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-AVRUC4C0;Initial Catalog=tech_shop_mgt;Integrated Security=True");
            //con.Open();

            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
        }

         public DataTable GetAllProduct()
         {
             con.Open();
             string query = string.Format("SELECT * FROM product_list1");
             SqlCommand cmd = new SqlCommand(query, con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }

         public bool Insert(string id, string name, int quantity, int buy, int sell, string date, byte[] image)
         {

             con.Open();
             string query = string.Format("INSERT INTO product_list1(product_id,product_name,quantity,buying_price,selling_price,date,image) VALUES('{0}','{1}',{2},{3},{4},'{5}','{6}')",id, name, quantity, buy, sell, date, @image);
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
         public bool Update(string id,string name,int invoice,int quantity,int sell)
         {

             con.Open();

             string query = string.Format("UPDATE product_list1 SET product_name='{0}',product_id='{1}',quantity={2},selling_price={3} WHERE invoice_no={4} ", name, id, quantity, sell,invoice);
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



         public DataTable SearchProduct(Product p)
         {

             con.Open();
             string query = string.Format("SELECT * FROM product_list1 WHERE invoice_no={0}", p.InvoiceNo);
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

         public bool Delete(int invoice)
         {
             con.Open();
             string query = string.Format("DELETE FROM product_list1 WHERE invoice_no={0} ", invoice);
             SqlCommand cmd = new SqlCommand(query, con);
             int rows = -1;
             rows = cmd.ExecuteNonQuery();
             con.Close();
             if (rows >= 0)
             {
                 con.Close();

                 return true;
             }
             con.Close();
             return false;
         }



         public DataTable GetProduct(Product p)
         {

             con.Open();
             string query = string.Format("SELECT product_id,product_name,invoice_no,quantity,buying_price,selling_price FROM product_list1 WHERE product_id like'{0}%'", p.ProductId);
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
         public DataTable GetProduct1()
         {

             con.Open();
             string query = string.Format("SELECT product_id,product_name,invoice_no,quantity,buying_price,selling_price FROM product_list1");
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
         public DataTable GetProduct1(Product p)
         {

             con.Open();
             string query = string.Format("SELECT product_id,product_name,invoice_no,quantity,buying_price,selling_price FROM product_list1 WHERE product_id like'{0}%'", p.ProductId);
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

         public bool UpdateQN(int quantity,int invoice)
         {

             con.Open();

             string query = string.Format("UPDATE product_list1 SET quantity={0} WHERE invoice_no={1} ",quantity,invoice);
             SqlCommand cmd = new SqlCommand(query, con);
             int rows = -1;
             rows = cmd.ExecuteNonQuery();
             con.Close();
             if (rows >= 0)
             {
                 con.Close();
                 return true;
             }
             con.Close();
             return false;
             

         }

         public bool RecoverQN(int quantity, int invoice)
         {

             con.Open();

             string query = string.Format("UPDATE product_list1 SET quantity={0} WHERE invoice_no={1} ", quantity, invoice);
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


         public DataTable SearchP(Product p)
         {

             con.Open();
             string query = string.Format("SELECT buying_price FROM product_list1 WHERE invoice_no={0}", p.InvoiceNo);
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


    }
}
