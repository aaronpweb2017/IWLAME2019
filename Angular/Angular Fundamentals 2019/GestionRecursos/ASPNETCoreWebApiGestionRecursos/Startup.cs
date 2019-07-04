using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using ASPNETCoreWebApiGestionRecursos.Helpers;
using ASPNETCoreWebApiGestionRecursos.Services;
using Microsoft.Extensions.DependencyInjection;
using ASPNETCoreWebApiORAGestionRecursos.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
            string CurrentUserName = ""; string ConnectionString = "";
            CurrentUserName = WindowsIdentity.GetCurrent().Name;
            if(CurrentUserName.Equals("DESKTOP-E7CRFE9\\Lenovo"))
                ConnectionString = Configuration.GetConnectionString("SQLHomeConnectionString");
            if(CurrentUserName.Equals("NEORIS\\e-lmedina"))
                ConnectionString = Configuration.GetConnectionString("SQLWorkConnectionString");
            services.AddDbContext<AsignacionContext>(options => options.UseSqlServer(ConnectionString));
            services.AddDbContext<ProyectoContext>(options => options.UseSqlServer(ConnectionString));
            services.AddDbContext<EmpleadoContext>(options => options.UseSqlServer(ConnectionString));
            services.AddScoped<IAsignacionesManager, AsignacionesManager>();
            services.AddScoped<IProyectosManager, ProyectosManager>();
            services.AddScoped<IEmpleadosManager, EmpleadosManager>();
            services.AddScoped<IUserService, UserService>();
            services.AddCors(options => { options.AddPolicy("Access-Control-Allow-Origin",
                builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });

            //Configure strongly typed Settings Objects:
            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //Configure JWT Authentication:
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, ValidateAudience = false
                };
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseCors("Access-Control-Allow-Origin");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}