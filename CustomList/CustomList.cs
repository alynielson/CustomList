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
        private T[] array;
        private T[] newArray;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    System.ArgumentException argEx = new System.ArgumentOutOfRangeException();
                    throw argEx;
                }
                else
                {
                    return array[index];
                }

            }
            set
            {
                array[index] = value;
            }
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
            DetermineInitialCapacity();
            array = CreateArray();
        }


        private T[] CreateArray()
        {
            T[] anyArray = new T[capacity];
            return anyArray;
        }

        private int DetermineInitialCapacity()
        {
            int n = 2;
            do
            {
                capacity = Convert.ToInt32(Math.Pow(2, n));
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

        private T[] PutValuesBackInNewArray()
        {
            for (int i = 0; i < count - 1; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }


        public void Add(T value)
        {
            count++;
            bool isOverCapacity = CheckCapacity();
            if (isOverCapacity == true)
            {
                ChangeCapacity();
                newArray = CreateArray();
                PutValuesBackInNewArray();
                array = newArray;
            }
            this[count - 1] = value;
        }

        public void RemoveFromList(T value) { }

        public void ToString(T value) { }
        public void Zip(List<T> list1, List<T> list2) { }
    }
}
