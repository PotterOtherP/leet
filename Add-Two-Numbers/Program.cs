// https://leetcode.com/problems/add-two-numbers/

using System;

namespace Add_Two_Numbers
{
    class Program
    {
        static void Main(string[] args) {

            ListNode l1 = new ListNode(9);
            l1.Add(9);
            l1.Add(9);
            l1.Add(9);
            l1.Add(9);
            l1.Add(9);
            l1.Add(9);
            l1.PrintNode();

            ListNode l2 = new ListNode(9);
            l2.Add(9);
            l2.Add(9);
            l2.Add(9);
            l2.PrintNode();

            ListNode answer = AddTwoNumbers(l1, l2);
            answer.PrintNode();
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2) {

            ListNode index = new ListNode();
            ListNode answer = index;

            while (l1 != null || l2 != null)
            {
                int val1 = (l1 != null)? l1.val : 0;
                int val2 = (l2 != null)? l2.val : 0;

                index.val += val1 + val2;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;

                if (index.val > 9)
                {
                    index.val %= 10;
                    index.next = new ListNode(1);
                }

                else if (l1 != null || l2 != null)
                {
                    index.next = new ListNode();
                }

                index = index.next;
            }

            return answer;
        }

    }

    public class ListNode {

        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null) {

            this.val = val;
            this.next = next;
        }

        public void Add(int val) {
            ListNode last = this;
            while(last.next != null)
            {
                last = last.next;
            }

            last.next = new ListNode(val);
        }

        public void PrintNode() {

            ListNode index = this.next;
            
            Console.Write($"[{val}");

            while (index != null)
            {
                Console.Write($", {index.val}");
                index = index.next;
            }

            Console.Write("]\n");

        }
    }
}
