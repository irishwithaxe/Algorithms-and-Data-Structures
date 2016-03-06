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
	class Program
	{
		static void Main(string[] args)
		{
			"Started".wl();
			var arr = new int[100000];
			var rnd = new Random();
			arr.FillItems(() => rnd.Next(11, 99));

			"start insertion sort for arr length {0}".wlStart(arr.Length);
			Insertion.Sort(arr, (x, y) => x <= y);
			"sorted".wlStop();

			"press any key".wl();
			Console.ReadKey();
		}
	}
}
