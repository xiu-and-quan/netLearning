using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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
            /*string constr = "server=.;database=TestBase;uid=sa;pwd=root;Max Pool Size=5；Pooling = true";
            for (int i = 0; i < 10; i++) 
            { 
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                Console.WriteLine($"第{i+1}个连接已经打开");
            }*/
            //获取配置文件中的connStr的值 就是数据库连接信息
            string constr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            try {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    //con.Open();
                    /*SqlCommand 这个对象可以让我们在数据库上做一下操作，比如说增、删、改、查。都可以使用SqlCommand 这个对象。

                    首先，要使用SqlCommand 对象的话，必须先声明它。

                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    其中strSQL 是我们定义好的SQL 语句，conn 是声明好的数据库链接。*/

                    //SqlCommand对数据库执行的一条sql语句或者存储过程
                    //SqlCommand对象，Ado.Net中执行数据库命令的一个对象


                    //Connection:SqlCommand对象使用的SqlConnection
                    //CommandText：获取或设置要执行的sql语句或存储过程名
                    //CommandType：CommandType.Text 说明执行的是sql语句
                    //CommandType。StoredProcedure 执行的是一个存储过程
                    //Paramerers:SqlCommand对象的命令参数集合，空集合
                    //Transaction；事务

                    //创建command对象
                    /*string sql = "select * from UserInfos";*/
                    //方式1
                    /*SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;                  
                    cmd.CommandText = sql;*/
                    //cmd.CommandType = CommandType.Text;没有必要
                    //cmd.CommandType = CommandType.StoredProcedure; 如果是存储过程必设置

                    //方式2
                    /*SqlCommand cmd = new SqlCommand(sql);
                    cmd.Connection = con;*/

                    //方式3
                    /*SqlCommand cmd = new SqlCommand(sql, con);*/

                    //方式4
                    /* SqlCommand cmd = con.CreateCommand();
                     cmd.CommandText = sql;*/
                    string uName = "quan";
                    int uPwd =123;
                    int uAge = 18;
                    int uDeptId = 2;
                    //拼接式sql 致命弱点 sql注入
                    string sql1 = "insert into UserInfos(UserName,UserPwd,Age,DeptId) values('"+uName+ "','"+uPwd+"','"+uAge+"','"+uDeptId+"')";
                    string sql2 = "delete from UserInfos where UserId=1";
                    string sql3 = "select count(1) from UserInfos";
                    string sql4 = "select * from UserInfos";
                    SqlCommand cmd = new SqlCommand(sql4, con);
                    //执行命令 执行Select查询操作,更新，删除操作 
                    con.Open();
                    //增删改
                    //int count = cmd.ExecuteNonQuery();
                    //查询 返回查询结果中的第一行第一列的值，忽略其他行或列 使用场合返回查询一个值
                    //object res = cmd.ExecuteScalar();
                    //xecuteReader用于实现只进只读的高效数据查询 返回的是一个对象 数据阅读器 SqlDataReader
                    //实时读取 用的是流 res读取需要保持数据库开启状态
                    //适合数据量小的情况
                    SqlDataReader  res= cmd.ExecuteReader();
                    //res.Read() 类似hasNext()方法
                    while (res.Read()) {
                        //读取里面的数据
                        int id = int.Parse(res["UserId"].ToString());
                        string name = res["UserName"].ToString();
                        int pwd = int.Parse(res["UserPwd"].ToString());
                        Console.WriteLine("id为" + id + "  姓名" + name + "密码" + pwd);
                    }
                    res.Close();
                    /*if (res != null)
                    {
                        Console.WriteLine("成功"+res);
                       *//* Console.WriteLine("用户删除信息成功！");*//*

                    }*/

                    //con.Close();
                   
                    

                }
            } catch (Exception ex) 
               { 
                Console.WriteLine(ex.Message);
            
               }
        }
        //封装.ExecuteReader方法
        private static void CreateCommand(string queryString,string connectionString)
        {
            try {
                using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(queryString, connection);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(String.Format("{0}", reader[0]));
                            }
                        }
                    }
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message);
            }
        }
    }
}
