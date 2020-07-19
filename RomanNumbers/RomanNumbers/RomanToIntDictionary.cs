using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumbers
{
    public class RomanToIntDictionary : IRomanToIntCalculator
    {
        private static Dictionary<char, int> map = new Dictionary<char, int>()
        {
            { 'M', 1000 },
            { 'D', 500 },
            { 'C', 100 },
            { 'L', 50 },
            { 'X', 10 },
            { 'V', 5 },
            { 'I', 1 }
        };

        public int RomanToInt(string s)
        {
            var span = s.AsSpan();
            int previousValue = 0;
            int result = 0;

            for (int i = 0; i < span.Length; i++)
            {
                var value = map[span[i]];

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
}
