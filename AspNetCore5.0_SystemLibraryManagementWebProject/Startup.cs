using BusinessLayer.AutoMapper;
using BusinessLayer.ValidationRules.CustomValidation;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5._0_SystemLibraryManagementWebProject
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

            //#region context
            //services.AddDbContext<DbContext>();
            //services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

            //#endregion

            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.SignIn.RequireConfirmedAccount = false;
                x.SignIn.RequireConfirmedEmail = false;
                x.SignIn.RequireConfirmedPhoneNumber = false;
                x.User.RequireUniqueEmail = false;
                x.Password.RequiredLength = 3; // => password e girilen karakterin minimum 3 olmasýný saðladýk. Varsayýlan deðer 6 dýr.
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequireLowercase = false; // =>özelliði; þifre içerisinde en az 1 adet küçük harf zorunluluðu olmasý özelliðini false yaptýk.
                x.Password.RequireUppercase = false; // => özelliði; þifre içerisinde en az 1 adet büyük harf zorunluluðu olmasýný false yaptýk.
                x.Password.RequireNonAlphanumeric = false; // =>  özelliði; þifre içerisinde en az 1 adet alfanümerik karakter zorunluluðu olmasý özelliði false.
                x.Password.RequireDigit = false; // =>  özelliði; þifre içerisinde en az 1 adet rakam olması false.
            }).AddPasswordValidator<CustomSignInPasswordValidation>()
         .AddErrorDescriber<SignInCustomIdentityErrorDescriber>()
         .AddEntityFrameworkStores<Context>();



            services.AddControllersWithViews();

            //proje seviyesinde Authorization işlemi 
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});

            services.AddMvc();

            //#region IoC
            //services.AddTransient<UserManager<AppUser>>();
            //services.AddTransient<UserManager<AppRole>>();
            //#endregion

            #region Automapper
            services.AddAutoMapper(typeof(UserMapping));
            #endregion

            //services.AddAuthentication(
            //    CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(x =>
            //    {
            //        x.LoginPath = "/Login/Index/";
            //    });


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            //hata sayfası kullanım tanımı
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Authentication işlemi
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                 );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");

            });
        }
    }
}
