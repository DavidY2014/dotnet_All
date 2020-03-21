using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net
{
    class Program
    {
        static void Main(string[] args)
        {
            //连接数据库的三种方式
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = "";

            //SqlConnectionStringBuilder sbr = new SqlConnectionStringBuilder();
            //sbr.DataSource = "";

            //string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Max pool Size =5";
            for (int i=0;i<10;i++)
            {
                conn.Open();
                Console.WriteLine($"第{i}个连接");
            }
            sw1.Stop();
            Console.WriteLine($"耗时为{sw1.ElapsedMilliseconds} ms");
        }
    }
}
