using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 配置系统的基本使用
{
    internal class Config
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Proxy Proxy { get; set; }
    }
    class Proxy 
    { 
        public string Address { get; set; }
        public int Port { get; set; }
    }
}
