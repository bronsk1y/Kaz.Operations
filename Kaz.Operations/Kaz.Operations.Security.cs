using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;

namespace Kaz.Operations.Security
{
    namespace Cryptography
    {
        /// <summary>
        /// Provides SHA-256 hashing and comparison utilities.
        /// </summary>
        public class Sha256
        {
            /// <summary>
            /// Computes a SHA-256 hash of the input string using UTF-8 encoding.
            /// </summary>
            /// <param name="input">Input text.</param>
            /// <returns>Hex-encoded hash string.</returns>
            public static string Hash(string input)
            {
                using var sha256 = SHA256.Create();
                var bytes = Encoding.UTF8.GetBytes(input);

                var hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Computes a SHA-256 hash of the input string using the specified encoding.
            /// </summary>
            /// <param name="input">Input text.</param>
            /// <param name="encoding">Text encoding.</param>
            /// <returns>Hex-encoded hash string.</returns>
            public static string Hash(string input, Encoding encoding)
            {
                using var sha256 = SHA256.Create();
                var bytes = encoding.GetBytes(input);

                var hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Compares the input string with a SHA-256 hash.
            /// </summary>
            /// <param name="input">Input text.</param>
            /// <param name="hash">Hex-encoded hash.</param>
            /// <returns>True if hashes match.</returns>
            public static bool Compare(string input, string hash)
            {
                var inputHash = Hash(input);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with a SHA-256 hash using the specified encoding.
            /// </summary>
            /// <param name="input">Input text.</param>
            /// <param name="hash">Hex-encoded hash.</param>
            /// <param name="encoding">Text encoding.</param>
            /// <returns>True if hashes match.</returns>
            public static bool Compare(string input, string hash, Encoding encoding)
            {
                var inputHash = Hash(input, encoding);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with a SHA-256 hash represented as bytes.
            /// </summary>
            /// <param name="input">Input text.</param>
            /// <param name="hash">Hash bytes.</param>
            /// <returns>True if hashes match.</returns>
            public static bool Compare(string input, byte[] hash)
            {
                using var sha256 = SHA256.Create();
                var inputBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }

            /// <summary>
            /// Compares the input string with a SHA-256 hash represented as bytes using the specified encoding.
            /// </summary>
            /// <param name="input">Input text.</param>
            /// <param name="hash">Hash bytes.</param>
            /// <param name="encoding">Text encoding.</param>
            /// <returns>True if hashes match.</returns>
            public static bool Compare(string input, byte[] hash, Encoding encoding)
            {
                using var sha256 = SHA256.Create();
                var inputBytes = sha256.ComputeHash(encoding.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Provides SHA-512 hashing and comparison utilities.
        /// </summary>
        public class Sha512
        {
            /// <summary>
            /// Computes a SHA-512 hash of the input string using UTF-8 encoding.
            /// </summary>
            public static string Hash(string input)
            {
                using var sha512 = SHA512.Create();
                var bytes = Encoding.UTF8.GetBytes(input);

                var hash = sha512.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Computes a SHA-512 hash of the input string using the specified encoding.
            /// </summary>
            public static string Hash(string input, Encoding encoding)
            {
                using var sha512 = SHA512.Create();
                var bytes = encoding.GetBytes(input);

                var hash = sha512.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Compares the input string with a SHA-512 hash.
            /// </summary>
            public static bool Compare(string input, string hash)
            {
                var inputHash = Hash(input);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with a SHA-512 hash using the specified encoding.
            /// </summary>
            public static bool Compare(string input, string hash, Encoding encoding)
            {
                var inputHash = Hash(input, encoding);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with a SHA-512 hash represented as bytes.
            /// </summary>
            public static bool Compare(string input, byte[] hash)
            {
                using var sha512 = SHA512.Create();
                var inputBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }

            /// <summary>
            /// Compares the input string with a SHA-512 hash represented as bytes using the specified encoding.
            /// </summary>
            public static bool Compare(string input, byte[] hash, Encoding encoding)
            {
                using var sha512 = SHA512.Create();
                var inputBytes = sha512.ComputeHash(encoding.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Provides MD5 hashing and comparison utilities.
        /// </summary>
        public class Md5
        {
            /// <summary>
            /// Computes an MD5 hash of the input string using UTF-8 encoding.
            /// </summary>
            public static string Hash(string input)
            {
                using var md5 = MD5.Create();
                var bytes = Encoding.UTF8.GetBytes(input);

                var hash = md5.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Computes an MD5 hash of the input string using the specified encoding.
            /// </summary>
            public static string Hash(string input, Encoding encoding)
            {
                using var md5 = MD5.Create();
                var bytes = encoding.GetBytes(input);

                var hash = md5.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Compares the input string with an MD5 hash.
            /// </summary>
            public static bool Compare(string input, string hash)
            {
                var inputHash = Hash(input);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with an MD5 hash using the specified encoding.
            /// </summary>
            public static bool Compare(string input, string hash, Encoding encoding)
            {
                var inputHash = Hash(input, encoding);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with an MD5 hash represented as bytes.
            /// </summary>
            public static bool Compare(string input, byte[] hash)
            {
                using var md5 = MD5.Create();
                var inputBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }

            /// <summary>
            /// Compares the input string with an MD5 hash represented as bytes using the specified encoding.
            /// </summary>
            public static bool Compare(string input, byte[] hash, Encoding encoding)
            {
                using var md5 = MD5.Create();
                var inputBytes = md5.ComputeHash(encoding.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Provides HMAC-SHA1 hashing and comparison utilities.
        /// </summary>
        public class HmacSha1
        {
            /// <summary>
            /// Computes an HMAC-SHA1 hash of the input string using UTF-8 encoding.
            /// </summary>
            public static string Hash(string input, byte[] key)
            {
                using var hmacsha1 = new HMACSHA1(key);
                var bytes = Encoding.UTF8.GetBytes(input);

                var hash = hmacsha1.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Computes an HMAC-SHA1 hash of the input string using the specified encoding.
            /// </summary>
            public static string Hash(string input, byte[] key, Encoding encoding)
            {
                using var hmacsha1 = new HMACSHA1(key);
                var bytes = encoding.GetBytes(input);

                var hash = hmacsha1.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA1 hash.
            /// </summary>
            public static bool Compare(string input, string hash, byte[] key)
            {
                var inputHash = Hash(input, key);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA1 hash using the specified encoding.
            /// </summary>
            public static bool Compare(string input, string hash, byte[] key, Encoding encoding)
            {
                var inputHash = Hash(input, key, encoding);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA1 hash represented as bytes.
            /// </summary>
            public static bool Compare(string input, byte[] hash, byte[] key)
            {
                using var hmacsha1 = new HMACSHA1(key);
                var inputBytes = hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA1 hash represented as bytes using the specified encoding.
            /// </summary>
            public static bool Compare(string input, byte[] hash, byte[] key, Encoding encoding)
            {
                using var hmacsha1 = new HMACSHA1(key);
                var inputBytes = hmacsha1.ComputeHash(encoding.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Provides HMAC-SHA256 hashing and comparison utilities.
        /// </summary>
        public class HmacSha256
        {
            /// <summary>
            /// Computes an HMAC-SHA256 hash of the input string using UTF-8 encoding.
            /// </summary>
            public static string Hash(string input, byte[] key)
            {
                using var hmacsha256 = new HMACSHA256(key);
                var bytes = Encoding.UTF8.GetBytes(input);

                var hash = hmacsha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Computes an HMAC-SHA256 hash of the input string using the specified encoding.
            /// </summary>
            public static string Hash(string input, byte[] key, Encoding encoding)
            {
                using var hmacsha256 = new HMACSHA256(key);
                var bytes = encoding.GetBytes(input);

                var hash = hmacsha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA256 hash.
            /// </summary>
            public static bool Compare(string input, string hash, byte[] key)
            {
                var inputHash = Hash(input, key);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA256 hash using the specified encoding.
            /// </summary>
            public static bool Compare(string input, string hash, byte[] key, Encoding encoding)
            {
                var inputHash = Hash(input, key, encoding);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA256 hash represented as bytes.
            /// </summary>
            public static bool Compare(string input, byte[] hash, byte[] key)
            {
                using var hmacsha256 = new HMACSHA256(key);
                var inputBytes = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA256 hash represented as bytes using the specified encoding.
            /// </summary>
            public static bool Compare(string input, byte[] hash, byte[] key, Encoding encoding)
            {
                using var hmacsha256 = new HMACSHA256(key);
                var inputBytes = hmacsha256.ComputeHash(encoding.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Provides HMAC-SHA512 hashing and comparison utilities.
        /// </summary>
        public class HmacSha512
        {
            /// <summary>
            /// Computes an HMAC-SHA512 hash of the input string using UTF-8 encoding.
            /// </summary>
            public static string Hash(string input, byte[] key)
            {
                using var hmacsha512 = new HMACSHA512(key);
                var bytes = Encoding.UTF8.GetBytes(input);

                var hash = hmacsha512.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Computes an HMAC-SHA512 hash of the input string using the specified encoding.
            /// </summary>
            public static string Hash(string input, byte[] key, Encoding encoding)
            {
                using var hmacsha512 = new HMACSHA512(key);
                var bytes = encoding.GetBytes(input);

                var hash = hmacsha512.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA512 hash.
            /// </summary>
            public static bool Compare(string input, string hash, byte[] key)
            {
                var inputHash = Hash(input, key);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA512 hash using the specified encoding.
            /// </summary>
            public static bool Compare(string input, string hash, byte[] key, Encoding encoding)
            {
                var inputHash = Hash(input, key, encoding);
                return inputHash == hash;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA512 hash represented as bytes.
            /// </summary>
            public static bool Compare(string input, byte[] hash, byte[] key)
            {
                using var hmacsha512 = new HMACSHA512(key);
                var inputBytes = hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }

            /// <summary>
            /// Compares the input string with an HMAC-SHA512 hash represented as bytes using the specified encoding.
            /// </summary>
            public static bool Compare(string input, byte[] hash, byte[] key, Encoding encoding)
            {
                using var hmacsha512 = new HMACSHA512(key);
                var inputBytes = hmacsha512.ComputeHash(encoding.GetBytes(input));

                if (inputBytes.Length != hash.Length) return false;
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    if (inputBytes[i] != hash[i]) return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Provides PBKDF2 password hashing and comparison utilities. 
        /// </summary>
        public class Pbkdf2
        {
            /// <summary>
            /// Computes a PBKDF2-HMAC-SHA1 hash of the password.
            /// </summary>
            /// <param name="password">Input password.</param>
            /// <param name="salt">Salt value.</param>
            /// <param name="iterationCount">Number of iterations.</param>
            /// <returns>Hex-encoded hash string.</returns>
            [Obsolete("HMACSHA1 is deprecated and should not be used for security-critical operations.")]
            public static string HMACSHA1(string password, byte[] salt, int iterationCount)
            {
                using var pbdkf2 = new Rfc2898DeriveBytes(password, salt, iterationCount, HashAlgorithmName.SHA1);
                var hash = pbdkf2.GetBytes(20);

                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Computes a PBKDF2-HMAC-SHA256 hash of the password.
            /// </summary>
            /// <param name="password">Input password.</param>
            /// <param name="salt">Salt value.</param>
            /// <param name="iterationCount">Number of iterations.</param>
            /// <returns>Hex-encoded hash string.</returns>
            public static string HMACSHA256(string password, byte[] salt, int iterationCount)
            {
                using var pbdkf2 = new Rfc2898DeriveBytes(password, salt, iterationCount, HashAlgorithmName.SHA256);
                var hash = pbdkf2.GetBytes(32);

                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Computes a PBKDF2-HMAC-SHA512 hash of the password.
            /// </summary>
            /// <param name="password">Input password.</param>
            /// <param name="salt">Salt value.</param>
            /// <param name="iterationCount">Number of iterations.</param>
            /// <returns>Hex-encoded hash string.</returns>
            public static string HMACSHA512(string password, byte[] salt, int iterationCount)
            {
                using var pbdkf2 = new Rfc2898DeriveBytes(password, salt, iterationCount, HashAlgorithmName.SHA512);
                var hash = pbdkf2.GetBytes(64);

                return BitConverter.ToString(hash).Replace("-", "");
            }

            /// <summary>
            /// Compares a password with a PBKDF2 hash using the specified algorithm.
            /// </summary>
            /// <param name="password">Input password.</param>
            /// <param name="salt">Salt value.</param>
            /// <param name="iterationCount">Number of iterations.</param>
            /// <param name="algorithmName">Hash algorithm.</param>
            /// <param name="hash">Hex-encoded hash.</param>
            /// <returns>True if hashes match.</returns>
            /// <exception cref="ArgumentException">Thrown when algorithm is not supported.</exception>
            public static bool Compare(string password, byte[] salt, int iterationCount, HashAlgorithmName algorithmName, string hash)
            {
                string passwordHash;

                switch (algorithmName.Name)
                {
                    case "SHA1":
#pragma warning disable
                        passwordHash = HMACSHA1(password, salt, iterationCount);
                        break;
#pragma warning restore
                    case "SHA256":
                        passwordHash = HMACSHA256(password, salt, iterationCount);
                        break;

                    case "SHA512":
                        passwordHash = HMACSHA512(password, salt, iterationCount);
                        break;

                    default:
                        throw new ArgumentException("All other types of crypto-algortihms are not supported.", nameof(algorithmName));
                }

                return passwordHash == hash;
            }

            /// <summary>
            /// Compares a password with a PBKDF2 hash represented as bytes using the specified algorithm.
            /// </summary>
            /// <param name="password">Input password.</param>
            /// <param name="salt">Salt value.</param>
            /// <param name="iterationCount">Number of iterations.</param>
            /// <param name="algorithmName">Hash algorithm.</param>
            /// <param name="hash">Hash bytes.</param>
            /// <returns>True if hashes match.</returns>
            /// <exception cref="ArgumentException">Thrown when algorithm is not supported.</exception>
            public static bool Compare(string password, byte[] salt, int iterationCount, HashAlgorithmName algorithmName, byte[] hash)
            {
                using var pbdkf2 = new Rfc2898DeriveBytes(password, salt, iterationCount, algorithmName);
                byte[] passwordHash;

                switch (algorithmName.Name)
                {
                    case "SHA1":
                        passwordHash = pbdkf2.GetBytes(20);
                        break;

                    case "SHA256":
                        passwordHash = pbdkf2.GetBytes(32);
                        break;

                    case "SHA512":
                        passwordHash = pbdkf2.GetBytes(64);
                        break;

                    default:
                        throw new ArgumentException("All other types of crypto-algortihms are not supported.", nameof(algorithmName));
                }

                if (passwordHash.Length != hash.Length) return false;
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != hash[i]) return false;
                }
                return true;
            }

            /// <summary>
            /// Generates a 32-byte cryptographically secure salt.
            /// </summary>
            /// <returns>Random salt bytes.</returns>
            public static byte[] GenerateSalt()
            {
                var salt = new byte[32];
                using var rnd = RandomNumberGenerator.Create();
                rnd.GetBytes(salt);

                return salt;
            }

            /// <summary>
            /// Generates a cryptographically secure salt into the specified buffer region.
            /// </summary>
            /// <param name="offset">Offset in the buffer.</param>
            /// <param name="count">Number of bytes to fill.</param>
            /// <returns>Salt buffer containing random bytes.</returns>
            public static byte[] GenerateSalt(int offset, int count)
            {
                var salt = new byte[32];
                using var rnd = RandomNumberGenerator.Create();
                rnd.GetBytes(salt, offset, count);

                return salt;
            }
        }
    }

    namespace Certificates
    {

        /// <summary>
        /// Provides helper methods for working with X.509 certificates.
        /// </summary>
        public static class X509CertificateInfo
        {
            /// <summary>
            /// Gets the expiration date of the certificate.
            /// </summary>
            /// <param name="certificate">The certificate instance.</param>
            /// <returns>The expiration date (NotAfter value).</returns>
            /// <exception cref="ArgumentNullException">Thrown when the certificate is null.</exception>
            public static DateTime GetExpirationDate(this X509Certificate2 certificate)
            {
                if (certificate == null)
                    throw new ArgumentNullException(nameof(certificate));

                return certificate.NotAfter;
            }

            /// <summary>
            /// Loads a certificate from a .cer or .crt file.
            /// </summary>
            /// <param name="path">The path to the certificate file.</param>
            /// <returns>The loaded certificate.</returns>
            /// <exception cref="ArgumentException">Thrown when the file extension is invalid.</exception>
            /// <exception cref="CryptographicException">Thrown when the certificate cannot be loaded.</exception>
            public static X509Certificate2 LoadCertificate(string path)
            {
                string extension = Path.GetExtension(path);
                bool correctExtension = extension == ".cer" || extension == ".crt";

                if (correctExtension)
                {
                    return new X509Certificate2(path);
                }

                throw new ArgumentException("Provided file is not a valid .cer or .crt certificate.", nameof(path));
            }

            /// <summary>
            /// Loads a certificate from a .pfx or .p12 file using the specified password.
            /// </summary>
            /// <param name="path">The path to the certificate file.</param>
            /// <param name="password">The certificate password.</param>
            /// <returns>The loaded certificate.</returns>
            /// <exception cref="ArgumentException">Thrown when the file extension is invalid.</exception>
            /// <exception cref="CryptographicException">Thrown when the certificate cannot be loaded or the password is incorrect.</exception>
            public static X509Certificate2 LoadCertificate(string path, string password)
            {
                string extension = Path.GetExtension(path);
                bool correctExtension = extension == ".pfx" || extension == ".p12";

                if (correctExtension)
                {
                    return new X509Certificate2(path, password);
                }

                throw new ArgumentException("Provided file is not a valid .pfx or .p12 certificate.", nameof(path));
            }

            /// <summary>
            /// Indicates whether the certificate is expired.
            /// </summary>
            /// <param name="certificate">The certificate instance.</param>
            /// <returns>True if the certificate is expired; otherwise, false.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the certificate is null.</exception>
            public static bool IsExpired(this X509Certificate2 certificate)
            {
                if (certificate == null)
                    throw new ArgumentNullException(nameof(certificate));

                return certificate.NotAfter < DateTime.UtcNow;
            }

            /// <summary>
            /// Indicates whether the certificate is trusted.
            /// </summary>
            /// <param name="certificate">The certificate instance.</param>
            /// <returns>True if the certificate is trusted; otherwise, false.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the certificate is null.</exception>
            /// <exception cref="CryptographicException">Thrown when an internal error occurs while building the certificate chain.</exception>
            public static bool IsTrusted(this X509Certificate2 certificate)
            {
                if (certificate == null)
                    throw new ArgumentNullException(nameof(certificate));

                var chain = new X509Chain();
                return chain.Build(certificate);
            }
        }

    }
}

