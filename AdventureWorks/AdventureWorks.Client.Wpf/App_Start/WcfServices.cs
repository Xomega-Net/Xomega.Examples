#if WCF
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Resources;
using System.Security.Claims;
using System.ServiceModel.Security;
using System.Xml;
using Xomega.Framework;
using Xomega.Framework.Wcf;

namespace AdventureWorks.Client.Wpf
{
    /// <summary>
    /// Static methods for configuring access to WCF services
    /// </summary>
    public static class WcfServices
    {
        /// <summary>
        /// Audience URI for the current application, which should be configured and accepted by the WCF services
        /// </summary>
        public const string AudienceUri = "http://Client.Wpf";

        /// <summary>
        /// Security token for communcation with WCF services
        /// </summary>
        private static SecurityToken IssuedToken { get; set; }

        /// <summary>
        /// Configures service container with WCF services
        /// </summary>
        /// <param name="services">Service container</param>
        /// <returns>Configured service container</returns>
        public static IServiceCollection AddWcfServices(this IServiceCollection services)
        {
            services.AddWcfClientServices(() => IssuedToken, null, null);
            return services;
        }

        /// <summary>
        /// Authenticates with WCF services using user name/password
        /// and receives a token for further communication with the services.
        /// </summary>
        /// <param name="user">User name</param>
        /// <param name="password">Password</param>
        public static ClaimsPrincipal Authenticate(string user, string password)
        {
            try
            {
                var factory = new WSTrustChannelFactory("sts message");
                factory.Credentials.UserName.UserName = user;
                factory.Credentials.UserName.Password = password;
                // TODO: re-enable certificate validation after using a trusted certificate
                factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                var channel = factory.CreateChannel();
                IssuedToken = channel.Issue(new RequestSecurityToken(RequestTypes.Issue, KeyTypes.Bearer)
                {
                    AppliesTo = new EndpointReference(AudienceUri)
                });

                var identities = GetIdentitiesFromSamlToken(IssuedToken, AudienceUri, true);
                return new ClaimsPrincipal(identities);
            }
            catch (MessageSecurityException)
            {
                ErrorList currentErrors = new ErrorList(App.Services.GetService<ResourceManager>());
                currentErrors.AddError(ErrorType.Security, Messages.InvalidCredentials);
                currentErrors.Abort(currentErrors.ErrorsText);
            }
            return null;
        }

        /// <summary>
        /// Gets claims identities from the specified SAML token as a GenericXmlSecurityToken
        /// </summary>
        /// <param name="token">SAML token to get identities from</param>
        /// <param name="audienceUri">Audience URI used to obtain the token</param>
        /// <param name="trustIssuer">True to automatically trust the issuer.
        /// False to validate the issuer against the app configuration</param>
        /// <returns>A collection of claims identities from the SAML token.</returns>
        public static IEnumerable<ClaimsIdentity> GetIdentitiesFromSamlToken(SecurityToken token, string audienceUri, bool trustIssuer)
        {
            SamlSecurityTokenHandler handler = new SamlSecurityTokenHandler
            {
                Configuration = new SecurityTokenHandlerConfiguration()
            };
            SamlSecurityToken samlToken = token as SamlSecurityToken;

            if (samlToken == null && token is GenericXmlSecurityToken)
                samlToken = handler.ReadToken(new XmlNodeReader(((GenericXmlSecurityToken)token).TokenXml)) as SamlSecurityToken;

            if (samlToken == null) throw new ArgumentException("The token must be a SAML token or a generic XML SAML token");

            handler.SamlSecurityTokenRequirement.CertificateValidator = X509CertificateValidator.None;
            handler.Configuration.AudienceRestriction.AllowedAudienceUris.Add(new Uri(audienceUri));
            if (trustIssuer)
            {
                // configure to auto-trust the issuer
                ConfigurationBasedIssuerNameRegistry issuers = handler.Configuration.IssuerNameRegistry as ConfigurationBasedIssuerNameRegistry;
                issuers.AddTrustedIssuer(((X509SecurityToken)samlToken.Assertion.SigningToken).Certificate.Thumbprint, "sts");
            }
            else handler.Configuration.IssuerNameRegistry.LoadCustomConfiguration(
                SystemIdentityModelSection.DefaultIdentityConfigurationElement.IssuerNameRegistry.ChildNodes);
            return handler.ValidateToken(samlToken);
        }
    }
}
#endif
