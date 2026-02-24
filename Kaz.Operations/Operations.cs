using Kaz.Operations.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Kaz.Operations.Text
{
    /// <summary>
    /// Provides methods for string manipulation and editing.
    /// </summary>
    public static class Editing
    {
        /// <summary>
        /// Reverses the sequence of characters in the specified string.
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>Returns a reversed string, or the original string if it is <see langword="null"/> or empty.</returns>
        public static string Reverse(this string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return input;

            var sb = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }    
            
            return sb.ToString();
        }

        /// <summary>
        /// Removes all white-space characters from the specified string.
        /// </summary>
        /// <param name="input">The <see cref="string"/> to process.</param>
        /// <returns>
        /// Returns a string that is equivalent to <paramref name="input"/> where all white-space 
        /// characters have been removed.
        /// </returns>
        public static string RemoveWhiteSpaces(this string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return input;

            return Regex.Replace(input, @"\s+", "");
        }

        /// <summary>
        /// Extracts numeric values from the specified string according to the selected
        /// <see cref="NumberExtractionOptions"/> and concatenates them into a single result string.
        /// </summary>
        /// <param name="input">
        /// The source string from which numeric values will be extracted.
        /// </param>
        /// <param name="options">
        /// A value of <see cref="NumberExtractionOptions"/> that specifies the type of numeric
        /// patterns to extract. The default option is <see cref="NumberExtractionOptions.Digits"/>.
        /// </param>
        /// <returns>
        /// A string containing all extracted numeric values concatenated in the order they appear
        /// in the input. If <paramref name="input"/> is <see langword="null"/> or empty, the method
        /// returns the original value.
        /// </returns>
        public static List<string> ExtractAllNumbers(this string input, NumberExtractionOptions options = NumberExtractionOptions.Digits)
        {
            if (string.IsNullOrEmpty(input))
                return new List<string>();

            string pattern = options switch
            {
                NumberExtractionOptions.Digits => @"\d+",
                NumberExtractionOptions.Decimals => @"[-+]?\d*\.?\d+",
                NumberExtractionOptions.Scientific => @"[-+]?\d*\.?\d+(?:[eE][-+]?\d+)?",
                _ => @"\d+"
            };

            var matches = Regex.Matches(input, pattern);
            var result = new List<string>();

            foreach (Match match in matches)
            {
                result.Add(match.Value);
            }

            return result;
        }


        /// <summary>
        /// Extracts all substrings from the specified input that match the provided
        /// <see cref="Regex"/> pattern and concatenates them into a single result string.
        /// </summary>
        /// <param name="input">
        /// The source string to search for pattern matches. If the value is
        /// <see langword="null"/> or empty, the method returns the original value.
        /// </param>
        /// <param name="pattern">
        /// A <see cref="Regex"/> instance that defines the pattern used to identify
        /// matching substrings within <paramref name="input"/>.
        /// </param>
        /// <returns>
        /// A string containing all matched substrings concatenated in the order they
        /// appear in <paramref name="input"/>. If no matches are found, an empty string
        /// is returned.
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ExtractPattern(this string input, Regex pattern)
        {
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            if (string.IsNullOrEmpty(input))
                return input;

            var matches = pattern.Matches(input);
            if (matches.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (Match match in matches)
            {
                sb.Append(match.Value);
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Provides methods for validating string data.
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Determines whether the string contains only Unicode letters and spaces.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><see langword="true"/> if the string is alphabetic; otherwise, <see langword="false"/>.</returns>
        public static bool IsAlpha(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^[\p{L} ]+$");
        }

        /// <summary>
        /// Determines whether the string represents a valid numeric format.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><see langword="true"/> if the string is numeric; otherwise, <see langword="false"/>.</returns>
        public static bool IsNumeric(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) 
                return false; 
            
            return Regex.IsMatch(input, @"^[+-]?\d*\.?\d+$");
        }

        /// <summary>
        /// Determines whether the string represents a boolean value.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><see langword="true"/> if the string is a recognized boolean representation; otherwise, <see langword="false"/>.</returns>
        public static bool IsBoolean(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^(?i:true|false|0|1)$");
        }

        /// <summary>
        /// Validates whether the string conforms to a standard email address format.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><see langword="true"/> if the format is valid; otherwise, <see langword="false"/>.</returns>
        public static bool IsEmail(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
        }

        /// <summary>
        /// Validates whether the string conforms to the international E.164 phone number format.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns><see langword="true"/> if the format is valid; otherwise, <see langword="false"/>.</returns>
        public static bool IsPhoneNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^\+[1-9]\d{7,14}$");

        }

        /// <summary>
        /// Determines whether the string matches the specified regular expression pattern.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns><see langword="true"/> if a match is found; otherwise, <see langword="false"/>.</returns>
        public static bool MatchesPattern(this string input, string pattern)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// Determines whether the string matches the specified regular expression pattern using provided options.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <param name="options">The <see cref="RegexOptions"/> to apply.</param>
        /// <returns><see langword="true"/> if a match is found; otherwise, <see langword="false"/>.</returns>
        public static bool MatchesPattern(this string input, string pattern, RegexOptions options = RegexOptions.None)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, pattern, options | RegexOptions.CultureInvariant);
        }
    }
}

namespace Kaz.Operations.Numerics
{
    /// <summary> 
    /// Provides culture-invariant conversion of string values into numeric types.
    /// </summary>
    public static class Conversion
    {
        /// <summary> 
        /// Converts the specified string to a numeric value of type <typeparamref name="T"/>, 
        /// returning the provided default value if the conversion fails. 
        /// </summary> 
        /// <typeparam name="T">  
        /// The numeric type to convert to. Supported types include: 
        /// <see cref="int"/>, <see cref="long"/>, <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>, <see cref="short"/>,  and <see cref="byte"/>. 
        /// </typeparam> 
        /// <param name="input">The string representation of the numeric value.</param> 
        /// <param name="defaultValue">The value to return if the conversion is unsuccessful.</param>
        /// <returns>The parsed numeric value if successful; otherwise, <paramref name="defaultValue"/>. 
        /// </returns>
        public static T ToNumericOrDefault<T>(this string input, T defaultValue = default) where T : struct
        {
            if (TryParseNumeric(input, out T result))
                return result;

            return defaultValue;
        }

        private static bool TryParseNumeric<T>(string input, out T result) where T : struct
        {
            result = default;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            string clean = input.Trim();
            Type t = typeof(T);

            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Int32:
                    if (int.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out int i32))
                    {
                        result = (T)(object)i32;
                        return true;
                    }
                    break;

                case TypeCode.Int64:
                    if (long.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out long i64))
                    {
                        result = (T)(object)i64;
                        return true;
                    }
                    break;

                case TypeCode.Single:
                    if (float.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out float f))
                    {
                        result = (T)(object)f;
                        return true;
                    }
                    break;

                case TypeCode.Double:
                    if (double.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out double d))
                    {
                        result = (T)(object)d;
                        return true;
                    }
                    break;

                case TypeCode.Decimal:
                    if (decimal.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dec))
                    {
                        result = (T)(object)dec;
                        return true;
                    }
                    break;

                case TypeCode.Int16:
                    if (short.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out short i16))
                    {
                        result = (T)(object)i16;
                        return true;
                    }
                    break;

                case TypeCode.Byte:
                    if (byte.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out byte b))
                    {
                        result = (T)(object)b;
                        return true;
                    }
                    break;
            }

            return false;
        }
    }

    /// <summary>
    /// Provides mathematical methods for numeric types.
    /// </summary>
    public static class MathOperations
    {
        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        /// <typeparam name="T">The type of the value to clamp.</typeparam>
        /// <param name="value">The value to restrict.</param>
        /// <param name="minValue">The inclusive lower bound.</param>
        /// <param name="maxValue">The inclusive upper bound.</param>
        /// <returns>The clamped value if it's within the range; otherwise, the nearest bound.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static T Clamp<T>(this T value, T minValue, T maxValue) where T : IComparable<T>
        {
            if (minValue.CompareTo(maxValue) > 0)
                throw new ArgumentException();
                 
            if (value.CompareTo(minValue) < 0) return minValue;
            if (value.CompareTo(maxValue) > 0) return maxValue;
            return value;   
        }

        /// <summary>
        /// Performs percentage-based mathematical operations on a numeric value.
        /// </summary>
        /// <param name="value">The source value to process.</param>
        /// <param name="total">The reference total value.</param>
        /// <param name="calculationMethod">The <see cref="PercentageCalculationMethod"/> determining the calculation logic.</param>
        /// <returns>The calculated result based on the selected <see cref="PercentageCalculationMethod"/>.</returns>
        public static T CalculatePercentage<T>(this T value, T total, PercentageCalculationMethod calculationMethod) where T : IConvertible
        {
            double v = value.ToDouble(null);
            double t = total.ToDouble(null);

            double result = calculationMethod switch
            {
                PercentageCalculationMethod.FractionOfTotal => v * (t / 100),
                PercentageCalculationMethod.RatioOfTotal => (v * t) / 100,
                _ => v * (t / 100)
            };

            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}

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

