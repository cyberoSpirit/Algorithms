using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            a4.PrintUnions();
            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
                                                        //your sample code

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            */

            int[] arr = new int[] { 0, 1, 2, 3, 5, 6, 8, 9, 15, 17, 24, 27, 28, 29, 31, 37, 39, 40 };
            int element = 38;
            int number = BinarySearch.Search(arr, element);
            if (number == -1)
            {
                Console.WriteLine($"Element {element} not found");
            }
            else
            {
                Console.WriteLine($"Element {element} is in position {number}");
            }

            int number2 = TwoStackDijkstraAlgorithm.CalculateExp("(1+((2+3)*(4*5)))");
            Console.WriteLine($"Element {number2}"); 
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
