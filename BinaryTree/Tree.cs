

using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Tree
    {
        public Node root;
        public Node last;
       

        int length;
        int depth;

        public Tree(int data)
        {
            this.root = new Node(data);
            

            this.length = 1;
            this.depth = 0;
        }

        private bool IsEmpty()
        {
            if (this.root == null)
                return true;
            else
                return false;
        }
            

        private Node FindTheParent(int number)
        {
            List<int> road = new List<int>();

            while (number > 0)
            {
                number--;
                number /= 2;

                road.Add(number);
            }
            road.Reverse();

            var x = this.root;

            for (int i = 1; i < road.Count; i++)
            {
                var temp = road[i];

                x = temp % 2 == 1 ? x.left : x.right;
            }

            return x;
        }

        public Node Push(int data)
        {
            
            
            var child = new Node(data);
            var parent = this.FindTheParent(this.length);
            

            child.parent = parent;

            if (this.length % 2 == 1)
                parent.left = child;
            else
                parent.right = child;

            this.length++;
            this.depth = (int)Math.Sqrt(this.length);

            this.last = child;

            return child;
        }


        public int Pop()
        {
            
            var parent = this.FindTheParent(this.length - 1);
            var child = (this.length - 1) % 2 == 1 ? parent.left : parent.right;

            var data = child.data;

            child = null;

            return data;

        }





        
        private void ValidateHeapDown()
        {
            var parent = this.root;
            
            while (true)
            {

                if (parent == null)
                    return;

                var child = parent.left;

                if (child == null)
                    return;

                if (parent.right != null)
                {
                    if (parent.right.data > child.data)
                    {
                        child = parent.right;//wskaznik
                    }

                }

                if (child.data > parent.data)
                {
                    int temp = child.data;
                    child.data = parent.data;
                    parent.data = temp;

                    parent = child;//nazwa obiektu to wskaznik na jego pola i referencje
                }
                else
                    return;
                
                
            }


            
        }

        private void ValidateHeapUp(Node n)
        {
            //1. jest rodzic albo go nie ma
            //2. porownanie dziecka z rodzicem

            while (n.parent != null)
            {
                
                if (n.data <= n.parent.data)
                    break;

                int temp = n.data;
                n.data = n.parent.data;
                n.parent.data = temp;

                n = n.parent;// zamiana wskaznikow
            }
            
            
        }

        

        public void AddToHeap(int data)
        {
            var child = this.Push(data);
            
            ValidateHeapUp(child);

        }

        private int PopFromHeap()
        {
            if (this.length > 1)
            {
                var data = this.root.data;
                this.root.data = this.Pop();
                this.ValidateHeapDown();

                return data;
            }
            else
            {
                return this.root.data;
            }

        }
        

        public static Tree CreateHeapFromArray(int[] array)
        {
            Tree heap = new Tree(array[0]);

            for (int i = 1; i < array.Length; i++)
                heap.AddToHeap(array[i]);

            return heap;
            
        }

        

        public static void HeapSort(int[] array, Tree tree)
        {
            int[] tempArray = new int[array.Length];

            for (int i = array.Length-1; i >= 0; i--)
            {
                tempArray[i] = tree.PopFromHeap();

            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = tempArray[i];
            }
            
        }

        public void BFS()
        {
            Node node;

            Queue<Node> q = new Queue<Node>();

            q.Enqueue(this.root);
            while (q.Count > 0)
            {
                node = q.Dequeue();
                Console.WriteLine(node.data + " ");

                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }



        }

        
    }
}
