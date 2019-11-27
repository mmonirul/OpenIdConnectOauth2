using AutoMapper;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using WestPay.Access.API.Authorization;
using WestPay.Access.API.Services;
using WestPay.Access.API.Services.Interfaces;
using WestPay.Access.DAL.Database;

namespace WestPay.Access.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var dbConnection = Configuration.GetConnectionString("WestPayAccessDbConnection");

            services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(dbConnection,
                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(8, 0, 17), ServerType.MySql);
                    }
                ));

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBookService, BookService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Description = "A Westpay future API library",
                    Contact = new Contact
                    {
                        Name = "Moni",
                        Email = string.Empty,
                        Url = "https://twitter.com/mrmonirul",
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", corsBuilder =>
                {
                    corsBuilder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => origin == "http://localhost:4200")
                    .AllowCredentials();
                });
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                { 
                    options.Authority = "https://localhost:44346";
                    options.ApiName = "west-test-api";

                    options.NameClaimType = JwtClaimTypes.GivenName;
                    options.RoleClaimType = JwtClaimTypes.Role;
                });
            //.AddJwtBearer("Bearer", options =>
            //{
            //    options.Authority = "https://localhost:44346";
            //    options.RequireHttpsMetadata = false;

            //    options.Audience = "west-test-api";
            //});

            services.AddAuthorization(authorizationOptions => 
            {
                authorizationOptions.AddPolicy(
                "superAdminOrOwner",
                policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.AddRequirements(new SuperAdminOrOwnerRequirement());
                });
            });

            services.AddScoped<IAuthorizationHandler, SuperAdminOrOwnerHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Westpay api v1");
                c.RoutePrefix = string.Empty;
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.InjectJavascript("/swagger-ui/custom.js", "text/javascript");
                c.DocumentTitle = "Westpay public Api connector";
            });

            app.UseCors("CorsPolicy");
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
