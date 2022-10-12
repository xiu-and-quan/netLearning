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
        //static void Main(string[] args)
        //{
        //    ////获取配置文件中的connStr的值 就是数据库连接信息
        //    //string constr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //    //try 
        //    //{
        //    //    //1、创建连接对象 推荐使用
        //    //    //插值语法
        //    //    SqlConnection sqlConnection = new SqlConnection(constr);
        //    //    Console.WriteLine($"Data Source:{sqlConnection.DataSource}");
        //    //    Console.WriteLine($"Database:{sqlConnection.Database}");
        //    //    //1、打开连接
        //    //    sqlConnection.Open();

        //    //    //增删改查
        //    //}
        //    //catch (Exception ex) 
        //    //{ 
        //    //    //打印异常
        //    //    Console.WriteLine(ex.Message);
        //    //}

        //    //using语句块 在using语句块中有效，出去就失效
        //    //使用using进行释放的对象必须继承IDisposable
        //    /* SqlConnection sqlConnection = null;
        //     using (sqlConnection = new SqlConnection(constr)) {
        //         sqlConnection.Open();
        //         Console.WriteLine($"State:{sqlConnection.State}");//open
        //     }
        //     Console.WriteLine($"在suing语句块之外的State:{sqlConnection.State}");//closed*/

        //    //连接池的使用
        //    //默认是使用连接池的 Pooling = false禁止启用连接池
        //    //如果conStr完全一样会公用一个连接池
        //    /*string constr = "server=.;database=TestBase;uid=sa;pwd=root;Max Pool Size=5；Pooling = true";
        //    for (int i = 0; i < 10; i++) 
        //    { 
        //        SqlConnection con = new SqlConnection(constr);
        //        con.Open();
        //        Console.WriteLine($"第{i+1}个连接已经打开");
        //    }*/
        //    //获取配置文件中的connStr的值 就是数据库连接信息
        //    string constr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //    try {
        //        using (SqlConnection con = new SqlConnection(constr))
        //        {
        //            //con.Open();
        //            /*SqlCommand 这个对象可以让我们在数据库上做一下操作，比如说增、删、改、查。都可以使用SqlCommand 这个对象。

        //            首先，要使用SqlCommand 对象的话，必须先声明它。

        //            SqlCommand cmd = new SqlCommand(strSQL, conn);
        //            其中strSQL 是我们定义好的SQL 语句，conn 是声明好的数据库链接。*/

        //            //SqlCommand对数据库执行的一条sql语句或者存储过程
        //            //SqlCommand对象，Ado.Net中执行数据库命令的一个对象
        //            //Connection:SqlCommand对象使用的SqlConnection
        //            //CommandText：获取或设置要执行的sql语句或存储过程名
        //            //CommandType：CommandType.Text 说明执行的是sql语句
        //            //CommandType。StoredProcedure 执行的是一个存储过程
        //            //Paramerers:SqlCommand对象的命令参数集合，空集合
        //            //Transaction；事务

        //            //创建command对象
        //            /*string sql = "select * from UserInfos";*/
        //            //方式1
        //            /*SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = con;                  
        //            cmd.CommandText = sql;*/
        //            //cmd.CommandType = CommandType.Text;没有必要
        //            //cmd.CommandType = CommandType.StoredProcedure; 如果是存储过程必设置

        //            //方式2
        //            /*SqlCommand cmd = new SqlCommand(sql);
        //            cmd.Connection = con;*/

        //            //方式3
        //            /*SqlCommand cmd = new SqlCommand(sql, con);*/

        //            //方式4
        //            /* SqlCommand cmd = con.CreateCommand();
        //             cmd.CommandText = sql;*/
        //            string uName = "quan";
        //            int uPwd =123;
        //            int uAge = 18;
        //            int uDeptId = 2;
        //            //拼接式sql 致命弱点 sql注入
        //            string sql1 = "insert into UserInfos(UserName,UserPwd,Age,DeptId) values('"+uName+ "','"+uPwd+"','"+uAge+"','"+uDeptId+"')";
        //            string sql2 = "delete from UserInfos where UserId=1";
        //            string sql3 = "select count(1) from UserInfos";
        //            string sql4 = "select * from UserInfos";
        //            SqlCommand cmd = new SqlCommand(sql4, con);
        //            //执行命令 执行Select查询操作,更新，删除操作 
        //            con.Open();
        //            //增删改
        //            //int count = cmd.ExecuteNonQuery();
        //            //查询 返回查询结果中的第一行第一列的值，忽略其他行或列 使用场合返回查询一个值
        //            //object res = cmd.ExecuteScalar();
        //            //xecuteReader用于实现只进只读的高效数据查询 返回的是一个对象 数据阅读器 SqlDataReader
        //            //实时读取 用的是流 res读取需要保持数据库开启状态
        //            //适合数据量小的情况
        //            SqlDataReader  res= cmd.ExecuteReader();//关闭res,并没有释放连接
        //            //cmd.ExecuteReader(CommandBehavior.CloseConnection); 将阅读器和连接connection关联，只要其中一个关闭就都关闭
        //            //res.Read() 类似hasNext()方法
        //            while (res.Read()) {
        //                //读取里面的数据
        //                int id = int.Parse(res["UserId"].ToString());
        //                string name = res["UserName"].ToString();
        //                int pwd = int.Parse(res["UserPwd"].ToString());
        //                Console.WriteLine("id为" + id + "  姓名" + name + "密码" + pwd);
        //            }
        //            res.Close();
        //            /*if (res != null)
        //            {
        //                Console.WriteLine("成功"+res);
        //               *//* Console.WriteLine("用户删除信息成功！");*//*

        //            }*/

        //            //con.Close();
        //        }
        //    } catch (Exception ex) 
        //       { 
        //        Console.WriteLine(ex.Message);

        //       }
        //}
        //1.SqlParameter表示SqlCommand的参数，也可以是他到DataSet列的映射
        //到目前为止，我只理解了前半句话，SqlParameter类型的数组作为SqlCommand的参数存在，
        //配合转义字符@，可以有效的防止' or 1=1--单引号而截断字符串，这一经典的注入语句，
        //有效提高拼接型sql命令的安全性。
        //static void Main(string[] args)
        //    {
        //    try {
        //        string conStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //        //创建连接
        //        using (SqlConnection sql = new SqlConnection(conStr))
        //        {
                  
                    
        //            string sqlS = "select * from UserInfos where UserName=@UserName";
        //            //参数化的sql使用
        //            SqlCommand sqlCommand = new SqlCommand(sqlS, sql);
        //            //学过C#的人都知道C# 中字符串常量可以以@ 开头声名，这样的优点是转义序列“不”被处理，按“原样”输出，即我们不需要对转义字符加上 \ （反斜扛），就可以轻松coding。如，

        //            //返回值类型为SqlParameter
        //            //sqlCommand.Parameters.Add(new SqlParameter("@UserName","@quan"));

        //            //添加单个参数 推荐使用 值参数不能加  @作为sql语句里的一个“标签”，声明此处需要插入一个参数,类似占位符
        //            //sqlCommand.Parameters.AddWithValue("@UserName", "quan");
        //            SqlParameter sqlParameter = new SqlParameter("@UserName", "quan");
        //            sqlCommand.Parameters.Add(sqlParameter);
        //            //设置输入输出参数
        //            /*
        //             输入参数：参数化sql语句或存储过程，默认使用参数是输入参数
        //            输出参数：程序中可以接收到的值
        //             */
        //            sqlParameter.Direction = ParameterDirection.Input;
        //            //开启连接
        //            sql.Open();
        //            object res = sqlCommand.ExecuteScalar();
        //            Console.WriteLine(res);

        //            //多个参数的情况 数组
        //            /*SqlParameter[] paras = {
        //                new SqlParameter("@UserName","@xiu"),
        //                new SqlParameter("@Age",18),
        //                new SqlParameter("@DeptId",1),
        //                new SqlParameter("@UserPwd",123),

        //            };
        //            sqlCommand.Parameters.AddRange(paras);*/
        //        }
        //    }
        //    catch (Exception e) { 
        //        Console.WriteLine(e.Message);
        //    }                
        //    /*//方式1 空参
        //    SqlParameter sqlParameter = new SqlParameter();
        //    sqlParameter.ParameterName = "@UserName";
        //    sqlParameter.SqlDbType = SqlDbType.VarChar;//数据类型
        //    sqlParameter.Value = "maLi";//参数值
        //    sqlParameter.Size = 20;

        //    //方式2 参数名和值
        //    SqlParameter sqlParameter2 = new SqlParameter("@Age",24);

        //    //方式3 参数名和类型
        //    SqlParameter sqlParameter3 = new SqlParameter("@DeptId",SqlDbType.Int);

        //    //方式4 多参数
        //    SqlParameter sqlParameter4 = new SqlParameter("@UserPwd",SqlDbType.Int,20);
        //    sqlParameter4.Value = 123;

        //    //方式5 参数名称 类型 大小 源列名（对应数据库里面的名字 相当于给添加映射关系DataTable中的列名）
        //    SqlParameter sqlParameter5 = new SqlParameter("@UserName",SqlDbType.VarChar,20,"UserName");

        //    //SqlCommand是拼接SQL字符串,存在sql注入*/


        //}

        //常用属性：Dbtype参数的数据类型
        //Direction 参数的类型 输入输出返回值
        //ParademterName 参数的名称
        //Size 最大大小 字节为单位
        //SqlValue 作为sql类型的参数的值
        //封装.ExecuteReader方法
        /*private static void CreateCommand(string queryString,string connectionString)
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
        }*/

        static void Main(string[] args) {
            //SqlDataReader 类 提供一种从 SQL Server 数据库中读取只进的行流的方式。单向 连接对象一直保持open，用完需要关闭
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            ReadOrderData(connStr);
        }

        private static void ReadOrderData(string connectionString)
        {
            string queryString =
                "SELECT * FROM UserInfos";

            using (SqlConnection connection =
                        new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();
                //没有读取到末尾就要关闭reader对象时，先调用cmd.cancel() 防止返回空数据;再调用read.close()
                //若要创建对象 SqlDataReader，必须调用 ExecuteReader 对象的方法 SqlCommand ，而不是直接使用构造函数
                /*
                 属性
                Connection	
                获取与 SqlConnection 关联的 SqlDataReader。

                Depth	
                获取一个值，用于指示当前行的嵌套深度。

                FieldCount	
                获取当前行中的列数。

                HasRows	
                获取一个值，该值指示 SqlDataReader 是否包含一行还是多行。

                IsClosed	
                检索一个布尔值，该值指示是否已关闭指定的 SqlDataReader 实例。

                Item[Int32]	
                在给定列序号的情况下，获取指定列的以本机格式表示的值。

                Item[String]	
                在给定列名称的情况下，获取指定列的以本机格式表示的值。

                RecordsAffected	
                获取执行 Transact-SQL 语句所更改、插入或删除的行数。

                VisibleFieldCount	
                获取 SqlDataReader 中未隐藏的字段的数目。
                 */
                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                }

                // Call Close when done reading.
                reader.Close();
            }
        }

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }
    }   
}
