using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLLinhKien
{
    public partial class Update : Form
    {
        private string mslk;
        public Update()
        {
            InitializeComponent();

           
        }
        public Update(string MSLK) : this()
        {
            this.mslk = MSLK;
            txtMSLK.Text = mslk;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string tenSanPham = txtTenLK.Text;
            int gia = int.Parse(txtGia.Text);
            bool tinhTrang = rbtnConHang.Checked ? true : false;

            DataProvider data = new DataProvider();
            data.SuaSanPham(mslk, tenSanPham, gia, tinhTrang);
            //MessageBox.Show("Bạn Đã Nhập Sai MSHH", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("Bạn Sửa Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Products proDuct = new Products();
            proDuct.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products proDuct = new Products();
            proDuct.ShowDialog();
        }
    }
}
