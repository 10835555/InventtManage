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
    public partial class UserSignIn : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserSignIn()
        {
            InitializeComponent();
        }

        private void UserSignIn_Load(object sender, EventArgs e)
        {

        }

        private void UShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (UShowPassword.Checked == true)
                txtUPassword.UseSystemPasswordChar = false;
            else
                txtUPassword.UseSystemPasswordChar = true;
        }

        private void ULoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM UserTable WHERE Username=@Username AND Password=@Password", Con);
                cm.Parameters.AddWithValue("@Username", txtUserUN.Text);
                cm.Parameters.AddWithValue("@Password", txtUPassword.Text);
                Con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    MessageBox.Show("Welcome " + dr["Username"].ToString() + " ! ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CashierMainform main = new CashierMainform();
                    this.Hide();
                    main.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
