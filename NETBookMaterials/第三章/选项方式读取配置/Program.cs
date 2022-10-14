using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using 选项方式读取配置;
using 配置系统的基本使用;

/*ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
IConfigurationRoot config = configBuilder.Build();
ServiceCollection services = new ServiceCollection();
services.AddOptions()
	.Configure<DbSettings>(e=>config.GetSection("DB").Bind(e))
	.Configure<SmtpSettings>(e => config.GetSection("Smtp").Bind(e));
services.AddTransient<Demo>();
using (var sp = services.BuildServiceProvider())
{
	while (true)
	{
		using (var scope = sp.CreateScope())
		{
			var spScope = scope.ServiceProvider;
			var demo = spScope.GetRequiredService<Demo>();
			demo.Test();
		}
		Console.WriteLine("可以改配置啦");
		Console.ReadKey();
	}
}*/
ConfigurationBuilder configBuilder = new ConfigurationBuilder();
//configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: false);

//命令行参数传参
configBuilder.AddCommandLine(args);
IConfigurationRoot config = configBuilder.Build();
//创建一个容器
ServiceCollection services = new ServiceCollection();
//注册容器 注入到根节点
services.AddScoped<TestController>();
services.AddScoped<Test2>();

services.AddOptions()
	.Configure<Config>(e => config.Bind(e))
    //GetSection获取名称为proxy的对象实例
    .Configure<Proxy>(e => config.GetSection("proxy").Bind(e));
//BuildServiceProvider获取容器中的对象
using (var sp = services.BuildServiceProvider())
{
	//获取对象实例
	using (var scope = sp.CreateScope()) 
	{
        var c = sp.GetRequiredService<TestController>();
        c.testc();

        var c1 = sp.GetRequiredService<Test2>();
        c1.Test();
    }
}
