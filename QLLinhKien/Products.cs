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
        private string mslk;


        public Products()
        {
            InitializeComponent();
            View();
        }

        string connectionString = ConfigurationManager.ConnectionStrings["QuanLyLinhKien"].ConnectionString.ToString();

        SqlConnection connection;

        public string Mslk { get => mslk; set => mslk = txtMSLK.Text; }

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
             Mslk = txtMSLK.Text;

            foreach(ListViewItem x in listView1.Items)
            {
                if (x.Text == Mslk)
                {
                    DataProvider data = new DataProvider();
                    data.XoaSanPham(Mslk);
                    MessageBox.Show("Bạn Đã Xóa Thành Công");
                    View();
                    txtMSLK.Text = "";
                    return;
                }

            }
            MessageBox.Show("Không Tìm Thấy Sản Phẩm");
            txtMSLK.SelectAll();
            txtMSLK.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            Update formUpDate = new Update();

            formUpDate.ShowDialog();
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
