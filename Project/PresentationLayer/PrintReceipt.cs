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
    public partial class PrintReceipt : Form
    {
        Product_DataAccess da = new Product_DataAccess();
        Product p = new Product();
        DataTable dt = new DataTable();

        public PrintReceipt()
        {
            InitializeComponent();
            
        }

        void GridUpdate()
        {
            dataGridView2.DataSource = p.GetAllProduct();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePassword c = new ChangePassword();
            this.Hide();
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SalesmanProfile s = new SalesmanProfile();
            this.Hide();
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            p.ProductId = textBox1.Text;
            dt = da.GetProduct(p);
            dataGridView2.DataSource = dt;
    
            
            

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            p.ProductId = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
