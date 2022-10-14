

namespace linq2dbTest02 {
    public class Program {
        public static void Main(string[] args) 
        {
            using (TestBaseDB db = new TestBaseDB("server=.;database=TestBase;uid=sa;pwd=root"))
            {
                List<UserInfo> res = db.UserInfos.ToList();
                foreach (UserInfo userInfo in res)
                { 
                    Console.WriteLine(userInfo);
                }
            }
        }
    
    }
}
