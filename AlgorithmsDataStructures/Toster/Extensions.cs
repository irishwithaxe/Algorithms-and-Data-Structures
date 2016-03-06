using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Toster
{
	public static class Extensions
	{
		static Stopwatch timer;
		static Extensions()
		{
			timer = new Stopwatch();
			timer.Start();
		}

		public static void wlStart(this string format, params object[] args)
		{
			timer.Start();
			format.wl(args);
		}

		public static void wlStop(this string format, params object[] args)
		{
			timer.Stop();
			var info = string.Format(format, args);
			"{0} затрачено {1} сек".wl(info, Math.Round(timer.Elapsed.TotalSeconds, 2));
		}

		public static void wl(this string format, params object[] args)
		{
			var info = string.Format(format, args);
			Console.WriteLine(string.Format("[{0}] {1}", GetDTNow() ,info));
		}

		static string GetDTNow()
		{
			var now = DateTime.Now;
			return string.Format("{0}:{1,3}", now.ToLongTimeString(), now.Millisecond);
		}

		public static void wl<T>(this T[] array)
		{
			Console.Write(string.Format("[{0}] ", GetDTNow()));
			foreach (var item in array.Take(array.Length -1))
			{
				Console.Write(item.ToString());
				Console.Write(", ");
			}
			Console.WriteLine(array.Last());
		}
	}
}
