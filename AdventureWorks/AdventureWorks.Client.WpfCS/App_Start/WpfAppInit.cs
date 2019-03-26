using AdventureWorks.Client.Objects;
using AdventureWorks.Client.ViewModels;
using AdventureWorks.Services;
using AdventureWorks.Services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Resources;
using Xomega.Framework;

namespace AdventureWorks.Client.WpfCS
{
    public class WpfAppInit : AppInitializer
    {
        public override IServiceProvider ConfigureServices()
        {
            IServiceCollection container = new ServiceCollection();

            // framework services configuration
            container.AddErrors();
            container.AddSingletonLookupCacheProvider();

            // app services configuration
            container.AddDataObjects();
            container.AddViewModels();
            container.AddViews();
            container.AddLookupCacheLoaders();
            container.AddXmlResourceCacheLoader(typeof(Enumerations.Operators).Assembly, ".enumerations.xres", true);
            container.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Services.Entities.Messages.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));
            string connStr = ConfigurationManager.ConnectionStrings["AdventureWorksEntities"].ConnectionString;
            container.AddDbContext<AdventureWorksEntities>(opt => opt
                .UseLazyLoadingProxies()
                .UseSqlServer(connStr, x => x.UseNetTopologySuite()));
            container.AddServices();

            // TODO: configure container with other services as needed

            return container.BuildServiceProvider();
        }
    }
}
