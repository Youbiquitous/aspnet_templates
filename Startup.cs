///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
////

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using $safeprojectname$.Common.Extensions;
using $safeprojectname$.Common.Settings;
using $safeprojectname$.Common.Shared.Localization;
using $safeprojectname$.Resources;

namespace $safeprojectname$
{
    /// <summary>
    /// Bootstrap class injected in the program
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Ctor laying the ground for configuration
        /// </summary>
        /// <param name="env"></param>
        public Startup(IWebHostEnvironment env)
        {
            var settingsFileName = env.IsDevelopment() 
                ? "app-settings-dev.json" 
                : "app-settings.json";

            var dom = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(settingsFileName, optional: true)
                .AddEnvironmentVariables()
                .Build();
            Configuration = dom;
        }

        /// <summary>
        /// Holds the current configuration tree
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Adds core services to the list
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Authentication
            services.AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.Cookie.SameSite = (SameSiteMode)(-1);
                    options.LoginPath = new PathString("/account/login");
                    options.Cookie.Name = AppSettings.AuthCookieName;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = new PathString("/account/denied");
                    options.EventsType = typeof(MinimoCookieAuthenticationEvent);
                });

            // Configuration
            var settings = new AppSettings();
            Configuration.Bind(settings);
            settings.ImportEmailSettings();
            
            // DI
            services.AddSingleton(settings);
            services.AddHttpContextAccessor();
            services.AddScoped<MinimoCookieAuthenticationEvent>();
            //services.AddSingleton<IAccountService, AccountService>();
            //services.AddSingleton<IAccountRepository>(new AccountRepository());

            // MVC
            services.AddLocalization();
            services.AddControllersWithViews()
                .AddMvcLocalization()
                .AddRazorRuntimeCompilation();
        }

        
        /// <summary>
        /// Configures core services
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="settings"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppSettings settings)
        {
            var provider = new CookieRequestCultureProvider()
            {
                CookieName = AppSettings.CultureCookieName
            };

            // Localization (the system will figure out the initial language)
            var languages = Configuration.GetSection("languages").Get<string[]>();
            var supportedCultures = AppSettings.GetSupportedCultures(languages);
            var defaultCulture = supportedCultures.Any() ? supportedCultures[0] : new CultureInfo(settings.General.DefaultCulture);
            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = supportedCultures,      // Formatting numbers, dates, etc.
                SupportedUICultures = supportedCultures,    // UI strings that we have localized
            };
            options.RequestCultureProviders.Insert(0, provider);
            app.UseRequestLocalization(options);

            // Initializes the ENUM description localizer
            LocalizedDescriptionAttribute.Initialize();
            LocalizedDescriptionAttribute.Map.Add("strings", AppStrings.ResourceManager);
            LocalizedDescriptionAttribute.Map.Add("messages", AppMessages.ResourceManager);
            LocalizedDescriptionAttribute.Map.Add("biz", AppBiz.ResourceManager);


            // Error handling (CHANGE THIS MANUALLY AS APPROPRIATE)
            app.UseExceptionHandler("/app/error");
            //app.UseDeveloperExceptionPage();

            // Set up PST database
            //IspiroDatabase.ConnectionString = settings.Secrets.IspiroConnectionString; 
            //var db = new IspiroDatabase();
            //db.Database.EnsureCreated();
            //IspiroDatabase.Seed(db);

            // Attach file system info to settings
            settings.General.TemplateRoot = Path.Combine(env.ContentRootPath, "templates");

            //app.UseCookiePolicy();
            app.UseAuthentication();

            if (env.IsProduction())
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
