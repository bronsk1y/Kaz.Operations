# Kaz.Operations

A set of utilities for working with strings, numeric conversions, and collections.
The package extends the standard capabilities of .NET and provides a unified API for basic operations.

**Dependency**: `Kaz.Operations.Core`

---

## Possibilities

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

        ``` csharp
        string example = "123";
        bool isNumeric= example.IsNumeric(); // true
        ```

        - ### `IsEmail`

        ``` csharp
        string example = "example@gmail.com";
        bool isEmail = example.IsEmail(); // true

        string example1 = "@hi.gmail.com".IsEmail(); 
        bool isEmail1 = example.IsEmail(); // false
        ```

        - ### `IsPhoneNumber`

        ```csharp
        string example = "+442079460000"; // only supports E.164 format
        bool isPhoneNumber = example.IsPhoneNumber(); // true

        string example1 = "+012345"; 
        bool isPhoneNumber1 = example1.IsPhoneNumber(); // false
        ```

        - **A bunch of other cool methods!**

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

        double number1 = 1000m;

        // RatioOfTotal (Calculates percentage ratio)
        decimal total = number1.CalculatePercentage(20, PercentageCalculationMethod.RatioOfTotal); // 200
        ```

        - ### `Lerp (+2 overloads)`

        ```csharp
        // Also supports overloads for float and decimal

        double example = 15;
        Console.WriteLine(example.Lerp(16, 0.5)); // 15.5
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

        -  ### `LinearSearch`

        ```csharp
        var list = {1, 2, 3};
        int index = list.LinearSearch(2); // 1 
        ```

        - **Other searching methods!**

    ---

    - **Note:** `BubbleSort` and `SelectionSort` are marked as deprecated and are not recommended for use (for educational purposes only).
        
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