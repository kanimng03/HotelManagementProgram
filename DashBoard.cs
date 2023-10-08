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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            users_AddRoom1.Visible = false;
            btnRoom.PerformClick();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            users_AddRoom1.Visible = true;
            users_AddRoom1.BringToFront();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            users_Customers1.Visible = true;
            users_Customers1.BringToFront();
        }
    }
}
