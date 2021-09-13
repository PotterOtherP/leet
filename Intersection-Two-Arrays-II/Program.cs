/*
    Given two integer arrays nums1 and nums2, return an array of their intersection.
    Each element in the result must appear as many times as it shows in both arrays
    and you may return the result in any order.

    https://leetcode.com/problems/intersection-of-two-arrays-ii/

*/

using System;
using System.Collections.Generic;

namespace Intersection_Two_Arrays_II
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = {4, 7, 9, 6, 7};
            int[] nums2 = {5, 0, 0, 6, 1, 6, 2, 2, 4};

            int[] output = Intersect(nums1, nums2);

            PrintArray(output);
        }

        public static int[] Intersect(int[] nums1, int[] nums2) {

            if (nums1.Length <= nums2.Length)
            {
                return IntersectSmaller(nums1, nums2);
            }

            return IntersectSmaller(nums2, nums1);
        }

        public static int[] IntersectSmaller(int[] nums1, int[] nums2) {

            List<int> list1 = new List<int>(nums1);
            List<int> list2 = new List<int>(nums2);

            PrintArray(list1.ToArray());
            PrintArray(list2.ToArray());

            // list1.Sort();
            // list2.Sort();

            for (int i = 0; i < list1.Count; ++i)
            {
                int x = list1[i];
                if (list2.Contains(x))
                {
                    list2.Remove(x);
                }

                else
                {
                    list1.Remove(x);
                    --i;
                }
            }

            return list1.ToArray();
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
