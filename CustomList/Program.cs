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
           

           
            Console.ReadLine();

            CustomList<int> newList = new CustomList<int>();
            for (int i = 0; i < 4; i++)
            {
                newList.Add(i);
            }
            for (int j = 4; j < 10; j++)
            {
                newList.Add(j);
            }
            Console.WriteLine($"Count: {newList.Count}");
            Console.WriteLine($"At Index 0: {newList[0]}");
            Console.WriteLine($"At Index 9: {newList[9]}");
            Console.WriteLine("Press Enter");
            Console.ReadLine();
            newList.Remove(5);
            Console.WriteLine("Removed the number 5");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Value at index {i}: {newList[i]}");
            }
            for (int i = 7; i < newList.Count; i++)
            {
                Console.WriteLine($"Value at index {i}: {newList[i]}");
            }
            Console.ReadLine();
            CustomList<int> list2 = new CustomList<int> { 10, 11, 12 };
            CustomList<int> list3 = new CustomList<int> { };
            list3 = newList + list2;
            for (int i = 0; i < list3.Count; i++)
            {
                Console.WriteLine($"List3 at index {i}: {list3[i]}");
            }
            Console.ReadLine();
            CustomList<int> numbers = new CustomList<int> {1,2,3};
            CustomList<int> moreNumbers = new CustomList<int> { 1 };
            CustomList<int> numbersRemoved = numbers - moreNumbers;
            for (int i = 0; i < numbersRemoved.Count; i++)
            {
                Console.WriteLine($"Subtracted list index{i}: {numbersRemoved[i]}");
            }
            Console.WriteLine($"Subtracted list count: {numbersRemoved.Count}");
            Console.ReadLine();

            
        }
    }
}
