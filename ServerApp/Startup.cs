using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using ServerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ServerApp.Repository;
using Microsoft.AspNetCore.Antiforgery;

namespace ServerApp
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
            services.AddScoped<IDataAccess, DataAccess>();
            services.AddDbContext<IdentityDataContext>(options => options.UseSqlServer(Configuration["Data:Identity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews().AddJsonOptions(opt => opt.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSession(options => {
                options.Cookie.Name = "VehiclePortal.Session";
                options.IdleTimeout = System.TimeSpan.FromHours(48);
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
            });

            services.AddAntiforgery(x => { x.HeaderName = "X-XSRF-TOKEN"; });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IAntiforgery antiforgery)
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
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(nextDelegate => context =>
            {
                string path = context.Request.Path.Value;
                string[] directUrls = {"/admin","/portal" };
                if (path.StartsWith("/api")
                     || string.Equals("/", path) 
                     || directUrls.Any(url => path.StartsWith(url))
                    )
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN",tokens.RequestToken,new Microsoft.AspNetCore.Http.CookieOptions()
                    {
                        HttpOnly = false,Secure=false,IsEssential=true
                    });
                }
                return nextDelegate(context);
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "angular_fallback",
                    pattern: "{target:regex(admin|portal):nonfile}/{*catchall}",
                    defaults: new { controller = "Home", action = "Index" });

               
                endpoints.MapRazorPages();
            });


            app.UseSpa(spa => { spa.Options.SourcePath = "../ClientApp"; spa.UseAngularCliServer("start"); });

            //IdentitySeedData.SeedDataBase(app);
            //IdentitySeedData.SeedDataBase(app.ApplicationServices.GetRequiredService<IdentityDataContext>());
        }
    }
}
