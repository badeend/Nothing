<p align="center">
  <img src="./docs/images/logo.png" alt="Nothing" width="300"/>
</p>

<p align="center">
  <em>If you want to use `void` as a type parameter, but C# won't let you...</em>
</p>

<p align="center">
  <a href="https://www.nuget.org/packages/Badeend.Nothing"><img src="https://img.shields.io/nuget/v/Badeend.Nothing" alt="Nuget"/></a>
</p>

---

`Badeend.Nothing` is struct that contains... well... nothing!

Also known as a "unit" type in Functional Programming parlance. 

In C# this can be used in places where you have nothing to return, but `void` is not allowed. Most notably: generics.

#### Example time!

Let's assume there exists an interface that you want to implement:

```cs
public interface IHandler<T>
{
  T Handle(MyInput input);
}
```

If your handler has nothing useful to return, then you would _want_ to write this:

```cs
public class MyHandler : IHandler<void> // COMPILE ERROR!
{
  void Handle(MyInput input)
  {
    // (my implementation here)
  }
}
```

Unfortunately, "Computer Says No". C# won't let you.

If you're lucky enough to own that interface, you could decide to duplicate the interface and all related code: one for `IHandler`, and one for `IHandler<T>`.

If you're not able to change the interface or just don't feel like doing a bunch of unnecessary work; you could also change the type argument to `Nothing`:

```cs
using Badeend;

public class MyHandler : IHandler<Nothing> // <--- Nothing to see here
{
  Nothing Handle(MyInput input)
  {
    // (my implementation here)

    return Nothing.Value;
  }
}
```

## Installation

[![NuGet Badeend.Nothing](https://img.shields.io/nuget/v/Badeend.Nothing?label=Badeend.Nothing)](https://www.nuget.org/packages/Badeend.Nothing)

```sh
dotnet add package Badeend.Nothing
```

## Fake `nothing` keyword

Depending on how intensively you use this package, you might be interested in using `Badeend.Nothing.Keyword` globally, which exposes `nothing` as a top level field.

```cs
using Badeend;

public class MyHandler : IHandler<Nothing>
{
  Nothing Handle(MyInput input)
  {
    // (my implementation here)

    return nothing; // <--- Note the lowercase 'n'
  }
}
```

In [C#10+](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive#global-modifier) this can be configured as follows:

```cs
global using static Badeend.Nothing.Keyword;
```

or:

```xml
<ItemGroup>
  <Using Include="Badeend.Nothing.Keyword" Static="True" />
</ItemGroup>
```

---

### Shameless self-promotion

May I interest you in one of my other packages?

- **[Badeend.ValueCollections](https://badeend.github.io/ValueCollections/)**: _Low overhead immutable collection types with structural equality._
- **[Badeend.EnumClass](https://badeend.github.io/EnumClass/)**: _Discriminated unions for C# with exhaustiveness checking._
- **[Badeend.Result](https://badeend.github.io/Result/)**: _For failures that are not exceptional: `Result<T,E>` for C#._
- **[Badeend.Any](https://badeend.github.io/Any/)**: _Holds any value of any type, without boxing small structs (up to 8 bytes)._
- **[Badeend.Nothing](https://github.com/badeend/Nothing)**: _If you want to use `void` as a type parameter, but C# won't let you._