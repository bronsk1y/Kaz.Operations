using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns>Retutns a parsed numeric value if successful; otherwise, <paramref name="defaultValue"/>. 
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
    public static class Arithmetics
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
                throw new ArgumentException("minValue must be less than or equal to maxValue", nameof(minValue));

            if (value.CompareTo(minValue) < 0) return minValue;
            if (value.CompareTo(maxValue) > 0) return maxValue;
            return value;   
        }

        /// <summary>
        /// Performs a linear interpolation between two values based on a given interpolant.
        /// </summary>
        /// <param name="start">The starting value.</param>
        /// <param name="end">The ending value.</param>
        /// <param name="amount">The interpolation factor, typically between 0 and 1.</param>
        /// <returns>The interpolated value.</returns>
        public static float Lerp(this float start, float end, float amount)
            => start + (end - start) * amount;

        /// <summary>
        /// Performs a linear interpolation between two values based on a given interpolant.
        /// </summary>
        /// <param name="start">The starting value.</param>
        /// <param name="end">The ending value.</param>
        /// <param name="amount">The interpolation factor, typically between 0 and 1.</param>
        /// <returns>The interpolated value.</returns>
        public static double Lerp(this double start, double end, double amount)
            => start + (end - start) * amount;

        /// <summary>
        /// Performs a linear interpolation between two values based on a given interpolant.
        /// </summary>
        /// <param name="start">The starting value.</param>
        /// <param name="end">The ending value.</param>
        /// <param name="amount">The interpolation factor, typically between 0 and 1.</param>
        /// <returns>The interpolated value.</returns>
        public static decimal Lerp(this decimal start, decimal end, decimal amount)
            => start + (end - start) * amount;


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
