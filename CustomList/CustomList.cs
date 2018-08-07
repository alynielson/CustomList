using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T>
    {
        private int count;
        private int capacity;
        public T this[int index]
        {
            get
            {
                if (index <= 0 || index >= count)
                {
                    return ArgumentOutOfRangeException;
                }
                

            }
            set;
        } 
        public int Count
        {
            get
            { 
                return count;
            }
        }

        public CustomList(int length = 0)
        {
            count = length;
            capacity = DetermineInitialCapacity(count);
            array1 = CreateArray(capacity);
        }


        private T[] CreateArray()
        {
            T[] array1 = new T[capacity];
            return array1;
        }

        private int DetermineInitialCapacity()
        {
            int n = 2;
            do
            {
                capacity = Math.Pow(2,n);
                n++;
            }
            while (capacity < count);
            return capacity;    
        }

        private int ChangeCapacity()
        {
            do
            {
                capacity = capacity * 2;
            }
            while (capacity < count);

            return capacity;
        }

        private bool CheckCapacity()
        {
            bool isOverCapacity;
            if (count > capacity)
            {
                isOverCapacity = true;
            }
            else 
            {
                isOverCapacity = false;
            }
            return isOverCapacity;
        }


        public void Add(T value)
        {
            count++;
            bool isOverCapacity = CheckCapacity();
            if (isOverCapacity == true)
            {
                capacity = ChangeCapacity();
            }
            this[count - 1] = value;
        }

        public void RemoveFromList(T value) { }

        public void ToString(T value) { }
        public void Zip(List<T> list1, List<T> list2) { }
    }
}
