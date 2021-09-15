using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Database
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        { }
        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            useridTB.Text = "";
            passwordTB.Text = "";
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        { }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if(useridTB.Text=="" || passwordTB.Text=="")
            {
                MessageBox.Show("Enter User Name and Password");
            }
            else if(useridTB.Text == "Ismail Ben Ali" && passwordTB.Text == "AYAYA")
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User Name or Password");
            }
        }
        //
        // Hide Password
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordTB.PasswordChar == '\0')
            {
                button2.BringToFront();
                passwordTB.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (passwordTB.PasswordChar == '*')
            {
                button1.BringToFront();
                passwordTB.PasswordChar = '\0';
            }
        }


        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}

