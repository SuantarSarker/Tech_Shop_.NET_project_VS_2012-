using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.DataAccessLayer;
using Project.BusinessLogicLayer;

namespace Project
{
    public partial class SalesmanProfile : Form
    {
        Salesman s = new Salesman();
        DataTable dt = new DataTable();
        DataAccess da = new DataAccess();

        public SalesmanProfile()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePassword c = new ChangePassword();
            //this.Hide();
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintReceipt m = new PrintReceipt();
            this.Hide();
            m.Show();
        }

        private void SalesmanProfile_Load(object sender, EventArgs e)
        {
            textBox4.Text = Login.id;
            s.ID = textBox4.Text;
            dt = da.Search(s);
            dataGridView1.DataSource = dt;

            textBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

             
           
        }

        }
    }


