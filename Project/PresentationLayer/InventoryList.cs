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
    public partial class InventoryList : Form
    {

        Product p = new Product();
        DataTable dt = new DataTable();
        Product_DataAccess da = new Product_DataAccess();

        public InventoryList()
        {
            InitializeComponent();
            dataGridView1.DataSource = da.GetProduct1();
        }

        void GridUpdate()
        {
            dataGridView1.DataSource = da.GetProduct1();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            p.ProductId = textBox4.Text;
            dt = da.GetProduct(p);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Nothing to search...");
            }
            else
            {
                p.ProductId = textBox4.Text;
                dt = da.GetProduct(p);
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }

        private void InventoryList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void InventoryList_Load(object sender, EventArgs e)
        {

        }
    }
}
