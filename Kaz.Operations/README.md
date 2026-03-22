<p align="center">
  <img width="200" alt="OperationsIconNoBg" src="https://github.com/user-attachments/assets/fe8dc34e-fca3-4385-942e-2c7840f6bede" />
</p>

<h1 align="center">Kaz.Operations</h1>

<p align="center">
  A utility library for .NET Framework 4.7.2 — string manipulation, numerics, collections,<br/>
  cryptography, date/time, file I/O, system info, and certificate utilities, all in one package.
</p>

<p align="center">
  <a href="https://www.nuget.org/packages/Kaz.Operations"><img src="https://img.shields.io/nuget/v/Kaz.Operations?color=blue&logo=nuget" alt="NuGet Version"></a>
  <a href="https://www.nuget.org/packages/Kaz.Operations"><img src="https://img.shields.io/nuget/dt/Kaz.Operations?color=blue" alt="NuGet Downloads"></a>
  <img src="https://img.shields.io/badge/.NET%20Framework-4.7.2-purple" alt=".NET Framework">
  <img src="https://img.shields.io/badge/language-C%23-239120?logo=csharp" alt="Language">
</p>

<p align="center">
  <a href="https://github.com/bronsk1y/Kaz.Operations/releases/latest"><img src="https://img.shields.io/github/v/release/bronsk1y/Kaz.Operations?label=latest%20release&color=brightgreen" alt="Latest Release"></a>
  <a href="https://github.com/bronsk1y/Kaz.Operations/releases"><img src="https://img.shields.io/github/release-date/bronsk1y/Kaz.Operations?color=blue" alt="Release Date"></a>
  <a href="https://github.com/bronsk1y/Kaz.Operations/releases"><img src="https://img.shields.io/github/downloads/bronsk1y/Kaz.Operations/total?color=orange" alt="GitHub Downloads"></a>
  <a href="https://github.com/bronsk1y/Kaz.Operations/releases"><img src="https://img.shields.io/github/commits-since/bronsk1y/Kaz.Operations/latest?color=yellow" alt="Commits since release"></a>
</p>

---

## ⚡ Installation

```bash
dotnet add package Kaz.Operations
```

```powershell
Install-Package Kaz.Operations
```

---

## 📦 What's Inside

| Namespace | Description |
|---|---|
| `Kaz.Operations.Text` | String editing, format validation (email, URL, IP, regex…) |
| `Kaz.Operations.Numerics` | Safe type conversion, clamp, lerp, factorial, prime check |
| `Kaz.Operations.Collections` | Merge/counting sort, linear/binary/interpolation search |
| `Kaz.Operations.Time` | Weekend/weekday checks, past/present/future, date validation |
| `Kaz.Operations.IO` | File CRUD, encoding control, directory validation |
| `Kaz.Operations.Security.Cryptography` | SHA-256/512, MD5, HMAC, PBKDF2 hashing |
| `Kaz.Operations.System` | Machine info, environment variables, system directories |
| `Kaz.Operations.Security.Certificates` | Load, validate, and inspect X.509 certificates |

---

## 🔎 Usage

<details>
<summary><b>Text</b></summary>

```csharp
"abc".Reverse();                              // "cba"
"example@gmail.com".IsEmail();                // true
"https://example.com".IsUrl(UrlScheme.Https); // true
```
</details>

<details>
<summary><b>Numerics</b></summary>

```csharp
"19.99".ToNumericOrDefault<double>(0.0); // 19.99
10.Clamp(0, 5);                          // 5
7.IsPrime();                             // true
```
</details>

<details>
<summary><b>Collections</b></summary>

```csharp
var list = new List<int> { 5, 3, 8, 1 };
list.MergeSort();      // [1, 3, 5, 8]
list.BinarySearch(3);  // index 1
```
</details>

<details>
<summary><b>Cryptography</b></summary>

```csharp
string hash   = Sha256.Hash("hello world");
bool   match  = Sha256.Compare("hello world", hash); // true

byte[] salt   = Pbkdf2.GenerateSalt();
string pwHash = Pbkdf2.HMACSHA256("my-password", salt, 10000);
```
</details>

<details>
<summary><b>Time</b></summary>

```csharp
new DateTime(2025, 1, 4).IsWeekend();     // true (Saturday)
DateTime.UtcNow.AddDays(-1).IsPastDate(); // true
"2025-01-01".IsValidDate();               // true
```
</details>

<details>
<summary><b>IO</b></summary>

```csharp
CRUD.AppendLine("logs/app.log", "Started");
List<string> lines = CRUD.ReadAllLines("data/file.txt", skipEmpty: true);
Validation.EnsureExists("logs/archive"); // creates directory if missing
```
</details>

<details>
<summary><b>System</b></summary>

```csharp
bool   isAdmin = SystemInfo.IsAdministrator;
double mb      = SystemInfo.WorkingSetMb;
string path    = EnvironmentVariables.GetVariable("PATH", "default");
```
</details>

<details>
<summary><b>Certificates</b></summary>

```csharp
var      cert    = X509CertificateInfo.LoadCertificate("mycert.pfx", "password");
bool     trusted = cert.IsTrusted();
DateTime exp     = cert.GetExpirationDate();
```
</details>

---

## 📄 License

- This project is distributed under the MIT License — free for personal and commercial use.

---

## 🔗 Contact

- If you want to contact me about the NuGet package, collaboration, or any development‑related questions, feel free to reach out through the links below:

[![NuGet](https://img.shields.io/badge/NuGet-Kaz.Operations-blue?logo=nuget)](https://www.nuget.org/packages/Kaz.Operations)

