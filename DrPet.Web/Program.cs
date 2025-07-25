using DrPet.Bll;
using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<VetDbContext>(opts =>
                        opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        sql => sql.MigrationsAssembly("DrPet.Data")));

            builder.Services.AddBusinessLayer();
            

            var app = builder.Build();
            await app.SeedAsync();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.MapRazorPages();
            app.MapControllers();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
