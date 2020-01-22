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
    public partial class DeleteSalesman : Form
    {
        
        Salesman s = new Salesman();
        DataTable dt = new DataTable();
        DataAccess da = new DataAccess();

        public DeleteSalesman()
        {
            InitializeComponent();
            dataGridView2.DataSource = s.GetAllSalesman();
            
            
        }

        void GridUpdate()
        {
            dataGridView2.DataSource = s.GetAllSalesman();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            s.ID = textBox4.Text;
            dt = da.Search(s);
            dataGridView2.DataSource = dt;
            //dataGridView1.DataSource = s.GetAllSalesman();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string id= textBox4.Text;
            if (textBox4.Text == "")
            {
                MessageBox.Show("Nothing to search");
            }
            else
            {
                if (s.DeleteSalesman(id))
                {
                    GridUpdate();
                    MessageBox.Show("Successfully Person deleted");
                    ManagerProfile m = new ManagerProfile();
                    this.Hide();
                    m.Show();
                }
                else
                {
                    MessageBox.Show("Error in deleting");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

