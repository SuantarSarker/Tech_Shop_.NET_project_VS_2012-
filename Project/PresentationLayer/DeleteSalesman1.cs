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

namespace Project.PresentationLayer
{
    public partial class DeleteSalesman1 : Form
    {
        Salesman s = new Salesman();
        DataTable dt = new DataTable();
        DataAccess da = new DataAccess();
        public DeleteSalesman1()
        {
            InitializeComponent();
            dataGridView1.DataSource = s.GetAllSalesman();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }
        void GridUpdate()
        {
            dataGridView1.DataSource = s.GetAllSalesman();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                GridUpdate();
                MessageBox.Show("Please fill the search box..");
            }
            else
            {

                s.ID = textBox4.Text;
                dt = da.Search(s);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox4.Text == "")
            {

                MessageBox.Show("Please select any salesman...");
                GridUpdate();
               
            }
            else
            {
                
                 DialogResult res=MessageBox.Show("Are You Sure?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                 if (res.Equals(DialogResult.Yes))
                 {
                     string id = textBox4.Text;
                     if (s.DeleteSalesman(id))
                     {
                         GridUpdate();
                         MessageBox.Show("Successfully deleted");
                         ManagerProfile m = new ManagerProfile();
                         this.Hide();
                         m.Show();
                     }
                 }
            
                else
                 {
                     dataGridView1.DataSource = s.GetAllSalesman();
                 }
            }
            textBox4.Text = string.Empty;
        }

        private void DeleteSalesman1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s.ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
