using System;
using System.Globalization;

namespace Kaz.Operations.Time
{
    /// <summary>
    /// Provides methods for validating time and date.
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Determines whether the date falls on a weekend.
        /// </summary>
        /// <param name="dateTime">Date to check.</param>
        /// <returns>True if Saturday or Sunday.</returns>
        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determines whether the date falls on a weekday.
        /// </summary>
        /// <param name="dateTime">Date to check.</param>
        /// <returns>True if Monday–Friday.</returns>
        public static bool IsWeekday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determines whether the date is in the past.
        /// </summary>
        /// <param name="dateTime">Date to check.</param>
        /// <returns>True if earlier than now.</returns>
        public static bool IsPastDate(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime() < DateTime.UtcNow;
        }

        /// <summary>
        /// Determines whether the date is today.
        /// </summary>
        /// <param name="dateTime">Date to check.</param>
        /// <returns>True if equal to today's date.</returns>
        public static bool IsPresentDate(this DateTime dateTime)
        {
            return dateTime.Date == DateTime.UtcNow.Date;
        }

        /// <summary>
        /// Determines whether the date is in the future.
        /// </summary>
        /// <param name="dateTime">Date to check.</param>
        /// <returns>True if later than now.</returns>
        public static bool IsFutureDate(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime() > DateTime.UtcNow;
        }

        /// <summary>
        /// Validates time components.
        /// </summary>
        /// <param name="seconds">Seconds value.</param>
        /// <param name="minutes">Minutes value.</param>
        /// <param name="hours">Hours value.</param>
        /// <returns>True if values form a valid time.</returns>
        public static bool IsValidTime(int seconds, int minutes, int hours)
        {
            return (seconds <= 59 && seconds >= 0) &&
                   (minutes <= 59 && minutes >= 0) &&
                   (hours <= 23 && hours >= 0);
        }

        /// <summary>
        /// Determines whether the string represents a valid date.
        /// </summary>
        /// <param name="dateTime">Date string.</param>
        /// <returns>True if valid.</returns>
        public static bool IsValidDate(this string dateTime)
        {
            return DateTime.TryParse(dateTime, out DateTime _);
        }

        /// <summary>
        /// Determines whether the integer represents a valid month.
        /// </summary>
        /// <param name="month">Month number.</param>
        /// <returns>True if 1–12.</returns>
        public static bool IsValidMonth(this int month)
        {
            return month >= 1 && month <= 12;
        }

        /// <summary>
        /// Determines whether the string matches the specified date format.
        /// </summary>
        /// <param name="dateTime">Date string.</param>
        /// <param name="format">Expected format.</param>
        /// <returns>True if valid.</returns>
        public static bool IsValidDate(this string dateTime, string format)
        {
            return DateTime.TryParseExact(
                dateTime, format,
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out DateTime _);
        }

        /// <summary>
        /// Determines whether the string matches the specified date format and culture.
        /// </summary>
        /// <param name="dateTime">Date string.</param>
        /// <param name="format">Expected format.</param>
        /// <param name="cultureInfo">Culture to use.</param>
        /// <returns>True if valid.</returns>
        public static bool IsValidDate(this string dateTime, string format, CultureInfo cultureInfo)
        {
            return DateTime.TryParseExact(
                dateTime,
                format,
                cultureInfo,
                DateTimeStyles.None,
                out DateTime _);
        }

        /// <summary>
        /// Determines whether the date is within the specified range.
        /// </summary>
        /// <param name="dateTime">Date to check.</param>
        /// <param name="bound1">Lower bound.</param>
        /// <param name="bound2">Upper bound.</param>
        /// <returns>True if between bounds.</returns>
        /// <exception cref="ArgumentException">Thrown when bound1 is greater than bound2.</exception>
        public static bool IsInRange(this DateTime dateTime, DateTime bound1, DateTime bound2)
        {
            if (bound1 > bound2)
                throw new ArgumentException("Bound1 cannot be greater than bound2.", nameof(bound1));

            return dateTime >= bound1 && dateTime <= bound2;
        }
    }
}
