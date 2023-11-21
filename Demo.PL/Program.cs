using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Migrations;
using Demo.DAL.Models;
using Demo.DAL.Models.Contexts;
using Demo.PL.MappingProfiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ApplicationUser = Demo.DAL.Models.ApplicationUser;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Builder = WebApplication.CreateBuilder(args);
            #region Configure Services that allow Dependency Injection
            Builder.Services.AddControllersWithViews();
            Builder.Services.AddDbContext<MVCAppContext>(Options =>
            {
                object value = Options.UseSqlServer(Builder.Configuration.GetConnectionString("DefaultConnections"));
            }); // Allow Dependency Injection

            Builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();  // Allow Dependency Injection Class Department Repository

            Builder.Services.AddAutoMapper(M => M.AddProfile(new EmployeeProfile()));
            Builder.Services.AddAutoMapper(M => M.AddProfile(new UserProfile()));
            Builder.Services.AddAutoMapper(M => M.AddProfile(new RoleProfile()));

            Builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<UserManager<ApplicationUser>> ();
            //services.AddScoped<SignInManager<ApplicationUser>>();
            Builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<MVCAppContext>()
                .AddDefaultTokenProviders();

            Builder.Services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Options =>
                {
                    Options.LoginPath = "Account/Login";
                    Options.AccessDeniedPath = "Home/Error";
                });
            #endregion

            var app = Builder.Build();
            #region Configure Http Request PipeLine
            if (app.Environment.IsDevelopment())
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
            app.Run();
            #endregion
        }


    }
}
