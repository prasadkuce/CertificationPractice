using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = new int[] { 2, 4, 9, 10, 22, 38, 67 };
            Console.WriteLine(BinarySearch(list, 10));
            Console.ReadKey();
        }
        public static int BinarySearch(int[] list, int target)
        {
            return BinarySearchHelper2(list, target, 0, list.Length - 1);
        }

        private static int BinarySearchHelper1(int[] list, int target, int left, int right) // Time Complexity O(logN) Space Complexity O(logN)
        {
            if (left > right)
                return -1;
            int mid = (left + right) / 2;
            if (target == list[mid])
                return mid;
            else if (target < list[mid])
                return BinarySearchHelper1(list, target, left, mid - 1);
            else
                return BinarySearchHelper1(list, target, mid+1, right);
        }
        private static int BinarySearchHelper2(int[] list, int target, int left, int right) // Time Complexity O(logN) Space Complexity O(1)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (target == list[mid])
                    return mid;
                else if (target < list[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }
    }
}
