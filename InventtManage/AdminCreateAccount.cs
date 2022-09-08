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
using System.Xml.Linq;

namespace InventtManage
{
    public partial class AdminCreateAccount : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public AdminCreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAdPassword.Text != txtConfirmAdPassword.Text)
                {
                    MessageBox.Show("Your passwords do not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Do you really want to add this new admin?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO AdminTable(AdminName,AUsername,APassword)VALUES(@AdminName,@AUsername,@APassword)", Con);
                    cm.Parameters.AddWithValue("@AdminName", txtAdmin.Text);
                    cm.Parameters.AddWithValue("@AUsername", txtAdUserName.Text);
                    cm.Parameters.AddWithValue("@APassword", txtAdPassword.Text);
                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("You have successfully added a new admin");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtAdmin.Clear();
            txtAdUserName.Clear();
            txtAdPassword.Clear();
            txtConfirmAdPassword.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAdPassword.Text != txtConfirmAdPassword.Text)
                {
                    MessageBox.Show("Your passwords do not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Do you really want to update this admin password?", "Password is being Updated", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE AdminTable SET AdminName=@AdminName, AUsername=@AUsername, APassword=@APassword WHERE AdminName LIKE '" + txtAdmin.Text + "' ", Con);
                    cm.Parameters.AddWithValue("@AdminName", txtAdmin.Text);
                    cm.Parameters.AddWithValue("@AUsername", txtAdUserName.Text);
                    cm.Parameters.AddWithValue("@APassword", txtAdPassword.Text);
                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("You have successfully updated the admin password");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Clear();
            AddButton.Enabled = true;
            UpdateButton.Enabled = false;
        }
    }
}
