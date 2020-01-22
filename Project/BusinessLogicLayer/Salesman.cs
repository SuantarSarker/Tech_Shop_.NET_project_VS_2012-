using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataAccessLayer;

namespace Project.BusinessLogicLayer
{
    class Salesman
    {
        
        public string ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Nid { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }


        DataAccess da = new DataAccess();
        Salesman s;

        public List<Salesman> GetAllSalesman()
        {
            var salesmans = da.GetAllSalesman();
            List<Salesman> list = new List<Salesman>();
            for (int i = 0; i < salesmans.Rows.Count; i++)
            {
                s = new Salesman();
                s.ID = salesmans.Rows[i][0].ToString();
                s.Name = salesmans.Rows[i][1].ToString();
                s.Password = salesmans.Rows[i][2].ToString();
                s.Address = salesmans.Rows[i][3].ToString();
                s.Nid = salesmans.Rows[i][4].ToString();
                s.Phone = salesmans.Rows[i][5].ToString();
                s.DOB = salesmans.Rows[i][6].ToString();
                s.Gender = salesmans.Rows[i][7].ToString();

               
                list.Add(s);
            }
            return list;
        }

        public bool AddSalesman(string name, string address,string nid,string phone,string dob,string gender )
        {
            
            return da.Insert(name,address,nid,phone,dob,gender);
        }

        

        public bool UpdateSalesman(string id, string name, string address, string phone)
        {

            return da.Update(id, name, address, phone);
        }

        public bool DeleteSalesman(string id)
        {
            return da.Delete(id);
        }

        public bool UpdatePass(string id,string password)
        {

            return da.UpdateP(id,password);
        }

        

    }
}
