using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RomanNumbers;

namespace Benchmark
{
    public class SwtichVsMap
    {
        List<(string, int)> codes = new List<(string, int)>() {
            ( "M", 1000 ),
            ( "CM", 900 ),
            ( "D", 500 ),
            ( "CD", 400 ),
            ( "C", 100 ),
            ( "XC", 90 ),
            ( "L", 50 ),
            ( "XL", 40 ),
            ( "X", 10 ),
            ( "IX", 9 ),
            ( "V", 5 ),
            ( "IV", 4 ),
            ( "III", 3 ),
            ( "II", 2 ),
            ( "I", 1 ),
        };
        RomanToIntSwitch romanNumbersSwitch = new RomanToIntSwitch();
        RomanToIntMap romanNumbersMap = new RomanToIntMap();
        RomanToIntDictionary romanNumbersDictionary = new RomanToIntDictionary();

        List<string> romans = new List<string>();

        [Params(1000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            var examples = new[] {
                "I",
                "II",
                "V",
                "X",
                "XI",
                "IX",
                "LVIII",
                "MCMXCIV"
            };
            var random = new Random();

            romans.AddRange(
                Enumerable.Range(0, N).Select(i => examples[random.Next(examples.Length)])
            );
        }

        [Benchmark]
        public void Switch()
        {
            foreach (var roman in romans)
            {
                int result = romanNumbersSwitch.RomanToInt(roman);
            }
        }

        [Benchmark]
        public void Map()
        {
            foreach (var roman in romans)
            {
                int result = romanNumbersMap.RomanToInt(roman);
            }
        }

        [Benchmark]
        public void Dictionary()
        {
            foreach (var roman in romans)
            {
                int result = romanNumbersDictionary.RomanToInt(roman);
            }
        }
    }
}
