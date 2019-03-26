using AdventureWorks.Services.Entities;
using Microsoft.EntityFrameworkCore;
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
            IServiceCollection container = new ServiceCollection();

            // framework services configuration
            container.AddErrors();
            container.AddSingletonLookupCacheProvider();

            // app services configuration
            string connStr = ConfigurationManager.ConnectionStrings["AdventureWorksEntities"].ConnectionString;
            container.AddDbContext<AdventureWorksEntities>(opt => opt
                .UseLazyLoadingProxies()
                .UseSqlServer(connStr, x => x.UseNetTopologySuite()));
            container.AddServices();
            container.AddSingleton<AppStsConfig>();
            container.AddLookupCacheLoaders();
            container.AddXmlResourceCacheLoader(typeof(Enumerations.Operators).Assembly, ".enumerations.xres", true);

            container.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Entities.Messages.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));

            // TODO: configure container with other services as needed

            return container.BuildServiceProvider();
        }
    }
}
