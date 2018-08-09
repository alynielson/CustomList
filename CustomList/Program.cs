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
            CustomList<int> firstList = new CustomList<int> { 1, 2, 3, 1, 2, 3 };
            CustomList<int> secondList = new CustomList<int> { 1, 0, 2, 6, 6, 6, 6 };
            CustomList<int> resultList = new CustomList<int> { };

            resultList = firstList - secondList;
            for (int i = 0; i < resultList.Count; i++)
            {
                Console.WriteLine($"resultList at index {i}: {resultList[i]}");
            }
            Console.WriteLine($"Count of resultList: {resultList.Count}");
            Console.ReadLine();


        }
    }
}
