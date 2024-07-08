using System.Globalization;
using Microsoft.Extensions.Localization;

namespace MudBlazor.Translations;

/// <summary>
/// Provides crowdsourced translations for the MudBlazor component library.
/// </summary>
public class MudTranslationsInterceptor : ILocalizationInterceptor
{
    /// <inheritdoc />
    public LocalizedString Handle(string key, params object[] arguments)
    {
        bool notFound = false;
        string? translation = LanguageResource.ResourceManager.GetString(key, CultureInfo.CurrentUICulture);

        // Weblate likes to create empty stubs for missing translations, so we need to ignore those and
        // use english as a fallback.
        if (
            !Equals(CultureInfo.CurrentUICulture, CultureInfo.InvariantCulture)
            && string.IsNullOrWhiteSpace(translation)
        )
        {
            translation = LanguageResource.ResourceManager.GetString(key, CultureInfo.InvariantCulture);
            notFound = true;
        }

        if (translation is not null && arguments.Length > 0)
        {
            translation = string.Format(translation, arguments);
        }

        if (translation is null)
        {
            translation = key;
            notFound = true;
        }

        return new LocalizedString(key, translation, notFound);
    }
}
