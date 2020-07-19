using System;
using System.Collections.Generic;

namespace RomanNumbers
{
    public class RomanToIntSwitch : IRomanToIntCalculator
    {
        HashSet<int> dupes = new HashSet<int>() { 900, 400, 90, 40, 9, 4, 2 };

        public int RomanToInt(string s)
        {
            // var codes = new List<(string, int)>() {
            //     ( "M", 1000 ),
            //     ( "CM", 900 ),
            //     ( "D", 500 ),
            //     ( "CD", 400 ),
            //     ( "C", 100 ),
            //     ( "XC", 90 ),
            //     ( "L", 50 ),
            //     ( "XL", 40 ),
            //     ( "X", 10 ),
            //     ( "IX", 9 ),
            //     ( "V", 5 ),
            //     ( "IV", 4 ),
            //     ( "III", 3 ),
            //     ( "II", 2 ),
            //     ( "I", 1 ),
            // };

            int result = 0;

            s = s + "00";

            for (var i = 0; i < s.Length; i++)
            {
                int value = s[i] switch
                {
                    'M' => 1000,
                    'D' => 500,
                    'L' => 50,
                    'V' => 5,
                    'C' => s[i + 1] switch
                    {
                        'M' => 900,
                        'D' => 400,
                        _ => 100
                    },
                    'X' => s[i + 1] switch
                    {
                        'C' => 90,
                        'L' => 40,
                        _ => 10
                    },
                    'I' => s[i + 1] switch
                    {
                        'X' => 9,
                        'V' => 4,
                        'I' => s[i + 2] switch
                        {
                            'I' => 3,
                            _ => 2
                        },
                        _ => 1
                    },
                    _ => 0
                };

                if (dupes.Contains(value))
                {
                    i++;
                }
                else if (value == 3)
                {
                    i += 2;
                }

                result += value;
            }

            return result;
        }
    }
}
