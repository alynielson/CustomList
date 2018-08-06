﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace CustomListUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToList_PositiveNumber_ReturnNewListItem()
        {
            CustomList<int> numbers = new CustomList<int> ();
            int number = 5;
            numbers.AddToList(number);
            Assert.AreEqual(number, numbers[0]);
        }
        [TestMethod]
        public void AddToList_String_ReturnNewListItem()
        {
            CustomList<string> words = new CustomList<string>();
            string word = "Test";
            words.AddToList(word);
            Assert.AreEqual(word, words[0]);
        }
        [TestMethod]
        public void AddToNonEmptyList_Int_ReturnNewListItem()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2 };
            int number = 3;
            numbers.AddToList(number);
            Assert.AreEqual(number, numbers[2]);
        }
        [TestMethod]
        public void AddToNonEmptyList_String_DoNotChangeOldItem()
        {
            CustomList<string> words = new CustomList<string> { "word1", "word2", "word3" };
            string word = "word4";
            words.AddToList(word);
            Assert.AreEqual("word2", words[1]);
        }
        [TestMethod]
        public void AddToList_Int_IncrementListCount()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2 };
            int number = 3;
            int count = numbers.Count;
            numbers.AddToList(number);
            Assert.AreEqual(count + 1, numbers.Count);
        }
        [TestMethod]
        public void AddToList_LotsOfNumbers_AnyIndexIsCorrect()
        {
            CustomList<int> numbers = new CustomList<int> { };
            for (int i = 0; i < 50; i++)
            {
                numbers.AddToList(i);
            }
            Assert.AreEqual(27, numbers[27]);
        }
      
        [TestMethod]
        public void RemoveFromList_SpecificNumber_DecrementCount()
        {
            CustomList<int> numbers = new CustomList<int> {1,2,3 };
            int numToRemove = 3;
            int intialCount = numbers.Count;
            numbers.RemoveFromList(numToRemove);
            Assert.AreEqual(intialCount - 1, numbers.Count);

        }
        [TestMethod]
        public void RemoveFromList_StringAtIndex_DecrementCount()
        {
            CustomList<string> words = new CustomList<string> { "word1", "word2", "word3" };
            int initialCount = words.Count;
            words.RemoveFromList(words[2]);
            Assert.AreEqual(initialCount - 1, words.Count);
        }
        [TestMethod]
        public void RemoveFromList_SpecificString_DecrementCount()
        {
            CustomList<string> words = new CustomList<string> { "Hello", "world" };
            string wordToRemove = "world";
            int initialCount = words.Count;
            words.RemoveFromList("world");
            Assert.AreEqual(intialCount - 1, words.Count);
        }
        [TestMethod]
        public void RemoveFromList_SpecificString_RestOfListUnchanged()
        {
            CustomList<string> words = new CustomList<string> { "Hello", "world" };
            string wordToRemove = "world";
            words.RemoveFromList("world");
            Assert.AreEqual("Hello", words[0]);
        }
        [TestMethod]
        public void RemoveFromList_LotsOfItems_DecrementCount()
        {
            CustomList<int> numbers = new CustomList<int> { };
            for (int i = 0; i < 50; i++)
            {
                numbers.AddToList(i);
            }
            for (int i = 49; i > 24; i --)
            {
                numbers.RemoveFromList(i);
            }
            Assert.AreEqual(25, numbers.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveFromEmptyList_OneItem_ReturnException()
        {
            CustomList<int> numbers = new CustomList<int> { };
            numbers.RemoveFromList(numbers[0]);
        }
        [TestMethod]
        public void ToString_LotsOfNumbers_ReturnString()
        {
            CustomList<int> numbers = new CustomList<int> { };
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    numbers.AddToList(i);
                }
            }
            string numbersString = numbers.ToString();
            Assert.AreEqual(numbersString, "01234567890123456789012345678901234567890123456789");
        }
        [TestMethod]
        public void ToString_Letters_ReturnString()
        {
            CustomList<string> letters = new CustomList<string> {"ABC", " ", "DEF" , " ", "GHI" };
            string lettersString = letters.ToString();
            Assert.AreEqual(lettersString, "ABC DEF GHI");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToString_EmptyList_ThrowsException()
        {
            CustomList<string> words = new CustomList<string> { };
            string wordsString = words.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetIndex_EmptyList_ThrowsException()
        {
            CustomList<string> words = new CustomList<string> { };
            string anyWord = words[3];
        }

        [TestMethod]
        public void Iterate_AddToEachInt_ReturnListWithSums()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3 };
            foreach (int number in numbers)
            {
                number += 1;
            }
            Assert.AreEqual(3, index[1]);
        }
        [TestMethod]
        public void Iterate_ConcatenateStrings_ReturnEditedList()
        {
            CustomList<string> words = new CustomList<string> { "word", "word", "word" };
            foreach (string word in words)
            {
                word += "test";
            }
            Assert.AreEqual("wordtest", index[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Iterate_EmptyList_ThrowException()
        {
            CustomList<string> words = new CustomList<string> { };
            foreach (string word in words)
            {
                word += "123";
            }
        }

        [TestMethod]
        public void Iterate_BreakDuringLoop_PartOfListUnchanged()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int number in numbers)
            {
                if (number >= 5)
                {
                    break;
                }
                else
                {
                    number += 2;
                }
            }
            Assert.AreEqual(6, numbers[5]);
        }
        [TestMethod]
        public void Iterate_BreakDuringLoop_PartOfListChanged()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int number in numbers)
            {
                if (number >= 5)
                {
                    break;
                }
                else
                {
                    number += 2;
                }
            }
            Assert.AreEqual(5, numbers[2]);
        }
    }
}
