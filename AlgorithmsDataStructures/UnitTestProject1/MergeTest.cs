using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
   [TestClass]
   public class MergeTest {

      [TestMethod]
      public void BaseMergeTest() {
         var rnd = new Random();
         var experimentlength = 100;

         var issorted = new bool[experimentlength];
         var etalon = new bool[experimentlength];
         for (var i = 0; i < etalon.Length; i++) etalon[i] = true;

         for (var i = 0; i < experimentlength; i++) {
            var arr1 = new double[rnd.Next(experimentlength)].RandomFill(rnd);
            var arr2 = new double[rnd.Next(experimentlength)].RandomFill(rnd);

            AlgorithmsDataStructures.Sorting.Heapsort.Sort(arr1);
            AlgorithmsDataStructures.Sorting.Heapsort.Sort(arr2);

            var arr = new double[arr1.Length + arr2.Length];
            int j = 0;
            foreach (var item in arr1)
               arr[j++] = item;
            foreach (var item in arr2)
               arr[j++] = item;

            AlgorithmsDataStructures.Sorting.MergeSort.MergeDescending(arr, 0, arr1.Length - 1, arr1.Length, arr.Length - 1);
            issorted[i] = arr.IsSorted(ArrayGenerator.IsSortedFunc);
         }

         CollectionAssert.AreEqual(issorted, etalon);
      }
   }
}
