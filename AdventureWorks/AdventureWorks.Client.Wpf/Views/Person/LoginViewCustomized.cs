using AdventureWorks.Client.Objects;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Wpf
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
                authObj.Validate(true);
                authObj.GetValidationErrors().AbortIfHasErrors();
                WcfServices.Authenticate(authObj.EmailProperty.Value, authObj.PasswordProperty.Value);
                authObj.TrackModifications = false; // to prevent confirmation on closing of the login view 

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