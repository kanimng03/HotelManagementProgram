using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProgram.Users
{
    public partial class User_payment : UserControl
    {
        function fn = new function();
        string query;
        int id;
        public User_payment()
        {
            InitializeComponent();
        }

        private void User_payment_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout_payment = 'NO'";
            DataSet ds = fn.getData(query);
            dgvCheckout.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtName.Text + "%' and checkout_payment ='NO'";
            DataSet ds = fn.getData(query);
            dgvCheckout.DataSource = ds.Tables[0];
        }

        private void dgvCheckout_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCheckout.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(dgvCheckout.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtFullname.Text = dgvCheckout.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNumber.Text = dgvCheckout.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtRoomType.Text = dgvCheckout.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtRoomPrice.Text = dgvCheckout.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtCheckinDate.Text = dgvCheckout.Rows[e.RowIndex].Cells[8].Value.ToString();
            }

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text != "")
            {
                if (MessageBox.Show("Are You Sure To Checkout?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    string cdate = dtpCheckout.Text;
                    query = "update customer set checkout_payment = 'YES', checkout_date = '" + cdate + "' where cid = " + id + " ";
                    fn.setData(query, "Payment Success");
                    Bill bill = new Bill(txtFullname.Text, txtRoomNumber.Text, txtRoomPrice.Text, txtCheckinDate.Text, cdate);
                    bill.ShowDialog();
                    User_payment_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("There are no customers to checkout", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtFullname.Clear();
            txtRoomNumber.Clear();
            txtRoomType.Clear();
            txtRoomPrice.Clear();
            txtCheckinDate.Clear();
            dtpCheckout.ResetText();
        }

        private void User_payment_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
