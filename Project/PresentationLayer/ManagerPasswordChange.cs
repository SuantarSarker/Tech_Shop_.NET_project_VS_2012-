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
    public partial class ManagerPasswordChange : Form
    {
        public ManagerPasswordChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
