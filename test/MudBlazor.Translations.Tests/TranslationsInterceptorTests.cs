using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.Extensions.Localization;

namespace MudBlazor.Translations.Tests;

[SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods")]
[SuppressMessage("Major Code Smell", "S4144:Methods should not have identical implementations")]
public class TranslationsInterceptorTests
{
    [Test]
    public async Task Translations_ShouldBeBasedOn_CurrentUICulture() =>
        await TestCulture.RunAsync(
            "en-US",
            "de-DE",
            async () =>
            {
                // Arrange
                MudTranslationsInterceptor interceptor = new();
                const string key = LanguageResource.MudAlert_Close;
                string? defaultTranslation = LanguageResource.ResourceManager.GetString(
                    key,
                    CultureInfo.InvariantCulture
                );

                // Act
                LocalizedString result = interceptor.Handle(key);

                // Assert
                await Assert.That(defaultTranslation).IsNotNullOrWhiteSpace();
                await Assert.That(result.Name).IsEqualTo(key);
                await Assert.That(result.Value).IsNotNullOrWhiteSpace();
                await Assert.That(result.Value).IsNotEqualTo(key);
                await Assert.That(result.Value).IsNotEqualTo(defaultTranslation);
                await Assert.That(result.ResourceNotFound).IsFalse();
            }
        );

    [Test]
    public async Task Translations_ShouldDefaultTo_English() =>
        await TestCulture.RunAsync(
            "en-US",
            "en-US",
            async () =>
            {
                // Arrange
                MudTranslationsInterceptor interceptor = new();
                const string key = LanguageResource.MudAlert_Close;
                string? defaultTranslation = LanguageResource.ResourceManager.GetString(
                    key,
                    CultureInfo.InvariantCulture
                );

                // Act
                LocalizedString result = interceptor.Handle(key);

                // Assert
                await Assert.That(defaultTranslation).IsNotNullOrWhiteSpace();
                await Assert.That(result.Name).IsEqualTo(key);
                await Assert.That(result.Value).IsNotNullOrWhiteSpace();
                await Assert.That(result.Value).IsNotEqualTo(key);
                await Assert.That(result.Value).IsEqualTo(defaultTranslation);
                await Assert.That(result.ResourceNotFound).IsFalse();
            }
        );
}
