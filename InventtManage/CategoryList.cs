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
    public partial class CategoryList : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public CategoryList()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM CategoryTable", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            Con.Close();
        }

        private void CategoryList_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.SaveButton.Enabled = true;
            categories.UpdateButton.Enabled = false;
            categories.ShowDialog();
            LoadCategory();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Categories categories = new Categories();
                categories.CustID.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                categories.txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();

                categories.SaveButton.Enabled = false;
                categories.UpdateButton.Enabled = true;
                categories.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    cm = new SqlCommand("DELETE FROM CategoryTable WHERE CategoryID LIKE '" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }
            LoadCategory();
        }
    }
}
