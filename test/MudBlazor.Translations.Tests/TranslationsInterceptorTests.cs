using System.Globalization;
using Microsoft.Extensions.Localization;

namespace MudBlazor.Translations.Tests;

public class TranslationsInterceptorTests
{
    [Fact, UseCulture(culture: "en-US", uiCulture: "de-DE")]
    public void Translations_ShouldBeBasedOn_CurrentUICulture()
    {
        // Arrange
        MudTranslationsInterceptor interceptor = new();
        const string key = LanguageResource.MudAlert_Close;
        string? defaultTranslation = LanguageResource.ResourceManager.GetString(key, CultureInfo.InvariantCulture);

        // Act
        LocalizedString result = interceptor.Handle(key);

        // Assert
        defaultTranslation.Should().NotBeNullOrWhiteSpace();
        result.Name.Should().Be(key);
        result.Value.Should().NotBeNullOrWhiteSpace().And.NotBe(key);
        result.Value.Should().NotBe(defaultTranslation);
        result.ResourceNotFound.Should().BeFalse();
    }

    [Fact, UseCulture(culture: "en-US", uiCulture: "en-US")]
    public void Translations_ShouldDefaultTo_English()
    {
        // Arrange
        MudTranslationsInterceptor interceptor = new();
        const string key = LanguageResource.MudAlert_Close;
        string? defaultTranslation = LanguageResource.ResourceManager.GetString(key, CultureInfo.InvariantCulture);

        // Act
        LocalizedString result = interceptor.Handle(key);

        // Assert
        defaultTranslation.Should().NotBeNullOrWhiteSpace();
        result.Name.Should().Be(key);
        result.Value.Should().NotBeNullOrWhiteSpace().And.NotBe(key);
        result.Value.Should().Be(defaultTranslation);
        result.ResourceNotFound.Should().BeFalse();
    }
}
