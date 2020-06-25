using AdventureWorks.Client.Blazor.Common;
using AdventureWorks.Client.Blazor.Common.Views;
using AdventureWorks.Client.Objects;
using AdventureWorks.Client.ViewModels;
using AdventureWorks.Enumerations;
using AdventureWorks.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Resources;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Blazor;
using Xomega.Framework.Blazor.Components;

namespace AdventureWorks.Client.Blazor.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            App.AdditionalAssemblies = new[] { typeof(Program).Assembly };
            string apiBaseAddress = builder.Configuration.GetValue<string>("RestAPI:BaseAddress");

            var services = builder.Services;

            // Xomega Framework configuration
            services.AddErrors(builder.HostEnvironment.IsEnvironment("Development"));
            services.AddSingletonLookupCacheProvider();
            services.AddXmlResourceCacheLoader(typeof(Operators).Assembly, ".enumerations.xres", true);
            services.AddOperators();
            services.AddSingleton<IPrincipalProvider, AuthStatePrincipalProvider>();

            // App services configuration
            services.AddSingleton<AuthenticationStateProvider, AuthStateProvider>();
            services.AddRestServices(apiBaseAddress);
            services.AddRestClients();
            services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Client.Common.Messages.ResourceManager,
                Messages.ResourceManager));
            services.AddDataObjects();
            services.AddViewModels();
            services.AddLookupCacheLoaders();

            MainMenu.Items.Insert(0, new MenuItem()
            {
                Text = "Home",
                Href = "/"
            });

            // TODO: add authorization with any security policies
            services.AddAuthorizationCore(o => {
                o.AddPolicy("Sales", policy => policy.RequireAssertion(ctx =>
                    ctx.User.IsEmployee() ||
                    ctx.User.IsIndividualCustomer() ||
                    ctx.User.IsStoreContact()));
            });
            foreach (var mi in MainMenu.Items)
                mi.ForEachItem(SecureMenu);

            var host = builder.Build();

            // TODO: add any custom initialization here

            await host.RunAsync();
        }

        private static void SecureMenu(MenuItem mi)
        {
            if (mi?.Href == null) return;
            if (mi.Href.StartsWith("Sales") || mi.Href.StartsWith("Customer"))
                mi.Policy = "Sales";
            else mi.Policy = ""; // visible for all authorized users
        }
    }
}
