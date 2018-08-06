using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList <T>
    {
        public void AddToList(T value) { }

        public void RemoveFromList(T value) { }

        public void ToString(T value) { }
        public void Zip(List<T> list1, List<T> list2) { }
    }
}
