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


<!--
[![LinkedIn](https://img.shields.io/badge/LinkedIn-white?logo=data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+Cjxzdmcgd2lkdGg9IjE4LjgwOTIyM21tIiBoZWlnaHQ9IjE5LjAwMDAwNG1tIiB2aWV3Qm94PSIwIDAgMTguODA5MjIzIDE5LjAwMDAwNCIgdmVyc2lvbj0iMS4xIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciPgogIDxnIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0zNC4wMTgzMjgsLTY5LjkyOTc1MikiPgogICAgPGc+CiAgICAgIDxyZWN0IHN0eWxlPSJmaWxsOiMwMDc3YjU7ZmlsbC1vcGFjaXR5OjEiIHdpZHRoPSIxOC44MDkyMjUiIGhlaWdodD0iMTkuMDAwMDA2IiB4PSIzNC4wMTgzMjYiIHk9IjY5LjkyOTc0OSIgcnk9IjEuODkwNTQ3OSIvPgogICAgICA8ZWxsaXBzZSBzdHlsZT0iZmlsbDojZmZmZmZmO2ZpbGwtb3BhY2l0eToxIiBjeD0iMzguMDkwMjM3IiBjeT0iNzMuMDY4NTUiIHJ4PSIxLjQyNzg3OTgiIHJ5PSIxLjQzNTMyMzUiLz4KICAgICAgPHBhdGggc3R5bGU9ImZpbGw6I2ZmZmZmZjtmaWxsLW9wYWNpdHk6MSIgZD0ibSAzNi41NDA2ODcsNzUuNjg5NzYyIHYgMTAuNzU3NTc2IGggMi45Nzc0MyBWIDc1LjY4OTc2MiBaIi8+CiAgICAgIDxnIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0xLjIzNTgxMjIsMC4xMTI2MjczNykiPgogICAgICAgIDxwYXRoIHN0eWxlPSJmaWxsOiNmZmZmZmY7ZmlsbC1vcGFjaXR5OjEiIGQ9Im0gNDIuOTIxOTE1LDg2LjI1NzU3NCBoIDIuOTc3NDMgViA3NS40OTk5OTggaCAtMi45Nzc0MyB6Ii8+CiAgICAgICAgPHBhdGggc3R5bGU9ImZpbGw6I2ZmZmZmZjtmaWxsLW9wYWNpdHk6MSIgZD0ibSA0OC43MDYyMTQsODYuMjU3NTc0IHYgLTguODAxNjUyIGwgMy4xNDc5OSwxMGUtNyAzZS02LDguODAxNjUxIHoiLz4KICAgICAgICA8cGF0aCBzdHlsZT0iZmlsbDojZmZmZmZmO2ZpbGwtb3BhY2l0eToxIiBkPSJtIDUxLjM3OTczOCw4Ny45NTI0MzYgYyAtMC41NzQzMjgsLTAuMDQ3NTYgLTAuODYxNDkzLC0wLjY0MjY4NCAtMS4xNDg2NTcsLTEuMjM3ODA3IDAuMjg4MTM5LC0wLjQwNDg3NyAwLjU3NjI3MiwtMC44MDk3NDYgMS40NDIwNDcsLTEuMTgxNTQ5IDAuODY1Nzc0LC0wLjM3MTgwNCAyLjMwOTA5MywtMC43MTA1MDYgMy42NTM1NDksLTAuNjU0ODIzIDEuMzQ0NDU3LDAuMDU1NjggMi41ODk4OTUsMC41MDU3NDQgMy4xNjQ4NDQsMS4yNTg0NDkgMC41NzQ5NDgsMC43NTI3MDUgMC40NzkzNCwxLjgwNzk4OCAtMC40MzQ4MzEsMi4wMDIzMDYgLTAuOTE0MTcyLDAuMTk0MzE5IC0yLjY0Njg3MywtMC40NzIzMzUgLTMuOTQ0MDEsLTAuNTU1NjcgLTEuMjk3MTM4LC0wLjA4MzM0IC0yLjE1ODYxNCwwLjQxNjY1NiAtMi43MzI5NDIsMC4zNjkwOTQgeiIgdHJhbnNmb3JtPSJtYXRyaXgoMC44NjQwMzI0NiwwLDAsMC45Nzc5NjE0MywxLjAwOTM0NTMsLTcuNjI2NzE5OCkiLz4KICAgICAgPC9nPgogICAgPC9nPgogIDwvZz4KPC9zdmc+Cg==)](https://linkedin.com/in/artem-kazantsev-39a3213b9)
-->
