using AdventureWorks.Client.Objects;
using AdventureWorks.Services;
#if TWO_TIER
using Microsoft.Extensions.DependencyInjection;
#endif
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Wpf
{
    public class LoginViewCustomized : LoginView
    {
        private readonly IPrincipalProvider principalProvider;

        public LoginViewCustomized(IPrincipalProvider principalProvider)
        {
            this.principalProvider = principalProvider;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            btnSave.Content = "_Login";
        }

        protected async Task<ClaimsPrincipal> Authenticate()
        {
            DetailsViewModel dvm = Model as DetailsViewModel;
            AuthenticationObject authObj = dvm.DetailsObject as AuthenticationObject;
#if REST
            authObj.Validate(true);
            authObj.GetValidationErrors().AbortIfHasErrors();
            return await RestServices.Authenticate(authObj.EmailProperty.Value, authObj.PasswordProperty.Value);
#endif
#if WCF
            authObj.Validate(true);
            authObj.GetValidationErrors().AbortIfHasErrors();
            var principal = WcfServices.Authenticate(authObj.EmailProperty.Value, authObj.PasswordProperty.Value);
            return await Task.FromResult(principal);
#endif
#if TWO_TIER
            await dvm.SaveAsync();
            dvm.Errors.AbortIfHasErrors();

            PersonInfo userInfo = null;
            using (var s = dvm.ServiceProvider.CreateScope())
            {
                IPersonService personService = s.ServiceProvider.GetRequiredService<IPersonService>();
                userInfo = (await personService.ReadAsync(authObj.EmailProperty.Value)).Result;
            }
            ClaimsIdentity ci = SecurityManager.CreateIdentity("Password", userInfo);
            return new ClaimsPrincipal(ci);
#endif
        }

        protected override async void Save(object sender, EventArgs e)
        {
            try
            {
                SaveButton.IsEnabled = false;
                var user = await Authenticate();
                principalProvider.CurrentPrincipal = user;
                MainMenu.M_Sales_Visible = user.IsEmployee() ||
                    user.IsStoreContact() || user.IsIndividualCustomer();
                MainView.Start();
                Close();
            }
            catch (Exception ex)
            {
                ErrorList errors = Model.ErrorParser.FromException(ex);
                ErrorPresenter.Show(errors);
            }
            finally
            {
                SaveButton.IsEnabled = true;
            }
        }
    }
}