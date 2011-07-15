using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogCodeExamples
{
    public class MathFunctions
    {
        //This version 3x faster than Math.Tanh
        public static double Tanh1(double x)
        {
            return 2.0 / (1.0 + Math.Exp(-2.0 * x)) - 1.0;
        }
        //This version is an estimate and is 10x faster than Math.Tanh
        public static double Tanh2(double x)
        {
            //This is based on Lambert continued fraction taken to 7 divisions and optimized
            var x2 = x * x;
            var ax = (((x2 + 378.0) * x2 + 17325.0) * x2 + 135135.0) * x;
            var bx = ((28.0 * x2 + 3150.0) * x2 + 62370.0) * x2 + 135135.0;
            return ax / bx;
        }
        public static double Scale(double x, double min, double max, double newMin, double newMax)
        {
            return ((x - min) / (max - min)) * (newMax - newMin) + newMin;
        }
        public static double Scale(double x, double min, double max)
        {
            return Scale(x, min, max, 0, 1);
        }
    }
}
