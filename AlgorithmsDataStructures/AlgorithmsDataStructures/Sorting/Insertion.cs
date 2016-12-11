using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructures.Extensions;

namespace AlgorithmsDataStructures.Sorting {
   public static class Insertion {
      private static void SortInternal<T>(T[] array, Func<T, T, bool> isSorted, long start, long basis) {
         long i, current;
         for (i = start + basis; i < array.LongLength; i += basis) {
            current = i;

            while (current > start && !isSorted(array[current - basis], array[current])) {
               array.Swap(current - basis, current);
               current -= basis;
            }
         }
      }

      public static void Sort<T>(T[] array, Func<T, T, bool> isSorted) {
         SortInternal(array, isSorted, 0, 1);
      }

      public static long[] ShellSortBasisHibard(long length) {
         var current = 1L;
         var res = new List<long>();

         for (var i = 2L; current < length; i++) {
            res.Add(current);
            current = Convert.ToInt64(Math.Pow(2, i) - 1);
         }

         return res.ToArray();
      }

      public static void ShellSort<T>(T[] array, Func<T, T, bool> isSorted) {
         var basisarray = ShellSortBasisHibard(array.LongLength);

         for (var b = basisarray.Length - 1; b >= 0; b--) {
            var basis = basisarray[b];
            for (var start = 0L; start < basis; start++) {
               SortInternal(array, isSorted, start, basis);
            }
         }
      }

   }
}
