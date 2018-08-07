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
            CustomList<int> newList = new CustomList<int>();
            for (int i = 0; i < 4; i++)
            {
                newList.Add(i);
            }
            for (int j = 4; j <10; j++)
            {
                newList.Add(j);
            }
            Console.WriteLine($"Count: {newList.Count}");
            Console.WriteLine($"At Index 0: {newList[0]}");
            Console.WriteLine($"At Index 9: {newList[9]}");
            Console.ReadLine();
        }
    }
}
