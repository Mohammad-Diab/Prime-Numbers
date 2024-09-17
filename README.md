# Prime Numbers

A small Windows app that finds the prime numbers up to a number you choose, with six methods from the slowest to the fastest, and shows how long each one takes. The interface is in Arabic or English. Written in C# with WPF on .NET Framework 4.0.

## Features

- Type a number, pick a method, and choose a text file: the primes up to that number are saved in it, one per line, and a message shows how many were found and the time in milliseconds.
- The six methods:
  - **Slowest**: divides each number by every number below it.
  - **Slow**: divides only up to the square root.
  - **Medium**: tries odd numbers only, divided by the primes up to the square root.
  - **Fast**: tries only numbers of the form 6k ± 1.
  - **Very Fast**: splits the range into four parts and works on them at the same time, writing four files to a folder you choose.
  - **The Fastest**: a parallel sieve of Eratosthenes.
- **View Numbers** also lists the primes in the window.
- **Settings** switches the interface between Arabic and English; the choice is remembered.
- **Help** opens `Help.ppsx`, Arabic slides that introduce algorithms with these methods as the example.

## Requirements

Windows with .NET Framework 4.0 or later. Windows 8, 10 and 11 already include it. **Help** needs PowerPoint or PowerPoint Viewer.

## Usage

Download the latest `Prime-Numbers-v<version>.7z` from [Releases](https://github.com/Mohammad-Diab/Prime-Numbers/releases), extract it, and run `Prime Numbers.exe`. Keep `Help.ppsx` in the same folder. There is no installer.

The exe is not signed, so Windows SmartScreen may warn the first time you run it: click **More info**, then **Run anyway**.

## Building

```
git clone https://github.com/Mohammad-Diab/Prime-Numbers.git
```

Open `Prime Numbers.sln` in Visual Studio and build, or run:

```
MSBuild "Prime Numbers.sln" /p:Configuration=Release
```

The exe is written to `Prime Numbers\bin\Release`.

The project targets .NET Framework 4.0. Recent Visual Studio versions don't ship its reference assemblies; if the build stops with `MSB3644`, extract the [Microsoft.NETFramework.ReferenceAssemblies.net40](https://www.nuget.org/packages/Microsoft.NETFramework.ReferenceAssemblies.net40) NuGet package and point MSBuild at its `build` folder:

```
MSBuild "Prime Numbers.sln" /p:Configuration=Release /p:TargetFrameworkRootPath=<package>\build
```

The [`trial-division`](https://github.com/Mohammad-Diab/Prime-Numbers/tree/trial-division) branch holds the other line of this program (v1.0.0, .NET Framework 4.5): it builds its table of small primes by trial division, and The Fastest is a single-threaded sieve.

## Author

Mohammad Diab

## License

[Apache 2.0](LICENSE)
