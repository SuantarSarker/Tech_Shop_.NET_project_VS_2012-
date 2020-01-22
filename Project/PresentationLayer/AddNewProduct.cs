using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Project.BusinessLogicLayer;
namespace Project
{
    public partial class AddNewProduct : Form
    {
        public AddNewProduct()
        {
            InitializeComponent();
        }
        Product p = new Product();

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerProfile m = new ManagerProfile();
            this.Hide();
            m.Show();
        }

        string imgLocation = "";

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox2.Text) > int.Parse(textBox4.Text))
                {
                    MessageBox.Show("Seeling price should be greater then buying price");
                }
                else
                {
                    byte[] images = null;
                    FileStream s = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(s);
                    images = brs.ReadBytes((int)s.Length);

                    string id = textBox1.Text;
                    string name = textBox3.Text;
                    int quantity = int.Parse(textBox5.Text);
                    int buy = int.Parse(textBox2.Text);
                    string date = dateTimePicker1.Value.ToShortDateString();
                    int sell = int.Parse(textBox4.Text);

                    //if(radioButton1.Checked==true)
                    //{
                    // gender="male";

                    //}
                    //if(radioButton2.Checked==true)
                    //{
                    //gender="female";
                    //}

                    if (p.AddProduct(id, name, quantity, buy, sell, date, images))
                    {

                        MessageBox.Show("Successfully Product added");

                    }
                    else
                    {
                        MessageBox.Show("Error in added");
                    }
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = null;
                    pictureBox1.Image = null;
                }
                
            }
            catch
                {
                    MessageBox.Show("Please fill the form correctly");
                }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
