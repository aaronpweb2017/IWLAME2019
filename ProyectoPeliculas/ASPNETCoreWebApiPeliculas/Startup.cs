using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using ASPNETCoreWebApiPeliculas.Helpers;
using Microsoft.Extensions.DependencyInjection;
using ASPNETCoreWebApiPeliculas.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ASPNETCoreWebApiPeliculas.Services;

namespace ASPNETCoreWebApiPeliculas
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            string SQLConnectionString = Configuration.GetConnectionString("SQLServerConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(SQLConnectionString));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUsuarios, UsuariosRepository>();
            services.AddScoped<ISolicitudes, SolicitudesRepository>();
            services.AddScoped<IVistas, VistasRepository>();
            services.AddCors(options => { options.AddPolicy("Access-Control-Allow-Origin",
                builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
            });
            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
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
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
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