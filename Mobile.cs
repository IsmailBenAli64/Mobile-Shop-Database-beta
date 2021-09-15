using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mobile_Shop_Database
{
    public partial class Mobile : Form
    {
        public Mobile()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\MobileShopDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        //Exit
        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //DATA TRANSFERMATION
        private void populate()
        {
            Con.Open();
            String query = "select * from MobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            mobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        //DATA TRANSFERMATION
        private void Mobile_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Add
        private void Badd_Click(object sender, EventArgs e)
        {
            if (idTB.Text == "" || brandTB.Text == "" || modeleTB.Text == "" || priceTB.Text == "" || stockTB.Text == "" || cameraTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into MobileTbl values(" + idTB.Text + " , '" + brandTB.Text + "' , '" + modeleTB.Text + "' , " + priceTB.Text + " , " + stockTB.Text + " , " + ramCB.SelectedItem.ToString() + " , " + romCB.SelectedItem.ToString() + " , " + cameraTB.Text + " )";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Added Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }
        //Clear
        private void Bclear_Click(object sender, EventArgs e)
        {
            idTB.Text = "";
            brandTB.Text = "";
            modeleTB.Text = "";
            priceTB.Text = "";
            stockTB.Text = "";
            cameraTB.Text = "";
        }
        //Data Affichage in textboxes
        private void mobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idTB.Text = mobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            brandTB.Text = mobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            modeleTB.Text = mobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            priceTB.Text = mobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            stockTB.Text = mobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            ramCB.SelectedItem= mobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            romCB.SelectedItem= mobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            cameraTB.Text = mobileDGV.SelectedRows[0].Cells[7].Value.ToString();
        }
        //Delete
        private void Bdelete_Click(object sender, EventArgs e)
        {
            if (idTB.Text == "")
            {
                MessageBox.Show("Enter The Mobile to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from MobileTbl where MId =" + idTB.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }
        //Update
        private void Bupdate_Click(object sender, EventArgs e)
        {
            if (idTB.Text == "" || brandTB.Text == "" || modeleTB.Text == "" || priceTB.Text == "" || stockTB.Text == "" || cameraTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update MobileTbl set MBrand='" + brandTB.Text + "' ,MModele ='" + modeleTB.Text + "' ,MPrice =" + priceTB.Text + " ,MStock =" + stockTB.Text + " ,MRam =" + ramCB.SelectedItem.ToString() + " ,MRom =" + romCB.SelectedItem.ToString() + " ,MCamera =" + cameraTB.Text + " where MId=" + idTB.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Updated Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
