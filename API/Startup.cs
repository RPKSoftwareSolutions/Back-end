using API.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using AutoMapper;
using TKD.Framework.ExceptionHandler;
using TKD.Framework.Swagger;
using TKD.Infrastructure;

namespace API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            if (env.IsDevelopment())
            {
                builder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddAutoMapper();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration.GetSection("CustomSettings").GetSection("Authority").GetSection("URL").Value;
                    options.RequireHttpsMetadata = bool.Parse(Configuration.GetSection("CustomSettings").GetSection("Authority").GetSection("RequireHTTPS").Value);
                    options.ApiName = "api1";
                });




            //swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "TKD API", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                       {"Bearer", new string[] { }}
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(security);

                c.OperationFilter<FormFileSwaggerFilter>();
            });


            //InitDatabase
            var dbContext = (AppDbContext)services
                .BuildServiceProvider()
                .GetService(typeof(AppDbContext));
            dbContext.Database.Migrate();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCustomUseExceptionHandler();
            }
            app.UseAuthentication();
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowCredentials();
            });
            app.UseStaticFiles();
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API V1");
                    options.DocExpansion(DocExpansion.None);
                });
            }
            else
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Contacts API V1");
                    options.DocExpansion(DocExpansion.None);
                });
            }

            app.UseMvc();

        }
    }
}
