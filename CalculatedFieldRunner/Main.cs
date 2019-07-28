﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CalculatedField
{
    static class ProgramMain
    {
        static void Main(string[] args)
        {
            DateTime dt;
            TimeSpan ts;
            var type = typeof(TimeSpan);
            Engine engine = new Engine();
            var script = "";
            while(true)
            {
                var line = Console.ReadLine();
                if(line.EndsWith(";"))
                {
                    script = script + line.TrimEnd(';');
                    try
                    {
                        var value = engine.CalculateValue(script);
                        Console.WriteLine(value ?? "null");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    script = "";
                }
                else
                {
                    script = script + line + "\r\n";
                }
            }
        }

        public static string func(int x, string y)
        {
            return x.ToString() + y;
        }
    }
}
