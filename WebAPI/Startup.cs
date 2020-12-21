//Vo Huu Tri - 18521531 UIT
using DataLayer.EF;
using DataLayer.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ModelAndRequest.Account;
using ServiceLayer.AccountServices;
using ServiceLayer.BookServices;
using ServiceLayer.CartService;
using ServiceLayer.CategoryServices;
using ServiceLayer.OrderServices;
using ServiceLayer.RatingService;
using ServiceLayer.SummaryService;
using System.Collections.Generic;

namespace WebAPI
{
    public class Startup
    {
        private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            //connect database, lazy load
            //sqlserver
            services.AddDbContext<EShopDbContext>(option =>
                option.UseLoggerFactory(MyLoggerFactory)
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("eshopSqlServer"))
            //.UseSqlServer(Configuration.GetConnectionString("eshopSqlServerAzure"))
            );

            //sqlite
            //services.AddEntityFrameworkSqlite()
            //        .AddDbContext<EShopDbContext>(option =>
            //            option.UseLoggerFactory(MyLoggerFactory

            //            )
            //        .UseLazyLoadingProxies()
            //        .UseSqlite(Configuration.GetConnectionString("eshopSqlite"))
            //);

            // use swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book store", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Coppy token in respone => paste to input with format : Bearer [token]",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },new List<string>()
                      }
                    });
            });

            services.AddIdentity<User, Role>(config =>
            {
                config.Password.RequiredLength = 6;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<EShopDbContext>()
                .AddDefaultTokenProviders();

            //fluent validator
            services.AddControllersWithViews()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

            // get issuer, key in appsettings.json  => create key
            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    //ma hoa doi xung
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });

            //tao policy tu cac role
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                     policy => policy.RequireRole("Administrator"));

                options.AddPolicy("Sales",
                    policy => policy.RequireRole("Administrator", "Sales"));

                options.AddPolicy("User",
                    policy => policy.RequireRole("User"));
            });

            //dependency injection
            services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookService, BookService_V2>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISummaryService, SummaryService>();
            services.AddScoped<IRatingService, RatingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            //app.UseCors(MyAllowSpecificOrigins);

            app.UseCors(builder =>
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book store API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}