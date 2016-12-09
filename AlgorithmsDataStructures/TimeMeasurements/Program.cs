using AlgorithmsDataStructures.Sorting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toster;

namespace TimeMeasurements {
   class Program {
      static long length = 15000L;
      static CancellationTokenSource _cts = new CancellationTokenSource();

      static void Main(string[] args) {
         var task = Task.Factory.StartNew(() => {
            long iteratin = 1L;

            "arrey length {0}.   {1} iteration. press any key to exit. \n".wl(length, iteratin++);
            var times = MakeMeasure(_cts.Token);

            foreach (var t in times)
               "{0}: {1} ms".wl(t.SortName, TimeSpan.FromTicks(t.Ticks).TotalMilliseconds);

            while (!_cts.IsCancellationRequested) {
               var times1 = MakeMeasure(_cts.Token);
               Console.Clear();

               "arrey length {0}.   {1} iteration. press any key to exit. \n".wl(length, iteratin++);

               for (int i = 0; i < times.Length; i++)
                  times[i].Ticks = (times[i].Ticks + times1[i].Ticks) / 2;

               foreach (var t in times)
                  "{0}: {1} ms".wl(t.SortName, TimeSpan.FromTicks(t.Ticks).TotalMilliseconds);
            }
         }, _cts.Token);

         Console.ReadKey(true);
         _cts.Cancel();
         try { task.Wait(); }
         catch { };

         "cancelled".wl();
      }

      private static SortMeasure[] MakeMeasure(CancellationToken ct) {
         var rnd = new Random();
         var etalon = length.MakeArray<double>().Fill(() => rnd.NextDouble());
         var array = length.MakeArray<double>();
         Func<double, double, bool> isSorted = (x1, x2) => { return x1 <= x2; };
         var watcher = new Stopwatch();

         Func<Action, TimeSpan> _makeSort = (sort) => {
            ct.ThrowIfCancellationRequested();

            etalon.CopyTo(array, 0L);

            watcher.Reset();
            watcher.Start();
            sort();
            watcher.Stop();

            if (!array.IsSorted(isSorted))
               throw new ArgumentException("NOT SORTED");

            return watcher.Elapsed;
         };

         var times = new List<SortMeasure>();
         times.Add(new SortMeasure("BubbleSort.CocktailSort ", _makeSort(() => BubbleSort.CocktailSort(array, isSorted)).Ticks));
         times.Add(new SortMeasure("BubbleSort.Sort         ", _makeSort(() => BubbleSort.Sort(array, isSorted)).Ticks));
         times.Add(new SortMeasure("Insertion.Sort          ", _makeSort(() => Insertion.Sort(array, isSorted)).Ticks));
         times.Add(new SortMeasure("Insertion.ShellSort     ", _makeSort(() => Insertion.ShellSort(array, isSorted)).Ticks));
         times.Add(new SortMeasure("Selection.Sort          ", _makeSort(() => Selection.Sort(array, isSorted)).Ticks));

         return times.ToArray();
      }

      class SortMeasure {
         public SortMeasure(string sortName, long ticks) {
            SortName = sortName;
            Ticks = ticks;
         }
         public long Ticks;
         public string SortName;
      }
   }
}
