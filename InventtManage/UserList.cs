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
    public partial class UserList : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserList()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM UserTable", Con);
            Con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            Con.Close();
        }
        private void UserList_Load(object sender, EventArgs e)
        {

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Users users = new Users();
                users.txtName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                users.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                users.txtPassword.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                users.txtTelephone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                users.SaveButton.Enabled = false;
                users.UpdateButton.Enabled = true;
                users.txtUserName.Enabled = false;
                users.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Do you really want to delete this user?", "Delete User Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   Con.Open();
                    cm = new SqlCommand("DELETE FROM UserTable WHERE Name LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", Con);
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("This user record has been successfully deleted!");
                }
            }
            LoadUser();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.SaveButton.Enabled = true;
            users.UpdateButton.Enabled = false;
            users.ShowDialog();
            LoadUser();
        }
    }
}
