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
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\MobileShopDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        //
        //EXIT
        //
        private void bunifuLabel9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        //Data Transfermation for mobile
        //
        private void populate()
        {
            Con.Open();
            String query = "select MBrand,mModele,MPrice from MobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            mobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        //Data Transfermation for accessoir
        private void populateAccess()
        {
            Con.Open();
            String query = "select ABrand,AModele,APrice from AccessorieTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            accessorieDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        //Data Transfermation
        private void Selling_Load(object sender, EventArgs e)
        {
            populate();
            populateAccess();
            Sum();
        } 
        //
        // Sell Amount
        //
        private void Sum()
        {
                string query = "select sum(Amt) from BillTbl";
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sellamountlbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
        }
        //
        //
        //
        private void mobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productTB.Text = mobileDGV.SelectedRows[0].Cells[0].Value.ToString() + mobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            priceTB.Text = mobileDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void accessorieDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productTB.Text = accessorieDGV.SelectedRows[0].Cells[0].Value.ToString() + accessorieDGV.SelectedRows[0].Cells[1].Value.ToString();
            priceTB.Text = accessorieDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void mobileDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            productTB.Text = mobileDGV.SelectedRows[0].Cells[0].Value.ToString() + mobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            priceTB.Text = mobileDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void accessorieDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            productTB.Text = accessorieDGV.SelectedRows[0].Cells[0].Value.ToString() + accessorieDGV.SelectedRows[0].Cells[1].Value.ToString();
            priceTB.Text = accessorieDGV.SelectedRows[0].Cells[2].Value.ToString();
        }
        //
        // insert Bill
        //
        public void insertbill()
        {
            if (bill_idTB.Text == "" || clientnameTB.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                int amount = Convert.ToInt32(amoutTB.Text);
                try
                {
                    Con.Open();
                    String sql = "insert into BillTbl values(" + bill_idTB.Text + " , '" + clientnameTB.Text + "',"+ amount + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // 
        // Add button to the bill
        //
        int n = 0, RS=0;
        private void Badd_Click(object sender, EventArgs e)
        {
            if (quantityTB.Text == "" || priceTB.Text == "")
            {
                MessageBox.Show("Enter The Quantity");
            }
            else
            {
                int total = Convert.ToInt32(quantityTB.Text) * Convert.ToInt32(priceTB.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(billDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = productTB.Text;
                newRow.Cells[2].Value = priceTB.Text;
                newRow.Cells[3].Value = quantityTB.Text;
                newRow.Cells[4].Value = total;
                billDGV.Rows.Add(newRow);
                n++;
                RS= RS + total;
                amoutTB.Text = ""+RS;               
            }
        }
        // 
        // Print
        //
        int prodid, prodqty, prodprice, tottal, pos = 60;
        string prodname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Mobile Shop Database", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26,40));
            foreach (DataGridViewRow row in billDGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = ""+row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString(""+prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26,pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Grand Total: Rs" + RS, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos+50));
            e.Graphics.DrawString("*********Mobile Shop Database*********", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(10, pos+85));
            billDGV.Rows.Clear();
            billDGV.Refresh();
            pos = 100;
            RS = 0;
            n = 0;
            insertbill();
            Sum();
        }
        private void printB_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm",285,600);
            if (printPreviewDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        // 
        // Home page
        //
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel10_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }
        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }
    }
}
