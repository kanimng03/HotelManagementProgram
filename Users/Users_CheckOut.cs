using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace HotelManagementProgram.Users
{
    public partial class Users_CheckOut : UserControl
    {
        function fn = new function();
        string query;
        public Users_CheckOut()
        {
            InitializeComponent();
        }

        private void Users_CheckOut_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";
            DataSet ds = fn.getData(query);
            dgvCheckOut.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtName.Text + "%' and chekout = 'NO'";
            DataSet ds = fn.getData(query);
            dgvCheckOut.DataSource = ds.Tables[0];
        }
        int id;
        private void dgvCheckOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCheckOut.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                id = int.Parse(dgvCheckOut.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCName.Text = dgvCheckOut.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = dgvCheckOut.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(txtCName.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc không ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string cdate = txtDate.Text;
                    query = "update customer set chekout = 'YES', checkout = '" + cdate + "' where cid = " + id + " update rooms set booked = 'NO' where roomNo ='" + txtRoom.Text + "'";
                    fn.setData(query, "Payment success");
                    Users_CheckOut_Load(this, null);
                    clearAll();
                } else
                {
                    MessageBox.Show("Không Có Khách Hàng Để Lựa Chọn", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void clearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoom.Clear();
            txtDate.ResetText();
        }

        private void Users_CheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
