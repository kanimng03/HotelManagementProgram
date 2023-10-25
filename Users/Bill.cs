using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProgram.Users
{
    public partial class Bill : Form
    {
        string fullname; 
        string roomNo;
        string roomPrice;
        string checkinDate;
        string checkoutDate;
        public Bill(string txtFullname, string txtRoomNumber, string txtRoomPrice, string txtCheckinDate, string txtCheckoutDate)
        {
            InitializeComponent();
            fullname = txtFullname;
            roomNo = txtRoomNumber;
            roomPrice = txtRoomPrice;
            checkinDate = txtCheckinDate;
            checkoutDate = txtCheckoutDate;
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            lbFullname.Text = fullname;
            lbRoomNo.Text = roomNo;
            lbPrice.Text = roomPrice;
            lbCheckinDate.Text = checkinDate;
            lbCheckoutDate.Text = checkoutDate;
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode("Just a URL generate for payment!", QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            picQRCode.Image = code.GetGraphic(6);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
        }
    }
}
