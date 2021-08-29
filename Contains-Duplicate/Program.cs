using System;
using System.Collections.Generic;

namespace Contains_Duplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = {1, 1, 1, 3, 3, 4, 3, 2, 4, 2};

            PrintArray(input1);
            Console.WriteLine(Solution2(input1));


        }

        public static void PrintArray(int[] arr) {
            Console.Write("[");
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                Console.Write(arr[i]);
                Console.Write(", ");
            }

            Console.Write(arr[arr.Length - 1]);
            Console.Write("]\n");
        }

        public static bool Solution(int[] nums) {

            if (nums.Length <= 1) return false;

            for (int i = 1; i < nums.Length; ++i)
            {
                int nextElement = nums[i];
                int nextPosition = 0;
                
                while (nums[nextPosition] < nextElement)
                {
                    ++nextPosition;
                }
                
                if (nextPosition == i)
                    continue;
                
                else if (nextElement == nums[nextPosition])
                    return true;
                
                else
                {
                    for (int j = i; j > nextPosition; --j)
                    {
                        nums[j] = nums[j - 1];
                    }
                    
                    nums[nextPosition] = nextElement;
                }
            }
            
            
            return false;
        }

        public static bool Solution2(int[] nums) {

            List<int> prevs = new List<int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                if (prevs.Contains(nums[i])) return true;

                else
                    prevs.Add(nums[i]);
            }


            return false;
        }

        public static bool Solution3(int[] nums) {

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (nums[i] == nums[i + 1]) return true;
            }

            return false;
        }

        public static bool Solution4(int[] nums) {

            HashSet<int> h = new HashSet<int>(nums);

            return (h.Count < nums.Length);
        }
    }
}
