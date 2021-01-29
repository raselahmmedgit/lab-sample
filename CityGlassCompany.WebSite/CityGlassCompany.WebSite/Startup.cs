using CityGlassCompany.WebSite.Core;
using CityGlassCompany.WebSite.Data;
using CityGlassCompany.WebSite.EntityModel;
using CityGlassCompany.WebSite.Managers;
using CityGlassCompany.WebSite.Mappers;
using CityGlassCompany.WebSite.Repository;
using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace CityGlassCompany.WebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            WebHostEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string dbPath = Path.Combine(WebHostEnvironment.ContentRootPath, "Data", "LocalDatabase", "CityGlassCompany.mdf");
            //string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddOptions();

            // Add our Config object so it can be injected
            services.Configure<CityGlassEmailConfig>(Configuration.GetSection("CityGlassEmailConfig"));
            services.Configure<CityGlassContactUsConfig>(Configuration.GetSection("CityGlassContactUsConfig"));

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
            });
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes =
                    ResponseCompressionDefaults.MimeTypes.Concat(
                        new[] { "image/svg+xml", "image/jpeg", "image/jpg", "image/png", "text/javascript", "application/x-msdownload", "application/x-msdownload" });
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();

            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));

            //AutoMapper registration
            services.RegisterMapper();

            // DataTables.AspNet registration with default options.
            services.RegisterDataTables();

            services.AddScoped<IEmploymentApplicationManager, EmploymentApplicationManager>();
            services.AddScoped<IEmploymentApplicationRepository, EmploymentApplicationRepository>();
            services.AddScoped<IEmailSenderManager, EmailSenderManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            #region App Settiing
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".mp4"] = "video/mp4";
            #endregion

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
