/*
    You are given two integer arrays nums1 and nums2, sorted in non-decreasing order,
    and two integers m and n, representing the number of elements in nums1 and nums2
    respectively.

    Merge nums1 and nums2 into a single array sorted in non-decreasing order.

    The final sorted array should not be returned by the function, but instead be stored
    inside the array nums1. To accomodate this, nums1 has a length of m + n, where the first
    m elements denote the elements that should be merged and the last n elements are set to 0
    and should be ignored. nums2 has a length of n.

    https://leetcode.com/problems/merge-sorted-array/
*/

using System;

namespace Merge_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = {0};
            int[] nums2 = {1};
            int m = 0;
            int n = 1;

            PrintArray(nums1);
            PrintArray(nums2);
            Merge(nums1, m, nums2, n);
            Console.Write("Merged: ");
            PrintArray(nums1);

        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n) {

            if (n == 0) return;
            if (m == 0)
            {
                // nums1 = nums2;
                Array.Copy(nums2, nums1, n);
                return;
            }

            int index1 = m - 1;
            int index2 = n - 1;
            int insertIndex = (m + n) - 1;

            while (index2 >= 0)
            {
                if (index1 < 0 || nums2[index2] >= nums1[index1])
                {
                    nums1[insertIndex] = nums2[index2];
                    --insertIndex;
                    --index2;
                }

                else
                {
                    nums1[insertIndex] = nums1[index1];
                    --insertIndex;
                    --index1;
                }
            }
        }

        public static void PrintArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                int next = arr[i];
                Console.Write($"{next}, ");
            }
            Console.Write(arr[arr.Length - 1]);
            Console.Write("]\n");
        }
    }
}
