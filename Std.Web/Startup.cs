using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Std.Core;
using Std.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Std.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Std.Application;
using AutoMapper;
using Std.Application.Product;
using Swashbuckle.AspNetCore.Swagger;
using Std.Application.Basket;
using Std.Application.User;

namespace Std.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapper();

            services.AddDbContext<StdDataContext>(option => option.UseInMemoryDatabase("StdMemory"));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IBasketService), typeof(BasketService));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("CoreSwagger", new Info
                {
                    Title = "Swagger on ASP.NET Core",
                    Version = "1.0.0",
                    Description = "Try Swagger on (ASP.NET Core 2.1)",
                    Contact = new Contact()
                    {
                        Name = "Swagger Implementation Onur Toklu"
                    },
                    TermsOfService = "http://swagger.io/terms/"
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSwagger()

            .UseSwaggerUI(c =>
            {
                //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger Test .Net Core");

                //TODO: Or alternatively use the original Swagger contract that's included in the static files
                // c.SwaggerEndpoint("/swagger-original.json", "Swagger Petstore Original");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
