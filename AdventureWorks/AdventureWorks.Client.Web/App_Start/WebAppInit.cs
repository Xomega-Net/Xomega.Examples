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
using Xomega.Framework.Web;

namespace AdventureWorks.Client.Web
{
    public class WebAppInit : AppInitializer
    {
        public override IServiceProvider ConfigureServices()
        {
            IServiceCollection container = new ServiceCollection();

            // framework services configuration
            container.AddErrors();
            container.AddWebLookupCacheProvider();

            // app services configuration
            container.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Services.Entities.Messages.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));
            container.AddDataObjects();
            container.AddViewModels();
            string connStr = ConfigurationManager.ConnectionStrings["AdventureWorksEntities"].ConnectionString;
            container.AddDbContext<AdventureWorksEntities>(opt => opt
                .UseLazyLoadingProxies()
                .UseSqlServer(connStr, x => x.UseNetTopologySuite()));
            container.AddServices();
            container.AddLookupCacheLoaders();
            container.AddXmlResourceCacheLoader(typeof(Enumerations.Operators).Assembly, ".enumerations.xres", true);

            // TODO: configure container with other services as needed

            return container.BuildServiceProvider();
        }
    }
}
