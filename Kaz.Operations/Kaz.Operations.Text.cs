using Kaz.Operations.Core;
using Kaz.Operations.Numerics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Kaz.Operations.Text
{
    /// <summary>
    /// Provides methods for string manipulation.
    /// </summary>
    public static class Manipulation
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
        /// Returns a string where all whitespace characters were removed, or the original string if it is <see langword="null"/> or empty.
        /// </returns>
        public static string RemoveWhiteSpaces(this string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return input;

            return Regex.Replace(input, @"\s+", "");
        }


        /// <summary>
        /// Extracts numeric values from the specified string according to the selected
        /// <see cref="NumberExtractionOptions"/>.
        /// </summary>
        /// <param name="input">
        /// The source string from which numeric values will be extracted.
        /// </param>
        /// <param name="options">
        /// A value of <see cref="NumberExtractionOptions"/> that specifies the type of numeric
        /// patterns to extract. The default option is <see cref="NumberExtractionOptions.Digits"/>.
        /// </param>
        /// <returns>
        /// Returns a list containing all extracted numeric values in the order they appear
        /// in the input. If <paramref name="input"/> is <see langword="null"/> or empty, the method
        /// returns an empty list.
        /// </returns>
        public static List<int> ExtractAllNumbers(this string input, NumberExtractionOptions options = NumberExtractionOptions.Digits)
        {
            if (string.IsNullOrEmpty(input))
                return new List<int>();

            string pattern = options switch
            {
                NumberExtractionOptions.Digits => @"\d+",
                NumberExtractionOptions.Decimals => @"[-+]?\d*\.?\d+",
                NumberExtractionOptions.Scientific => @"[-+]?\d*\.?\d+(?:[eE][-+]?\d+)?",
                _ => @"\d+"
            };

            var matches = Regex.Matches(input, pattern);
            var result = new List<int>();

            foreach (Match match in matches)
            {
                result.Add(match.Value.ToNumericOrDefault(0));
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
        /// Returns a string containing all matched substrings concatenated in the order they
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
        /// Validates whether the string contains only Unicode letters and spaces.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>Returns <see langword="true"/> if the string is alphabetic; otherwise, <see langword="false"/>.</returns>
        public static bool IsAlpha(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^[\p{L} ]+$");
        }

        /// <summary>
        /// Validates whether the string represents a valid numeric format.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>Returns <see langword="true"/> if the string is numeric; otherwise, <see langword="false"/>.</returns>
        public static bool IsNumeric(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) 
                return false; 
            
            return Regex.IsMatch(input, @"^[+-]?\d*\.?\d+$");
        }

        /// <summary>
        /// Validates whether the string represents a boolean value.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>Returns <see langword="true"/> if the string is a recognized boolean representation; otherwise, <see langword="false"/>.</returns>
        public static bool IsBoolean(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^(?i:true|false|0|1)$");
        }

        /// <summary>
        /// Validates whether the string is a valid email address.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>Returns <see langword="true"/> if the format is valid; otherwise, <see langword="false"/>.</returns>
        public static bool IsEmail(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
        }

        /// <summary>
        /// Validates whether the string is a valid international phone number.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>Returns <see langword="true"/> if the format is valid; otherwise, <see langword="false"/>.</returns>
        public static bool IsPhoneNumber(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^\+[1-9]\d{7,14}$");

        }

        /// <summary>
        /// Validates whether the string is a valid <see href="Http"/> or <see href="Https"/> URL based on the selected <see cref="UrlScheme"/>.
        /// </summary>
        /// <param name="source">The string to validate.</param>
        /// <param name="urlScheme">Specified URL scheme to validate the provided URL address string.</param>
        /// <returns>Returns <see langword="true"/> if the format is valid; otherwise, <see langword="false"/>.</returns>
        public static bool IsUrl(this string source, UrlScheme urlScheme = UrlScheme.Any)
        {
            if (string.IsNullOrWhiteSpace(source))
                return false;

            if (!Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult))
                return false;

            return urlScheme switch
            {
                UrlScheme.Http => uriResult.Scheme == Uri.UriSchemeHttp,
                UrlScheme.Https => uriResult.Scheme == Uri.UriSchemeHttps,
                _ => uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps
            };
        }

        /// <summary>
        /// Validates whether the string is a valid <see href="IPv4"/> or <see href="IPv6"/> based on the selected <see cref="IpVersion"/>.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="ipVersion">Specified version of the IP address to validate the provided IP address string.</param>
        /// <returns></returns>
        public static bool IsIpAddress(this string input, IpVersion ipVersion = IpVersion.Any)
        {
            if (!IPAddress.TryParse(input, out var address)) 
                return false;

            return ipVersion switch
            {
                IpVersion.IPv4 => address.AddressFamily == AddressFamily.InterNetwork,
                IpVersion.IPv6 => address.AddressFamily == AddressFamily.InterNetworkV6,
                _ => true
            };
        }

        /// <summary>
        /// Determines whether the string matches the specified regular expression pattern.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>Returns <see langword="true"/> if a match is found; otherwise, <see langword="false"/>.</returns>
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
        /// <returns>Returns <see langword="true"/> if a match is found; otherwise, <see langword="false"/>.</returns>
        public static bool MatchesPattern(this string input, string pattern, RegexOptions options = RegexOptions.None)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, pattern, options | RegexOptions.CultureInvariant);
        }
    }
}

