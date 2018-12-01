using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using T1_Union_Find.Engine;

namespace T1_Union_Find
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Union_Find a = new Union_Find();
            a.FillInput();
            a.Printinput();
            a.SortByUnions();
            a.PrintUnions();

            var a2 = new Union_Find_Algorithm();
            a2.FillInput();
            a2.PrintInput();
            a2.PrintUnions();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
