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
       
    public partial class ProfitAndLoss : Form
    {
        Sold_Records sr = new Sold_Records();
        Sold_Item si = new Sold_Item();
        DataTable dt = new DataTable();
        public ProfitAndLoss()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            si.Date = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dt = sr.SearchDate(si);
            dataGridView1.DataSource = dt;

            int t = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                t = t + int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }

            textBox1.Text = t.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            si.Date = dateTimePicker4.Value.ToString("dd-MM-yyyy");
            si.DateOne = dateTimePicker5.Value.ToString("dd-MM-yyyy");
            dt = sr.SearchBwDate(si);

            dataGridView1.DataSource = dt;

            int t = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                t = t + int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }

            textBox4.Text = t.ToString();
            
            

        }

        private void ProfitAndLoss_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }
    }
}
