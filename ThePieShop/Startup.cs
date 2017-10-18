using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThePieShop.Data;
using ThePieShop.Models;
using ThePieShop.Services;
using Microsoft.AspNetCore.Authentication.Google;

namespace ThePieShop
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
            // Version 1 - using mock data
            //services.AddTransient<ICategoryRepository, MockCategoryRepository>();
            //services.AddTransient<IPieRepository, MockPieRepository>();

            //Version 2 - calling the DB
            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?tabs=aspnetcore2x
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.User.RequireUniqueEmail = true;

                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPieReviewRepository, PieReviewRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Creates an object associated with a request (a shopping cart per user)
            // Creates the shopping cart when user visits.
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            // Configure ability to work with sessions
            services.AddMemoryCache();

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                //options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });

            services.AddRouting(options => options.LowercaseUrls = true); //lowercase URLs, FTW

            // register the policy on the Controller with [Authorize(Policy = "DeletePie")]
            // can be stacked with roles and other policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorOnly", policy => policy.RequireClaim("Administrator"));
                options.AddPolicy("DeletePie", policy => policy.RequireClaim("Delete Pie"));
                options.AddPolicy("AdPie", policy => policy.RequireClaim("Add Pie"));
                options.AddPolicy("MinimumOrderAge", policy => policy.Requirements.Add(new MinimumOrderAgeRequirement(18)));
            });


            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                //googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                //googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                //https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?tabs=aspnetcore2x
                googleOptions.ClientId = "480025973479-gi12jddt7g9e69okpugv87hfgs38su5e.apps.googleusercontent.com";
                googleOptions.ClientSecret = "-bILs4fpQyU6mzqa17LYjRj1";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseExceptionHandler("/AppException");
                // Can use 
                // throw new Exception("Error");
                // In a class (like the controller) to trip things up.
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Pie/{action}/{category?}",
                    defaults: new { Controller = "Pie", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //DbInitializer.Initialize(app);

        }
    }
}
