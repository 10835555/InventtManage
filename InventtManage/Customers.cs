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
using System.Xml.Linq;

namespace InventtManage
{
    public partial class Customers : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you really want to add this new customer?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO CustomerTable(CustomerName,CustomerTelephone)VALUES(@CustomerName, @CustomerTelephone)", Con);
                    cm.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cm.Parameters.AddWithValue("@CustomerTelephone", txtCustomerTelephone.Text);
                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("You have successfully added a new customer.");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtCustomerName.Clear();
            txtCustomerTelephone.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Clear();
            SaveButton.Enabled = true;
            UpdateButton.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            { 
                if (MessageBox.Show("Do you really want to update this customer record?", "Record is being Updated", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE CustomerTable SET CustomerName=@CustomerName, CustomerTelephone=@CustomerTelephone WHERE CustomerID LIKE '" + CustID.Text + "' ", Con);
                    cm.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cm.Parameters.AddWithValue("@CustomerTelephone", txtCustomerTelephone.Text);
                    Con.Open();
                    cm.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("You have successfully updated the user record");
                    this.Dispose();
                }
              }
              catch (Exception ex)
              {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
