using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BlogCodeExamples;

namespace BlogBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting benchmark of Tanh");

            Random rand = new Random();
            double[] randValues = new double[100000];
            for (int i = 0; i < randValues.Length; i++)
            {
                randValues[i] = rand.NextDouble();
            }
            double temp = 0;
            var sw = new Stopwatch();
            sw.Start();
            foreach (double t in randValues)
            {
                temp += Math.Tanh(t);
            }
            sw.Stop();
            Console.WriteLine("Math.Tanh: {0} ticks per Calc",sw.ElapsedTicks);
            
            sw.Restart();
            foreach (double t in randValues)
            {
                temp += MathFunctions.Tanh2(t);
            }
            sw.Stop();
            Console.WriteLine("MathFunctions.Tanh2: {0} ticks per Calc", sw.ElapsedTicks);

            sw.Restart();
            foreach (double t in randValues)
            {
                temp += MathFunctions.Tanh1(t);
            }
            sw.Stop();
            Console.WriteLine("MathFunctions.Tanh1: {0} ticks per Calc", sw.ElapsedTicks);
            
        }
    }
}
