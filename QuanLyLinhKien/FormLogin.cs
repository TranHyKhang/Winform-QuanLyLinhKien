using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace QuanLyLinhKien
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["QLQuan"].ConnectionString.ToString();

        SqlConnection connection;


        private void button1_Click(object sender, EventArgs e)
        {
            string txtName = txtUserName.Text;
            string txtPass = txtPassword.Text;

            connection = new SqlConnection(connectionString);
            string queryString = "select * from UserLogin where userAccount = " + txtName + "and userPassword = " + txtPass;

            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read() == true)
            {
                MessageBox.Show("Dang nhap thanh cong");
            }
            else
            {
                MessageBox.Show("Dang nhap that bai");
            }
        }
    }
}
