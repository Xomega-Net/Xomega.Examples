using AdventureWorks.Services.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Resources;
using System.Security.Principal;
using System.Text;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Rest
{
    public class Startup
    {
        public const string ConfigConnectionString = "add:AdventureWorksEntities:connectionString";
        public const string ConfigJwtKey = "AppSettings:JwtKey";

        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            // configure global exception handling using Xomega Framework
            app.UseExceptionHandler(err => err.Run(async ctx =>
            {
                ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ctx.Response.ContentType = "application/json";
                Exception ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;

                // use environment-aware error parser to hide exception details in non-Dev environments
                ErrorList errorList = new ErrorParser().FromException(ex);
                Output output = new Output(errorList);
                await ctx.Response.WriteAsync(JsonConvert.SerializeObject(output));
            }));
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            ConfigureAuth(services);
            ConfigureWebApi(services);

            // framework services configuration
            services.AddErrors();
            services.AddSingletonLookupCacheProvider();
            services.AddOperators();

            // app services configuration
            services.AddSingleton<ResourceManager>(sp => new CompositeResourceManager(
                Messages.ResourceManager,
                Entities.Messages.ResourceManager,
                Xomega.Framework.Messages.ResourceManager));
            string connStr = Configuration.GetValue<string>(ConfigConnectionString);
            services.AddDbContext<AdventureWorksEntities>(opt => opt
                .UseLazyLoadingProxies()
                .UseSqlServer(connStr, x => x.UseNetTopologySuite()));
            services.AddServices();
            services.AddControllers();
            services.AddScoped<LookupTableController>();
            services.AddLookupCacheLoaders();
            services.AddXmlResourceCacheLoader(typeof(Enumerations.Operators).Assembly, ".enumerations.xres", true);

            // TODO: configure other services as needed
        }

        public void ConfigureAuth(IServiceCollection services)
        {
            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>(ConfigJwtKey));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddHttpContextAccessor();
            services.AddTransient<IPrincipal>(sp => sp.GetService<IHttpContextAccessor>()?.HttpContext?.User);
        }

        public void ConfigureWebApi(IServiceCollection services)
        {
            services.AddMvc(o => o.Filters.Add(new AuthorizeFilter()))
                .AddJsonOptions(o => o.UseMemberCasing())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}