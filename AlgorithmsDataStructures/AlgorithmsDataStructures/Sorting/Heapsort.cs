using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructures.DataStructures;

namespace AlgorithmsDataStructures.Sorting {
   public static class Heapsort {
      public static void Sort<T>(T[] array) where T : IComparable {
         var heap = new BinaryHeap_onArray<T>(array, array.Length);

         var i = array.Length - 1;
         while (heap.Length > 0)
            array[i--] = heap.MaxExtract();
      }
   }
}
