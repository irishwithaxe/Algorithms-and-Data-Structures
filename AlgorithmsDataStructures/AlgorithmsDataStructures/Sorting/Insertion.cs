using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructures.Extensions;

namespace AlgorithmsDataStructures.Sorting
{
	public static class Insertion
	{
		public static void Sort<T>(T[] array, Func<T, T, bool> isSorted)
		{
			long i, current;
			for (i = 1; i < array.LongLength; i++)
			{
				current = i;

				while (current > 0 && !isSorted(array[current - 1], array[current]))
					array.Replace(current - 1, current--);
			}
		}
	}
}
