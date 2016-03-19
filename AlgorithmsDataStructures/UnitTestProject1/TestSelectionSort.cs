using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures.Sorting;

namespace UnitTestProject1
{
	[TestClass]
	public class TestSelectionSort
	{
		[TestMethod]
		public void TestEmpty()
		{
			var arr = new int[0];
			Selection.Sort<int>(arr, (x1, x2) => x1 >= x2);
		}

		[TestMethod]
		public void TestBaseRandomSort1()
		{
			var arr = ArrayGenerator.RandomArray1.GetCopy();
			Selection.Sort(arr, ArrayGenerator.IsSortedFunc);
			Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
			Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
		}

		[TestMethod]
		public void TestBaseRandomSort2()
		{
			var arr = ArrayGenerator.RandomArray2.GetCopy();
			Selection.Sort(arr, ArrayGenerator.IsSortedFunc);
			Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
			Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
		}

		[TestMethod]
		public void TestBaseSortedSort1()
		{
			var arr = ArrayGenerator.SortedArray1.GetCopy();
			Selection.Sort(arr, ArrayGenerator.IsSortedFunc);
			Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
			Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
		}

		[TestMethod]
		public void TestBaseSortedSort2()
		{
			var arr = ArrayGenerator.SortedArray2.GetCopy();
			Selection.Sort(arr, ArrayGenerator.IsSortedFunc);
			Assert.AreEqual(arr.LongLength, ArrayGenerator.Length);
			Assert.IsTrue(arr.IsSorted(ArrayGenerator.IsSortedFunc));
		}
	}
}
