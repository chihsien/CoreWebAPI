using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TodoApi.DapperUnitOfWork;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>{
                    var env = hostContext.HostingEnvironment;
                    config.SetBasePath(Path.Combine(env.ContentRootPath, ""))                      
                    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);
                })
                .UseStartup<Startup>()
                .Build();
    }
}
