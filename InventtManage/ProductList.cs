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
    public partial class ProductList : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductList()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProducts.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM ProductTable WHERE CONCAT(ProductID, ProductName, Price, Description, Category) LIKE '%"+txtSearchBox.Text+"%'", Con);
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.SaveButton.Enabled = true;
            products.UpdateButton.Enabled = false;
            products.ShowDialog();
            LoadProduct();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProducts.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Products products = new Products();
                products.ProdID.Text = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
                products.txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells[2].Value.ToString();
                products.txtQuantity.Text = dgvProducts.Rows[e.RowIndex].Cells[3].Value.ToString();
                products.txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells[4].Value.ToString();
                products.txtDescription.Text = dgvProducts.Rows[e.RowIndex].Cells[5].Value.ToString();
                products.txtCategory.Text = dgvProducts.Rows[e.RowIndex].Cells[6].Value.ToString();

                products.SaveButton.Enabled = false;
                products.UpdateButton.Enabled = true;
                products.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do you really want to delete this product?", "Delete User Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    cm = new SqlCommand("DELETE FROM ProductTable WHERE ProductID LIKE '" + dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("This user record has been successfully deleted!");
                }
            }
            LoadProduct();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
