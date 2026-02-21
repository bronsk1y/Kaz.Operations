using System;
using Kaz.Operations.Core;
using System.Collections.Generic;
using System.Globalization;

namespace Kaz.Operations.Text
{
    /// <summary>
    /// Предоставляет методы для проверки строковых данных на соответствие заданным правилам.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверяет строку на корректность и удаляет из неё все пробельные символы.
        /// </summary>
        /// <param name="input">Исходная строка для обработки.</param>
        /// <returns>Строка без пробелов, если исходная строка была валидной.</returns>
        /// <exception cref="StringValidationException">
        /// Вызывается, если <paramref name="input"/> равен <c>null</c>, пуст или состоит только из пробелов.
        /// </exception>
        public static string ValidateString(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
                return input.Replace(" ", "");
            else
                throw new StringValidationException("The string cannot be empty or contain only spaces.");
        }

        /// <summary>
        /// Пытается проверить строку на корректность и удалить из неё все пробелы.
        /// </summary>
        /// <param name="input">Исходная строка для обработки.</param>
        /// <param name="result">
        /// При успешном выполнении содержит строку без пробелов; 
        /// в противном случае — пустую строку <see cref="string.Empty"/>.
        /// </param>
        /// <returns>
        /// <c>true</c>, если исходная строка содержит значимые символы; 
        /// <c>false</c>, если строка была <c>null</c>, пустой или состояла только из пробелов.
        /// </returns>
        public static bool TryValidateString(this string input, out string result)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                result = input.Replace(" ", "");
                return true;
            }

            result = string.Empty;
            return false;
        }
    }
}

namespace Kaz.Operations.Numerics
{
    /// <summary>
    /// Предоставляет методы для безопасного преобразования числовых значений между различными типами.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Преобразует строку в число, используя инвариантную культуру.
        /// Если преобразование невозможно, возвращает значение по умолчанию.
        /// </summary>
        /// <typeparam name="T">Числовой тип (например, int, double).</typeparam>
        /// <param name="input">Строка для конвертации.</param>
        /// <param name="defaultValue">Значение, которое вернется при ошибке.</param>
        /// <returns>Преобразованное число или <paramref name="defaultValue"/>.</returns>
        public static T ToNumericOrDefault<T>(this string input, T defaultValue = default) where T : struct
        {
            if (TryParse(input, out T result))
            {
                return result;
            }
            return defaultValue;
        }

        private static bool TryParse<T>(string input, out T result) where T : struct
        {
            string cleanInput = input?.Trim() ?? string.Empty;

            try
            {
                result = (T)Convert.ChangeType(cleanInput, typeof(T), CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}

namespace Kaz.Operations.Collections
{
    /// <summary>
    /// Предоставляет операции по сортировке коллекций.
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Выполняет сортировку элементов в указанном <see cref="IList{T}"/> методом простых обменов.
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции. Должен реализовывать <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="list">Коллекция <see cref="IList{T}"/> для сортировки.</param>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// Выполняет сортировку элементов в указанном <see cref="IList{T}"/> методом деления коллекции на отсортировнную и неотсортированную части.
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции. Должен реализовывать <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="list">Коллекция <see cref="IList{T}"/> для сортировки.</param>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// Рекурсивно делит коллекцию реализующую <see cref="IList{T}"/> пополам, сортирует половины и сливает их обратно.
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции. Должен реализовывать <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="list">Коллекция для сортировки.</param>
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

