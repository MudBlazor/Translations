using MudBlazor.Services;
using MudBlazor.Translations;
using MudBlazor.Translations.SampleApp;
using MudBlazor.Translations.SampleApp.Components;

var builder = WebApplication.CreateBuilder(args);

AppOptions appOptions = builder.Configuration.GetSection("AppOptions").Get<AppOptions>()!;
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("AppOptions"));

// Add MudBlazor services
builder.Services.AddMudServices();

// Add MudBlazor.Translations
builder.Services.AddMudTranslations();
builder.Services.AddLocalization();

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseRequestLocalization(
    new RequestLocalizationOptions()
        .SetDefaultCulture(appOptions.SupportedCultures[0])
        .AddSupportedCultures(appOptions.SupportedCultures)
        .AddSupportedUICultures(appOptions.SupportedCultures)
);

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.MapControllers();

await app.RunAsync();
