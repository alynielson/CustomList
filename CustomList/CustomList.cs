﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable
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
            int n = 1;
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
        private T[] RecreateArrayWithoutRemovedItem(T value, T[] temporaryArray)
        {
            int i = 0;
            int indexAtValue = count + 1;
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
       

        public bool Remove(T value)
        {
            bool didRemoveItem;
            if (count == 0)
            {
                return didRemoveItem = false;
            }
            bool isValueInList = CheckIfValueInList(value);
            if (isValueInList == true)
            {
                count--;
                bool shouldCapacityBeShrunk = CheckIfCapacityTooHigh();
                if (shouldCapacityBeShrunk == true)
                {
                    ShrinkCapacity();
                }
                T[] temporaryArray = CreateArray();
                temporaryArray = RecreateArrayWithoutRemovedItem(value, temporaryArray);
                array = temporaryArray;
                didRemoveItem = true;
            }
            else
            {
                didRemoveItem = false;
            } 
            return didRemoveItem;
        }
        private bool CheckIfValueInList(T value)
        {
            bool isValueInList = false;
            for (int i = 0; i < count; i++)
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
            CustomList<T> listC = new CustomList<T>(listA.count) { };
            listC.array = listC.PutValuesBackInNewArray(listC.array, listA.count, listA.array);
            for (int i = 0; i < listB.Count; i++)
            {
                T itemToRemove = listB[i];
                listC.Remove(itemToRemove);
            }
            return listC;
        }

       
        public override string ToString()
        {
            string listAsString = "";
            for (int i = 0; i < count; i++)
            {
                listAsString += $"{array[i]}";
            }
            return listAsString;
        }

        public string ToStringWithSeparator(string separator)
        {
            string listAsString = "";
            for (int i = 0; i < count; i++)
            {
                listAsString += $"{array[i]}";
                if (i < (count - 1))
                {
                    listAsString += separator;
                }
            }
            return listAsString;
        }
        public void Zip(CustomList<T> listA, CustomList<T> listB)
        {
            if (listA.count == listB.count)
            {
                for (int i = 0; i < listA.count; i++)
                {
                    Add(listA[i]);
                    Add(listB[i]);
                }
            }
            else
            {
                CustomList<T> biggerList;
                CustomList<T> smallerList;
                if (listA.count > listB.count)
                {
                    biggerList = listA;
                    smallerList = listB;
                }
                else
                {
                    biggerList = listB;
                    smallerList = listA;
                }
                for (int i = 0; i < smallerList.count; i++)
                {
                    Add(listA[i]);
                    Add(listB[i]);
                }
                for (int i = smallerList.count; i < biggerList.count; i++)
                {
                    Add(biggerList[i]);
                }
            }
        }

        public void Sort()
        {
            int i = 0;
            while (i < count-1)
            {
                int result = Compare(array[i], array[i + 1]);
                if (result == 1)
                {
                    i++;
                }
                else if (result == -1)
                {
                    T[] temporaryArray = CreateArray();
                    int j = 0;
                    while (j < count)
                    {
                       if (j == i)
                       {
                            temporaryArray[i] = array[i + 1];
                            temporaryArray[i + 1] = array[i];
                            j += 2;
                            
                       }
                        else
                        {
                            temporaryArray[j]= array[j];
                            j++;
                        }
                    }
                    array = temporaryArray;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            
           
        }

       

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
            yield break;
        }

        public int CompareTo(object current, object other)
        {
            int result = 0;
            bool isNumber = DetermineIfObjectIsAnyTypeOfNumber(current);
            if (other is string)
            {
                int whichIsLonger = DetermineWhichStringLonger((string)current, (string)other);
                int maxI = DetermineMaxStringIndexToCheck((string)current, (string)other);
                result = DetermineWhichStringFirst((string)current, (string)other, maxI, whichIsLonger);
            }
            else if (isNumber == true)
            {
                decimal numberA = ConvertToDecimal(current);
                decimal numberB = ConvertToDecimal(other);
                result = DetermineWhichNumberFirst(numberA, numberB);

            }
            else
            {
                System.NotSupportedException cannotSort = new System.NotSupportedException();
                throw cannotSort;
            }
            return result;
        }

        private decimal ConvertToDecimal(object possibleNumber)
        {
            string possible = $"{possibleNumber}";
            decimal num;
            bool canBeConverted = Decimal.TryParse(possible, out num);
            return num;
        }

       

        public int Compare(T x, T y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {

                    return CompareTo(x, y);

                }
            }
        }

        private bool DetermineIfObjectIsAnyTypeOfNumber(object current)
        {

            return current is sbyte
            || current is byte
            || current is short
            || current is ushort
            || current is int
            || current is uint
            || current is long
            || current is ulong
            || current is float
            || current is double
            || current is decimal;

        }

        private int DetermineWhichStringLonger(string stringA, string stringB)
        {
            int whichIsLonger;
            if (stringA.Length > stringB.Length)
            {
                whichIsLonger = 1;
            }
            else if (stringA.Length < stringB.Length)
            {
                whichIsLonger = -1;
            }
            else
            {
                whichIsLonger = 0; 
            }
            return whichIsLonger;
        }
    
      

        private int DetermineMaxStringIndexToCheck(string stringA, string stringB)
        {
            int maxI;
            if (stringA.Length > stringB.Length)
            {
                maxI = stringB.Length;
            }
            else if (stringA.Length < stringB.Length)
            {
                maxI = stringA.Length;
            }
            else
            {
                maxI = stringA.Length;
            }
            return maxI;
        }

        
        private int DetermineWhichNumberFirst(decimal numberA, decimal numberB)
        {
            if (numberA > numberB)
            {
                return 1;
            }
            else if (numberA < numberB)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int DetermineWhichStringFirst(string stringA, string stringB, int maxI, int whichIsLonger)
        {
            int result = 0;
            int i = 0;
            while (i < maxI)
            {
                byte currentValue = Convert.ToByte(stringA[i]);
                byte otherValue = Convert.ToByte(stringB[i]);
                if (currentValue < otherValue)
                {
                    result = 1;
                    break;
                }
                else if (currentValue > otherValue)
                {
                    result = -1;
                    break;
                }
                else
                {
                    i++;
                }
            }
            if (result == 0)
            {
                result = whichIsLonger;
            }
            return result;
        }
    }
}
