using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures.Sorting;

namespace UnitTestProject1 {
   [TestClass]
   public class TestHoarSort {
      [TestMethod]
      public void TestEmpty() {
         var arr = new int[0];
         Hoar.Sort<int>(arr);
      }

      [TestMethod]
      public void TestRandomSort1() {
         var arr = ArrayGenerator.RandomArray1.GetCopy();
         //Hoar.Sort(arr);
         Hoar.QuickSort(arr);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestRandomSort2() {
         var arr = ArrayGenerator.RandomArray2.GetCopy();
         //Hoar.Sort(arr);
         Hoar.QuickSort(arr);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestSortedSort1() {
         var arr = ArrayGenerator.SortedArray1.GetCopy();
         //Hoar.Sort(arr);
         Hoar.QuickSort(arr);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestSortedSort2() {
         var arr = ArrayGenerator.SortedArray2.GetCopy();
         //Hoar.Sort(arr);
         Hoar.QuickSort(arr);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }
   }
}
