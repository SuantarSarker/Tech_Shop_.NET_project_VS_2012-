using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DataAccessLayer;

namespace Project.BusinessLogicLayer
{
    class Sold_Item
    {

        public string SalesmanId { get; set; }
        public string ProductName { get; set; }
        public int InvoiceNo { get; set; }
        public int Quantity { get; set; }
        public int BuyingPrice { get; set; }
        public int UnitPrice { get; set; }
        public string ProductId { get; set; }
        public int TotalPrice { get; set; }
        public string Date { get; set; }
        public string DateOne { get; set; }
        public int Profit { get; set; }


        Sold_Records dp = new Sold_Records();
        Sold_Item s;

        public List<Sold_Item> GetAllRecords()
        {
            var items = dp.GetAllRecords();
            List<Sold_Item> list = new List<Sold_Item>();

            

            for (int i = 0; i < items.Rows.Count; i++)
            {
                s = new Sold_Item();
                s.Date = items.Rows[i][1].ToString();
                s.DateOne = items.Rows[i][1].ToString();
                s.SalesmanId = items.Rows[i][2].ToString();
                s.ProductId = items.Rows[i][3].ToString();
                
                s.InvoiceNo = int.Parse(items.Rows[i][4].ToString());
                s.ProductName = items.Rows[i][5].ToString();
                s.Quantity = int.Parse(items.Rows[i][6].ToString());
                s.UnitPrice = int.Parse(items.Rows[i][7].ToString());
                s.TotalPrice = int.Parse(items.Rows[i][8].ToString());
                s.Profit = int.Parse(items.Rows[i][9].ToString()); 

               


                list.Add(s);
            }
            return list;
        }

        public bool AddRecords(string date,string s_id, string product_id, string product_name,int invoice_no,int  quantity, int unit, int total, int tprofit)
        {

            return dp.InsertItem(date, s_id, product_id, product_name, invoice_no, quantity, unit, total, tprofit);
        }
    }
}
