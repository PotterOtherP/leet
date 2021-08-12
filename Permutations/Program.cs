using System;
using System.Collections.Generic;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testNums = {1, 2, 3, 4};
        
            Permute(testNums);
        }
        
        public static IList<IList<int>> Permute(int[] nums) {

            IList<IList<int>> result = new List<IList<int>>();
            int k = nums.Length;

            if (k <= 1)
            {
                result.Add(ArrayToList(nums));
                return result;
            }

            if (k > 5)
            {
                Console.WriteLine("Too many elements.");
                return result;
            }



            Generate(k, nums, result);


            Console.Write("\n\nSorted:\n\n");

            result = SortPermList(result);
            PrintPermList(result);

            return result;
        }

        // Heap's algorithm
        public static void Generate(int k, int[] nums, IList<IList<int>> result) {

            int temp = 0;

            if (k == 1)
            {
                PrintArray(nums);
                result.Add(ArrayToList(nums));
            }

            else
            {
                Generate(k - 1, nums, result);

                for (int i = 0; i < k - 1; ++i)
                {
                    if (k % 2 == 0)
                    {
                        temp = nums[i];
                        nums[i] = nums[k - 1];
                        nums[k - 1] = temp;
                    }

                    else
                    {
                        temp = nums[0];
                        nums[0] = nums[k - 1];
                        nums[k - 1] = temp;
                    }

                    Generate(k - 1, nums, result);
                }
            }
        }

        public static List<int> ArrayToList(int[] arr) {

            List<int> result = new List<int>();

            for (int i = 0; i < arr.Length; ++i)
            {
                result.Add(arr[i]);
            }

            return result;
        }

        public static void PrintArray(int[] arr) {

            Console.Write("[");

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                Console.Write(arr[i]);
                Console.Write(", ");
            }

            Console.Write(arr[arr.Length - 1]);
            Console.Write("]");
            Console.Write("\n");
            
        }


        public static int Factorial(int n) {

            if (n <= 1) return 1;

            else return n* Factorial(n - 1);
        }

        public static int CompareArrays(IList<int> a1, IList<int> a2) {

            if (a1.Count != a2.Count)
            {
                Console.WriteLine("Something is wrong, permutations are not the same length");
                return 0;
            }

            int len = a1.Count;

            for (int i = 0; i < len; ++i)
            {
                if (a1[i] > a2[i]) return 1;
                if (a1[i] < a2[i]) return -1;
            }

            return 0;
        }

        public static void PrintPermList(IList<IList<int>> perms) {

            foreach (IList<int> item in perms)
            {
                Console.Write("[");

                for (int i = 0; i < item.Count - 1; ++i)
                {
                    Console.Write(item[i]);
                    Console.Write(", ");
                }

                Console.Write(item[item.Count - 1]);
                Console.Write("]");
                Console.Write("\n");
            }
        }

        public static IList<IList<int>> SortPermList(IList<IList<int>> perms) {

            IList<IList<int>> result = new List<IList<int>>();

            int minIndex = 0;

            while (perms.Count > 0)
            {
                for (int i = 0; i < perms.Count; ++i)
                {
                    if (CompareArrays(perms[i], perms[minIndex]) < 0)
                    {
                        minIndex = i;
                    }
                }

                result.Add(perms[minIndex]);
                perms.Remove(perms[minIndex]);
                minIndex = 0;
                
            }


            return result;
        }


    }
}
