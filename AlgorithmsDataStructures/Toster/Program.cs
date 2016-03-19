using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructures;
using AlgorithmsDataStructures.Extensions;
using AlgorithmsDataStructures.Sorting;

namespace Toster
{
	public static class Program
	{
		static T[] MakeArray<T>(this long length) { return new T[length]; }
		static T[] Fill<T>(this T[] array, Func<T> getValue)
		{
			for (long i = 0; i < array.LongLength; i++)
				array[i] = getValue();
			return array;
		}

		static bool IsSorted<T>(this T[] array, Func<T, T, bool> isSorted)
		{
			for (long i = 0; i < array.LongLength - 1; i++)
				if (!isSorted(array[i], array[i + 1]))
					return false;

			return true;
		}

		static void Main(string[] args)
		{
			var length = 12L;
			"Started for arrey length {0}\n".wl(length);

			var rnd = new Random();
			var etalon = length.MakeArray<int>().Fill(() => rnd.Next(1, 9));
			var array = length.MakeArray<int>();
			Func<int, int, bool> isSorted = (x1, x2) => { return x1 <= x2; };

			etalon.CopyTo(array, 0L);
			BubbleSort.Sort(array, isSorted);

			etalon.wl();
			array.wl();

			Console.ReadKey();

			//TimeCalc();
		}

		private static void TimeCalc()
		{
			var length = 8000L;
			"Started for arrey length {0}\n".wl(length);

			var rnd = new Random();
			var etalon = length.MakeArray<int>().Fill(() => rnd.Next(-1000, 1000));
			var array = length.MakeArray<int>();
			Func<int, int, bool> isSorted = (x1, x2) => { return x1 <= x2; };

			etalon.CopyTo(array, 0L);
			if (!array.IsSorted(isSorted))
			{
				"start bubble sort.".wlStart();
				BubbleSort.CocktailSort(array, isSorted);
				if (!array.IsSorted(isSorted))
					"NOT SORTED".wlStop();
				else
					"sorted.".wlStop();
			}

			etalon.CopyTo(array, 0L);
			if (!array.IsSorted(isSorted))
			{
				"start simple insertion sort.".wlStart();
				Insertion.Sort(array, isSorted);
				if (!array.IsSorted(isSorted))
					"NOT SORTED".wlStop();
				else
					"sorted.".wlStop();
			}

			etalon.CopyTo(array, 0L);
			if (!array.IsSorted(isSorted))
			{
				"start simple selection sort.".wlStart();
				Selection.Sort(array, isSorted);
				if (!array.IsSorted(isSorted))
					"NOT SORTED".wlStop();
				else
					"sorted.".wlStop();
			}

			"\npress any key".wl();
			Console.ReadKey();
		}
	}
}
