using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Project.BusinessLogicLayer;

namespace Project.DataAccessLayer
{
    class DataAccess
    {
        SqlConnection con;
        public DataAccess()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-AVRUC4C0;Initial Catalog=tech_shop_mgt;Integrated Security=True");
            //con.Open();

            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
        }

        public DataTable GetAllSalesman()
        {
            con.Open();
            string query = string.Format("SELECT * FROM Reg_Sales");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        

        public bool Insert(string name, string address,string nid,string phone,string dob,string gender)
        {
            
                con.Open();
                string i = "S-"+DateTime.Now.Date.ToString("yydd") +"-"+ DateTime.Now.ToString("mmss") ;
                string password = "Pass-" + GetHashCode();  
                string query = string.Format("INSERT INTO Reg_Sales(id,name,password,address,nid,phone,dob,gender,usertype) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", i, name,password, address, nid, phone, dob, gender, "U");
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

        public DataTable Login(Salesman s)
        {
            

                con.Open();
                //string query = string.Format("select * from Reg_Sals where id='{0}' and password='{2}'", s.ID, s.Password);
                //SqlCommand cmd = new SqlCommand(query, con);
                //int rows = -1;
                //rows = cmd.ExecuteNonQuery();


                string query = string.Format("select * from Reg_Sales where id='" + s.ID + "' and password='" + s.Password + "'");
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandText = "select * from Reg_Sales where id='" + s.ID + "' and password='" + s.Password + "'";
                //cmd.Connection = getcon();
                SqlDataReader sdr;

                cmd.CommandType = CommandType.Text;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();
                return dt;
            
            
            
        }

        public bool Delete(string id)
        {
            con.Open();
            string query = string.Format("DELETE FROM Reg_Sales WHERE id='{0}' ", id);
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


        public bool Update(string id, string name, string address, string phone)
        {

            con.Open();

            string query = string.Format("UPDATE Reg_Sales SET name='{0}',address='{1}',phone='{2}' WHERE id='{3}' ", name, address, phone, id);
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

        public DataTable Search(Salesman s)
        {

            con.Open();
            string query = string.Format("SELECT * FROM Reg_Sales WHERE id='{0}'", s.ID);
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


        public DataTable SearchPass(Salesman s)
        {

            con.Open();
            string query = string.Format("SELECT password FROM Reg_Sales WHERE id='{0}'", s.ID);
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


        public bool UpdateP(string id, string password)
        {

            con.Open();

            string query = string.Format("UPDATE Reg_Sales SET password='{0}' WHERE id='{1}' ", password,id);
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

        ~DataAccess()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        
    }
}
