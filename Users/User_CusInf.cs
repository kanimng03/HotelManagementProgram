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
    public partial class User_CusInf : UserControl
    {
        function fn = new function();
        String query;
        public User_CusInf()
        {
            InitializeComponent();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSearch.SelectedIndex == 0)
            {
                query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid";
                getRecord(query);
            }
            else if (cbSearch.SelectedIndex == 1)
            {
                query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout_payment ='NO'";
                getRecord(query);
            }
            else if (cbSearch.SelectedIndex == 2)
            {
                query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout_payment ='YES'";
                getRecord(query);
            }
        }
        private void getRecord(String query)
        {
            DataSet ds = fn.getData(query);
            dgvCusInf.DataSource = ds.Tables[0];
        }

        private void User_CusInf_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid";
            getRecord(query);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            query = "SELECT customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price FROM customer inner join rooms on customer.roomid = rooms.roomid " +
                "WHERE checkin >= '"+ dtpFrom.Value.ToString("yyyy/MM/dd") + "' and checkin <= '"+ dtpTo.Value.ToString("yyyy/MM/dd") +"' ";
            getRecord(query);
        }
    }
}
