﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures.Extensions
{
	public static class ArrayExt
	{
		public static void FillItems<T> (this T[] array, Func<T> getValue)
		{
			for (long i = 0; i < array.LongLength; i++)
				array[i] = getValue();
		}
	}
}
