using System;


namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[10] {9, 8, 7, -6, 5, -4, 3, 2, -1, -50};
            
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
