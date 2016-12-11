using AlgorithmsDataStructures.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures.DataStructures {
   public class BinaryHeap_onArray<T> where T : IComparable {
      private readonly T[] data;

      public T[] ToArray() {
         var arr = new T[Length];
         Array.Copy(data, arr, Length);
         return arr;
      }

      public int Length { get; private set; }

      public T this[int index] {
         get { return data[index]; }
         set {
            var old = data[index];
            data[index] = value;

            if (old.CompareTo(value) < 0)
               SiftUp(index);
            else
               SiftDown(index);
         }
      }

      public T GetMax() {
         var max = data[0];
         data[0] = data[Length - 1];
         Length--;
         SiftDown(0);
         return max;
      }

      public void Add(T value) {
         data[Length] = value;
         Length++;
         SiftUp(Length - 1);
      }

      public BinaryHeap_onArray(T[] rawdata, int capacity) {
         if (rawdata.Length > capacity)
            data = rawdata;
         else
            data = new T[capacity];

         Length = rawdata.Length;
         rawdata.CopyTo(data, 0);

         for (var currentIndex = Length / 2; currentIndex >= 0; currentIndex--)
            SiftDown(currentIndex);
      }

      private bool TryGetLeftOf(int index, out int leftIndex, out T left) {
         left = default(T);
         leftIndex = index * 2 + 1;
         if (leftIndex >= Length)
            return false;

         left = data[leftIndex];
         return true;
      }

      public bool TryGetRightOf(int index, out int rightIndex, out T right) {
         right = default(T);
         rightIndex = index * 2 + 2;
         if (rightIndex >= Length)
            return false;

         right = data[rightIndex];
         return true;
      }

      public void SiftUp(int index) {
         if (index == 0 || index >= Length)
            return;

         int parentIndex = (index - 1) / 2;
         if (data[parentIndex].CompareTo(data[index]) >= 0)
            return;

         data.Swap(parentIndex, index);
         SiftUp(parentIndex);
      }

      public void SiftDown(int index) {
         T right, left;
         int rightIndex, leftIndex;

         if (index >= Length)
            return;

         T max = data[index];
         int maxIndex = index;

         if (TryGetLeftOf(index, out leftIndex, out left) && max.CompareTo(left) < 0) {
            max = left;
            maxIndex = leftIndex;
         }

         if (TryGetRightOf(index, out rightIndex, out right) && max.CompareTo(right) < 0) {
            max = right;
            maxIndex = rightIndex;
         }

         if (maxIndex == index)
            return;

         data.Swap(index, maxIndex);
         SiftDown(maxIndex);
      }
   }
}
