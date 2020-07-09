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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            View();
        }

        string connectionString = ConfigurationManager.ConnectionStrings["QuanLyLinhKien"].ConnectionString.ToString();

        SqlConnection connection;

        public void View()
        {
            connection = new SqlConnection(connectionString);
            string queryString = "Select * From Products;";
            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                lv.SubItems.Add(reader.GetString(1).ToString());
                lv.SubItems.Add(reader.GetInt32(2).ToString());
                lv.SubItems.Add(reader.GetBoolean(3).ToString());

                listView1.Items.Add(lv);
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            foreach (ListViewItem x in listView1.Items)
            {
                if (x.SubItems[3].Text == "True")
                {
                    x.SubItems[3].Text = "Còn hàng";
                }
                else
                    x.SubItems[3].Text = "Hết hàng";
            }

        }

        public void SapXepTangDan()
        {
            connection = new SqlConnection(connectionString);
            string queryString = "SELECT * FROM Products ORDER BY Gia ASC; ";
            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                lv.SubItems.Add(reader.GetString(1).ToString());
                lv.SubItems.Add(reader.GetInt32(2).ToString());
                lv.SubItems.Add(reader.GetBoolean(3).ToString());

                listView1.Items.Add(lv);
            }

            reader.Close();
            command.Dispose();
            connection.Close();
        }

        public void SapXepGiamDan()
        {
            connection = new SqlConnection(connectionString);
            string queryString = "SELECT * FROM Products ORDER BY Gia DESC; ";
            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                lv.SubItems.Add(reader.GetString(1).ToString());
                lv.SubItems.Add(reader.GetInt32(2).ToString());
                lv.SubItems.Add(reader.GetBoolean(3).ToString());

                listView1.Items.Add(lv);
            }

            reader.Close();
            command.Dispose();
            connection.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string MSLK = txtMSLK.Text;
            connection = new SqlConnection(connectionString);
            string queryString = "select * from Products where MSLK='" + MSLK + "';";
            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            listView1.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                lv.SubItems.Add(reader.GetString(1).ToString());
                lv.SubItems.Add(reader.GetInt32(2).ToString());
                lv.SubItems.Add(reader.GetBoolean(3).ToString());

                listView1.Items.Add(lv);
            }
            
            if (MSLK == "")
            {
                View();
            }
        }

        private void txtMSLK_KeyUp(object sender, KeyEventArgs e)
        {
            string MSLK = txtMSLK.Text;

            if (MSLK.Length == 0)
            {
                View();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem x in listView1.Items)
            {
                if (x.Text == txtMSLK.Text)
                {
                    DataProvider data = new DataProvider();
                    data.XoaSanPham(txtMSLK.Text);
                    MessageBox.Show("Bạn Đã Xóa Thành Công");
                    View();
                    txtMSLK.Text = "";
                    return;
                }

            }
            MessageBox.Show("Không Tìm Thấy Sản Phẩm Cần Xóa");
            txtMSLK.SelectAll();
            txtMSLK.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var flag = false;
            foreach (ListViewItem x in listView1.Items)
            {
                if (x.Text == txtMSLK.Text)
                {
                    flag = true;
                    this.Hide();
                    Update formUpDate = new Update(txtMSLK.Text);
                    formUpDate.ShowDialog();
                }
            }
            if (flag == false)
            {
                MessageBox.Show("Không Tìm Thấy Sản Phẩm Cần Sửa");
                txtMSLK.SelectAll();
                txtMSLK.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (rbtnTangDan.Checked)
            {
                SapXepTangDan();
            }
            else
            {
                SapXepGiamDan();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowBill showBill = new ShowBill();
            showBill.ShowDialog();
        }
    }
}
