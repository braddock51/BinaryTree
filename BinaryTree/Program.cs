using System;


namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[6] {10, 1, 9, 2, 8, -1};
            
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");

            var tree = Tree.CreateHeapFromArray(array);

            Tree.HeapSort(array, tree);

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }









        }
    }
}
