
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VentaReal.API.Data;
using VentaReal.API.Data.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using VentaReal.API.Service;
using VentaReal.API.Common.tools;

namespace VentaReal.API
{
    public class Startup
    {
        private readonly string _myCors = "Cors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors( opt => 
            {

                opt.AddPolicy(name:_myCors, builder => {

                    builder.WithHeaders("*");
                    builder.WithOrigins("*");
                    builder.WithMethods("*");
                }  
                    
                );

            });

            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>( appSettingSection );

            //JWT
            var appSettings = appSettingSection.Get<AppSettings>();
            var llave = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication( JwtToken => 
            
                {
                    JwtToken.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     JwtToken.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }
            ).AddJwtBearer( JwtBearer => 
            {
                JwtBearer.RequireHttpsMetadata = false;
                JwtBearer.SaveToken = true;
                JwtBearer.TokenValidationParameters = new TokenValidationParameters {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =  new SymmetricSecurityKey(llave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddMvc(opt => opt.EnableEndpointRouting = false);
            services.AddDbContext<VentaRealContext>();
            services.AddTransient<ICarServices, Carservices>();
            services.AddScoped<IUserService,UserService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(_myCors);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvcWithDefaultRoute();
        }
    }
}
