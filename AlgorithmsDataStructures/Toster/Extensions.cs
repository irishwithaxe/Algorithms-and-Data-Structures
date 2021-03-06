﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Toster {
   public static class Extensions {
      static Stopwatch timer;
      static Extensions() {
         timer = new Stopwatch();
         timer.Start();
      }

      public static void wlStart(this string format, params object[] args) {
         timer.Start();
         format.wl(args);
      }

      public static void wlStop(this string format, params object[] args) {
         timer.Stop();
         var info = string.Format(format, args);
         "{0} затрачено {1} сек".wl(info, Math.Round(timer.Elapsed.TotalSeconds, 2));
      }

      public static void wl(this string format, params object[] args) {
         var info = string.Format(format, args);
         Console.WriteLine(string.Format("[{0}] {1}", GetDTNow(), info));
      }

      public static string GetDTNow() {
         var now = DateTime.Now;
         return string.Format("{0}:{1,3}", now.ToLongTimeString(), now.Millisecond);
      }

      public static void wl<T>(this T[] array) {
         Console.Write(string.Format("[{0}] ", GetDTNow()));

         if (array.Length == 0) {
            Console.WriteLine("array is empty");
            return;
         }

         foreach (var item in array.Take(array.Length - 1)) {
            Console.Write(item.ToString());
            Console.Write(", ");
         }
         Console.WriteLine(array.Last());
      }

      public static T[] MakeArray<T>(this long length) { return new T[length]; }

      public static T[] Fill<T>(this T[] array, Func<T> getValue) {
         for (long i = 0; i < array.LongLength; i++)
            array[i] = getValue();
         return array;
      }

      public static bool IsSorted<T>(this T[] array, Func<T, T, bool> isSorted) {
         for (long i = 0; i < array.LongLength - 1; i++)
            if (!isSorted(array[i], array[i + 1]))
               return false;

         return true;
      }

   }
}
