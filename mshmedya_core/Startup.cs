using Core.Filters;
using Core.Helpers.Abstract;
using Core.Helpers.Base;
using Core.Helpers.Media.Abstract;
using Core.Helpers.Media.Concrete;
using DataAccess.Abstract.Repositories;
using DataAccess.Base.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Abstract;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace mshmedya_core
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
            services.AddLocalization(options =>
            {
                // Resource (kaynak) dosyalarýmýzý ana dizin altýnda "Resources" klasorü içerisinde tutacaðýmýzý belirtiyoruz.     
                options.ResourcesPath = "Resources";
            });

            services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

            #region DependencyInjection

            //FILTERS
            services.AddSingleton<ActionFiltersAttribute>();

            //DATAACCESS
            services.AddSingleton<IAppUsersRepository, AppUsersRepository>();
            services.AddSingleton<ICustomersRepository, CustomersRepository>();
            services.AddSingleton<IStaffRepository, StaffRepository>();
            services.AddSingleton<IServicesRepository, ServicesRepository>();
            services.AddSingleton<ISessionsRepository, SessionsRepository>();
            services.AddSingleton<IStaffServicesRepository, StaffServicesRepository>();
            services.AddSingleton<IStaffSessionsRepository, StaffSessionsRepository>();
            services.AddSingleton<IAppointmentsRepository, AppointmentsRepository>();
            services.AddSingleton<ILogsRepository, LogsRepository>();

            //SERVICE
            services.AddSingleton<IAppUsersService, AppUsersManager>();
            services.AddSingleton<ICustomersService, CustomersManager>();
            services.AddSingleton<IStaffService, StaffManager>();
            services.AddSingleton<IServicesService, ServicesManager>();
            services.AddSingleton<ISessionsService, SessionsManager>();
            services.AddSingleton<IStaffServicesService, StaffServicesManager>();
            services.AddSingleton<IStaffSessionsService, StaffSessionsManager>();
            services.AddSingleton<IAppointmentsService, AppointmentsManager>();
            services.AddSingleton<ILogsService, LogsManager>();

            //CORE   
            services.AddSingleton<ISessionService, SessionManager>();
            services.AddSingleton<IAppUserService, AppUserManager>();
            services.AddSingleton<IRowButtonService, RowButtonManager>();
            services.AddSingleton<ISvgIconService, SvgIconManager>();
            services.AddSingleton<IButtonService, ButtonManager>();
            services.AddSingleton<IFileService, FileManager>();

            #endregion

            services.AddHttpContextAccessor();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(2);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new List<CultureInfo>
            {
                 new CultureInfo("tr-TR"),
                 new CultureInfo("en-US"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture("tr-TR")
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); 
            
            app.UseSession();

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
