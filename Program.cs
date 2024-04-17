using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Online_store.Data;
using System;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Online_store

/* This is the main fucntion for our Capstone Project!
 * Authors:
 * Cam Carlson, TODO: <add name here>
 * David Khuu, TODO: work on code 
 * Saicharith Vaitla TODO: work
 * 
 * Erin Hughey
 * This is a test commit!!!!!!! :)
 * Amgad Ahmed
 */

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<OnlineStoreContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnectionString")
            ));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<OnlineStoreContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            using (var serviceScope = app.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<OnlineStoreContext>();
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");

            app.Run();

        }
    }
}
