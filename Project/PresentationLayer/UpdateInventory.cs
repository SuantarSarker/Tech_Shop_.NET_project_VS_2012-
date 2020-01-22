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
    public partial class UpdateInventory : Form
    {
        Product_DataAccess da = new Product_DataAccess();
        Product p = new Product();
        DataTable dt = new DataTable();
        public UpdateInventory()
        {
            InitializeComponent();
            dataGridView1.DataSource = p.GetAllProduct();
        }
        void GridUpdate()
        {
            dataGridView1.DataSource = p.GetAllProduct();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Please fill the search box..");
            }
            p.InvoiceNo = int.Parse(textBox4.Text);
            dt = da.SearchProduct(p);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox2.Text;
                string name = textBox1.Text;
                int invoice = int.Parse(textBox4.Text);
                int sell = int.Parse(textBox5.Text);
                int quantity = int.Parse(textBox3.Text);
                if (p.UpdateProduct(id, name, invoice, quantity, sell))
                {

                    MessageBox.Show("Successfully Updated");
                    ManagerProfile m = new ManagerProfile();
                    this.Hide();
                    m.Show();
                }
                else
                {
                    MessageBox.Show("Error in updating");
                }
            }
            catch
            {
                
                MessageBox.Show("Please fill the form....");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            p.InvoiceNo = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void UpdateInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
