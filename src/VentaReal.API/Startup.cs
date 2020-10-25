
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer( opt => {

                        opt.TokenValidationParameters = new TokenValidationParameters 
                        {
                            ValidateIssuer              = true,
                            ValidateAudience            = true,
                            ValidateLifetime            = true,
                            ValidateIssuerSigningKey    = true,
                            ValidIssuer                 = Configuration["AppSettings:Issuer"],
                            ValidAudience               = Configuration["AppSettings:Issuer"],
                            IssuerSigningKey            = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AppSettings:Secret"))
                        };

                    } );

            services.AddMvc(opt => opt.EnableEndpointRouting = false);
            services.AddDbContext<VentaRealContext>();
            services.AddTransient<ICarServices, Carservices>();
            
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
