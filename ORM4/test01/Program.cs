using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace test01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //这个就是数据库
            using (TestBaseEntities testBaseEntities = new TestBaseEntities()) {
                //.表 操作对应的数据表
                //TEntity entity 参数为 实体类
                UserInfos u = new UserInfos
                {
                    Age = 18,
                    DeptId = 1,
                    UserName = "chun",
                    UserPwd = 123
                };
                //需要两步才可以
                testBaseEntities.UserInfos.Add(u);
                int res= testBaseEntities.SaveChanges();
                if (res > 0) 
                {
                    Console.WriteLine("添加成功！");
                }
                
            }
        }
    }
}
