using AdventureWorks.Client.Objects;
using AdventureWorks.Client.ViewModels;
using AdventureWorks.Services;
using AdventureWorks.Services.Entities;
#if !EF6
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Resources;
using Xomega.Framework;
using Xomega.Framework.Web;

namespace AdventureWorks.Client.Web
{
    public class WebAppInit : AppInitializer
    {
        public override IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            // framework services configuration
            services.AddErrors(true);
            services.AddWebLookupCacheProvider();

            // app services configuration
            services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Services.Entities.Messages.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));
            services.AddDataObjects();
            services.AddViewModels();
            string connStr = ConfigurationManager.ConnectionStrings["AdventureWorksEntities"].ConnectionString;
#if EF6
            services.AddScoped(sp => new AdventureWorksEntities(connStr));
#else
            services.AddDbContext<AdventureWorksEntities>(opt => opt
                .UseLazyLoadingProxies()
                .UseSqlServer(connStr));
#endif
            services.AddServiceImplementations();
            services.AddLookupCacheLoaders();
            services.AddXmlResourceCacheLoader(typeof(Enumerations.Operators).Assembly, ".enumerations.xres", true);

            // TODO: configure container with other services as needed

            return services.BuildServiceProvider();
        }
    }
}
