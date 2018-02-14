using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace CommandLineParserTimings
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var file = File.CreateText("timings.csv"))
            {
                file.WriteLine("Args", "Ms");

                for (var i = 1; i <= 10; i++)
                {
                    var testArgs = Enumerable.Range(0, i).Select(index => $"--arg{index}=blah").ToArray();
                    var milliseconds = TestParse(testArgs);
                    file.WriteLine($"{i},{milliseconds}");
                }
            }
               
            Console.ReadKey();
        }

        private static long TestParse(string[] args)
        {
            var parser = new Parser(config => config.IgnoreUnknownArguments = true);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = parser.ParseArguments<Options>(args) as Parsed<Options>;

            stopwatch.Stop();
            Console.WriteLine($"Parsing {args.Length} args took {stopwatch.ElapsedMilliseconds}ms.");

            return stopwatch.ElapsedMilliseconds;
        }

        public class Options
        {
            [Option]
            public string arg0 { get; set; }

            [Option]
            public string arg1 { get; set; }

            [Option]
            public string arg2 { get; set; }

            [Option]
            public string arg3 { get; set; }

            [Option]
            public string arg4 { get; set; }

            [Option]
            public string arg5 { get; set; }

            [Option]
            public string arg6 { get; set; }

            [Option]
            public string arg7 { get; set; }

            [Option]
            public string arg8 { get; set; }

            [Option]
            public string arg9 { get; set; }
        }
    }
}
