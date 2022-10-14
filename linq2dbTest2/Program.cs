using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq2dbTest2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始");
            using (TestBaseDB db = new TestBaseDB()) {
                List<UserInfo> res = db.UserInfos.ToList();
                if (res.Count > 0)
                {
                    Console.WriteLine("success");
                }
                foreach (UserInfo info in res) 
                { 
                    Console.WriteLine(info);
                }
            }
        }
    }
}
