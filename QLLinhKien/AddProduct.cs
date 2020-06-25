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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mslk = txtMSLK.Text;
            string tenLK = txtTenLK.Text;
            int gia = int.Parse(txtGia.Text);
            bool tinhTrang = rbtnConHang.Checked ? true : false;

            DataProvider data = new DataProvider();
            data.ThemSanPham(mslk, tenLK, gia, tinhTrang);

            MessageBox.Show("Bạn Đã Thêm Thành Công", "Thông Báo!");

            
            Clear();
        }

        public void Clear()
        {
            txtMSLK.Text = "";    
            txtTenLK.Text = "";
            txtGia.Text = "";
            rbtnConHang.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products product = new Products();
            product.ShowDialog();
            product.View();
        }
    }
}
