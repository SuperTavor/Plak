using System.IO;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using Plak.ArrayFormatManager;

namespace Plak
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Plak Interpreter Usage:\nplak.exe file-to-run.plk");
            }
            else
            {
                if (!File.Exists(args[0]))
                {

                    Console.WriteLine($"{args[0]} does not exist.");
                    Environment.Exit(1);
                }
                else if (Path.GetExtension(args[0]) != ".plk")
                {
                    Console.WriteLine($"{args[0]} is not a plak (.plk) file.");
                    Environment.Exit(1);
                }
                FileInfo input = new FileInfo(args[0]);
                toArrayMain.start(input);
                
            }

        }
    }
}


