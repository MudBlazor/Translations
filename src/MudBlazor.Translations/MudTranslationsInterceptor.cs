using System.Globalization;
using Microsoft.Extensions.Localization;

namespace MudBlazor.Translations;

/// <summary>
/// Provides community translations for the MudBlazor component library.
/// </summary>
public class MudTranslationsInterceptor : ILocalizationInterceptor
{
    public LocalizedString Handle(string key, params object[] arguments)
    {
        // rewrite upstream key to match overrides
        key = key switch
        {
            "MudDataGrid.=" => "MudDataGrid.Equal",
            "MudDataGrid.!=" => "MudDataGrid.NotEqual",
            "MudDataGrid.>" => "MudDataGrid.MoreThan",
            "MudDataGrid.>=" => "MudDataGrid.MoreThanOrEqual",
            "MudDataGrid.<" => "MudDataGrid.LessThan",
            "MudDataGrid.<=" => "MudDataGrid.LessThanOrEqual",
            _ => key
        };

        string? translation = LanguageResource.ResourceManager.GetString(key, CultureInfo.CurrentCulture);

        if (translation is not null && arguments.Length > 0)
        {
            translation = string.Format(translation, arguments);
        }

        return new LocalizedString(key, translation ?? key, translation == null);
    }
}
