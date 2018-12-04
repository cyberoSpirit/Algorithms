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
            /*Union_Find a = new Union_Find();
            a.FillInput();
            a.Printinput();
            a.SortByUnions();
            a.PrintUnions();

            var a2 = new Union_Find_Algorithm();
            a2.FillInput();
            a2.PrintInput();
            a2.PrintUnions();

            var a3 = new Quick_Union();
            a3.FillInput();
            a3.PrintInput();
            a3.PrintUnions();

            var a4 = new Quick_Union_Improved();
            a4.FillInput();
            a4.PrintInput();
            a4.PrintUnions();*/

            var percolation = new Percolation(10);
            /*percolation.Open(0, 0);
            percolation.Percolates();
            percolation.Open(0, 2);
            percolation.Percolates();
            percolation.PrintMatrix();
            percolation.Open(0, 4);
            percolation.Percolates();
            percolation.Open(1, 1);
            percolation.Percolates();
            percolation.Open(1, 2);
            percolation.Percolates();
            percolation.Open(1, 4);
            percolation.Percolates();
            percolation.PrintMatrix();
            percolation.Open(1, 5);
            percolation.Percolates();
            percolation.Open(2, 1);
            percolation.Percolates();
            percolation.Open(2, 2);
            percolation.Percolates();
            percolation.Open(3, 0);
            percolation.Percolates();
            percolation.PrintMatrix();
            percolation.Open(3, 2);
            percolation.Percolates();
            percolation.Open(3, 3);
            percolation.Percolates();
            percolation.Open(3, 4);
            percolation.Percolates();
            percolation.Open(4, 3);
            percolation.Percolates();
            percolation.Open(5, 2);
            percolation.Percolates();
            percolation.Open(5, 3);
            percolation.Percolates();
            percolation.PrintMatrix();*/
            Random rnd = new Random();
            int row;
            int col;
            bool a = true;
            for (int i = 0; i < 30;++i)
            {
                for (int j = 0; j < 30;++j)
                {
                    row = rnd.Next(0, 10);
                    col = rnd.Next(0, 10);
                    percolation.Open(row, col);
                    if(a && percolation.Percolates())
                    {
                        Console.WriteLine("Matrix percolates!!!");
                        percolation.PrintMatrix();
                        a = false;
                    }
                }
            }
            percolation.Percolates();
            percolation.PrintMatrix();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
