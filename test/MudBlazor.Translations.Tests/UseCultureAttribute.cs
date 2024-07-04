using System.Globalization;
using System.Reflection;
using Xunit.Sdk;

namespace MudBlazor.Translations.Tests;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class UseCultureAttribute : BeforeAfterTestAttribute
{
    private readonly CultureInfo _culture;
    private readonly CultureInfo _uiCulture;
    private CultureInfo? _originalCulture;
    private CultureInfo? _originalUICulture;

    public UseCultureAttribute(string culture, string uiCulture)
    {
        _culture = new CultureInfo(culture);
        _uiCulture = new CultureInfo(uiCulture);
    }

    public override void Before(MethodInfo methodUnderTest)
    {
        _originalCulture = CultureInfo.CurrentCulture;
        _originalUICulture = CultureInfo.CurrentUICulture;
        Thread.CurrentThread.CurrentCulture = _culture;
        Thread.CurrentThread.CurrentUICulture = _uiCulture;
    }

    public override void After(MethodInfo methodUnderTest)
    {
        Thread.CurrentThread.CurrentCulture = _originalCulture!;
        Thread.CurrentThread.CurrentUICulture = _originalUICulture!;
    }
}
