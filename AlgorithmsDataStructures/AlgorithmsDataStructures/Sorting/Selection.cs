using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructures.Extensions;

namespace AlgorithmsDataStructures.Sorting
{
	public static class Selection
	{
		public static void Sort<T>(T[] array, Func<T, T, bool> isSorted)
		{
			long selected;

			for (long i = 0; i < array.LongLength - 1; i++)
			{
				selected = i;
				for (long j = i + 1; j < array.LongLength; j++)
					if (!isSorted(array[selected], array[j]))
						selected = j;

				if (selected != i)
					array.Replace(i, selected);
			}
		}
	}
}
