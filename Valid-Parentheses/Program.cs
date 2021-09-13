/*

    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']',
    determine if the input string is valid.

    An input string is valid if:

    1) Open brackets must be closed by the same type of brackets.
    2) Open brackets must be closed in the correct order.


*/

using System;
using System.Collections.Generic;

namespace Valid_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "[({(())}[()])]";
            // string s2 = "()[]{}";
            // string s3 = "(]";
            // string s4 = "([)]";
            // string s5 = "{[]}";
            // string s6 = "((";

            bool result = IsValid(s1);

            Console.WriteLine($"{s1} \t{result}");
            // result = IsValid(s2);
            // Console.WriteLine($"{s2} \t{result}");
            // result = IsValid(s3);
            // Console.WriteLine($"{s3} \t{result}");
            // result = IsValid(s4);
            // Console.WriteLine($"{s4} \t{result}");
            // result = IsValid(s5);
            // Console.WriteLine($"{s5} \t{result}");
            // result = IsValid(s6);
            // Console.WriteLine($"{s6} \t{result}");
        }

        public static bool IsValid(string s) {

            if (s.Length % 2 == 1) return false;

            Stack<char> opens = new Stack<char>();

            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    opens.Push(s[i]);
                }

                else if (s[i] == ')')
                {
                    if (opens.Count == 0 || opens.Peek() != '(')
                        return false;

                    opens.Pop();
                }

                else if (s[i] == ']')
                {
                    if (opens.Peek() != '[')
                        return false;

                    opens.Pop();
                }

                else if (s[i] == '}')
                {
                    if (opens.Peek() != '{')
                        return false;

                    opens.Pop();
                }


            }

            if (opens.Count == 0) return true;

            return false;
        }
    }
}
