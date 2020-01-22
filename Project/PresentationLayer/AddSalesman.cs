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

namespace Project
{
    public partial class AddSalesman : Form
    {
        Salesman s = new Salesman();
        public AddSalesman()
        {
            InitializeComponent();
        }

        private void AddSalesman_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please Fill Up The Form");

            }
            else
            {
                if (textBox2.Text.Length == 14)
                {
                    string phone = textBox2.Text;
                    string name = textBox1.Text;
                    string address = textBox3.Text;
                    string nid = textBox5.Text;


                    string dob = dateTimePicker1.Value.ToShortDateString();
                    string gender = "";
                    if (radioButton1.Checked == true)
                    {
                        gender = "male";

                    }
                    if (radioButton2.Checked == true)
                    {
                        gender = "female";
                    }


                    if (s.AddSalesman(name, address, nid, phone, dob, gender))
                    {

                        MessageBox.Show("Successfully Person Created");
                    }
                    else
                    {
                        MessageBox.Show("Error in creating");
                    }
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox5.Text = string.Empty;
                    this.Hide();
                    ManagerProfile m = new ManagerProfile();
                    m.Show();
                }
                else 
                {
                    MessageBox.Show("Please insert Phone number correctly");
                }
                


            }

        }

        private void AddSalesman_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
