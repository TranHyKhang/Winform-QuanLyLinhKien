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
    public partial class ShowBill : Form
    {
        public ShowBill()
        {
            InitializeComponent();
            View();
        }

        string connectionString = ConfigurationManager.ConnectionStrings["QuanLyLinhKien"].ConnectionString.ToString();

        SqlConnection connection;

        public void View()
        {
            connection = new SqlConnection(connectionString);
            string queryString = "SELECT MSHD,Products.MSLK,TenLK,Products.Gia,SoLuong from HDChiTietDatHang, Products Where HDChiTietDatHang.MSLK = Products.MSLK";

            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                lv.SubItems.Add(reader.GetString(1).ToString());
                lv.SubItems.Add(reader.GetString(2).ToString());
                lv.SubItems.Add(reader.GetInt32(3).ToString());
                lv.SubItems.Add(reader.GetInt32(4).ToString());

                listView1.Items.Add(lv);
            }

            reader.Close();
            command.Dispose();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int tong = 0;
            foreach (ListViewItem x in listView1.Items)
            {
                int gia = Convert.ToInt32((x.SubItems[3].Text));
                int soLuong = Convert.ToInt32((x.SubItems[4].Text));
                tong += gia * soLuong;
            }
            

            label3.Text = tong.ToString() + " VNĐ";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            addNewBil newBill = new addNewBil();

            newBill.ShowDialog();
        }

        private void txtMSLK_KeyUp(object sender, KeyEventArgs e)
        {
            string MSLK = txtMSHD.Text;

            if (MSLK.Length == 0)
            {
                View();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MSHD = txtMSHD.Text;
            connection = new SqlConnection(connectionString);
            string queryString = "SELECT MSHD,Products.MSLK,TenLK,Products.Gia,SoLuong from HDChiTietDatHang, Products Where HDChiTietDatHang.MSLK = Products.MSLK and MSHD='" + MSHD + "';";

            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                lv.SubItems.Add(reader.GetString(1).ToString());
                lv.SubItems.Add(reader.GetString(2).ToString());
                lv.SubItems.Add(reader.GetInt32(3).ToString());
                lv.SubItems.Add(reader.GetInt32(4).ToString());

                listView1.Items.Add(lv);
            }

            if (MSHD == "")
            {
                View();
            }
        }
    }
}
