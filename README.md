[![GitHub](https://img.shields.io/github/license/meenzen/MudBlazor.Translations.svg)](https://github.com/meenzen/MudBlazor.Translations/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MudBlazor.Translations.svg)](https://www.nuget.org/packages/MudBlazor.Translations)
[![NuGet](https://img.shields.io/nuget/dt/MudBlazor.Translations.svg)](https://www.nuget.org/packages/MudBlazor.Translations)
[![Translation status](https://hosted.weblate.org/widget/mudblazor/svg-badge.svg)](https://hosted.weblate.org/engage/mudblazor/)
[![Discord](https://img.shields.io/discord/786656789310865418?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.gg/mudblazor)

# MudBlazor.Translations

Community translations for the MudBlazor component library.

## Compatibility

| MudBlazor | MudBlazor.Translations |
|-----------|------------------------|
| 7.x.x     | 1.x.x                  |
| 8.x.x     | 2.x.x                  |

## Installation

Install the package

```bash
dotnet add package MudBlazor.Translations
```

Add the following to the relevant sections of `Program.cs`

```csharp
using MudBlazor.Translations;
```

```csharp
builder.Services.AddMudTranslations();
```

> [!IMPORTANT]
> Blazor localization needs to be configured, otherwise Blazor will default to English.

To learn more about Localization in Blazor visit
the [ASP.NET Core Blazor globalization and localization](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization)
documentation page.

## Translation Status

[![Translation status](https://hosted.weblate.org/widget/mudblazor/multi-auto.svg)](https://hosted.weblate.org/engage/mudblazor/)

## License

This project is licensed under the MIT License. See the [LICENSE](https://choosealicense.com/licenses/mit/) file for details.

## Contributing

Contributions are welcome! Please see the [CONTRIBUTING](CONTRIBUTING.md) guide for more details.

## Contact

For questions or support, please open an issue on this repository.

