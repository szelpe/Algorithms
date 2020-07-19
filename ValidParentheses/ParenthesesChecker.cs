using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidParentheses
{
    public class ParenthesesChecker
    {
        private sbyte[] brackets = new sbyte[126];

        public ParenthesesChecker()
        {
            brackets['('] = (sbyte)')';
            brackets['{'] = (sbyte)'}';
            brackets['['] = (sbyte)']';

            brackets[')'] = -1;
            brackets['}'] = -1;
            brackets[']'] = -1;
        }

        public bool IsValid(string s)
        {
            var openBrackets = new Stack<char>();

            for (var i = 0; i < s.Length; i++)
            {
                if (brackets[s[i]] > 0)
                {
                    openBrackets.Push(s[i]);
                }
                else if (brackets[s[i]] < 0)
                {
                    if(!openBrackets.TryPop(out var lastOpenBracket))
                    {
                        return false;
                    }

                    if (s[i] != brackets[lastOpenBracket])
                    {
                        return false;
                    }
                }
            }

            return !openBrackets.Any();
        }
    }
}
