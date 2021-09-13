using System;

namespace Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "bb";

            string answer = LongestPalindrome(str);
            Console.WriteLine($"Answer: {answer}");
        }

        /*
         * Solution: iterate over every possible palindrome center
         */
        public static string LongestPalindrome(string s) {

            if (s.Length <= 1) return s;

            string longestPal = s.Substring(0,1);


            for (int i = 0; i < (s.Length * 2) - 3; ++i)
            {
                int l = i / 2;
                int r = l + 1;

                if (i % 2 == 1)
                {
                    l = (i / 2) + 1;
                    r = l;
                }

                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    if (s[l] == s[r] && s.Substring(l, r - l + 1).Length > longestPal.Length)
                    {
                        longestPal = s.Substring(l, r - l + 1);
                    }
                    
                    --l;
                    ++r;
                }
            }

            

            return longestPal;
        }

        /**
         * This method checks every substring in
         * reverse order of length. (Takes too long, O(n^3))
         */
        public static string LongestPalindromeBF(string s) {

            for (int i = 0; i < s.Length; ++i)
            {
                int subLength = s.Length - i;
                Console.WriteLine($"subLength is {subLength}");

                for (int j = 0; j <= s.Length - subLength; ++j)
                {
                    string subStr = s.Substring(j, subLength);
                    Console.WriteLine(subStr);
                    if (CheckPalindrome(subStr))
                        return subStr;
                }
            }


            return s;
        }


        // Helper method
        public static bool CheckPalindrome(string s) {

            if (s.Length <= 1) return true;

            for (int i = 0; i < s.Length / 2; ++i)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
