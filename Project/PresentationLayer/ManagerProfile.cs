using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.PresentationLayer;
using Project.BusinessLogicLayer;

namespace Project
{
    public partial class ManagerProfile : Form
    {
        Salesman s = new Salesman();


        public ManagerProfile()
        {
            InitializeComponent();
            textBox12.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteSalesman1 d = new DeleteSalesman1();
            this.Hide();
            d.Show();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            AddSalesman a = new AddSalesman();
            this.Hide();
            a.Show();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateSalesmanInformation u = new UpdateSalesmanInformation();
            this.Hide();
            u.Show();
        }

        

        

        

        
        private void button11_Click(object sender, EventArgs e)
        {
         ChangePassword s = new ChangePassword();
            
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }

        private void ManagerProfile_Load(object sender, EventArgs e)
        {
            //s.ID = Login.id;
            //textBox1.Text = Login.id;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AddNewProduct a = new AddNewProduct();
            this.Hide();
            a.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            UpdateInventory u = new UpdateInventory();
            this.Hide();
            u.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            DeleteInventory d = new DeleteInventory();
            this.Hide();
            d.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            InventoryList i = new InventoryList();
            this.Hide();
            i.Show();

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            ProfitAndLoss p = new ProfitAndLoss();
            this.Hide();
            p.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            SoldRecord s = new SoldRecord();
            this.Hide();
            s.Show();
        }
    }
}
