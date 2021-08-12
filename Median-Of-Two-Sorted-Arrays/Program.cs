using System;

namespace Median_Of_Two_Sorted_Arrays
{
    class Program
    {
        static void Main(string[] args) {

            int[] nums1 = {1, 2, 3, 7, 11, 16, 25, 34, 61, 88};
            int[] nums2 = {3, 4, 5, 22, 41, 55, 112};

            Console.Write($"nums1: ");
            PrintArray(nums1);

            Console.Write($"nums2: ");
            PrintArray(nums2);


            int[] merged = MergeArrays(nums1, nums2);
            double median = MedianOfSingleArray(merged);
            Console.Write($"Merged array: ");
            PrintArray(merged);
            Console.WriteLine($"Median of merged array by brute force: {median}");

            double median2 = 0.0;

            if (nums1.Length >= nums2.Length)
            {
                median2 = FindMedianSortedArrays(nums1, nums2);
            }

            else
            {
                median2 = FindMedianSortedArrays(nums2, nums1);
            }

            Console.WriteLine($"Median of merged array by algorithm: {median2}");

            bool expected = (median == median2);
            Console.WriteLine($"Expected result? {expected}");



        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2) {

            int m = nums1.Length;
            int n = nums2.Length;

            if (m < 1) return MedianOfSingleArray(nums2);
            if (n < 1) return MedianOfSingleArray(nums1);

            bool odd = (m + n) % 2 == 1;

            int while_control = 0;

            while(true)
            {
                ++while_control;
                if (while_control > (m + n))
                {
                    Console.WriteLine("Too many iterations.");
                    return 0.0;
                }

                // Number of elements below the median
                int magicNumber = (odd)? (m + n - 1) / 2 : (m + n) / 2;


            }

        }

        public static int[] MergeArrays(int[] nums1, int[] nums2) {

            int len1 = nums1.Length;
            int len2 = nums2.Length;

            int[] result = new int[len1 + len2];

            int i = 0; int j = 0;

            while (i < len1 || j < len2)
            {
                if (i >= len1)
                {
                    result[i + j] = nums2[j];
                    ++j;
                }

                else if (j >= len2)
                {
                    result[i + j] = nums1[i];
                    ++i;
                }

                else if (nums1[i] <= nums2[j])
                {
                    result[i + j] = nums1[i];
                    ++i;
                }

                else
                {
                    result[i + j] = nums2[j];
                    ++j;
                }
            }


            return result;
        }

        public static double MedianOfSingleArray(int[] nums) {

            int len = nums.Length;
            int last = len - 1;

            if (len % 2 == 1)
            {
                return 1.0 * (nums[(last + 1) / 2]);
            }

            return 0.5 * (nums[last / 2] + nums[(last / 2) + 1]);
        }

        public static void PrintArray(int[] nums) {

            for (int i = 0; i < nums.Length; ++i)
            {
                int x = nums[i];
                Console.Write($"{x} ");
            }

            Console.Write("\n");
        }
    }
}
