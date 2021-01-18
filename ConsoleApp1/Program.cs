using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Node
    {
        public int Value { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }
        public Node(int val)
        {
            Value = val;
        }
    }
    public class BST
    {
        public Node Root { get; set; }
        public BST()
        {
            Root = null;
        }
        public void Insert(Node newNode)
        {
            Node current;
            if (Root == null)
                Root = newNode;
            else
            {
                current = Root;
                Node parent;
                while(true)
                {
                    parent = current;
                    if(current.Value > newNode.Value)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }
        public void PreOrder(Node root)
        {
            if(root != null)
            {
                Console.Write(root.Value + " ");
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }
        public void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Console.Write(root.Value + " ");
                InOrder(root.Right);
            }
        }
        public void PostOrder(Node root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                Console.Write(root.Value + " ");
            }
        }
    }
    class Program
    {
        public delegate void myDel(int a, int b);
        
        static void Main(string[] args)
        {
            //int[] list = new int[] { 2, 4, 9, 10, 22, 38, 67 };
            //Console.WriteLine(BinarySearch(list, 10));
            
            myDel del = sum;
            del += div;
            del(2, 2);

            BST tree = new BST();
            tree.Insert(new Node(10));
            tree.Insert(new Node(8));
            tree.Insert(new Node(9));
            tree.Insert(new Node(12));
            tree.Insert(new Node(11));

            tree.PreOrder(tree.Root);
            Console.WriteLine();
            tree.InOrder(tree.Root);
            Console.WriteLine();
            tree.PostOrder(tree.Root);
            Console.WriteLine();

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

        public static void sum(int x, int y)
        {
            Console.WriteLine("Sum is " + (x + y));
        }
        public static void div(int x, int y)
        {
            Console.WriteLine("Div is " + (x / y));
        }
    }
}
