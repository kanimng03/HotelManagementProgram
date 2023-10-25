using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProgram
{
    public partial class DashBoard : Form
    {
        DataSet dsUser;
        string role;
        public DashBoard(DataSet dataset)
        {
            InitializeComponent();
            dsUser = dataset;
            role = dsUser.Tables[0].Rows[0][0].ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            users_AddRoom1.Visible = false;
            user_payment1.Visible = false;
            users_Customers1.Visible = false;
            user_CusInf1.Visible = false;
            users_Employee1.Visible = false;
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

        private void btnPayment_Click(object sender, EventArgs e)
        {
            user_payment1.Visible = true;
            user_payment1.BringToFront();
        }

        private void btnCusInf_Click(object sender, EventArgs e)
        {
            if(role == "admin")
            {
                user_CusInf1.Visible = true;
                user_CusInf1.BringToFront();
            }
            else
            {
                MessageBox.Show("You do not have Permission to access this section!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (role == "admin")
            {
                users_Employee1.Visible = true;
                users_Employee1.BringToFront();
            }
            else
            {
                MessageBox.Show("You do not have Permission to access this section!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

    }
}
