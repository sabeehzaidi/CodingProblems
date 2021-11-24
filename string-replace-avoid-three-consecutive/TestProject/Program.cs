using System;
using System.Text;
using System.Collections.Generic;

//Question:
//Given a string, replace all “?” in it to create a final string with no 3 consecutive letters.
//e.g. given a?bb, return aabb. Given ??aa return abaa or bbaa.
//Multiple solutions can exist. Return any one.

namespace TestProject
{
    class MainClass
    {
        static Dictionary<string, string> memo = new Dictionary<string, string>();

        public static void Main(string[] args)
        {
            string input = "aa?b";

            Console.WriteLine(Solution(input, memo));
        }

        public static string Solution(string input, Dictionary<string, string> memo)
        {
            return ReplaceCharRecursive(input, memo);
        }

        public static string ReplaceCharRecursive(string input, Dictionary<string, string> memo)
        {
            if (memo.ContainsKey(input))
                return memo[input];

            if (!input.Contains("?"))
            {
                return input;
            }

            if (isValidString(ReplaceChar(input, '?', 'a')))
            {
                memo[input] = ReplaceCharRecursive(ReplaceChar(input, '?', 'a'), memo);
            }

            else if (isValidString(ReplaceChar(input, '?', 'b')))
            {
                memo[input] = ReplaceCharRecursive(ReplaceChar(input, '?', 'b'), memo);
            }

            return memo[input];
        }

        public static bool isValidString(string input)
        {
            return (!input.Contains("aaa") && !input.Contains("bbb"));
        }

        public static string ReplaceChar(string s, char toReplace, char replaceWith)
        {
            return s.Remove(s.IndexOf(toReplace)) + replaceWith + s.Substring(s.IndexOf(toReplace) + 1);
        }
    }
}
