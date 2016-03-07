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
		static long length = 100000;
		static int[] GetArr() { return new int[length]; }
		
		static void Main(string[] args)
		{
			"Started for arrey length {0}".wl(length);
			var etalon = GetArr();
			var array = GetArr();
			var rnd = new Random();
			etalon.FillItems(() => rnd.Next(-1000, 1000));

			etalon.CopyTo(array, 0L);
			"start simple insertion sort.".wlStart();
			Insertion.Sort(array, (x, y) => x <= y);
			"sorted.".wlStop();

			etalon.CopyTo(array, 0L);
			"start simple selection sort.".wlStart();
			Selection.Sort(array, (x,y) => x<= y);
			"sorted.".wlStop();

			"\npress any key".wl();
			Console.ReadKey();
		}
	}
}
