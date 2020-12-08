using AdventureWorks.Client.Blazor.Common.Views;
using AdventureWorks.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Client.Blazor.Server
{
    [AllowAnonymous]
    [Route("/login")]
    public class BlazorLoginView : LoginView
    {
        [Inject] SignInManager signInManager { get; set; }
        [Inject] IPersonService personService { get; set; }

        protected override async Task OnViewEventsAsync(object sender, ViewEvent e, CancellationToken token = default)
        {
            await base.OnViewEventsAsync(sender, e, token);
            if (e.IsSaved())
            {
                ClaimsIdentity ci = null;
                if (VM?.MainObj?.EmailProperty?.Value != null)
                {
                    PersonInfo userInfo = (await personService.ReadAsync(VM.MainObj.EmailProperty.Value)).Result;
                    ci = SecurityManager.CreateIdentity(CookieAuthenticationDefaults.AuthenticationScheme, userInfo);
                }
                var principal = new ClaimsPrincipal(ci);
                string ticket = signInManager.GetSignInTicket(principal);
                Navigation.NavigateTo("/SignIn?ticket=" + ticket, true);
            }
        }
    }
}