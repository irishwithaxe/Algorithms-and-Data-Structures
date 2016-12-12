using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures.Extensions {
   public static class ArrayExt {
      public static void Swap<T>(this T[] array, long i, long j) {
         T x = array[i];
         array[i] = array[j];
         array[j] = x;
      }

      public static void Swap<T>(this T[] array, int i, int j) {
         T x = array[i];
         array[i] = array[j];
         array[j] = x;
      }
   }
}
