using DataLayer.EF;
using DataLayer.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelAndRequest.Common;
using ServiceLayer.Admin.Product;
using ServiceLayer.Common.Account;
using System;

namespace WebApplication
{
    public class Startup
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<EShopDbContext>(option =>
                option.UseLoggerFactory(MyLoggerFactory)
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("eshopSqlServer"))

            );


            //services.AddEntityFrameworkSqlite()
            //        .AddDbContext<EShopDbContext>(option =>
            //            option.UseLoggerFactory(MyLoggerFactory
                        
            //            )
            //        .UseLazyLoadingProxies()
            //        .UseSqlite(Configuration.GetConnectionString("eshopSqlite"))
            //);

            services.AddIdentity<User, Role>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<EShopDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator",
                     policy => policy.RequireRole("Administrator"));
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.ExpireTimeSpan = new TimeSpan(hours:1, 0,0) ;
                config.Cookie.Name = "EshopCookie";
                config.LoginPath = "/Account/Login";
            }
            );
            //dependency injection
            services.AddScoped<IAccountService, AccountService>();
            services.AddTransient<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });


        }
    }
}
