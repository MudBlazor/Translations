using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MudBlazor.Translations.SampleApp.Controllers;

[Route("[controller]/[action]")]
[SuppressMessage("Major Code Smell", "S6967:ModelState.IsValid should be called in controller actions")]
public class CultureController : Controller
{
    public IActionResult SelectCulture(string? culture, string redirectUri)
    {
        if (culture != null)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, culture))
            );
        }

        return LocalRedirect(redirectUri);
    }
}
