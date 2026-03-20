using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;

namespace Kaz.Operations.System
{
    /// <summary>
    /// Provides access to system, environment, and runtime information.
    /// </summary>
    public static class SystemInfo
    {
        /// <summary>
        /// Gets the machine name.
        /// </summary>
        public static string MachineName => Environment.MachineName;

        /// <summary>
        /// Gets the number of milliseconds since the system started.
        /// </summary>
        public static int TickCount => Environment.TickCount;

        /// <summary>
        /// Gets the current user name.
        /// </summary>
        public static string UserName => Environment.UserName;

        /// <summary>
        /// Gets the domain of the current user.
        /// </summary>
        public static string UserDomainName => Environment.UserDomainName;

        /// <summary>
        /// Gets a value indicating whether the OS is 64‑bit.
        /// </summary>
        public static bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;

        /// <summary>
        /// Gets a value indicating whether the process is 64‑bit.
        /// </summary>
        public static bool Is64BitProcess => Environment.Is64BitProcess;

        /// <summary>
        /// Gets a value indicating whether system shutdown has started.
        /// </summary>
        public static bool HasShutdownStarted => Environment.HasShutdownStarted;

        /// <summary>
        /// Gets the number of logical processors.
        /// </summary>
        public static int ProcessorCount => Environment.ProcessorCount;

        /// <summary>
        /// Gets the memory used by the process in bytes.
        /// </summary>
        public static long WorkingSet => Environment.WorkingSet;

        /// <summary>
        /// Gets the memory used by the process in megabytes.
        /// </summary>
        public static double WorkingSetMb => (double)Environment.WorkingSet / 1048576;

        /// <summary>
        /// Gets the operating system version.
        /// </summary>
        public static OperatingSystem OSVersion => Environment.OSVersion;

        /// <summary>
        /// Gets the .NET runtime version.
        /// </summary>
        public static Version DotNetVersion => Environment.Version;

        /// <summary>
        /// Gets the system directory path.
        /// </summary>
        public static string SystemDirectory => Environment.SystemDirectory;

        /// <summary>
        /// Gets the operating system platform.
        /// </summary>
        public static PlatformID PlatformID => Environment.OSVersion.Platform;

        /// <summary>
        /// Gets a value indicating whether the process has administrator rights.
        /// </summary>
        public static bool IsAdministrator =>
            new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        /// <summary>
        /// Gets the newline sequence for the current environment.
        /// </summary>
        public static string NewLine => Environment.NewLine;

        /// <summary>
        /// Gets the command line used to start the process.
        /// </summary>
        public static string CommandLine => Environment.CommandLine;

        /// <summary>
        /// Gets the ID of the current managed thread.
        /// </summary>
        public static int CurrentManagedThreadId => Environment.CurrentManagedThreadId;

        /// <summary>
        /// Gets a value indicating whether the Windows major version
        /// meets or exceeds the specified value.
        /// </summary>
        /// <param name="major">Required major version.</param>
        /// <returns>True if the current Windows major version is at least the specified value.</returns>
        public static bool IsWindowsVersionAtLeast(int major)
        {
            return OSVersion.Version.Major >= major;
        }

        /// <summary>
        /// Gets a value indicating whether the Windows version
        /// meets or exceeds the specified major and minor values.
        /// </summary>
        /// <param name="major">Required major version.</param>
        /// <param name="minor">Required minor version.</param>
        /// <returns>True if the current Windows version is at least the specified version.</returns>
        public static bool IsWindowsVersionAtLeast(int major, int minor)
        {
            if (OSVersion.Version.Major > major)
                return true;
            if (OSVersion.Version.Major == major)
                return OSVersion.Version.Minor >= minor;
            return false;
        }

        /// <summary>
        /// Gets the system uptime based on the environment tick counter.
        /// </summary>
        /// <returns>Time span representing the system uptime.</returns>
        /// <exception cref="OverflowException">Thrown when <see cref="Environment.TickCount"/> result overflows after 24.9 days.</exception>
        public static TimeSpan GetUptime()
        {
            return TimeSpan.FromMilliseconds(Environment.TickCount);
        }

        /// <summary>
        /// Gets the total free space for all available drives.
        /// </summary>
        /// <returns>
        /// A dictionary containing drive names and their corresponding total free space values in bytes.
        /// </returns>
        public static Dictionary<string, long> GetDriveFreeSpace()
        {
            var result = new Dictionary<string, long>();
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    result.Add(drive.Name, drive.TotalFreeSpace);
                }
            }

            return result;
        }
    }

    /// <summary>
    /// Provides access to environment variables and related operations.
    /// </summary>
    public static class EnvironmentVariables
    {
        /// <summary>
        /// Gets the value of an environment variable or the specified default value.
        /// </summary>
        /// <param name="name">The environment variable name.</param>
        /// <param name="defaultValue">The value to return if the variable is not set.</param>
        /// <returns>The environment variable value or the default value.</returns>
        public static string GetVariable(string name, string defaultValue)
        {
            string variable = Environment.GetEnvironmentVariable(name);
            variable ??= defaultValue;

            return variable;
        }

        /// <summary>
        /// Gets the value of an environment variable from the specified target
        /// or the specified default value.
        /// </summary>
        /// <param name="name">The environment variable name.</param>
        /// <param name="defaultValue">The value to return if the variable is not set.</param>
        /// <param name="environmentVariableTarget">The environment variable target scope.</param>
        /// <returns>The environment variable value or the default value.</returns>
        public static string GetVariable(string name, string defaultValue, EnvironmentVariableTarget environmentVariableTarget)
        {
            string variable = Environment.GetEnvironmentVariable(name, environmentVariableTarget);
            variable ??= defaultValue;

            return variable;
        }

        /// <summary>
        /// Gets all environment variables as a dictionary.
        /// </summary>
        /// <returns>A dictionary containing all environment variables.</returns>
        public static Dictionary<string, string> GetVariables()
        {
            var variables = Environment.GetEnvironmentVariables();
            var result = new Dictionary<string, string>();

            foreach (var variable in variables)
            {
                DictionaryEntry entry = (DictionaryEntry)variable;
                result.Add(entry.Key.ToString(), entry.Value.ToString());
            }

            return result;
        }

        /// <summary>
        /// Sets the value of an environment variable for the current process.
        /// </summary>
        /// <param name="name">The environment variable name.</param>
        /// <param name="value">The value to assign.</param>
        /// <exception cref="ArgumentException">Thrown when the name is invalid.</exception>
        public static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
        }

        /// <summary>
        /// Sets the value of an environment variable in the specified target.
        /// </summary>
        /// <param name="name">The environment variable name.</param>
        /// <param name="value">The value to assign.</param>
        /// <param name="environmentVariableTarget">The environment variable target scope.</param>
        /// <exception cref="ArgumentException">Thrown when the name is invalid.</exception>
        public static void SetVariable(string name, string value, EnvironmentVariableTarget environmentVariableTarget)
        {
            Environment.SetEnvironmentVariable(name, value, environmentVariableTarget);
        }

        /// <summary>
        /// Deletes an environment variable from the current process.
        /// </summary>
        /// <param name="name">The environment variable name.</param>
        public static void DeleteVariable(string name)
        {
            Environment.SetEnvironmentVariable(name, null);
        }

        /// <summary>
        /// Deletes an environment variable from the specified target.
        /// </summary>
        /// <param name="name">The environment variable name.</param>
        /// <param name="environmentVariableTarget">The environment variable target scope.</param>
        public static void DeleteVariable(string name, EnvironmentVariableTarget environmentVariableTarget)
        {
            Environment.SetEnvironmentVariable(name, null, environmentVariableTarget);
        }

        /// <summary>
        /// Indicates whether the specified environment variable exists.
        /// </summary>
        /// <param name="name">The environment variable name.</param>
        /// <returns>True if the environment variable exists; otherwise, false.</returns>
        public static bool Exists(string name)
        {
            return Environment.GetEnvironmentVariable(name) != null;
        }
    }

    /// <summary>
    /// Provides access to commonly used system directories.
    /// </summary>
    public static class SystemDirectories
    {
        /// <summary>
        /// Gets the current working directory.
        /// </summary>
        public static string CurrentDirectory => Environment.CurrentDirectory;

        /// <summary>
        /// Gets the path to the desktop directory.
        /// </summary>
        public static string Desktop => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        /// <summary>
        /// Gets the path to the documents directory.
        /// </summary>
        public static string Documents => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Gets the path to the local application data directory.
        /// </summary>
        public static string LocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        /// <summary>
        /// Gets the path to the system temporary directory.
        /// </summary>
        public static string Temporary => Path.GetTempPath();
    }
}
