using AdventureWorks.Client.Objects;
using AdventureWorks.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;
using System.Threading;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.WpfCS
{
    public class LoginViewCustomized : LoginView
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            btnSave.Content = "_Login";
        }

        protected override void Save(object sender, EventArgs e)
        {
            DetailsViewModel dvm = Model as DetailsViewModel;
            AuthenticationObject authObj = dvm.DetailsObject as AuthenticationObject;

            try
            {
                dvm.Save(sender, e);
                if (dvm.Errors != null && dvm.Errors.HasErrors()) return;
                PersonInfo userInfo = dvm.ServiceProvider.GetService<IPersonService>().Read(authObj.EmailProperty.Value).Result;
                ClaimsIdentity ci = SecurityManager.CreateIdentity(AuthenticationTypes.Password, userInfo);
                Thread.CurrentPrincipal = new ClaimsPrincipal(ci);

                MainView.Start();
                Close();
            }
            catch (Exception ex)
            {
                ErrorParser ep = dvm.ServiceProvider.GetService<ErrorParser>();
                ErrorList errors = ep.FromException(ex);
                ErrorPresenter.Show(errors);
            }
        }
    }
}