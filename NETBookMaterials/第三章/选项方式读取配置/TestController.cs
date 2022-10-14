using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 配置系统的基本使用;

namespace 选项方式读取配置
{
    internal class TestController
    {
        public IOptionsSnapshot<Config> optConfig;

        //控制注入 用IOptionsSnapshot
        public TestController(IOptionsSnapshot<Config> optConfig)
        {
            this.optConfig = optConfig;
        }

        public  void testc() {
            Console.WriteLine(optConfig.Value.Age);
            Console.WriteLine("#######################");
        }
    }
}
