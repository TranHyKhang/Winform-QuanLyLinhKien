using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLinhKien
{
    public partial class addNewBil : Form
    {
        public addNewBil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mslk = txtMSLK.Text;
            string mshd = txtMSHD.Text;
            int soLuong = int.Parse(txtSoLuong.Text);

            DataProvider data = new DataProvider();
            data.ThemDonHang(mshd, mslk, soLuong);

            MessageBox.Show("Bạn Đã Thêm Thành Công", "Thông Báo!");


            Clear();
        }

        public void Clear()
        {
            txtMSLK.Text = "";
            txtMSHD.Text = "";
            txtSoLuong.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowBill showBill = new ShowBill();
            showBill.ShowDialog();
        }
    }
}
