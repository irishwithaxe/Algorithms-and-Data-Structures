using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsDataStructures.Extensions;

namespace AlgorithmsDataStructures.Sorting {
   public static class Hoar {
      // спёртая реализация, тоже не работает
      public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> list) where T : IComparable<T> {
         if (!list.Any()) {
            return Enumerable.Empty<T>();
         }
         var pivot = list.First();
         var smaller = list.Skip(1).Where(item => item.CompareTo(pivot) <= 0).QuickSort();
         var larger = list.Skip(1).Where(item => item.CompareTo(pivot) > 0).QuickSort();

         return smaller.Concat(new[] { pivot }).Concat(larger);
      }

      private static void SortInternal<T>(T[] array, int start, int end) where T : IComparable {
         if (start >= end)
            return;

         int left = start;
         int right = end;

         var basis = array[(start + end) / 2];

         while (left < right) {
            while (array[left].CompareTo(basis) < 0 && left < right)
               left++;
            while (basis.CompareTo(array[right]) < 0 && left < right)
               right--;

            if (left != right)
               array.Swap(left, right);

            left++;
            right--;
         }

         int mid = (left + right) / 2;
         SortInternal(array, start, right);
         SortInternal(array, left, end);
      }

      public static void Sort<T>(T[] array) where T : IComparable {
         SortInternal(array, 0, array.Length - 1);
      }
   }
}
