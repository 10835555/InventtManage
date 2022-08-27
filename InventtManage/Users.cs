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
    public partial class Users : Form
    {

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public Users()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you really want to add this new user?", "Saving Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cm= new SqlCommand("INSERT INTO UserTable(Name,Username,Password,Telephone)VALUES(@Name,@Username,@Password,@Telephone)", Con);
                    cm.Parameters.AddWithValue("@Name", txtName.Text);
                    cm.Parameters.AddWithValue("@Username", txtUserName.Text);
                    cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("You have successfully added a new user"); 
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             Clear();
        }

        public void Clear()
        {
            txtName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtTelephone.Clear();
        }
    }
}
