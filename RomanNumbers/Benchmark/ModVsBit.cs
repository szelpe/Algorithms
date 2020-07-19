using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmark
{
    public class ModVsBit
    {
        private const int N = 1000;
        List<char> data;

        List<(char, int)> digits = new List<(char, int)>() {
             ( 'M', 1000 ),
             ( 'D', 500 ),
             ( 'C', 100 ),
             ( 'L', 50 ),
             ( 'X', 10 ),
             ( 'V', 5 ),
             ( 'I', 1 ),
         };

        public ModVsBit()
        {
            data = new List<char>();
            var random = new Random();
            data.AddRange(
                Enumerable.Range(0, N).Select(i => digits[random.Next(digits.Count)].Item1)
            );
        }

        [Benchmark]
        public void Mod()
        {
            foreach (var item in data)
            {
                var result = item % 17;
            }
        }

        [Benchmark]
        public void Bit()
        {
            foreach (var item in data)
            {
                var result = item & 63;
            }
        }
    }
}
