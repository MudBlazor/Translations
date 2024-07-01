using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace MudBlazor.Translations;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMudTranslations(this IServiceCollection services)
    {
        services.AddLocalizationInterceptor<MudTranslationsInterceptor>();
        return services;
    }
}
