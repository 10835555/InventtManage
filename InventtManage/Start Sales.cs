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
    public partial class Start_Sales : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public Start_Sales()
        {
            InitializeComponent();
            LoadOrder();
        }

        public void LoadOrder()
        {
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM OrderTable", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            Con.Close();
        }
        private void StartSalesBtn_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.ShowDialog();
            LoadOrder();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

                        cm = new SqlCommand("UPDATE ProductTable SET PQuantity=(PQuantity+@PQuantity) WHERE ProductID LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", Con);
                        cm.Parameters.AddWithValue("@PQuantity", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));

                        Con.Open();
                        cm.ExecuteNonQuery();
                        Con.Close();
                    }
                }
                LoadOrder();
            }
        }
    }
}
