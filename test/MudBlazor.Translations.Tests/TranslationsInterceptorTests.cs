using System.Collections;
using System.Globalization;
using System.Resources;
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

    [Fact, UseCulture(culture: "en-US", uiCulture: "nn-NO")]
    public void All_keys_except_known_identical_keys_are_translated_nnNO() => AssertAllKeys();

    [Fact, UseCulture(culture: "en-US", uiCulture: "nb-NO")]
    public void All_keys_except_known_identical_keys_are_translated_nbNO() => AssertAllKeys();

    /* Known identical keys between nn-NO/nb-NO and en-US culture */
    private static readonly HashSet<string> IdenticalAcrossFiles = new(StringComparer.Ordinal)
    {
        "MudDataGrid_EqualSign",
        "MudDataGrid_Filter",
        "MudDataGrid_GreaterThanOrEqualSign",
        "MudDataGrid_GreaterThanSign",
        "MudDataGrid_LessThanOrEqualSign",
        "MudDataGrid_LessThanSign",
        "MudDataGrid_NotEqualSign",
        "MudDataGrid_Operator",
    };

    private static void AssertAllKeys()
    {
        MudTranslationsInterceptor interceptor = new MudTranslationsInterceptor();
        ResourceManager rm = LanguageResource.ResourceManager;

        ResourceSet? invariantSet = rm.GetResourceSet(
            CultureInfo.InvariantCulture,
            createIfNotExists: true,
            tryParents: true
        );
        invariantSet.Should().NotBeNull("we need the neutral resources to compare against");

        foreach (DictionaryEntry entry in invariantSet!)
        {
            if (entry.Key is not string key || entry.Value is not string invariantValue)
            {
                continue;
            }

            if (IdenticalAcrossFiles.Contains(key))
            {
                continue;
            }

            // Act
            LocalizedString result = interceptor.Handle(key);

            // Assert
            invariantValue.Should().NotBeNullOrWhiteSpace();
            result.Name.Should().Be(key);
            result.Value.Should().NotBeNullOrWhiteSpace().And.NotBe(key);
            result.Value.Should().NotBe(invariantValue);
            result.ResourceNotFound.Should().BeFalse();
        }
    }
}
