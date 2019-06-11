using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ASPNETCoreWebApiORAGestionRecursos.Models;

namespace ASPNETCoreWebApiORAGestionRecursos
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            String SQLHomeConnectionString = Configuration.GetConnectionString("SQLHomeConnectionString");
            String SQLWorkConnectionString = Configuration.GetConnectionString("SQLWorkConnectionString");
            
            services.AddDbContext<EmpleadoContext>(options => options.UseSqlServer(SQLWorkConnectionString));
            services.AddDbContext<ProyectoContext>(options => options.UseSqlServer(SQLWorkConnectionString));
            services.AddDbContext<AsignacionContext>(options => options.UseSqlServer(SQLWorkConnectionString));
            
            services.AddScoped<IEmpleadosManager, EmpleadosManager>();
            services.AddScoped<IProyectosManager, ProyectosManager>();
            services.AddScoped<IAsignacionesManager, AsignacionesManager>();

            services.AddCors(options => {
                options.AddPolicy("Access-Control-Allow-Origin",
                builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }
            app.UseCors("Access-Control-Allow-Origin");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}