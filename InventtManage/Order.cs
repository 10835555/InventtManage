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
    public partial class Order : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int Quantity = 0;
        public Order()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT CustomerID, CustomerName FROM CustomerTable WHERE CONCAT(CustomerID,CustomerName) LIKE '%" + txtSearchCustomer.Text + "%'", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            Con.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProducts.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM ProductTable WHERE CONCAT(ProductID, ProductName, Price, Description, Category) LIKE '%" + txtSearchProduct.Text + "%'", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProducts.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            Con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }


        private void UDQuantity_ValueChanged(object sender, EventArgs e)
        {
            GetQuantity();
            if (Convert.ToInt16(UDQuantity.Value) > Quantity)
            {
                MessageBox.Show("There is not enough items in stock!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDQuantity.Value = UDQuantity.Value - 1;
                return;
            }
            if (Convert.ToInt16(UDQuantity.Value) < 0)
            {
            int total = Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(UDQuantity.Value);
            txtTotal.Text = total.ToString();
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerID.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCustomerName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductID.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerID.Text == "")
                {
                    MessageBox.Show("Please select the customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtProductID.Text == "")
                {
                    MessageBox.Show("Please select the product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Do you really want to add this new order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO OrderTable(OrderDate, ProductID, CustomerID, Quantity, Price, Total)VALUES(@OrderDate, @ProductID, @CustomerID, @Quantity, @Price, @Total)", Con);
                    cm.Parameters.AddWithValue("@OrderDate", txtOrderDate.Value);
                    cm.Parameters.AddWithValue("@ProductID", Convert.ToInt16(txtProductID.Text));
                    cm.Parameters.AddWithValue("@CustomerID", Convert.ToInt16(txtCustomerID.Text));
                    cm.Parameters.AddWithValue("@Quantity", Convert.ToInt16(UDQuantity.Value));
                    cm.Parameters.AddWithValue("@Price", Convert.ToInt16(txtPrice.Text));
                    cm.Parameters.AddWithValue("@Total", Convert.ToInt16(txtTotal.Text));
                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("You have successfully added a new order");
                    Clear();

                    cm = new SqlCommand("UPDATE ProductTable SET PQuantity=(PQuantity-@PQuantity) WHERE ProductID LIKE '" + txtProductID.Text + "' ", Con);
                    cm.Parameters.AddWithValue("@PQuantity", Convert.ToInt16(UDQuantity.Value));


                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                    Clear();
                    LoadProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();

            txtProductID.Clear();
            txtProductName.Clear();

            txtPrice.Clear();
            UDQuantity.Value = 1;
            txtTotal.Clear();
            txtOrderDate.Value = DateTime.Now;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void GetQuantity()
        {
            cm = new SqlCommand("SELECT PQuantity FROM ProductTable WHERE ProductID='" + txtProductID.Text + "'", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Quantity = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            Con.Close();
        }
    }
}
