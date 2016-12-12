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
   public class Program {
      static long length = 50L;
      static CancellationTokenSource _cts = new CancellationTokenSource();

      static long iteration = 1L;
      static Dictionary<string, FinalSortMeasure> measure = new Dictionary<string, FinalSortMeasure>();

      public static void Main(string[] args) {
         var times = MakeMeasure(_cts.Token);
         iteration++;
         foreach (var time in times) measure.Add(time.SortName, new FinalSortMeasure(time));
         Print(measure);

         var tasks = new Task[3];
         for (int i = 0; i < tasks.Length; i++)
            tasks[i] = Task.Factory.StartNew(RunMeasures, _cts.Token);

         var timer = new Timer((obj) => { lock (measure) Print(measure); }, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

         Console.ReadKey(true);

         timer.Dispose();
         _cts.Cancel();

         foreach (var task in tasks)
            try { task.Wait(); } catch { };

         "cancelled".wl();
      }

      private static void RunMeasures() {
         while (!_cts.IsCancellationRequested) {
            var times = MakeMeasure(_cts.Token);
            iteration++;
            lock (measure) {
               foreach (var time in times) measure[time.SortName].Ticks = time.Ticks;
               //Print(measure);
            }
         }
      }

      private static void Print(Dictionary<string, FinalSortMeasure> measure) {
         Console.Clear();
         "arrey length {0}.   {1} iteration. press any key to exit. \n".wl(length, iteration);
         foreach (var t in measure.Values.OrderBy(x => x.Ticks))
            "{0}: {1:F4} ms; min {2:F4} ms; max: {3:F4} ms".wl(t.SortName,
               TimeSpan.FromTicks(t.Ticks).TotalMilliseconds,
               TimeSpan.FromTicks(t.TicksMin).TotalMilliseconds,
               TimeSpan.FromTicks(t.TicksMax).TotalMilliseconds);
      }

      private static SortMeasure[] MakeMeasure(CancellationToken ct) {
         var rnd = new Random();
         var etalon = length.MakeArray<double>().Fill(() => rnd.NextDouble());
         var array = length.MakeArray<double>();
         Func<double, double, bool> isSorted = (x1, x2) => { return x1 <= x2; };
         var watcher = new Stopwatch();

         Func<Action, TimeSpan> _makeSort = (sort) => {
            if (ct.IsCancellationRequested)
               return TimeSpan.FromSeconds(0);

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
         times.Add(new SortMeasure("Heapsort.Sort           ", _makeSort(() => Heapsort.Sort(array)).Ticks));
         times.Add(new SortMeasure("MergeSort.Sort          ", _makeSort(() => MergeSort.SortDescending(array)).Ticks));

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

      class FinalSortMeasure {
         public FinalSortMeasure(SortMeasure measure) {
            SortName = measure.SortName;
            TicksMax = measure.Ticks;
            TicksMin = measure.Ticks;
            Ticks = measure.Ticks;
            n = 1;
         }

         public double TicksSum;
         public long Ticks {
            get { return Convert.ToInt64(TicksSum / n); }
            set {
               TicksMax = TicksMax < value ? value : TicksMax;
               TicksMin = TicksMin > value ? value : TicksMin;
               TicksSum += value;
               n++;
            }
         }
         public long TicksMin;
         public long TicksMax;
         public long n = 0;
         public string SortName;
      }
   }
}
