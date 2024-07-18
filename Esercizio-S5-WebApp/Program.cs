using Esercizio_S5_WebApp.Models;
using Esercizio_S5_WebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace Esercizio_S5_WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                 {
                     opt.LoginPath = "/Auth/Login";
                 });
            builder.Services.
                AddAuthorization(opt =>
                {
                    opt.AddPolicy(Policies.LoggedIn, cfg => cfg.RequireAuthenticatedUser());
                    opt.AddPolicy(Policies.IsAdmin, cfg => cfg.RequireRole("Admin"));
                    opt.AddPolicy(Policies.IsWorker, cfg => cfg.RequireRole("Workers"));
                });


            builder.Services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ISpedizioniService, SpedizioneService>()
                .AddScoped<IClientePrivatoService, ClientePrivatoService>()
                .AddScoped<IClienteAziendaService, ClienteAziendaService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
