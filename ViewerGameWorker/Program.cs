using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;

namespace ViewerGameWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try { CreateHostBuilder(args).Build().Run(); }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ViewerGameSvc>();
                });

        


    }
}
