using System;
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
            CustomList<int> numbers = new CustomList<int>();
            int number = 5;
            numbers.Add(number);
            Assert.AreEqual(number, numbers[0]);
        }
        [TestMethod]
        public void AddToList_String_ReturnNewListItem()
        {
            CustomList<string> words = new CustomList<string>();
            string word = "Test";
            words.Add(word);
            Assert.AreEqual(word, words[0]);
        }


        [TestMethod]
        public void AddToNonEmptyList_Int_ReturnNewListItem()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2 };
            int number = 3;
            numbers.Add(number);
            Assert.AreEqual(number, numbers[2]);
        }
        [TestMethod]
        public void AddToNonEmptyList_String_DoNotChangeOldItem()
        {
            CustomList<string> words = new CustomList<string> { "word1", "word2", "word3" };
            string word = "word4";
            words.Add(word);
            Assert.AreEqual("word2", words[1]);
        }
        [TestMethod]
        public void AddToList_Int_IncrementListCount()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2 };
            int number = 3;
            int count = numbers.Count;
            numbers.Add(number);
            Assert.AreEqual(count + 1, numbers.Count);
        }
        [TestMethod]
        public void AddToList_LotsOfNumbers_AnyIndexIsCorrect()
        {
            CustomList<int> numbers = new CustomList<int> { };
            for (int i = 0; i < 50; i++)
            {
                numbers.Add(i);
            }
            Assert.AreEqual(27, numbers[27]);
        }

        [TestMethod]
        public void RemoveFromList_SpecificNumber_DecrementCount()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3 };
            int numToRemove = 3;
            int intialCount = numbers.Count;
            numbers.Remove(numToRemove);
            Assert.AreEqual(intialCount - 1, numbers.Count);

        }
        [TestMethod]
        public void RemoveFromList_ValueWithDuplicates_RemoveCorrectValues()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3, 1 };
            int numToRemove = 1;
            numbers.Remove(numToRemove);
            Assert.AreEqual(1, numbers[2]);
        }
        [TestMethod]
        public void RemoveFromList_StringAtIndex_DecrementCount()
        {
            CustomList<string> words = new CustomList<string> { "word1", "word2", "word3" };
            int initialCount = words.Count;
            words.Remove(words[2]);
            Assert.AreEqual(initialCount - 1, words.Count);
        }
        [TestMethod]
        public void RemoveFromList_SpecificString_DecrementCount()
        {
            CustomList<string> words = new CustomList<string> { "Hello", "world" };
            int initialCount = words.Count;
            words.Remove("world");
            Assert.AreEqual(initialCount - 1, words.Count);
        }
        [TestMethod]
        public void RemoveFromList_SpecificString_RestOfListUnchanged()
        {
            CustomList<string> words = new CustomList<string> { "Hello", "world" };
            words.Remove("world");
            Assert.AreEqual("Hello", words[0]);
        }
        [TestMethod]
        public void RemoveFromList_LotsOfItems_DecrementCount()
        {
            CustomList<int> numbers = new CustomList<int> { };
            for (int i = 0; i < 50; i++)
            {
                numbers.Add(i);
            }
            for (int i = 49; i > 24; i--)
            {
                numbers.Remove(i);
            }
            Assert.AreEqual(25, numbers.Count);
        }

       
        
       
        [TestMethod]
        public void RemoveFromList_ItemNotInList_CountDoesntChange()
        {
            CustomList<int> numbers = new CustomList<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
            numbers.Remove(7);
            CustomList<int> expectedResult = new CustomList<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
            Assert.AreEqual(expectedResult.Count, numbers.Count);
        }
        [TestMethod]
        public void RemoveFromList_ItemNotInList_ReturnFalseBool()
        {
            CustomList<int> numbers = new CustomList<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
            bool actualResult = numbers.Remove(7);
            bool expectedResult = false;
            Assert.AreEqual(actualResult, expectedResult);
        }
       
        [TestMethod]
        public void RemoveFromList_ItemInList_ReturnTrue()
        {
            CustomList<int> numbers = new CustomList<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
            bool actualResult = numbers.Remove(1);
            bool expectedResult = true;
            Assert.AreEqual(actualResult, expectedResult);
        }
        [TestMethod]
        public void RemoveFromEmptyList_OneItem_ReturnFalse()
        {
            CustomList<int> numbers = new CustomList<int> { };
            bool actual = numbers.Remove(2);
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void ToString_LotsOfNumbers_ReturnString()
        {
            CustomList<int> numbers = new CustomList<int> { };
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    numbers.Add(i);
                }
            }
            string numbersString = numbers.ToString();
            Assert.AreEqual(numbersString, "01234567890123456789012345678901234567890123456789");
        }
        [TestMethod]
        public void ToString_Letters_ReturnString()
        {
            CustomList<string> letters = new CustomList<string> { "ABC", " ", "DEF", " ", "GHI" };
            string lettersString = letters.ToString();
            Assert.AreEqual(lettersString, "ABC DEF GHI");
        }

        [TestMethod]
        
        public void ToString_EmptyList_ReturnsEmptyString()
        {
            CustomList<string> words = new CustomList<string> { };
            string wordsString = words.ToString();
            Assert.AreEqual("", wordsString);
        }

        [TestMethod]
        public void ToString_ListWithSeparator_ReturnStringWithSeparator()
        {
            CustomList<int> numbers = new CustomList<int> { 817, 584, 8034 };
            string phoneNumber = numbers.ToStringWithSeparator("-");
            Assert.AreEqual("817-584-8034", phoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetIndex_EmptyList_ThrowsException()
        {
            CustomList<string> words = new CustomList<string> { };
            string anyWord = words[3];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetIndex_EmptyList_ThrowsException()
        {
            CustomList<string> words = new CustomList<string> { };
            words[3] = "word";
        }

        [TestMethod]
        public void Iterate_AddNumbersToSum_SumIsCorrect()
        {
            int sum = 0;
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3 };
            foreach (int number in numbers)
            {
                sum += number;
            }
            Assert.AreEqual(6, sum);
        }
        [TestMethod]
        public void Iterate_ConcatenateStrings_ReturnCorrectString()
        {
            string finalString = "";
            CustomList<string> words = new CustomList<string> { "word", "word", "word" };
            foreach (string word in words)
            {
                finalString += word;
            }
            Assert.AreEqual("wordwordword", finalString);
        }

        [TestMethod]
        
        public void Iterate_EmptyList_DoNothing()
        {
            string newString = "";
            CustomList<string> words = new CustomList<string> { };
            foreach (string word in words)
            {
                newString += word;
            }
            Assert.AreEqual(newString, "");
        }

        [TestMethod]
        public void Iterate_BreakDuringLoop_ConfirmBreakOccurs()
        {
            string test = "passed";
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int number in numbers)
            {
                if (number <= 5)
                {
                    test += "!";
                }
                else if (number == 6)
                {
                    test += " now stop";
                    break;
                }
                else
                {
                    test += "?";
                }
            }
            Assert.AreEqual(test, "passed!!!!! now stop");
        }
        [TestMethod]
        public void Iterate_CustomListOfCustomLists_ReturnCorrectProperties()
        {
            int totalOfQuantities = 0;
            CustomList<int> list1 = new CustomList<int> { 1 };
            CustomList<int> list2 = new CustomList<int> { 1, 2 };
            CustomList<int> list3 = new CustomList<int> { 1,2,3 };
            CustomList<CustomList<int>> listOfLists = new CustomList<CustomList<int>> { list1, list2, list3 };
            foreach (CustomList<int> list in listOfLists)
            {
                totalOfQuantities += list.Count;
            }
            Assert.AreEqual(totalOfQuantities, 6);
            
        }

        [TestMethod]
        public void AddLists_TwoLists_AssertNumbersAtIndex()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3 };
            CustomList<int> moreNumbers = new CustomList<int> { 4, 5, 6 };
            CustomList<int> numbersAdded = numbers + moreNumbers;
            Assert.AreEqual(numbersAdded[3], 4);
        }

        [TestMethod]
        public void AddLists_TwoLists_ConfirmCount()
        {
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3 };
            CustomList<int> moreNumbers = new CustomList<int> { 4, 5, 6 };
            CustomList<int> numbersAdded = numbers + moreNumbers;
            Assert.AreEqual(numbersAdded.Count, 6);
        }
        [TestMethod]
        public void AddLists_SeveralLists_ConfirmCount()
        {
            CustomList<int> list1 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> list2 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> list3 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> list4 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> list5 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> list6 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> list7 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> list8 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> list9 = list1 + list2 + list3 + list4 + list5 + list6 + list7 + list8;
            Assert.AreEqual(list9.Count, 24);
        }
        [TestMethod]
        public void AddLists_AddToEmptyList_ConfirmIndexUnchanged()
        {
            CustomList<int> emptyList = new CustomList<int>();
            CustomList<int> numbers = new CustomList<int> { 1, 2, 3 };
            CustomList<int> newList = emptyList + numbers;
            Assert.AreEqual(newList[0], 1);
        }

        [TestMethod]
        public void AddLists_TwoEmptyLists_ConfirmZeroCount()
        {
            CustomList<int> list1 = new CustomList<int>() { };
            CustomList<int> list2 = new CustomList<int>() { };
            CustomList<int> newList = list1 + list2;
            Assert.AreEqual(0, newList.Count);
        }

        [TestMethod]
        public void AddLists_TwoLists_ConfirmOriginalListUnchanged()
        {
            CustomList<int> list1 = new CustomList<int>() { 1, 2, 3 };
            CustomList<int> list2 = new CustomList<int>() { 2 };
            CustomList<int> list3 = list1 + list2;
            Assert.AreEqual(list1[1], 2);
        }
        [TestMethod]
        public void GetCount_EmptyList_ReturnZeroCount()
        {
            CustomList<int> emptyList = new CustomList<int>();
            Assert.AreEqual(emptyList.Count, 0);
        }

        [TestMethod]
        public void Subtract_SameLists_ReturnEmptyList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(0, subtracted.Count);
        }

        [TestMethod]
        public void Subtract_OneSimilarityInLists_ReturnSubtractedList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> numbers2 = new CustomList<int> { 1 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(2, subtracted.Count);
        }
        [TestMethod]
        public void Subtract_OneSimilarityDuplicated_ReturnSubtractedList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3, 1 };
            CustomList<int> numbers2 = new CustomList<int> { 1, 1 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(2, subtracted.Count);
        }
        [TestMethod]
        public void Subtract_OneSimilarityMultipleTimes_ReturnSubtractedList()
        {

            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3, 1, 1 };
            CustomList<int> numbers2 = new CustomList<int> { 1, 1 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(3, subtracted.Count);
        }
        [TestMethod]
        public void Subtract_NoSimilaritiesBetweenLists_ReturnSubtractedList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3, 4, 5 };
            CustomList<int> numbers2 = new CustomList<int> { 6, 7 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(5, subtracted.Count);
        }
        [TestMethod]
        public void Subtract_SecondListBigger_ReturnSubtractedList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3, 6, 7 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(0, subtracted.Count);
        }
        [TestMethod]
        public void Subtract_OneItemRemoved_IndexChanges()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3, 6, 7 };
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(6, subtracted[0]);
        }
        [TestMethod]
        public void Subtract_StringLists_ReturnSubtractedList()
        {
            CustomList<string> strings1 = new CustomList<string> { "hi", "word", "my", "name", "word", "is" };
            CustomList<string> strings2 = new CustomList<string> { "word" };
            CustomList<string> subtracted = strings1 - strings2;
            Assert.AreEqual("is", subtracted[4]);
        }
        [TestMethod]
        public void Subtract_EmptyList_ReturnsOriginalList()
        {
            CustomList<string> strings1 = new CustomList<string> { "hi", "word", "test" };
            CustomList<string> emptyList = new CustomList<string> { };
            CustomList<string> subtracted = strings1 - emptyList;
            Assert.AreEqual(3, subtracted.Count);
        }
        [TestMethod]
        public void Subtract_FromEmptyList_ReturnsEmptyList()
        {
            CustomList<int> numbers1 = new CustomList<int> { };
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(0, subtracted.Count);
        }
        [TestMethod]
        public void Subtract_FromItself_ReturnEmptyList()
        {
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> subtracted = numbers2 - numbers2;
            Assert.AreEqual(0, subtracted.Count);
        }

        [TestMethod]
        public void Subtract_MultipleLists_ReturnNewList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CustomList<int> numbers2 = new CustomList<int> { 1 };
            CustomList<int> numbers3 = new CustomList<int> { 8, 7 };
            CustomList<int> subtracted = numbers1 - numbers2 - numbers2 - numbers3;
            Assert.AreEqual(subtracted.Count, 14);
        }

        [TestMethod]
        public void Subtract_TwoLists_ConfirmFirstListUnchanged()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3, 6, 7 };
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(numbers1.Count,5);
        }

        [TestMethod]
        public void Subtract_TwoLists_ConfirmSecondListUnchanged()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3, 6, 7 };
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> subtracted = numbers1 - numbers2;
            Assert.AreEqual(numbers2.Count, 3);
        }


        [TestMethod]
        public void Zip_TwoListsOfSameLength_ReturnNewList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 3, 5 };
            CustomList<int> numbers2 = new CustomList<int> { 2, 4, 6 };
            CustomList<int> zipped = new CustomList<int> { };
            zipped.Zip(numbers1, numbers2);
            Assert.AreEqual(zipped[4], 5);
        }
        [TestMethod]
        public void Zip_TwoStringsDifferentLength_ReturnNewList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> numbers2 = new CustomList<int> { 6 };
            CustomList<int> zipped = new CustomList<int> { };
            zipped.Zip(numbers1, numbers2);
            CustomList<int> expected = new CustomList<int> { 1, 6, 2, 3 };
            Assert.AreEqual(expected[2], zipped[2]);
        }
        [TestMethod]
        public void Zip_OneEmptyString_ReturnSameList()
        {
            CustomList<int> numbers1 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> numbers2 = new CustomList<int> { };
            CustomList<int> zipped = new CustomList<int> { };
            zipped.Zip(numbers1, numbers2);
            CustomList<int> expected = new CustomList<int> { 1, 2, 3 };
            Assert.AreEqual(expected.Count, zipped.Count);
        }
        [TestMethod]
        public void Zip_FirstStringEmpty_ReturnEmptyString()
        {
            CustomList<int> numbers1 = new CustomList<int> { };
            CustomList<int> numbers2 = new CustomList<int> { 1, 2, 3 };
            CustomList<int> zipped = new CustomList<int> { };
            zipped.Zip(numbers1, numbers2);
            CustomList<int> expected = new CustomList<int> {1,2,3 };
            Assert.AreEqual(zipped.Count, expected.Count);
        }

        
        [TestMethod]
        public void Zip_TwoEmptyStrings_ReturnEmptyString()
        {
            CustomList<int> numbers1 = new CustomList<int> { };
            CustomList<int> numbers2 = new CustomList<int> { };
            CustomList<int> zipped = new CustomList<int> { };
            zipped.Zip(numbers1, numbers2);
            Assert.AreEqual(zipped.Count, 0);
        }
    }
}
