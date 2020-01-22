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
    public partial class SoldRecord : Form
    {
        Sold_Records s = new Sold_Records();
        Sold_Item si = new Sold_Item();
        DataTable dt = new DataTable();

        public SoldRecord()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }

        private void SoldRecord_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = s.GetAllRecords();
        }

        private void SoldRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
