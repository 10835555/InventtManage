using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace InventtManage
{
    public partial class OrderList : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public OrderList()
        {
            InitializeComponent();
        }

        public void LoadOrder()
        {
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT OrderID, OrderDate, O.ProductID, P.ProductName, O.CustomerID, C.CustomerName, P.Quantity, P.Price, Total  FROM OrderTable AS O JOIN CustomerTable AS C ON O.CustomerID=C.CustomerID JOIN ProductTable AS P ON O.ProductID=P.ProductID", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
            }
            dr.Close();
            Con.Close();
        }

        private void OrderList_Load(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;
          
            if (colName == "Delete")
            {
                if (MessageBox.Show("Do you really want to delete this user?", "Delete User Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    cm = new SqlCommand("DELETE FROM OrderTable WHERE OrderID LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("This order record has been successfully deleted!");

                    cm = new SqlCommand("UPDATE ProductTable SET Quantity=(Quantity+@Quantity) WHERE ProductID LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", Con);
                    cm.Parameters.AddWithValue("@Quantity", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));

                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                }
            }
            LoadOrder();
        }
    }
}
