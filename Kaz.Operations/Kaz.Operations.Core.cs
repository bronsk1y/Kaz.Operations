namespace Kaz.Operations.Core
{
	/// <summary>
	/// Specifies which URL scheme is used for validating a provided URL address string.
	/// </summary>
	public enum UrlScheme
	{
		/// <summary>
		/// Both <see href="Http"/> and <see href="Https"/> are validated.
		/// </summary>
		Any,
		/// <summary>
		/// Only <see href="Http"/> is validated.
		/// </summary>
		Http,
		/// <summary>
		/// Only <see href="Https"/> is validated.
		/// </summary>
		Https
	}

	/// <summary>
	/// Specifies which IP version is used for validating a provided IP address string.
	/// </summary>
	public enum IpVersion
	{
		/// <summary>
		/// Both <see href="IPv4"/> and <see href="IPv6"/> are validated.
		/// </summary>
		Any,
		/// <summary>
		/// Only <see href="IPv4"/> is validated.
		/// </summary>
		IPv4,
		/// <summary>
		/// Only <see href="IPv6"/> is validated.
		/// </summary>
		IPv6
	}

	/// <summary>
	/// Specifies the calculation logic for percentage-based operations.
	/// </summary>
	public enum PercentageCalculationMethod
	{
		/// <summary>
		/// Calculates the value that represents a specified percentage of a total.
		/// </summary>
		FractionOfTotal,
		/// <summary>
		/// Calculates the ratio between a specific value and a total as a percentage.
		/// </summary>
		RatioOfTotal
	}

	/// <summary>
	/// Specifies the criteria for identifying and extracting numeric values from a string.
	/// </summary>
	public enum NumberExtractionOptions
	{
		/// <summary>
		/// Matches sequences consisting only of decimal digits.
		/// </summary>
		Digits,

		/// <summary>
		/// Matches numeric sequences including optional signs and decimal points.
		/// </summary>
		Decimals,

		/// <summary>
		/// Matches numeric sequences in scientific notation, including signs, decimal points, and exponents.
		/// </summary>
		Scientific
	}

}
