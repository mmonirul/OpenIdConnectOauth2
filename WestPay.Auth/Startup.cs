using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WestPay.Auth.Configurations;
using WestPay.Auth.Data;
using WestPay.Auth.Data.Seed;

namespace WestPay.Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //var connectionString = Configuration.GetConnectionString("WestPayOauth");
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //services.AddDbContext<ApplicationDbContext>(builder =>
            //    builder.UseSqlServer(connectionString, 
            //        sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();



            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                //.AddOperationalStore(options =>
                //    options.ConfigureDbContext = builder => 
                //    builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                //.AddConfigurationStore(options =>
                //    options.ConfigureDbContext = builder =>
                //        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                //.AddAspNetIdentity<IdentityUser>();

                .AddInMemoryClients(Clients.GetClients())
                .AddInMemoryApiResources(Resources.GetApiResources())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddTestUsers(Users.GetUsers());

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", corsBuilder =>
            //    {
            //        corsBuilder.AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .SetIsOriginAllowed(origin => origin == "http://localhost:4200")
            //        .AllowCredentials();
            //    });
            //});


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseCors("CorsPolicy");
            //DBInitialize.InitializeDbWithTestData(app);

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();
        }
    }
}
