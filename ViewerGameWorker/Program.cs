using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;


namespace ViewerGameWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try 
            {
                CreateHostBuilder(args).Build().Run(); 
            }
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
