using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Guna.UI2.WinForms;

namespace HotelManagementProgram.Users
{
    public partial class Users_Customers : UserControl
    {
        function fn = new function();
        string query;
        int roomId;

        public Users_Customers()
        {
            InitializeComponent();
        }

        public void setComboBox(String query, ComboBox combobox)
        {
            SqlDataReader sdr = fn.getForComboBox(query);
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combobox.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }


        private void txtRType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBedType.SelectedIndex = -1;
            cbRoomNo.Items.Clear();
            txtPrice.Clear();
        }

        private void txtBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRoomNo.Items.Clear();
            query = "select roomNo from rooms where bed = '" + cbBedType.Text + "' and roomType = '" + cbRoomType.Text + "'";
            setComboBox(query, cbRoomNo);
        }

        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price, roomid from rooms where roomNo = '" + cbRoomNo.Text + "'";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            roomId = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        public void clearAll()
        {
            cbRoomNo.Items.Clear();
            foreach (Control control in gbInfo.Controls)
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
            foreach (Control control in gbInfo.Controls)
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

                if (control is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = (DateTimePicker)control;
                    if (!dateTimePicker.Checked)
                    {
                        isInformationFilled = false;
                        MessageBox.Show("Please fill all the information!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }

            if (isInformationFilled)
            {
                string name = txtName.Text;
                string gender = cbGender.Text;
                int mobile;
                try
                {
                    mobile = int.Parse(txtMobileNum.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid character for contact number!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMobileNum.Focus();
                    return;

                }

                string idCard = txtIDCard.Text;
                string nation = txtNation.Text;
                string dob = txtDOB.Text;
                string checkinDate = txtCheckin.Text;
                string address = txtAddress.Text;

                query = "insert into customer (cname, mobile, nationality, gender, dob, idproof, address, checkin, roomid) " +
                    "values ('" + name + "'," + mobile + ", '" + nation + "', '" + gender + "','" + dob + "','" + idCard + "','" + address + "','" + checkinDate + "'," + roomId + ") ";

                fn.setData(query, "Successful customer booking!");
                clearAll();
            }

        }
    }
}
