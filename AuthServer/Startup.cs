using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.Services;
using AuthServer.Auth;
using IdentityServer4.Validation;
using IdentityServer4.Stores;
using IdentityServer4.ResponseHandling;

using TKD.Infrastructure;

namespace AuthServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            if (env.IsDevelopment())
            {
                builder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            }
            else
            {
                builder.AddJsonFile("appsettings.Relase.json", optional: true, reloadOnChange: true);
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                    //.AddTransient<ITokenValidator, RefreshTokenValidator>()
                    //.AddTransient<IRefreshTokenService, RefreshTokenService>()
                    .AddTransient<IPersistedGrantStore, PersistedGrantStore>()
                    .AddTransient<ICorsPolicyService, Auth.CorsPolicyService>()
                    //.AddTransient<ISecretValidator, Auth.SecretValidator>()
                    //.AddTransient<IRefreshTokenStore, RefreshTokenStore>()
                    //.AddTransient<ITokenResponseGenerator, Auth.TokenResponseGenerator>()
                    .AddTransient<IProfileService, ProfileService>();

            services.AddCors();
            services.AddIdentityServer()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddClientStore<ClientStore>()
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString);


                    options.DefaultSchema = "auth";
                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 3600;
                })
                .AddDeveloperSigningCredential()
                .AddExtensionGrantValidator<GoogleGrant>()
                .AddExtensionGrantValidator<FacebookGrant>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
            //}
   
            app.UseIdentityServer();
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowCredentials();
            });

       
        }
    }
}
