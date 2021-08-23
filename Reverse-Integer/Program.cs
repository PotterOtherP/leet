/*
    Given a signed 32-bit integer x, return x with its digits reversed.
    If reversing x causes the value to go outside the signed 32-bit integer range
    [-2^31, 2^31 - 1], then return 0.

    Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

    https://leetcode.com/problems/reverse-integer/
*/

using System;
using System.Collections.Generic;

namespace Reverse_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Max Int32: " + Int32.MaxValue);
            Console.WriteLine("Min Int32: " + Int32.MinValue);

            int[] tests = {123, -123, 120, 0, 1534236469};

            foreach (int test in tests)
            {
                int res = Reverse(test);
                Console.WriteLine($"Input: {test} ... reversed: {res}");
            }

        }

        public static int Reverse(int x) {

            if (Math.Abs(x) < 10) return x;

            int result = 0;
            bool negative = (x < 0);
            int originalX = x;
            x = Math.Abs(x);

            List<int> digits = new List<int>();

            while (x > 0)
            {
                digits.Add(x % 10);
                x /= 10;
            }

            if (digits.Count == 10 && digits[0] > 2) return 0;

            for (int i = 0; i < digits.Count; ++i)
            {
                int next = digits[i] * PowerTen(digits.Count - 1 - i);
                result += next;
                if (result < 0) return 0;
            }

            if (negative) result *= -1;

            return result;
        }

        public static int PowerTen(int n) {

            if (n == 0) return 1;

            else return 10 * PowerTen(n - 1);
        }
    }
}
