using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kaz.Operations.IO
{
	/// <summary>
	/// Provides static CRUD file operations methods.
	/// </summary>
	public static class CRUD
	{
		/// <summary>
		/// Gets or sets the encoding used by the file CRUD operations.
		/// </summary>
		public static Encoding Encoding { get; set; } =
			new UTF8Encoding();

		/// <summary>
		/// Appends a line to a file, creating the directory if needed.
		/// </summary>
		/// <param name="path">File path.</param>
		/// <param name="line">Text to append.</param>
		/// <returns>True if successful.</returns>
		public static bool AppendLine(string path, string line)
		{
			try
			{
				Validation.EnsureExists(Path.GetDirectoryName(path)!);
				File.AppendAllText(path, line, Encoding);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Copies a file if the source is newer than the destination.
		/// </summary>
		/// <param name="sourcePath">Source file.</param>
		/// <param name="destinationPath">Destination file.</param>
		/// <returns>True if copied.</returns>
		public static bool CopyIfNewer(string sourcePath, string destinationPath)
		{
			try
			{
				if (!File.Exists(sourcePath))
					return false;

				if (!File.Exists(destinationPath))
				{
					File.Copy(sourcePath, destinationPath);
					return true;
				}

				var sourceLastWriteTime = File.GetLastWriteTime(sourcePath);
				var destinationLastWriteTime = File.GetLastWriteTime(destinationPath);

				if (sourceLastWriteTime > destinationLastWriteTime)
				{
					File.Copy(sourcePath, destinationPath);
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Reads all lines from a file.
		/// </summary>
		/// <param name="path">File path.</param>
		/// <returns>List of lines.</returns>
		public static List<string> ReadAllLines(string path)
		{
			try
			{
				var content = File.ReadAllLines(path, Encoding);
				return content.ToList();
			}
			catch (Exception)
			{
				return new List<string>();
			}
		}

		/// <summary>
		/// Reads all lines from a file with optional empty-line filtering.
		/// </summary>
		/// <param name="path">File path.</param>
		/// <param name="skipEmpty">Skip empty lines.</param>
		/// <returns>List of lines.</returns>
		public static List<string> ReadAllLines(string path, bool skipEmpty)
		{
			try
			{
				var result = new List<string>();
				var content = File.ReadAllLines(path, Encoding);

				if (skipEmpty)
				{
					foreach (var line in content)
					{
						if (!string.IsNullOrEmpty(line))
							result.Add(line);
					}

					return result;
				}
				else
				{
					return content.ToList();
				}
			}
			catch (Exception)
			{
				return new List<string>();
			}
		}

		/// <summary>
		/// Gets files by extension from a directory and subdirectories.
		/// </summary>
		/// <param name="directoryPath">Directory path.</param>
		/// <param name="extension">File extension.</param>
		/// <returns>List of file paths.</returns>
		public static List<string> GetFilesByExtension(string directoryPath, string extension)
		{
			try
			{
				if (!extension.StartsWith("*"))
					extension = "*." + extension.TrimStart('.');

				var files = Directory.GetFiles(directoryPath, extension, SearchOption.AllDirectories);
				return files.ToList();
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Deletes a file if it exists.
		/// </summary>
		/// <param name="path">File path.</param>
		/// <returns>True if deleted.</returns>
		public static bool TryDelete(string path)
		{
			try
			{
				if (File.Exists(path))
				{
					File.Delete(path);
					return true;
				}
				else
					return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	/// <summary>
	/// Provides static methods for file and directory validation.
	/// </summary>
	public static class Validation
	{
		/// <summary>
		/// Ensures that a directory exists.
		/// </summary>
		/// <param name="directoryPath">Directory path.</param>
		public static void EnsureExists(string directoryPath)
		{
			try
			{
				if (!Directory.Exists(directoryPath))
					Directory.CreateDirectory(directoryPath);
			}
			catch (Exception)
			{
				return;
			}
		}

		/// <summary>
		/// Checks whether a file is locked.
		/// </summary>
		/// <param name="path">File path.</param>
		/// <returns>True if locked.</returns>
		public static bool IsFileLocked(string path)
		{
			try
			{
				using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
				return !fileStream.CanRead;
			}
			catch (Exception)
			{
				return true;
			}
		}
	}

}
