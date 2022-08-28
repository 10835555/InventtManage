using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventtManage
{
    public partial class Products : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Products()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            txtCategory.Items.Clear();
            cm = new SqlCommand("SELECT CategoryName FROM CategoryTable", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txtCategory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            Con.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO ProductTable(ProductName,Quantity,Price,Description,Category)VALUES(@ProductName, @Quantity, @Price, @Description, @Category)", Con);
                    cm.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cm.Parameters.AddWithValue("@Quantity", Convert.ToInt16(txtQuantity.Text));
                    cm.Parameters.AddWithValue("@Price", Convert.ToInt16(txtPrice.Text));
                    cm.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cm.Parameters.AddWithValue("@Category", txtCategory.Text);
                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtProductName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
            txtCategory .Text = "";
        }
    }
}
