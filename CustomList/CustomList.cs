﻿using System;
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

        private T[] PutValuesBackInNewArray(T[] newArray, int length, T[] arrayToCopy, int whereToStart = 0)
        {

            for (int i = whereToStart; i < length + whereToStart; i++)
            {
                newArray[i] = arrayToCopy[i - whereToStart];
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
                temporaryArray = PutValuesBackInNewArray(temporaryArray, count-1, array);
                array = temporaryArray;
            }
            this[count-1] = value;
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
                temporaryArray = PutValuesBackInNewArray(temporaryArray, index, array);
            }
            int i = index;
            int indexAtValue = count;
            while (i <= count)
            {
                if (array[i].Equals(value) && indexAtValue > i)
                {
                    indexAtValue = i;
                    i++;
                }
                else if (i > indexAtValue)
                {
                    temporaryArray[i-1] = array[i];
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
        public static CustomList<T> operator +(CustomList<T> listA, CustomList<T> listB)
        {
            int length = listA.count + listB.count;
            CustomList<T> listC = new CustomList<T>(length) { };
            listC.array = listC.PutValuesBackInNewArray(listC.array, listA.count, listA.array);
            listC.array = listC.PutValuesBackInNewArray(listC.array, listB.count,listB.array, listA.count);
            return listC;
        }

        public static CustomList<T> operator -(CustomList<T> listA, CustomList<T> listB)
        {
            CustomList<T> listC = listA;
            for (int i = 0; i < listB.Count; i++)
            {
                listC.Remove(listB[i]);
            }
            return listC;
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
