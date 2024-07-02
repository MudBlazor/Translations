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
        // rewrite upstream key to match overrides
        string fixedKey = key switch
        {
            "MudDataGrid.=" => "MudDataGrid.Equal",
            "MudDataGrid.!=" => "MudDataGrid.NotEqual",
            "MudDataGrid.>" => "MudDataGrid.MoreThan",
            "MudDataGrid.>=" => "MudDataGrid.MoreThanOrEqual",
            "MudDataGrid.<" => "MudDataGrid.LessThan",
            "MudDataGrid.<=" => "MudDataGrid.LessThanOrEqual",
            _ => key
        };

        bool notFound = false;
        string? translation = LanguageResource.ResourceManager.GetString(fixedKey, CultureInfo.CurrentCulture);

        // Weblate likes to create empty stubs for missing translations, so we need to ignore those and
        // use english as a fallback.
        if (!Equals(CultureInfo.CurrentCulture, CultureInfo.InvariantCulture) && string.IsNullOrWhiteSpace(translation))
        {
            translation = LanguageResource.ResourceManager.GetString(fixedKey, CultureInfo.InvariantCulture);
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
