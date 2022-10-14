using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 配置系统的基本使用;

namespace 选项方式读取配置
{
    internal class Test2
    {
        private readonly IOptionsSnapshot<Proxy> optProty;

        public Test2(IOptionsSnapshot<Proxy> optProty) 
        { 
            this.optProty = optProty;
        }

        public void Test() {
            Console.WriteLine(optProty.Value.Port);
        }
    }
}
