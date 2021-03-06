﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures.Sorting;

namespace UnitTestProject1 {
   [TestClass]
   public class TestInsertionSort {
      [TestMethod]
      public void TestEmpty() {
         var arr = new int[0];
         Insertion.Sort<int>(arr, (x1, x2) => x1 >= x2);
      }

      [TestMethod]
      public void TestShellRandomSort1() {
         var arr = ArrayGenerator.RandomArray1.GetCopy();
         Insertion.ShellSort(arr, ArrayGenerator.IsSortedFunc);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestShellRandomSort2() {
         var arr = ArrayGenerator.RandomArray2.GetCopy();
         Insertion.ShellSort(arr, ArrayGenerator.IsSortedFunc);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestShellSortedSort1() {
         var arr = ArrayGenerator.SortedArray1.GetCopy();
         Insertion.ShellSort(arr, ArrayGenerator.IsSortedFunc);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestShellSortedSort2() {
         var arr = ArrayGenerator.SortedArray2.GetCopy();
         Insertion.ShellSort(arr, ArrayGenerator.IsSortedFunc);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestBaseRandomSort1() {
         var arr = ArrayGenerator.RandomArray1.GetCopy();
         Insertion.Sort(arr, ArrayGenerator.IsSortedFunc);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestBaseRandomSort2() {
         var arr = ArrayGenerator.RandomArray2.GetCopy();
         Insertion.Sort(arr, ArrayGenerator.IsSortedFunc);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestBaseSortedSort1() {
         var arr = ArrayGenerator.SortedArray1.GetCopy();
         Insertion.Sort(arr, ArrayGenerator.IsSortedFunc);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }

      [TestMethod]
      public void TestBaseSortedSort2() {
         var arr = ArrayGenerator.SortedArray2.GetCopy();
         Insertion.Sort(arr, ArrayGenerator.IsSortedFunc);
         Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
         Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
      }
   }
}
