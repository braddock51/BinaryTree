using System


namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[40];

            Random rnd = new Random();
            
            for (int i = 0; i < array.Length; i++)
            {
                var los = rnd.Next(-10, 10);
                array[i] = los;
            }

            
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n\n\n");

            var tree = Tree.CreateHeapFromArray(array);

            //tree.BFS();
            //
            //tree.Pop();
            //Console.Write("\n\n\n");
            //
            //tree.BFS();
            //
            //tree.Pop();
            //Console.Write("\n\n\n");
            //
            //tree.BFS();

            Tree.HeapSort(array, tree);

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }









        }
    }
}
