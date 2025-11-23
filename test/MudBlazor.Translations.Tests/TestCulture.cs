using System.Globalization;

namespace MudBlazor.Translations.Tests;

public static class TestCulture
{
    public static async Task RunAsync(string culture, string uiCulture, Func<Task> testBody)
    {
        var orig = CultureInfo.CurrentCulture;
        var origUi = CultureInfo.CurrentUICulture;
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(uiCulture);
            await testBody();
        }
        finally
        {
            CultureInfo.CurrentCulture = orig;
            CultureInfo.CurrentUICulture = origUi;
        }
    }
}
