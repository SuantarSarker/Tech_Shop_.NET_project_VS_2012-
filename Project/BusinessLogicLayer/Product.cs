using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataAccessLayer;

namespace Project.BusinessLogicLayer
{
    class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int InvoiceNo { get; set; }
        public int Quantity { get; set; }
        public int BuyingPrice { get; set; }
        public int SellingPrice { get; set; }
        public byte[] Image { get; set; }
        public string Date { get; set; }


        Product_DataAccess dp = new Product_DataAccess();
        Product s;

        public List<Product> GetAllProduct()
        {
            var products = dp.GetAllProduct();
            List<Product> list = new List<Product>();

            //byte[] image = products.Rows[6][6].ToString();

            for (int i = 0; i < products.Rows.Count; i++)
            {
                s = new Product();
                s.ProductId = products.Rows[i][0].ToString();
                s.ProductName = products.Rows[i][1].ToString();
                s.InvoiceNo = int.Parse(products.Rows[i][2].ToString());
                s.Quantity = int.Parse(products.Rows[i][3].ToString());
                s.BuyingPrice = int.Parse(products.Rows[i][4].ToString());
                s.SellingPrice = int.Parse(products.Rows[i][5].ToString());

                //byte[] i = Encoding.ASCII.GetBytes(s);
                //byte[] img = ((byte[])i);

                s.Image = Encoding.ASCII.GetBytes(products.Rows[i][6].ToString());
                s.Date = products.Rows[i][7].ToString();


                list.Add(s);
            }
            return list;
        }

        public bool AddProduct(string id, string name, int quantity, int buy, int sell, string date, byte[] image)
        {

            return dp.Insert(id,name ,quantity, buy, sell, date,image);
        }

        public bool UpdateProduct(string id, string name, int invoice, int quantity,int sell)
        {

            return dp.Update(id, name, invoice, quantity,sell);
        }

        public bool DeleteProduct(int invoice)
        {
            return dp.Delete(invoice);
        }

        public bool UpdateQ(int quantity,int invoice)
        {

            return dp.UpdateQN(quantity,invoice);
        }

        public bool RecoverQ(int quantity, int invoice)
        {

            return dp.RecoverQN(quantity, invoice);
        }

    }
}