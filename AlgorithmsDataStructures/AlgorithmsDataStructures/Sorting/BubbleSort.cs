using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructures.Extensions;

namespace AlgorithmsDataStructures.Sorting
{
	public static class BubbleSort
	{
		public static void Sort<T>(T[] array, Func<T, T, bool> isSorted)
		{
			bool hasReplace = true;
			long start, end, leftreplace, rightreplace;

			start = 0;
			leftreplace = 0;
			rightreplace = array.LongLength;

			while (hasReplace)
			{
				hasReplace = false;

				// <<<
				end = rightreplace;
				for (long i = end - 1; i > start; i--)
					if (!isSorted(array[i - 1], array[i]))
					{
						hasReplace = true;
						leftreplace = i;
						array.Replace(i - 1, i);
					}

				// >>>
				start = leftreplace;
				for (long i = start + 1; i < end; i++)
					if (!isSorted(array[i - 1], array[i]))
					{
						hasReplace = true;
						rightreplace = i;
						array.Replace(i - 1, i);
					}
			}
		}
	}
}
