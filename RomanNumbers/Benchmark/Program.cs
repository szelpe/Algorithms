using BenchmarkDotNet.Running;
using RomanNumbers;
using System;
using System.Collections.Generic;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //   List<(char, int)> digits = new List<(char, int)>() {
            //    ( 'M', 1000 ),
            //    ( 'D', 500 ),
            //    ( 'C', 100 ),
            //    ( 'L', 50 ),
            //    ( 'X', 10 ),
            //    ( 'V', 5 ),
            //    ( 'I', 1 ),
            //};

            //   digits.ForEach(d => Console.WriteLine($"{d} => {d.Item1 & 63}"));

            sbyte[] brackets = new sbyte[125];

            brackets['('] = (sbyte)')';
            brackets['{'] = (sbyte)'}';
            brackets['['] = (sbyte)']';

            brackets[')'] = -1;
            brackets['}'] = -1;
            brackets[']'] = -1;

            List<(char, int)> digits = new List<(char, int)>() {
                ( '{', 1000 ),
                ( '[', 500 ),
                ( '(', 100 ),
                ( '}', 50 ),
                ( ']', 10 ),
                ( ')', 5 ),
            };

            digits.ForEach(d => Console.WriteLine($"{d.Item1} => {(byte)d.Item1} => {d.Item1 % 7}"));

            // BenchmarkRunner.Run<SwtichVsMap>();
        }
    }
}
