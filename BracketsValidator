using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strData = new List<string>()
            {
                "()",
                "()[]{}",
                "()[()]{}",
                "]()",
                "({[})]",
                "({[)",
                "(){}}{"
            };

            foreach (var VARIABLE in strData)
            {
                Console.WriteLine(validStringIncluding(VARIABLE));
            }
        }

        public static bool validStringIncluding(string s)
        {
            if (s == null || s.Length % 2 != 0)
            {
                return false;
            }

            var stack = new Stack<char>();
            foreach (var item in s)
            {
                if (!BracketsConstant.brackets.ContainsKey(item))
                {
                    stack.Push(item);
                }
                else
                {
                    var topStack = ' ';

                    if (stack.Count != 0)
                    {
                        topStack = stack.Pop();
                    }

                    if (topStack != BracketsConstant.brackets[item])
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        public static class BracketsConstant
        {
            public static Dictionary<char, char> brackets = new Dictionary<char, char>()
            {
                { ')', '('},
                { ']', '['},
                { '}', '{'}
            };
        }
    }
}
