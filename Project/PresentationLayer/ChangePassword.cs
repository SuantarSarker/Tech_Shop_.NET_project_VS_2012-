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
    public partial class ChangePassword : Form
    {
        Salesman s = new Salesman();
        DataTable dt = new DataTable();
        DataAccess da = new DataAccess();

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string p=textBox1.Text;
            string pw = dataGridView1.Rows[0].Cells[0].Value.ToString();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill the form first....");
            }
            else
            {
                if (p == pw)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        if (s.UpdatePass(Login.id, textBox2.Text))
                        {

                            MessageBox.Show("Successfully password changed");
                            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Confirm password should match with the new password");
                        textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Existing password not matched");
                    textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
                }
            }
                       
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            
            s.ID = Login.id;
            dt = da.SearchPass(s);
            dataGridView1.DataSource = dt;
            
        }
    }
}
