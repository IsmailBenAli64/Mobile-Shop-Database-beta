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
    public partial class Accessories : Form
    {
        public Accessories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\MobileShopDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        //
        //Exit
        //
        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        //DATA TRANSFERMATION
        //
        private void populate()
        {
            Con.Open();
            String query = "select * from AccessorieTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            accessorieDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        //
        //DATA TRANSFERMATION
        //
        private void Accessories_Load(object sender, EventArgs e)
        {
            populate();
        }
        //
        //Add
        //
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (AidTB.Text == "" || AbrandTB.Text == "" || AmodeleTB.Text == "" || ApriceTB.Text == "" || AstockTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into AccessorieTbl values(" + AidTB.Text + " , '" + AbrandTB.Text + "' , '" + AmodeleTB.Text + "' , " + ApriceTB.Text + " , " + AstockTB.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Added Successfully");
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
        //
        //Clear
        //
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            AidTB.Text = "";
            AbrandTB.Text = "";
            AmodeleTB.Text = "";
            ApriceTB.Text = "";
            AstockTB.Text = "";
        }
        //
        //DATA AFFICHAGE
        //
        private void accessorieDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AidTB.Text = accessorieDGV.SelectedRows[0].Cells[0].Value.ToString();
            AbrandTB.Text = accessorieDGV.SelectedRows[0].Cells[1].Value.ToString();
            AmodeleTB.Text = accessorieDGV.SelectedRows[0].Cells[2].Value.ToString();
            ApriceTB.Text = accessorieDGV.SelectedRows[0].Cells[3].Value.ToString();
            AstockTB.Text = accessorieDGV.SelectedRows[0].Cells[4].Value.ToString();
        }
        //
        //DELETE
        //
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            if (AidTB.Text == "")
            {
                MessageBox.Show("Enter The Accessorie to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from AccessorieTbl where AId =" + AidTB.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Deleted");
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

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {

        }
        //
        //Update
        //
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (AidTB.Text == "" || AbrandTB.Text == "" || AmodeleTB.Text == "" || ApriceTB.Text == "" || AstockTB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update AccessorieTbl set ABrand='" + AbrandTB.Text + "' ,AModele ='" + AmodeleTB.Text + "' ,APrice =" + ApriceTB.Text + " ,AStock =" + AstockTB.Text + " where AId=" + AidTB.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Updated Successfully");
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
        //
        // Home
        //
        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
