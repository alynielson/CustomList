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
            List<int> numbers = new List<int> { };
            numbers.Remove(numbers[1]);
            Console.WriteLine("Test done");
            Console.ReadLine();

            //CustomList<int> newList = new CustomList<int>();
            //for (int i = 0; i < 4; i++)
            //{
            //    newList.Add(i);
            //}
            //for (int j = 4; j <10; j++)
            //{
            //    newList.Add(j);
            //}
            //Console.WriteLine($"Count: {newList.Count}");
            //Console.WriteLine($"At Index 0: {newList[0]}");
            //Console.WriteLine($"At Index 9: {newList[9]}");
            //Console.WriteLine("Press Enter");
            //Console.ReadLine();
            //newList.Remove(5);
            //Console.WriteLine("Removed the number 5");
            //for (int i = 0; i < 7; i++)
            //{
            //    Console.WriteLine($"Value at index {i}: {newList[i]}");
            //}
            //for (int i =7; i < newList.Count; i++)
            //{
            //    Console.WriteLine($"Value at index {i}: {newList[i]}");
            //}
            //Console.ReadLine();
        }
    }
}
