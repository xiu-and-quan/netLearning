using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (TestBaseDB db = new TestBaseDB()) {
                List<UserInfo> res = db.UserInfos.ToList();
                foreach (UserInfo info in res) 
                { 
                    Console.WriteLine(info);
                }
            }
        }
    }
}
