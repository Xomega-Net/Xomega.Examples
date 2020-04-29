using AdventureWorks.Client.Objects;
using AdventureWorks.Client.ViewModels;
using AdventureWorks.Services;
#if TWO_TIER
using AdventureWorks.Services.Entities;
#if !EF6
using Microsoft.EntityFrameworkCore;
#endif
#endif
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Resources;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Wpf
{
    public class WpfAppInit : AppInitializer
    {
        private readonly IServiceProvider serviceProvider;

        public WpfAppInit(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override IServiceProvider ConfigureServices()
        {
            if (serviceProvider != null) return serviceProvider;
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(null, services);
            return services.BuildServiceProvider();
        }

        public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // framework services configuration
            services.AddErrors(context?.HostingEnvironment?.IsDevelopment() ?? false);
            services.AddTransient<IErrorPresenter, ErrorsView>();
            services.AddSingletonLookupCacheProvider();
            services.AddSingleton<IPrincipalProvider, DefaultPrincipalProvider>();

            // app ui services configuration
            services.AddDataObjects();
            services.AddViewModels();
            services.AddViews();
            services.AddLookupCacheLoaders();
            services.AddXmlResourceCacheLoader(typeof(Enumerations.Operators).Assembly, ".enumerations.xres", true);
            services.AddSingleton<IWindowCreator, MainViewWindowCreator>();

            // app resources
            services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Messages.ResourceManager,
#if TWO_TIER
                Services.Entities.Messages.ResourceManager,
#endif
                Xomega.Framework.Messages.ResourceManager));

            // app services configuration
#if TWO_TIER
            string connStr = context.Configuration.GetValue<string>("add:AdventureWorksEntities:connectionString");
#if EF6
            services.AddScoped(sp => new AdventureWorksEntities(connStr));
#else
            services.AddDbContext<AdventureWorksEntities>(opt => opt.UseLazyLoadingProxies().UseSqlServer(connStr));
#endif
            services.AddServiceImplementations();
#endif
#if WCF
            services.AddWcfServices();
#endif
#if REST
            string apiBaseAddress = context.Configuration.GetValue<string>("RestAPI:BaseAddress");
            services.AddRestServices(apiBaseAddress);
#endif

            // TODO: configure container with other services as needed
        }
    }
}
