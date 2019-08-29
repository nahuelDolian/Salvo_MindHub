using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ProyectoSalvo.Data;
using ProyectoSalvo.Repositories;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace ProyectoSalvo
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<SalvoDatabaseContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SalvoDatabaseContext")));
            //options.UseSqlServer("Server=.\\SQLEXPRESS;Database=MinHubUltimate;Trusted_Connection=True;MultipleActiveResultSets=true"));

            //order json
            services.AddMvc().AddJsonOptions(options =>
            { options.SerializerSettings.Formatting = Formatting.Indented; });

            services.AddMvc().AddJsonOptions(options =>
            { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = new PathString("/index.html");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PlayerOnly", policy => policy.RequireClaim("Player"));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IGameRepository, GameRepository>();

            services.AddScoped<IGamePlayerRepository, GamePlayerRepository>();

            services.AddScoped<IPlayerRepository, PlayerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //app.UseCors(builder => builder.AllowAnyHeader()
            //.AllowAnyMethod()
            //.SetIsOriginAllowed((host) => true)
            //.AllowCredentials());//Configuracion para tener acceso desde cualquier lado en modo desarrollo
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();


            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
        }
    }
}