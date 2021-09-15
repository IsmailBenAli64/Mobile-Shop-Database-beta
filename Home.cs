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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            Mobile mobile = new Mobile();
            mobile.Show();
            this.Hide();
        }

        private void Bupdate_Click(object sender, EventArgs e)
        {
            Accessories accessories = new Accessories();
            accessories.Show();
            this.Hide();
        }

        private void Bdelete_Click(object sender, EventArgs e)
        {
            Selling selling = new Selling();
            selling.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            About_Us Aboutus = new About_Us();
            Aboutus.Show();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
