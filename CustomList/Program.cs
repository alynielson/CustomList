using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CustomList<int> ints = new CustomList<int> { 1, 2, 3 };
            CustomList<int> ints2 = new CustomList<int> { 1, 2, 3 };
            CustomList<CustomList<int>> firstList = new CustomList<CustomList<int>> {ints,ints2 };
            firstList.Sort();
            for (int i = 0; i < firstList.Count; i ++)
            {
                Console.WriteLine($"Sorted list at index {i}: {firstList[i]}");
            }
            Console.ReadLine();

        }
    }
}
