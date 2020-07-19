using System;

namespace RomanNumbers
{
    public class RomanToIntMap : IRomanToIntCalculator
    {
        static readonly RomanMap map = new RomanMap();
        
        public int RomanToInt(string s)
        {
            var span = s.AsSpan();
            int previousValue = 0;
            int result = 0;

            for (int i = 0; i < span.Length; i++)
            {
                var value = map.Get(span[i]);

                if (value > previousValue)
                {
                    result += value - previousValue * 2;
                }
                else
                {
                    result += value;
                }

                previousValue = value;
            }

            return result;
        }
    }

    class RomanMap
    {
        // var digits = new List<(string, int)>() {
        //     ( "M", 1000 ),
        //     ( "D", 500 ),
        //     ( "C", 100 ),
        //     ( "L", 50 ),
        //     ( "X", 10 ),
        //     ( "V", 5 ),
        //     ( "I", 1 ),
        // };

        // character % 17
        // M => 77, 9
        // D => 68, 0
        // C => 67, 16
        // L => 76, 8
        // X => 88, 3
        // V => 86, 1
        // I => 73, 5

        private const int modus = 17;

        private readonly int[] buckets = new int[modus];

        public RomanMap()
        {
            buckets['M' % modus] = 1000;
            buckets['D' % modus] = 500;
            buckets['C' % modus] = 100;
            buckets['L' % modus] = 50;
            buckets['X' % modus] = 10;
            buckets['V' % modus] = 5;
            buckets['I' % modus] = 1;
        }

        public int Get(char character)
        {
            return buckets[character % modus];
        }
    }
}
