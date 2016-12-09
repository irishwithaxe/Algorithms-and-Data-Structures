using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructures;
using AlgorithmsDataStructures.Extensions;
using AlgorithmsDataStructures.Sorting;
using AlgorithmsDataStructures.DataStructures;

namespace Toster {
   public static class Program {
      static void Main(string[] args) {
         var length = 8L;

         "Started for arrey length {0}:\n".wl(length);

         var rnd = new Random();
         var etalon = length.MakeArray<int>().Fill(() => rnd.Next(1, 50));
         etalon.wl();

         var binheap = new BinaryHeap_onArray<int>(etalon, 100);
         binheap.ToArray().wl();

         binheap[6] = 55;
         binheap.ToArray().wl();

         //binheap.Add(rnd.Next(1, 50));
         //binheap.Add(rnd.Next(1, 50));
         //binheap.Add(rnd.Next(1, 50));
         //binheap.Add(rnd.Next(1, 50));
         //binheap.Add(rnd.Next(1, 50));
         //binheap.Add(rnd.Next(1, 50));
         //binheap.Add(rnd.Next(1, 50));
         //binheap.ToArray().wl();

         while (binheap.Length > 0) {
            "max is {0}".wl(binheap.GetMax());
            binheap.ToArray().wl();
         }

         Console.ReadKey();
      }

      private static void TimeCalc() {
         var length = 8000L;
         "Started for arrey length {0}\n".wl(length);

         var rnd = new Random();
         var etalon = length.MakeArray<int>().Fill(() => rnd.Next(-1000, 1000));
         var array = length.MakeArray<int>();
         Func<int, int, bool> isSorted = (x1, x2) => { return x1 <= x2; };

         etalon.CopyTo(array, 0L);
         if (!array.IsSorted(isSorted)) {
            "start bubble sort.".wlStart();
            BubbleSort.CocktailSort(array, isSorted);
            if (!array.IsSorted(isSorted))
               "NOT SORTED".wlStop();
            else
               "sorted.".wlStop();
         }

         etalon.CopyTo(array, 0L);
         if (!array.IsSorted(isSorted)) {
            "start simple insertion sort.".wlStart();
            Insertion.Sort(array, isSorted);
            if (!array.IsSorted(isSorted))
               "NOT SORTED".wlStop();
            else
               "sorted.".wlStop();
         }

         etalon.CopyTo(array, 0L);
         if (!array.IsSorted(isSorted)) {
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
