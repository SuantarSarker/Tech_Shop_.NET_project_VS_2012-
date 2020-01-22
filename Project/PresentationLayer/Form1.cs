using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Project.BusinessLogicLayer;
using Project.DataAccessLayer;
using Microsoft.VisualBasic;


namespace Project.PresentationLayer
{
    public partial class Form1 : Form
    {
        Product_DataAccess da = new Product_DataAccess();
        Product p = new Product();
        Sold_Records sr = new Sold_Records();
        Sold_Item si = new Sold_Item();
        //DataAccess d = new DataAccess();
        //Salesman s = new Salesman();
        DataTable dt = new DataTable();
        int s;
        public Form1()
        {
            InitializeComponent();

            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].HeaderText = "Product ID";
            dataGridView2.Columns[1].HeaderText = "Product Name";
            dataGridView2.Columns[2].HeaderText = "Invoice No";
            dataGridView2.Columns[3].HeaderText = "Quantity";
            dataGridView2.Columns[4].HeaderText = "Unit Price";
            dataGridView2.Columns[5].HeaderText = "Total Price";
        }

        void GridUpdate()
        {
            dataGridView1.DataSource = p.GetAllProduct();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nothing to search");
            }
            else
            {
                p.ProductId = textBox1.Text;
                dt = da.GetProduct(p);
                dataGridView1.DataSource = dt;
            }

        }

        void UpdateQuantity()
        {
            int invoice = int.Parse(textBox8.Text);
            int q = int.Parse(textBox2.Text) - int.Parse(textBox7.Text);
            int quantity = q;
            p.UpdateQ(quantity,invoice);
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            p.ProductId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //string s = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //byte[] i = Encoding.ASCII.GetBytes(s);
            ////byte[] img = ((byte[])i);
            //MemoryStream ms = new MemoryStream(i);
            //pictureBox1.Image = Image.FromStream(ms);
            //dt.Dispose();

        }



        private void sTOCK(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox6.Text = Login.id;
            textBox12.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox10.Text;
                string id = textBox1.Text;
                string invoice = textBox8.Text;
                string quantity = textBox7.Text;
                string unit_price = textBox9.Text;
                int t = int.Parse(quantity) * int.Parse(unit_price);
                string total_price = t.ToString();

                AddData(id, name, invoice, quantity, unit_price, total_price);


                UpdateQuantity();


                textBox1.Text = textBox2.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = string.Empty;
            }
            catch 
            {
                MessageBox.Show("Please select any product");
            }
                
            
            

        }

        


        public void AddData(string id, string name,string invoice, string quantity, string u, string t)
        {

            string[] row = { id, name,invoice, quantity, u, t };
            dataGridView2.Rows.Add(row);

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap obj = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(obj,new Rectangle(5,5,this.dataGridView2.Width,this.dataGridView2.Height));
            e.Graphics.DrawImage(obj, 50, 300);
            e.Graphics.DrawString("TECH SHOP" ,new Font("Old English Text MT", 35, FontStyle.Underline), Brushes.BlueViolet, new Point(280, 10));
            e.Graphics.DrawString("Customer Name: " + textBox3.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 180));
            e.Graphics.DrawString("Date: " + DateTime.Now, new Font("Arial", 12), Brushes.Black, new Point(25, 200));
            e.Graphics.DrawString("Salesman " + textBox6.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));
            e.Graphics.DrawString("Total Amount: " + textBox5.Text+"  TAKA", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(450, 800));
           // e.Graphics.DrawString("TAKA" ,  new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 800));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == ""|| textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please give all the information");
            }
            else
            {
                if (textBox4.Text.Length == 11)
                {
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                    dataGridView2.Rows.Clear();
                    textBox5.Text = textBox3.Text = textBox4.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Phone number is not valid");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(rowIndex);
            UndoQuantity();

            textBox1.Text = textBox2.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = string.Empty;
            }
            catch 
            {
                MessageBox.Show("Please select any product");
            }
            //dataGridView1.DataSource = p.GetAllProduct();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox7.Text=dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            s = e.RowIndex;

            p.InvoiceNo = int.Parse(textBox8.Text);
            dt = da.SearchProduct(p);
            dataGridView1.DataSource = dt;

            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


            
        }

        void UndoQuantity()
        {
            int i = int.Parse(textBox8.Text);
            int q = int.Parse(textBox2.Text) + int.Parse(textBox7.Text);
            p.RecoverQ(q, i);
            


        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView2.Rows[s];
            textBox7.Text = row.Cells[3].Value.ToString();
            int q = int.Parse(textBox7.Text);
            string quantity = Interaction.InputBox("Enterr the quantity to add", "Add Quantity ", row.Cells[3].Value.ToString(), -1, -1);
            int u = int.Parse(quantity) + q;
            string qn = u.ToString();
            row.Cells[3].Value = qn;
            row.Cells[5].Value = int.Parse(row.Cells[3].Value.ToString()) * int.Parse(row.Cells[4].Value.ToString());
            
            
            int invoice = int.Parse(textBox8.Text);
            int quan = int.Parse(textBox2.Text) - int.Parse(quantity);
            p.UpdateQ(quan, invoice);
            }
            catch 
            {
                MessageBox.Show("Please select any product");
            }
            textBox1.Text = textBox2.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = string.Empty;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("No item in cart");
            }
            else
            {

                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    string date = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    string s_id = textBox6.Text;
                    string product_id = dataGridView2.Rows[j].Cells[0].Value.ToString();
                    string product_name = dataGridView2.Rows[j].Cells[1].Value.ToString();
                    int invoice_no = int.Parse(dataGridView2.Rows[j].Cells[2].Value.ToString());
                    int quantity = int.Parse(dataGridView2.Rows[j].Cells[3].Value.ToString());
                    int unit = int.Parse(dataGridView2.Rows[j].Cells[4].Value.ToString());
                    int total = int.Parse(dataGridView2.Rows[j].Cells[5].Value.ToString());

                    p.InvoiceNo = invoice_no;
                    dt = da.SearchP(p);


                    dataGridView3.DataSource = dt;
                    int buy = int.Parse(dataGridView3.Rows[0].Cells[0].Value.ToString());
                    int profit, tprofit;
                    profit = unit - buy;
                    tprofit = profit * quantity;

                    si.AddRecords(date, s_id, product_id, product_name, invoice_no, quantity, unit, total, tprofit);
                }
                textBox1.Text = textBox2.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = string.Empty;


            }



          int t=0;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
               t =t+ int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString());
            }

            textBox5.Text = t.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            p.ProductId = textBox1.Text;
            dt = da.GetProduct(p);
            dataGridView1.DataSource = dt;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login m = new Login();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SalesmanProfile S = new SalesmanProfile();
            this.Hide();
            S.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
