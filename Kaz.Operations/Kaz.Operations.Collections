using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaz.Operations.Collections
{
    /// <summary>
    /// Provides search algorithms for working with <see cref="IList{T}"/> collections.
    /// </summary>
    public static class Searching
    {
        /// <summary>
        /// Searches for the specified value in the <see cref="IList{T}"/> collection using linear search.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="value">The value to locate.</param>
        /// <returns>
        /// The index of the first matching element, or <see href="-1"/> if not found.
        /// </returns>
        public static int LinearSearch<T>(this IList<T> list, T value) where T : IEquatable<T>
        {
            if (list == null || list.Count == 0)
                return -1;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(value))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Searches for the specified value in the <see cref="IList{T}"/> collection using binary search.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="list">The sorted list to search.</param>
        /// <param name="value">The value to locate.</param>
        /// <returns>
        /// The index of the matching element, or <see href="-1"/> if not found.
        /// </returns>
        public static int BinarySearch<T>(this IList<T> list, T value) where T : IComparable<T>
        {
            if (list == null || list.Count == 0)
                return -1;

            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int cmp = value.CompareTo(list[mid]);

                if (cmp == 0)
                    return mid;

                if (cmp < 0)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        /// <summary>
        /// Searches for the specified integer value in the sorted list using interpolation search.
        /// </summary>
        /// <param name="list">The sorted list of integers.</param>
        /// <param name="value">The value to locate.</param>
        /// <returns>
        /// The index of the matching element, or <c>-1</c> if not found.
        /// </returns>
        public static int InterpolationSearch(this IList<int> list, int value)
        {
            if (list == null || list.Count == 0)
                return -1;

            int low = 0;
            int high = list.Count - 1;

            while (low <= high && value >= list[low] && value <= list[high])
            {
                if (low == high)
                    return list[low] == value ? low : -1;

                int pos = low + (value - list[low]) * (high - low) / (list[high] - list[low]);

                if (list[pos] == value)
                    return pos;

                if (list[pos] < value)
                    low = pos + 1;
                else
                    high = pos - 1;
            }

            return -1;
        }

    }

    /// <summary>
    /// Provides methods for sorting <see cref="IList{T}"/> collections.
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Sorts the elements in an <see cref="IList{T}"/> using the bubble sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The <see cref="IList{T}"/> to sort.</param>
        [Obsolete]
        public static void BubbleSort<T>(this IList<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count <= 1) return;

            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped) break;
            }
        }

        /// <summary>
        /// Sorts the elements in the <see cref="IList{T}"/> using the selection sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <param name="list">The <see cref="IList{T}"/> to sort.</param>
        [Obsolete]
        public static void SelectionSort<T>(this IList<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count <= 1) return;

            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (list[j].CompareTo(list[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    T temp = list[minIndex];
                    list[minIndex] = list[i];
                    list[i] = temp;
                }
            }
        }

        /// <summary>
        /// Sorts the elements in the <see cref="IList{T}"/> using the counting sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <param name="list">The <see cref="IList{T}"/> to sort.</param>
        /// <param name="keySelector">
        /// A function that extracts an integer key from each element. 
        /// </param>
        public static void CountingSort<T>(this IList<T> list, Func<T, int> keySelector)
        {
            if (list == null || list.Count <= 1)
                return;

            int count = list.Count;

            int min = keySelector(list[0]);
            int max = min;

            for (int i = 1; i < count; i++)
            {
                int key = keySelector(list[i]);
                if (key < min) min = key;
                if (key > max) max = key;
            }

            int range = max - min + 1;

            int[] counts = new int[range];

            for (int i = 0; i < count; i++)
            {
                int key = keySelector(list[i]) - min;
                counts[key]++;
            }

            for (int i = 1; i < range; i++)
            {
                counts[i] += counts[i - 1];
            }

            T[] output = new T[count];

            for (int i = count - 1; i >= 0; i--)
            {
                int key = keySelector(list[i]) - min;
                int position = --counts[key];
                output[position] = list[i];
            }

            for (int i = 0; i < count; i++)
            {
                list[i] = output[i];
            }
        }


        /// <summary>
        /// Sorts the elements in an <see cref="IList{T}"/> using the merge sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The <see cref="IList{T}"/> to sort.</param>
        public static void MergeSort<T>(this IList<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count <= 1) return;

            T[] array = new T[list.Count];
            list.CopyTo(array, 0);

            T[] aux = new T[list.Count];

            Sort(array, aux, 0, array.Length - 1);

            for (int i = 0; i < array.Length; i++)
                list[i] = array[i];
        }

        private static void Sort<T>(T[] array, T[] aux, int low, int high) where T : IComparable<T>
        {
            if (high <= low) return;

            int mid = low + (high - low) / 2;

            Sort(array, aux, low, mid);
            Sort(array, aux, mid + 1, high);

            Merge(array, aux, low, mid, high);
        }

        private static void Merge<T>(T[] array, T[] aux, int low, int mid, int high) where T : IComparable<T>
        {
            for (int k = low; k <= high; k++)
                aux[k] = array[k];

            int i = low;
            int j = mid + 1;

            for (int k = low; k <= high; k++)
            {
                if (i > mid) array[k] = aux[j++];
                else if (j > high) array[k] = aux[i++];
                else if (aux[j].CompareTo(aux[i]) < 0) array[k] = aux[j++];
                else array[k] = aux[i++];
            }
        }
    }
}
