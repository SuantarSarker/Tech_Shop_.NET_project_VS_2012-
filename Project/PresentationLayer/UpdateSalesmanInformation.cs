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
    public partial class UpdateSalesmanInformation : Form
    {
        DataAccess da = new DataAccess();
        Salesman s = new Salesman();
        DataTable dt = new DataTable();
        public UpdateSalesmanInformation()
        {
            InitializeComponent();
            dataGridView1.DataSource = s.GetAllSalesman();
        }
        void GridUpdate()
        {
            dataGridView1.DataSource = s.GetAllSalesman();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text== "")
            {
                MessageBox.Show("Please fill the search box..");

            }
            else
            {
                s.ID = textBox4.Text;
                dt = da.Search(s);
                dataGridView1.DataSource = dt;
            }
            s.ID = textBox4.Text;
            dt = da.Search(s);
            dataGridView1.DataSource = dt;

            //if (s.SearchSalesman(id))
            //{

            //    GridUpdate();
            //    MessageBox.Show("search");
            //}
            //else
            //{
            //    MessageBox.Show("Error in creating");
            //}


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }

        

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s.ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == ""||textBox2.Text == ""||textBox1.Text == "")
            {
                MessageBox.Show("Please fill the form correctly...");
            }
            else
            {
                if (textBox2.Text.Length == 14)
                {
                    string id = textBox4.Text;
                    string name = textBox1.Text;
                    string address = textBox3.Text;
                    string phone = textBox2.Text;
                    if (s.UpdateSalesman(id, name, address, phone))
                    {

                        MessageBox.Show("Successfully Person Updated");
                        ManagerProfile m = new ManagerProfile();
                        this.Hide();
                        m.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error in creating");
                    }
                }
                else {
                    MessageBox.Show("Please insert Phone number correctly");
                }
            }
        }

        private void UpdateSalesmanInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
