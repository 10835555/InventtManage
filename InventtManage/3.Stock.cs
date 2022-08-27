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

namespace InventtManage
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            ShowProduct();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void ShowProduct()
        {
            Con.Open();
            string Query = "select * from ProductTable";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\InventtManageDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button2_Click(object sender, EventArgs e)
        {
            if (ProductNameTB.Text == "" || CategoryCB.Text == "" || SPriceTB.Text == "" || BPriceTB.Text == "" || SupplierCB.SelectedIndex == -1 || CategoryCB.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please input all required information");
            }
            else
            {
                int Gain = Convert.ToInt32(SPriceTB.Text) - Convert.ToInt32(BPriceTB.Text);
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProductTable values(@ProductName,@ProductCategory,@ProductQuantity,@BPrice,@SPrice,@ExpiryDate,@Supplier,@G)", Con);
                    cmd.Parameters.AddWithValue("@ProductName", ProductNameTB.Text);
                    cmd.Parameters.AddWithValue("@ProductCategory", CategoryCB.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@ProductQuantity", QuantityTB.Text);
                    cmd.Parameters.AddWithValue("@BPrice", BPriceTB.Text);
                    cmd.Parameters.AddWithValue("@SPrice", SPriceTB.Text);
                    cmd.Parameters.AddWithValue("@ExpiryDate", ExpiryDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Supplier", SupplierCB.SelectedIndex);
                    cmd.Parameters.AddWithValue("@G", Gain);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Product has been saved");
                    Con.Close();
                    ShowProduct();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductNameTB.Text = ProductDGV.SelectedRows[0].Cells[1].Value.ToString();
            CategoryCB.Text = ProductDGV.SelectedRows[0].Cells[2].Value.ToString();
            QuantityTB.Text = ProductDGV.SelectedRows[0].Cells[3].Value.ToString();
            BPriceTB.Text = ProductDGV.SelectedRows[0].Cells[4].Value.ToString();
            SPriceTB.Text = ProductDGV.SelectedRows[0].Cells[5].Value.ToString();
            ExpiryDate.Text = ProductDGV.SelectedRows[0].Cells[6].Value.ToString();
            SupplierCB.Text = ProductDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (ProductNameTB.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProductNameTB.Text == "" || CategoryCB.Text == "" || SPriceTB.Text == "" || BPriceTB.Text == "" || SupplierCB.SelectedIndex == -1 || CategoryCB.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Please input all required information");
            }
            else
            {
                int Gain = Convert.ToInt32(SPriceTB.Text) - Convert.ToInt32(BPriceTB.Text);
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ProductTable set ProductName=@ProductName,ProductCategory=@ProductCategory,ProductQuantity=@ProductQuantity,BuyingPrice=@BPrice,SellingPrice=@SPrice,ProductDate=@ExpiryDate,SSup=@Supplier,Gain=@G where ProductID=@ProductKey", Con);
                    cmd.Parameters.AddWithValue("@ProductName", ProductNameTB.Text);
                    cmd.Parameters.AddWithValue("@ProductCategory", CategoryCB.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@ProductQuantity", QuantityTB.Text);
                    cmd.Parameters.AddWithValue("@BPrice", BPriceTB.Text);
                    cmd.Parameters.AddWithValue("@SPrice", SPriceTB.Text);
                    cmd.Parameters.AddWithValue("@ExpiryDate", ExpiryDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Supplier", SupplierCB.SelectedIndex);
                    cmd.Parameters.AddWithValue("@G", Gain);
                    cmd.Parameters.AddWithValue("@ProductKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Product has been edited");
                    Con.Close();
                    ShowProduct();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show(this, "Please select the product");
            }
            else
            {
                _ = Convert.ToInt32(SPriceTB.Text) - Convert.ToInt32(BPriceTB.Text);
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ProductTable where ProductID=@ProductKey", Con);
                    cmd.Parameters.AddWithValue("@ProductKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Product has been deleted");
                    Con.Close();
                    ShowProduct();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BPriceTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void KeyBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
