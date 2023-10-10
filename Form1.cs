using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Login()
        {
            if (txtUser.Text == "KN" && txtPass.Text == "123")
            {
                lblError.Visible = false;
                DashBoard ds = new DashBoard();
                this.Hide();
                ds.Show();
            }
            else
            {
                lblError.Visible = true;
                txtPass.Clear();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
