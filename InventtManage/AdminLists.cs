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
    public partial class AdminLists : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public AdminLists()
        {
            InitializeComponent();
            LoadAdminCreateAccount();
        }

        public void LoadAdminCreateAccount()
        {
            int i = 0;
            dgvAdmin.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM AdminTable", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvAdmin.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            Con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminCreateAccount adminCreateAccount = new AdminCreateAccount();
            adminCreateAccount.AddButton.Enabled = true;
            adminCreateAccount.UpdateButton.Enabled = false;
            adminCreateAccount.ShowDialog();
            LoadAdminCreateAccount();
        }

        private void dgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvAdmin.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                AdminCreateAccount adminCreateAccount = new AdminCreateAccount();
                adminCreateAccount.txtAdmin.Text = dgvAdmin.Rows[e.RowIndex].Cells[1].Value.ToString();
                adminCreateAccount.txtAdUserName.Text = dgvAdmin.Rows[e.RowIndex].Cells[2].Value.ToString();
                adminCreateAccount.txtAdPassword.Text = dgvAdmin.Rows[e.RowIndex].Cells[3].Value.ToString();

                adminCreateAccount.AddButton.Enabled = false;
                adminCreateAccount.UpdateButton.Enabled = true;
                adminCreateAccount.txtAdUserName.Enabled = false;
                adminCreateAccount.txtAdmin.Enabled = false;
                adminCreateAccount.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do you really want to delete this admin?", "Delete Admin Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Con.Open();
                    cm = new SqlCommand("DELETE FROM AdminTable WHERE AdminName LIKE '" + dgvAdmin.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("This user record has been successfully deleted!");
                }
            }
            LoadAdminCreateAccount();
        }
    }
}
