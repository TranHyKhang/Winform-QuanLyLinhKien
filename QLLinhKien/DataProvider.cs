using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLinhKien
{
    class DataProvider
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["QuanLyLinhKien"].ConnectionString.ToString();

        SqlConnection connection;

        public int flag = 0;


        public void ThemSanPham(string MSLK, string TenLinhKien, int Gia, bool TinhTrang)
        {
            connection = new SqlConnection(connectionString);
            string queryString = "INSERT INTO Products (MSLK, TenLK, Gia, TinhTrang)" + "VALUES (@MSLK, @TenLinhKien, @Gia, @TinhTrang);";

            string mslk = MSLK;
            string tenLinhKien = TenLinhKien;
            int gia = Gia;
            bool tinhTrang = TinhTrang;

            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@MSLK", mslk);
            command.Parameters.AddWithValue("@TenLinhKien", tenLinhKien);
            command.Parameters.AddWithValue("@Gia", gia);
            command.Parameters.AddWithValue("@TinhTrang", tinhTrang);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }

        public void ThemDonHang(string MSHD, string MSLK, int SoLuong)
        {
            connection = new SqlConnection(connectionString);
            string queryString = "INSERT INTO HDChiTietDatHang (MSHD, MSLK, SoLuong)" + "VALUES (@MSHD, @MSLK, @SoLuong);";

            string mshd = MSHD;
            string mslk = MSLK;
            int soLuong = SoLuong;
       

            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@MSHD", mshd);
            command.Parameters.AddWithValue("@MSLK", mslk);
            command.Parameters.AddWithValue("@SoLuong", soLuong);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }

        public void XoaSanPham(string MSLK)
        {
            connection = new SqlConnection(connectionString);
            string queryString = "DELETE FROM Products WHERE MSLK=@MSLK";

            string mslk = MSLK;

            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@MSLK", mslk);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }

        public void SuaSanPham(string MSLK, string TenLinhKien, int Gia, bool TinhTrang)
        {
            connection = new SqlConnection(connectionString);
            string queryString = "UPDATE Products SET TenLK = @TenLinhKien, Gia = @Gia, TinhTrang = @TinhTrang WHERE MSLK=@MSLK";

            string mslk = MSLK;
            string tenLinhKien = TenLinhKien;
            int gia = Gia;
            bool tinhTrang = TinhTrang;


            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@MSLK", mslk);
            command.Parameters.AddWithValue("@TenLinhKien", tenLinhKien);
            command.Parameters.AddWithValue("@Gia", gia);
            command.Parameters.AddWithValue("@TinhTrang", tinhTrang);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
        }
    }
}
