using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoNet2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////获取配置文件中的connStr的值 就是数据库连接信息
            //string constr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            //try 
            //{
            //    //1、创建连接对象 推荐使用
            //    //插值语法
            //    SqlConnection sqlConnection = new SqlConnection(constr);
            //    Console.WriteLine($"Data Source:{sqlConnection.DataSource}");
            //    Console.WriteLine($"Database:{sqlConnection.Database}");
            //    //1、打开连接
            //    sqlConnection.Open();

            //    //增删改查
            //}
            //catch (Exception ex) 
            //{ 
            //    //打印异常
            //    Console.WriteLine(ex.Message);
            //}

            //using语句块 在using语句块中有效，出去就失效
            //使用using进行释放的对象必须继承IDisposable
            /* SqlConnection sqlConnection = null;
             using (sqlConnection = new SqlConnection(constr)) {
                 sqlConnection.Open();
                 Console.WriteLine($"State:{sqlConnection.State}");//open
             }
             Console.WriteLine($"在suing语句块之外的State:{sqlConnection.State}");//closed*/

            //连接池的使用
            //默认是使用连接池的 Pooling = false禁止启用连接池
            //如果conStr完全一样会公用一个连接池
            string constr = "server=.;database=TestBase;uid=sa;pwd=root;Max Pool Size=5；Pooling = true";
            for (int i = 0; i < 10; i++) 
            { 
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                Console.WriteLine($"第{i+1}个连接已经打开");
            }

        }
    }
}
