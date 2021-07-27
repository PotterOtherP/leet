using System;
using System.Collections.Generic;

namespace Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = " ";

            int x = LengthOfLongestSubstring(input1);
        }

        public static int LengthOfLongestSubstring(string str) {

            Console.WriteLine($"Input: {str}");

            List<char> UsedCharacters = new List<char>();

            if (str == null || str.Length < 1)
            {
                return 0;
            }

            int max = 0;
            int count = 0;

            for (int i = 0; i < str.Length; ++i)
            {
                Console.Write($"{i}: ");

                if (!UsedCharacters.Contains(str[i]))
                {
                    ++count;
                    if (count > max) max = count;
                    UsedCharacters.Add(str[i]);
                    Console.WriteLine($"New character: {str[i]}");
                }
                else
                {
                    if (count > max) max = count;
                    i = str.Substring(0, i).LastIndexOf(str[i]);
                    count = 0;
                    UsedCharacters.Clear();
                    Console.WriteLine($"Found repeat '{str[i]}', max is {max}, returning to position {i}");
                }

            }

            Console.WriteLine($"Final answer: {max}");
            return max;
        }
    }
}
