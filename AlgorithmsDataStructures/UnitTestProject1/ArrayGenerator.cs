using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
	[TestClass]
	public class ArrayGeneratorTest
	{
		[TestMethod]
		public void LengthTest()
		{
			Assert.AreEqual(ArrayGenerator.RandomArray1.LongLength, ArrayGenerator.Length);
			Assert.AreEqual(ArrayGenerator.RandomArray2.LongLength, ArrayGenerator.Length);
			Assert.AreEqual(ArrayGenerator.SortedArray1.LongLength, ArrayGenerator.Length);
			Assert.AreEqual(ArrayGenerator.SortedArray2.LongLength, ArrayGenerator.Length);
		}

		[TestMethod]
		public void IsSortedTest()
		{
			var issorted1 = ArrayGenerator.RandomArray1.IsSorted(ArrayGenerator.IsSortedFunc);
			var issorted2 = ArrayGenerator.RandomArray2.IsSorted(ArrayGenerator.IsSortedFunc);
			var issorted3 = ArrayGenerator.SortedArray1.IsSorted(ArrayGenerator.IsSortedFunc);
			var issorted4 = ArrayGenerator.SortedArray2.IsSorted(ArrayGenerator.IsSortedFunc);

			Assert.IsFalse(issorted1);
			Assert.IsFalse(issorted2);
			Assert.AreNotEqual(issorted3, issorted4);
		}
	}

	public static class ArrayGenerator
	{
		public static readonly long Length = 900L;

		public static double[] RandomArray1 { get; private set; }
		public static double[] RandomArray2 { get; private set; }
		public static double[] SortedArray1 { get; private set; }
		public static double[] SortedArray2 { get; private set; }

		static T[] MakeArray<T>(this long length) { return new T[length]; }

		static T[] Fill<T>(this T[] array, Func<T> getValue)
		{
			for (long i = 0; i < array.LongLength; i++)
				array[i] = getValue();
			return array;
		}

		public static Func<double, double, bool> IsSortedFunc = (x1, x2) => { return x1 <= x2; };

		public static bool IsSorted<T>(this T[] array, Func<T, T, bool> isSorted)
		{
			for (long i = 0; i < array.LongLength - 1; i++)
				if (!isSorted(array[i], array[i + 1]))
					return false;

			return true;
		}

		public static T[] GetCopy<T>(this T[] array)
		{
			var copyed = array.LongLength.MakeArray<T>();
			array.CopyTo(copyed, 0L);
			return copyed;
		}

		static ArrayGenerator()
		{
			var rnd = new Random();

			RandomArray1 = Length.MakeArray<double>().Fill(() => rnd.Next(-1000, 1000) * rnd.NextDouble());
			RandomArray2 = Length.MakeArray<double>().Fill(() => rnd.Next(-1000, 1000) * rnd.NextDouble());

			SortedArray1 = Length.MakeArray<double>();
			for (var i = 0L; i < Length; i++) SortedArray1[i] = 0.01 * (i + 0.5);

			SortedArray2 = Length.MakeArray<double>();
			for (var i = 0L; i < Length; i++) SortedArray2[i] = 0.01 * ((Length - i) + 0.5);
		}
	}
}
