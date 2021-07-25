// https://leetcode.com/problems/two-sum/

using System;

namespace Two_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {26, 15, 4, 13, 2, 11, 3, 9, 44, 8, 5, 7, 6};
            // Sorted: {2, 3, 4, 5, 6, 7, 8, 9, 11, 13, 15, 26, 44}

            Console.Write("nums: ");
            PrintIntArray(nums);

            int target = 23;
            Console.WriteLine($"target: {target}");

            Console.Write("Result: ");
            PrintIntArray(twoSum(nums, target));


        }

        public static int[] twoSum(int[] nums, int target) {

            int[] original = new int[nums.Length];
            Array.Copy(nums, original, nums.Length);

            Array.Sort(nums);
            int lower = 0;
            int higher = nums.Length - 1;

            while (nums[lower] + nums[higher] != target)
            {
                int difference = target - nums[lower];

                while (nums[higher] > difference)
                {
                    --higher;
                }

                if (nums[higher] < difference)
                    ++lower;

            }

            int[] result = new int[2];
            result[0] = Array.IndexOf(original, nums[lower]);
            result[1] = Array.LastIndexOf(original, nums[higher]);

            return result;
        }

        public static void PrintIntArray(int[] nums) {

            foreach(int num in nums)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine();
        }

        public static int[] BubbleSort(int[] arr) {

            Console.WriteLine("Executing method: Bubble Sort");

            bool sortFinished = false;
            int temp = 0;

            while(!sortFinished)
            {
                sortFinished = true;

                for (int i = 0; i < arr.Length - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        sortFinished = false;
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1]  = temp;
                    }
                }
            }

            return arr;
        }

        public static int[] InsertionSort(int[] arr) {

            Console.WriteLine("Executing method: Insertion Sort");

            // Take the next unsorted element and find its position
            // in the sorted portion of the array. Shift greater elements
            // to the right and insert the new element.

            for (int i = 1; i < arr.Length; ++i)
            {
                int nextElement = arr[i];
                int nextPosition = 0;
                while (arr[nextPosition] < nextElement)
                {
                    ++nextPosition;
                }

                if (nextPosition == i)
                    continue;

                else
                {
                    for (int j = i; j > nextPosition; --j)
                    {
                        arr[j] = arr[j - 1];
                    }

                    arr[nextPosition] = nextElement;
                }

            }

            return arr;
        }

        public static int[] SelectionSort(int[] arr) {

            Console.WriteLine("Executing method: Selection Sort");

            // Search the unsorted portion of the array for the smallest
            // element and stick it at the end of the sorted portion.

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                // Find the smallest entry between i and the end of the array.
                int smallestIndex = i;
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j] < arr[smallestIndex])
                    {
                        smallestIndex = j;
                    }
                }

                // Swap that entry with the entry at index i.
                if (smallestIndex != i)
                {
                    int temp = arr[smallestIndex];
                    arr[smallestIndex] = arr[i];
                    arr[i] = temp;
                }
            }

            return arr;
        }

        public static int[] twoSumBF(int[] nums, int target) {

            int[] result = new int[2];

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                for (int j = i + 1; j < nums.Length; ++j)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }

            return result;
        }
    }


    
}
