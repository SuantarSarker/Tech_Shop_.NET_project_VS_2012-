using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class ManagerProfile : Form
    {
        public ManagerProfile()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteInventory d = new DeleteInventory();
            d.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSalesman a = new AddSalesman();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddNewProduct a = new AddNewProduct();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateSalesmanInformation u = new UpdateSalesmanInformation();
            u.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ProfitAndLoss p = new ProfitAndLoss();
            p.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SoldRecord s = new SoldRecord();
            s.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InventoryList i = new InventoryList();
            i.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateInventory u = new UpdateInventory();
            u.Show();
        }
    }
}
