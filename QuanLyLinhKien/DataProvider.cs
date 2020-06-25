using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyLinhKien
{
    class DataProvider
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["QuanLyLinhKien"].ConnectionString.ToString();
    }
}
