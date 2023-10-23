using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelManagementProgram.Users
{
    public partial class Users_Employee : UserControl
    {

        function fn = new function();
        string query;
        public Users_Employee()
        {
            InitializeComponent();
        }

        //public void getRole()
        //{
        //    query = "select role from employee";
        //    DataSet ds = fn.getData(query);

        //    if (ds.Tables[0].Rows[0][0].ToString() != "")
        //    {
        //        label8.Text = ds.Tables[0].Rows[0][0].ToString();
        //    }
        //}

        public void getEmployee()
        {
            query = "select * from employee";
            DataSet ds = fn.getData(query);
            dgvInfo.DataSource = ds.Tables[0];
        }

        private void Users_Employee_Load(object sender, EventArgs e)
        {
            getEmployee();
        }

        public void clearAll()
        {
            foreach (Control control in tabRegistration.Controls)
            {
                if (control is Guna2TextBox textBox)
                {
                    textBox.Clear();
                }

                if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }

                if (control is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)control;

                    dateTimePicker.ResetText();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isInformationFilled = true;
            foreach (Control control in tabRegistration.Controls)
            {
                if (control is Guna2TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        isInformationFilled = false;
                        MessageBox.Show("Please fill all the information!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

                if (control is ComboBox comboBox)
                {
                    if (comboBox.SelectedIndex == -1)
                    {
                        isInformationFilled = false;
                        MessageBox.Show("Please fill all the information!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

            }

            if (isInformationFilled)
            {
                string name = txtFullname.Text;
                string gender = cbGender.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string email = txtEmail.Text;
                int mobile;
                try
                {
                    mobile = int.Parse(txtMobile.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid character for contact number!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMobile.Focus();
                    return;

                }

                query = "insert into employee (ename, mobile, gender, email, username, password) " +
                    "values ('" + name + "'," + mobile + ", '" + gender + "', '" + email + "','" + username + "','" + password + "' )";

                fn.setData(query, "Create new employee successful!");
                clearAll();
                getEmployee();
            }
        }
    }
}
