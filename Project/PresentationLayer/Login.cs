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
using Project.PresentationLayer;

namespace Project
{
    public partial class Login : Form
    {

        
       
        public string utype;

        DataTable dt = new DataTable();
        Salesman s=new Salesman();
        public static string id;
        
        DataAccess da = new DataAccess();
        

        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please give Id & password");
            }
            else
            {

                s.ID = textBox4.Text;
                s.Password = textBox3.Text;
                dt = da.Login(s);



                if (dt.Rows.Count > 0)
                {
                    utype = dt.Rows[0][8].ToString().Trim();
                    if (utype == "M")
                    {
                        id = textBox4.Text;
                        this.Hide();
                        ManagerProfile mda = new ManagerProfile();
                        mda.Show();
                    }
                    else
                    {
                        id = textBox4.Text;
                        this.Hide();
                        Form1 mde = new Form1();
                        mde.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Please enter valid Id & password");
                }

            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Application.Exit();
        }
    }
}
