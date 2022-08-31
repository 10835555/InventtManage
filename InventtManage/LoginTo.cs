using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventtManage
{
    public partial class LoginTo : Form
    {
        public LoginTo()
        {
            InitializeComponent();
        }

        private void LoginTo_Load(object sender, EventArgs e)
        {

        }

        private void ACAB_Click(object sender, EventArgs e)
        {
            var myForm = new AdminSignIn();
            myForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new UserSignIn();
            myForm.Show();
        }

        private void ACAB_Click_1(object sender, EventArgs e)
        {
            var myForm = new AdminCreateAccount();
            myForm.Show();
        }
    }
}
