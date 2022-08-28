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
    public partial class CustomerList : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public CustomerList()
        {
            InitializeComponent();
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM CustomerTable", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            Con.Close();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Customers customers = new Customers();
                customers.CustID.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                customers.txtCustomerName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                customers.txtCustomerTelephone.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();

                customers.SaveButton.Enabled = false;
                customers.UpdateButton.Enabled = true;
                customers.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do you really want to delete this user?", "Delete User Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    cm = new SqlCommand("DELETE FROM CustomerTable WHERE CustomerID LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("This user record has been successfully deleted!");
                }
            }
            LoadCustomer();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.SaveButton.Enabled = true;
            customers.UpdateButton.Enabled = false;
            customers.ShowDialog();
            LoadCustomer();
        }
    }
}
