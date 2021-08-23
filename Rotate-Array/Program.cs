using System;

// Given an array, rotate the array to the right by k steps,
// where k is non-negative.

namespace Rotate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 2;

            Console.WriteLine($"k = {k}");
            PrintArray(nums);
            RotateThree(nums, k);
        }

        public static void Rotate(int[] nums, int k) {

            int len = nums.Length;
            if (len == 0) return;

            k = k % len;
            if (k == 0) return;

            int[] result = new int[len];

            for (int i = 0; i < k; ++i)
            {
                result[i] = nums[len - k + i];
            }

            for (int i = k; i < len; ++i)
            {
                result[i] = nums[i - k];
            }

            nums = result;
            PrintArray(nums);

        }

        public static void RotateTwo(int[] nums, int k) {

            int len = nums.Length;
            if (len == 0) return;

            k = k % len;
            if (k == 0) return;

            int[] extra = new int[k];

            for (int i = 0; i < k; ++i)
            {
                extra[i] = nums[len - k + i];
            }

            for (int i = len - 1; i >= k; --i)
            {
                if (k <= i)
                    nums[i] = nums[i - k];
                else
                    nums[i] = nums[i - k + len];
            }

            for (int i = 0; i < k; ++i)
            {
                nums[i] = extra[i];
            }


            PrintArray(extra);
            PrintArray(nums);
        }

        public static void RotateThree(int[] nums, int k) {

            int len = nums.Length;
            if (len == 0) return;

            k = k % len;
            if (k == 0) return;

            for (int i = 0; i < k; ++i)
            {
                


            }

            PrintArray(nums);
        }

        public static void PrintArray(int[] arr)
        {
            string str = "[";
            int len = arr.Length;
            for (int i = 0; i < len - 1; ++i)
            {
                str += (arr[i]);
                str += ", ";
            }

            str += arr[len - 1];
            str += "]";

            Console.WriteLine(str);
        }
    }
}
