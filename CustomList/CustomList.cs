using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>
    {
        private int count;
        private int capacity;
        private T[] array;
        

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
                if (index < 0 || index >= count)
                {
                    System.ArgumentException argEx = new System.ArgumentOutOfRangeException();
                    throw argEx;
                }
                else
                {
                    array[index] = value;
                }
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

        private bool CheckIfOverCapacity()
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

        private T[] PutValuesBackInNewArray(T[] newArray, int length)
        {
            for (int i = 0; i < length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }


        public void Add(T value)
        {
            count++;
            bool isOverCapacity = CheckIfOverCapacity();
            if (isOverCapacity == true)
            {
                ChangeCapacity();
                T[] temporaryArray = CreateArray();
                int lengthToCopyOldArray = count;
                lengthToCopyOldArray--;
                temporaryArray = PutValuesBackInNewArray(temporaryArray, lengthToCopyOldArray);
                array = temporaryArray;
            }
            int indexToAddNewValue = count;
            indexToAddNewValue--;
            this[indexToAddNewValue] = value;
        }

        private bool CheckIfCapacityTooHigh()
        {
            bool canCapacityBeShrunk;
            int nextLowestCapacity = capacity / 2;
            if (count <= nextLowestCapacity)
            {
                canCapacityBeShrunk = true;
            }
            else
            {
                canCapacityBeShrunk = false;
            }
            return canCapacityBeShrunk;
        }

        private int ShrinkCapacity()
        {
            capacity = capacity / 2;
            return capacity;
        }
        private T[] RecreateArrayWithoutRemovedItem(T value, T[] temporaryArray, int index)
        {
            if (index > 0)
            {
                temporaryArray = PutValuesBackInNewArray(temporaryArray, index);
            }
            int i = index;
            int indexAtValue = count;
            while (i <= count)
            {
                if (array[i].Equals(value))
                {
                    indexAtValue = i;
                    i++;
                }
                else if (i > indexAtValue)
                {
                    int indexToPlaceValue = i;
                    indexToPlaceValue--;
                    temporaryArray[indexToPlaceValue] = array[i];
                    i++;
                }
                else
                {
                    temporaryArray[i] = array[i];
                    i++;
                }
            }
            return temporaryArray;
        }
       

        public bool Remove(T value, int indexToStartLooking = 0)
        {
            bool didRemoveItem;
            if (count == 0)
            {
                return didRemoveItem = false;
            }
            bool isValueInList = CheckIfValueInList(indexToStartLooking, value);
            if (isValueInList == true)
            {
                count--;
                bool shouldCapacityBeShrunk = CheckIfCapacityTooHigh();
                if (shouldCapacityBeShrunk == true)
                {
                    ShrinkCapacity();
                }
                T[] temporaryArray = CreateArray();
                temporaryArray = RecreateArrayWithoutRemovedItem(value, temporaryArray, indexToStartLooking);
                array = temporaryArray;
                didRemoveItem = true;
            }
            else
            {
                didRemoveItem = false;
            } 
            return didRemoveItem;
        }
        private bool CheckIfValueInList(int index,T value)
        {
            bool isValueInList = false;
            for (int i = index; i < count; i++)
            {
                if (array[i].Equals(value))
                {
                    isValueInList = true;
                    break;
                }
            }
            return isValueInList;
        }

        public void ForEach()
        {

        }
        public void ToString(T value) { }
        public void Zip(List<T> list1, List<T> list2) { }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
