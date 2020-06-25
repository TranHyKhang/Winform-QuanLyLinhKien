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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["QuanLyLinhKien"].ConnectionString.ToString();

        SqlConnection connection;

        private void button1_Click(object sender, EventArgs e)
        {
            string txtName = txtUserName.Text;
            string txtPass = txtPassword.Text;

            connection = new SqlConnection(connectionString);
            string queryString = "select * from UserLogin where userAccount = '" + txtName + "' and userPassword = '" + txtPass +"'";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        MessageBox.Show("Đăng Nhập Thành Công", "Thông Báo!", MessageBoxButtons.OK);
                        this.Hide();
                        Products product = new Products();
                        product.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Đăng Nhập Thất Bại", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi ket noi");
                }

            }


        }
    }
}
