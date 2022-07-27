using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_project_horse_races_db.EntityFramework;
using Web_project_horse_races_db.Model;
using Web_project_horse_races_web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Web_project_horse_races_web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.AccessDeniedPath = new PathString("/Account/Login");
            });
            services.AddSingleton<ApplicationContext>();
            services.AddSingleton<UserService>();
            services.AddSingleton<RaceService>();
            services.AddSingleton<BetService>();
            //services.AddSingleton<HorseService>();
            //System.Reflection.Assembly.GetAssembly(typeof(IRepository<>))
            //.GetTypes()
            //.Where(item => item.GetInterfaces()
            //.Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IRepository<>)) && !item.IsAbstract && !item.IsInterface)
            //.ToList()
            //.ForEach(assignedTypes =>
            //{
            //    var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IRepository<>));
            //    services.AddTransient(serviceType, assignedTypes);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            //} else
            //{
                //app.UseExceptionHandler(options =>
                //{
                //    options.Run(
                //        async context =>
                //        {
                //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //            context.Response.ContentType = "text/html";
                //            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                //            if(exceptionObject != null)
                //            {
                //                var errorMessage = $"<b>Exception Error: {exceptionObject.Error.Message} <b> {exceptionObject.Error.StackTrace}";
                //                await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                //            }
                //        });
                //});
                //app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseMvc(configure => configure.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"));
        }
    }
}
