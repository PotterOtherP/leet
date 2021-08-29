/*
    Given an integer array nums, find the contiguous subarray (containing at least one number)
    which has the largest sum and return its sum.

    https://leetcode.com/problems/maximum-subarray/
*/

using System;

namespace Maximum_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = {-2, 1, -3, 4, -1, 2, 1, -5, 4};
            int[] test2 = {1};
            int[] test3 = {5, 4, -1, 7, 8};

            int result = MaxSubArray(test);

            Console.WriteLine($"Result for test1: {result}");

            result = MaxSubArray(test2);
            Console.WriteLine($"Result for test2: {result}");

            result = MaxSubArray(test3);
            Console.WriteLine($"Result for test3: {result}");
        }

        public static int MaxSubArray(int[] nums) {

            int maxSum = int.MinValue;
            int currentSum = 0;

            for (int i = 0; i < nums.Length; ++i)
            {
                currentSum += nums[i];

                maxSum = Math.Max(maxSum, currentSum);

                currentSum = Math.Max(0, currentSum);
            }

            return maxSum;
        }

    }
}
