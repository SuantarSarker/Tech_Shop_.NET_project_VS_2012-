using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.BusinessLogicLayer;
using Project.DataAccessLayer;

namespace Project
{
    public partial class DeleteInventory : Form
    {
        Product_DataAccess da = new Product_DataAccess();
        Product p = new Product();
        DataTable dt = new DataTable();

        public DeleteInventory()
        {
            InitializeComponent();
            dataGridView1.DataSource = p.GetAllProduct();
        }

        void GridUpdate()
        {
            dataGridView1.DataSource = p.GetAllProduct();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Nothing to search...");
                }
                else
                {
                    p.InvoiceNo = int.Parse(textBox1.Text);
                    dt = da.SearchProduct(p);
                    dataGridView1.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show("Please give invoice number correctly");
                dataGridView1.DataSource = p.GetAllProduct();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please select any product");
                }
                else
                {
                    DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res.Equals(DialogResult.Yes))
                    {
                        int invoice = int.Parse(textBox1.Text);
                        if (p.DeleteProduct(invoice))
                        {
                            GridUpdate();
                            MessageBox.Show("Successfully product deleted");
                            ManagerProfile m = new ManagerProfile();
                            this.Hide();
                            m.Show();
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = p.GetAllProduct();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please give invoice number correctly");
                dataGridView1.DataSource = dt;
            }
            textBox1.Text = string.Empty;
        }

        private void DeleteInventory_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
        }
            
                
           

        

        private void DeleteInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            p.InvoiceNo = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
