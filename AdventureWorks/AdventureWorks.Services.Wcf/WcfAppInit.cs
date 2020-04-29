using AdventureWorks.Services.Entities;
#if !EF6
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Resources;
using Xomega.Framework;

namespace AdventureWorks.Services.Wcf
{
    public class WcfAppInit : AppInitializer
    {
        public override IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            // framework services configuration
            services.AddErrors(true);
            services.AddSingletonLookupCacheProvider();
            services.AddScoped<IPrincipalProvider, DefaultPrincipalProvider>();

            // app services configuration
            string connStr = ConfigurationManager.ConnectionStrings["AdventureWorksEntities"].ConnectionString;
#if EF6
            services.AddScoped(sp => new AdventureWorksEntities(connStr));
#else
            services.AddDbContext<AdventureWorksEntities>(opt => opt
                .UseLazyLoadingProxies()
                .UseSqlServer(connStr));
#endif
            services.AddServiceImplementations();
            services.AddSingleton<AppStsConfig>();
            services.AddLookupCacheLoaders();
            services.AddXmlResourceCacheLoader(typeof(Enumerations.Operators).Assembly, ".enumerations.xres", true);

            services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Entities.Messages.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));

            // TODO: configure container with other services as needed

            return services.BuildServiceProvider();
        }
    }
}
