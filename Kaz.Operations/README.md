# Kaz.Operations

Provides string manipulation, numeric conversion, collection algorithms, cryptographic hashing, date/time validation, file I/O, system environment access, and certificate utilities for .NET Framework 4.7.2.

---

## Features

---
- ### `Kaz.Operations.Text`

    - #### String editing and manipulation:

        - ### `Reverse`

        ```csharp
        string example = "abc";
        string reversed = example.Reverse(); // cba
        ```

        - ### `RemoveWhiteSpaces`

        ```csharp
        string example = "a b c";
        string noWhiteSpaces = example.RemoveWhiteSpaces(); // abc
        ```

        - ### `ExtractAllNumbers`

        ```csharp
        string example = "a1b2c";
        var digits = input.ExtractAllNumbers(NumberExtractionOptions.Digits); // 1, 2 (List<string>)
        ```

        - ### `ExtractPattern`

        ```csharp
        Regex regex = new Regex(@"[A-Z]");
        string example = "Hello User!".ExtractPattern(regex); // HU
        ```

    - #### If Regex is null, an exception will be thrown:

        ```csharp
        string example = "Hello User!".ExtractPattern(null); // Throws ArgumentNullException
        ```

    ---
    - #### Checking strings for format compliance:

        - ### `IsNumeric`

        ```csharp
        string example = "123";
        bool isNumeric = example.IsNumeric(); // true
        ```

        - ### `IsEmail`

        ```csharp
        string example = "example@gmail.com";
        bool isEmail = example.IsEmail(); // true

        string example1 = "@hi.gmail.com";
        bool isEmail1 = example1.IsEmail(); // false
        ```

        - ### `IsPhoneNumber`

        ```csharp
        string example = "+442079460000"; // only supports E.164 format
        bool isPhoneNumber = example.IsPhoneNumber(); // true

        string example1 = "+012345";
        bool isPhoneNumber1 = example1.IsPhoneNumber(); // false
        ```

        - ### `IsAlpha`

        ```csharp
        string example = "Hello World";
        bool isAlpha = example.IsAlpha(); // true

        string example1 = "Hello123";
        bool isAlpha1 = example1.IsAlpha(); // false
        ```

        - ### `IsBoolean`

        ```csharp
        bool result = "true".IsBoolean(); // true
        bool result1 = "1".IsBoolean(); // true
        bool result2 = "yes".IsBoolean(); // false
        ```

        - ### `IsUrl`

        ```csharp
        bool result = "https://example.com".IsUrl(); // true

        // With specific scheme
        bool result1 = "http://example.com".IsUrl(UrlScheme.Https); // false
        bool result2 = "https://example.com".IsUrl(UrlScheme.Https); // true
        ```

        - ### `IsIpAddress`

        ```csharp
        bool result = "192.168.1.1".IsIpAddress(); // true

        // With specific version
        bool result1 = "192.168.1.1".IsIpAddress(IpVersion.IPv4); // true
        bool result2 = "::1".IsIpAddress(IpVersion.IPv6); // true
        ```

        - ### `MatchesPattern (+1 overload)`

        ```csharp
        bool result = "Hello123".MatchesPattern(@"^[A-Za-z0-9]+$"); // true

        // With RegexOptions
        bool result1 = "HELLO".MatchesPattern(@"^hello$", RegexOptions.IgnoreCase); // true
        ```

---
- ### `Kaz.Operations.Numerics`

    - #### Safe conversion of string values into numeric types:

        - ### `ToNumericOrDefault<T>`

        ```csharp
        // Supported types: int, long, float, double, decimal, short, byte.

        string example = "123";
        int number = example.ToNumericOrDefault<int>(0); // 123

        string invalidExample = "invalid";
        int fallback = invalidExample.ToNumericOrDefault<int>(0); // 0 (Specified default value)

        string example1 = "19.99";
        double price = example1.ToNumericOrDefault<double>(0.0); // 19.99
        ```

    ---
    - #### Math operations:

        - ### `Clamp<T>`

        ```csharp
        int number = 10;
        int result = number.Clamp(0, 5); // 5
        ```

        - ### `CalculatePercentage<T>`

        ```csharp
        double number = 500;

        // FractionOfTotal (Calculates 10% of 500)
        double result = number.CalculatePercentage(10, PercentageCalculationMethod.FractionOfTotal); // 50

        decimal number1 = 1000m;

        // RatioOfTotal (Calculates percentage ratio)
        decimal total = number1.CalculatePercentage(20, PercentageCalculationMethod.RatioOfTotal); // 200
        ```

        - ### `Lerp (+2 overloads)`

        ```csharp
        // Also supports overloads for float and decimal

        double example = 15;
        Console.WriteLine(example.Lerp(16, 0.5)); // 15.5
        ```

        - ### `Factorial (+1 overload)`

        ```csharp
        // Also supports long overload

        int number = 5;
        int result = number.Factorial(); // 120
        ```

        - ### `IsPrime (+1 overload)`

        ```csharp
        // Also supports long overload

        int number = 7;
        bool result = number.IsPrime(); // true

        int number1 = 10;
        bool result1 = number1.IsPrime(); // false
        ```

---
- ### `Kaz.Operations.Collections`

    - #### Sorting IList collections:

        - ### `MergeSort`

        ```csharp
        var items = new List<int> { 5, 3, 8, 1 };
        items.MergeSort(); // [1, 3, 5, 8]
        ```

        - ### `CountingSort`

        ```csharp
        var users = new List<User>
        {
            new User { Id = 103, Name = "Alice" },
            new User { Id = 101, Name = "Bob" }
        };
        users.CountingSort(u => u.Id); // Sorted by Id property
        ```

        - ### `BubbleSort`

        ```csharp
        int[] list = {3, 2, 1};
        list.BubbleSort(); // [1, 2, 3]
        ```

        - ### `SelectionSort`

        ```csharp
        int[] list = {3, 2, 1};
        list.SelectionSort(); // [1, 2, 3]
        ```

    ---

    - #### Searching through IList collections:

        - ### `LinearSearch`

        ```csharp
        var list = new List<int> { 1, 2, 3 };
        int index = list.LinearSearch(2); // 1
        ```

        - ### `BinarySearch`

        ```csharp
        // List must be sorted
        var list = new List<int> { 1, 2, 3, 4, 5 };
        int index = list.BinarySearch(3); // 2
        ```

        - ### `InterpolationSearch`

        ```csharp
        // List must be sorted, works only with int
        var list = new List<int> { 10, 20, 30, 40, 50 };
        int index = list.InterpolationSearch(30); // 2
        ```

    ---

    - **Note:** `BubbleSort` and `SelectionSort` are marked as deprecated and are not recommended for use (for educational purposes only).

---
- ### `Kaz.Operations.Time`

    - #### Checking date and time conditions:

        - ### `IsWeekend`

        ```csharp
        DateTime date = new DateTime(2025, 1, 4); // Saturday
        bool result = date.IsWeekend(); // true
        ```

        - ### `IsWeekday`

        ```csharp
        DateTime date = new DateTime(2025, 1, 6); // Monday
        bool result = date.IsWeekday(); // true
        ```

        - ### `IsPastDate`

        ```csharp
        DateTime date = DateTime.UtcNow.AddDays(-1);
        bool result = date.IsPastDate(); // true
        ```

        - ### `IsPresentDate`

        ```csharp
        DateTime date = DateTime.UtcNow;
        bool result = date.IsPresentDate(); // true
        ```

        - ### `IsFutureDate`

        ```csharp
        DateTime date = DateTime.UtcNow.AddDays(1);
        bool result = date.IsFutureDate(); // true
        ```

    ---
    - #### Validating date and time values:

        - ### `IsValidTime`

        ```csharp
        bool result = Validation.IsValidTime(seconds: 30, minutes: 45, hours: 12); // true
        bool result1 = Validation.IsValidTime(seconds: 61, minutes: 0, hours: 0); // false
        ```

        - ### `IsValidDate (+2 overloads)`

        ```csharp
        bool result = "2025-01-01".IsValidDate(); // true
        bool result1 = "not-a-date".IsValidDate(); // false

        // With format
        bool result2 = "01/01/2025".IsValidDate("MM/dd/yyyy"); // true

        // With format and culture
        bool result3 = "01.01.2025".IsValidDate("dd.MM.yyyy", new CultureInfo("de-DE")); // true
        ```

        - ### `IsValidMonth`

        ```csharp
        bool result = 6.IsValidMonth(); // true
        bool result1 = 13.IsValidMonth(); // false
        ```

        - ### `IsInRange`

        ```csharp
        DateTime date = new DateTime(2025, 6, 15);
        DateTime from = new DateTime(2025, 1, 1);
        DateTime to = new DateTime(2025, 12, 31);

        bool result = date.IsInRange(from, to); // true
        ```

    - #### If bound1 is greater than bound2, an exception will be thrown:

        ```csharp
        date.IsInRange(to, from); // Throws ArgumentException
        ```

---
- ### `Kaz.Operations.IO`

    - #### File CRUD operations:

        - ### `AppendLine`

        ```csharp
        bool success = CRUD.AppendLine("logs/app.log", "Application started."); // true
        ```

        - ### `CopyIfNewer`

        ```csharp
        bool copied = CRUD.CopyIfNewer("source/config.json", "backup/config.json"); // true if source is newer
        ```

        - ### `ReadAllLines (+1 overload)`

        ```csharp
        List<string> lines = CRUD.ReadAllLines("data/file.txt");

        // Skip empty lines
        List<string> filtered = CRUD.ReadAllLines("data/file.txt", skipEmpty: true);
        ```

        - ### `GetFilesByExtension`

        ```csharp
        List<string> files = CRUD.GetFilesByExtension("logs/", ".log");
        // or
        List<string> files1 = CRUD.GetFilesByExtension("logs/", "log"); // both formats supported
        ```

        - ### `TryDelete`

        ```csharp
        bool deleted = CRUD.TryDelete("temp/file.tmp"); // true if file existed and was deleted
        ```

    ---
    - #### File and directory validation:

        - ### `EnsureExists`

        ```csharp
        Validation.EnsureExists("logs/archive"); // Creates directory if it doesn't exist
        ```

        - ### `IsFileLocked`

        ```csharp
        bool locked = Validation.IsFileLocked("data/file.db"); // true if file is in use
        ```

    ---
    - **Note:** `CRUD.Encoding` defaults to UTF-8 and can be changed:

        ```csharp
        CRUD.Encoding = Encoding.Unicode;
        ```

---
- ### `Kaz.Operations.Security.Cryptography`

    - #### Hashing algorithms:

        - ### `Sha256.Hash (+1 overload)`

        ```csharp
        string hash = Sha256.Hash("hello world");

        // With custom encoding
        string hash1 = Sha256.Hash("hello world", Encoding.Unicode);
        ```

        - ### `Sha256.Compare (+2 overloads)`

        ```csharp
        bool match = Sha256.Compare("hello world", hash);

        // Compare against byte array
        bool match1 = Sha256.Compare("hello world", hashBytes);
        ```

        - **Same API available for `Sha512` and `Md5`.**

    ---
    - #### HMAC algorithms:

        - ### `HmacSha256.Hash (+1 overload)`

        ```csharp
        byte[] key = Encoding.UTF8.GetBytes("secret-key");
        string hash = HmacSha256.Hash("message", key);
        ```

        - ### `HmacSha256.Compare (+3 overloads)`

        ```csharp
        bool match = HmacSha256.Compare("message", hash, key);
        ```

        - **Same API available for `HmacSha1` and `HmacSha512`.**

    ---
    - #### Password hashing:

        - ### `Pbkdf2.HMACSHA256`

        ```csharp
        byte[] salt = Pbkdf2.GenerateSalt();
        string hash = Pbkdf2.HMACSHA256("my-password", salt, iterationCount: 10000);
        ```

        - ### `Pbkdf2.Compare`

        ```csharp
        bool match = Pbkdf2.Compare("my-password", salt, 10000, HashAlgorithmName.SHA256, hash);
        ```

        - ### `Pbkdf2.GenerateSalt (+1 overload)`

        ```csharp
        byte[] salt = Pbkdf2.GenerateSalt(); // 32-byte cryptographically secure salt

        // With offset and count
        byte[] salt1 = Pbkdf2.GenerateSalt(offset: 0, count: 16);
        ```

    - **Note:** `Pbkdf2.HMACSHA1` is marked as deprecated and is not recommended for security-critical operations.

---
- ### `Kaz.Operations.System`

    - #### System and runtime information:

        - ### `SystemInfo.IsAdministrator`

        ```csharp
        bool isAdmin = SystemInfo.IsAdministrator; // true if elevated
        ```

        - ### `SystemInfo.WorkingSetMb`

        ```csharp
        double mb = SystemInfo.WorkingSetMb; // 134.5
        ```

        - ### `SystemInfo.IsWindowsVersionAtLeast (+1 overload)`

        ```csharp
        bool result = SystemInfo.IsWindowsVersionAtLeast(10); // true on Windows 10+

        // With minor version
        bool result1 = SystemInfo.IsWindowsVersionAtLeast(10, 0); // true
        ```

        - ### `SystemInfo.GetUptime`

        ```csharp
        TimeSpan uptime = SystemInfo.GetUptime(); // 2.05:13:44
        ```

        - **Other properties:** `MachineName`, `UserName`, `UserDomainName`, `ProcessorCount`, `Is64BitOperatingSystem`, `Is64BitProcess`, `OSVersion`, `DotNetVersion`, `SystemDirectory`, `CommandLine`, `HasShutdownStarted`, `NewLine`, `PlatformID`, `TickCount`, `CurrentManagedThreadId`, `WorkingSet`.

    ---
    - #### Environment variables:

        - ### `EnvironmentVariables.GetVariable (+1 overload)`

        ```csharp
        string value = EnvironmentVariables.GetVariable("PATH", "default");

        // With target scope
        string value1 = EnvironmentVariables.GetVariable("PATH", "default", EnvironmentVariableTarget.Machine);
        ```

        - ### `EnvironmentVariables.GetVariables`

        ```csharp
        Dictionary<string, string> all = EnvironmentVariables.GetVariables();
        ```

        - ### `EnvironmentVariables.SetVariable (+1 overload)`

        ```csharp
        EnvironmentVariables.SetVariable("MY_VAR", "hello");
        ```

        - ### `EnvironmentVariables.DeleteVariable (+1 overload)`

        ```csharp
        EnvironmentVariables.DeleteVariable("MY_VAR");
        ```

        - ### `EnvironmentVariables.Exists`

        ```csharp
        bool exists = EnvironmentVariables.Exists("PATH"); // true
        ```

    ---
    - #### System directories:

        - ### `SystemDirectories.GetDriveFreeSpace`

        ```csharp
        Dictionary<string, long> space = SystemDirectories.GetDriveFreeSpace();
        // { "C:\", 53687091200 }
        ```

        - **Other properties:** `CurrentDirectory`, `Desktop`, `Documents`, `LocalAppData`, `Temporary`.

---
- ### `Kaz.Operations.Security.Certificates`

    - #### Loading certificates:

        - ### `LoadCertificate`

        ```csharp
        // Supported formats: .cer, .crt
        X509Certificate2 cert = X509CertificateInfo.LoadCertificate("mycert.cer");
        ```

        - ### `LoadCertificate (with password)`

        ```csharp
        // Supported formats: .pfx, .p12
        X509Certificate2 cert = X509CertificateInfo.LoadCertificate("mycert.pfx", "password");
        ```

    - #### If the file extension is invalid, an exception will be thrown:

        ```csharp
        X509CertificateInfo.LoadCertificate("mycert.xyz"); // Throws ArgumentException
        ```

    ---
    - #### Certificate validation:

        - ### `IsExpired`

        ```csharp
        bool expired = cert.IsExpired(); // true if past expiration date
        ```

        - ### `IsTrusted`

        ```csharp
        bool trusted = cert.IsTrusted(); // true if certificate chain is valid
        ```

        - ### `GetExpirationDate`

        ```csharp
        DateTime expiresOn = cert.GetExpirationDate(); // 01/01/2026 00:00:00
        ```

---
## Installation

- **.NET CLI:**

```bash
dotnet add package Kaz.Operations
```

- **NuGet Package Manager:**

```powershell
Install-Package Kaz.Operations
```

---
## Links

- [NuGet](https://www.nuget.org/packages/Kaz.Operations)