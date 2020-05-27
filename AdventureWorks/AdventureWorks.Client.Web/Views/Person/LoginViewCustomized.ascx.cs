using AdventureWorks.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Xomega.Framework;

namespace AdventureWorks.Client.Web
{
    public class LoginViewCustomized : LoginView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            btn_Save.Text = "Login";
            pnl_View.Width = new Unit("500px");
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (Page.User.Identity.IsAuthenticated)
            {
                // user that is authenticated, but not authorized to view a page will be redirected
                // to this view, so display an appropriate message (instead of the login form) here
                lbl_ViewTitle.Text = "Unauthorized";
                ErrorList el = new ErrorList();
                el.AddError(ErrorType.Security, Messages.PageNotAuthorized);
                Model.Errors = el;
                pnl_Object.Visible = false;
                btn_Save.Visible = false;
            }
        }

        protected override async Task OnViewEventsAsync(object sender, ViewEvent e, CancellationToken token = default)
        {
            await base.OnViewEventsAsync(sender, e, token);
            if (e.IsSaved()) // authenticated successfully
            {
                ClaimsIdentity ci = null;
                if (VM?.MainObj?.EmailProperty?.Value != null)
                {
                    var personService = ServiceProvider.GetService<IPersonService>();
                    PersonInfo userInfo = (await personService.ReadAsync(VM.MainObj.EmailProperty.Value)).Result;
                    ci = SecurityManager.CreateIdentity(CookieAuthenticationDefaults.AuthenticationType, userInfo);
                }
                if (ci != null)
                {
                    HttpContext.Current.GetOwinContext().Authentication.SignIn(ci);
                    string url = HttpContext.Current.Request.QueryString[CookieAuthenticationDefaults.ReturnUrlParameter];
                    if (url != null)
                        HttpContext.Current.Response.Redirect(url, false);
                }
            }
        }
    }
}