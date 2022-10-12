using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        static void Main(string[] args)
        {
        }

        public void Add() {
            using (SqlConnection con = new SqlConnection(connStr)) 
            { 
                con.Open();
            }
        }
    }
}
