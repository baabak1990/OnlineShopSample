using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using OzhanIoCLayer;
using Microsoft.AspNetCore.Http.Features;

namespace OzhanITFinalVersion
{
    public class Startup
    {
        public IConfiguration confiquration;

        public Startup(IConfiguration confiquration)
        {
            this.confiquration = confiquration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ////این هم برای اندروید و آی او اس و سایر Hint:
            //#region LimitContentForOtherPlatforms
            //services.Configure<FormOptions>(options =>
            //{
            //    options.MultipartBodyLengthLimit = 60000000;
            //});
            //#endregion
            services.AddControllersWithViews();
            services.AddServices(confiquration);
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
            #region Authentication
            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(op =>
            {
                op.LoginPath = "/auth/Login";
                op.LogoutPath = "/auth/Logout";
                op.ExpireTimeSpan = TimeSpan.FromMinutes(143200);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                });
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "/{controller=Home}/{action=Index}/{id?}"
                    );
                });
            });
        }
    }
}
