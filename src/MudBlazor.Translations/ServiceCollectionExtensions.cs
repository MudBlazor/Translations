using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace MudBlazor.Translations;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="MudTranslationsInterceptor"/> to the service collection, replacing the default <see cref="ILocalizationInterceptor"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the interceptor to.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddMudTranslations(this IServiceCollection services)
    {
        services.AddLocalizationInterceptor<MudTranslationsInterceptor>();
        return services;
    }
}
