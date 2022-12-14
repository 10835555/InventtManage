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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void customButtons5_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customButtons5_Click_1(object sender, EventArgs e)
        {
            openChildForm(new UserList());
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customButtons2_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerList());
        }

        private void customButtons3_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryList());
        }

        private void customButtons1_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductList());
        }

        private void customButtons4_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderList());
        }

        private void panelSub_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (MessageBox.Show("Do you really want to logout?", "Logging Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void customButtons6_Click(object sender, EventArgs e)
        {
            openChildForm(new AdminLists());
        }
    }
}
