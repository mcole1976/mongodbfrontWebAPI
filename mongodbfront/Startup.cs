using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using mongodbfront.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace mongodbfront
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = "dotnet - user - jwts", // Use 'Configuration' (not 'builder')
               // ValidateAudience = true,
                ValidAudience = "https://localhost:44377/api/Exercise",
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkV4ZXJjaXNlVXNlciIsInN1YiI6IkV4ZXJjaXNlVXNlciIsImp0aSI6ImY2NDNjZTVmIiwic2NvcGUiOiJleGVyY2lzZTpyZWFkLGV4ZXJjaXNlOndyaXRlIiwiYXVkIjpbImh0dHA6Ly9sb2NhbGhvc3Q6NTE3NTMiLCJodHRwczovL2xvY2FsaG9zdDo0NDM3NyIsImh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJodHRwOi8vbG9jYWxob3N0OjUwMDAiXSwibmJmIjoxNzQzODI3MDc3LCJleHAiOjE3NTE2ODk0NzcsImlhdCI6MTc0MzgyNzA4MiwiaXNzIjoiZG90bmV0LXVzZXItand0cyJ9.uy5ecTaygIKFE-ITu6HNJghwuEyHLHtB1k2HpWFQZUI")) // Replace with your key
            };

    });
            services.AddTransient<ServiceClass>();
            services.AddSingleton<ServiceB>();
          services.AddTransient<JWTService>();
            services.AddSingleton<Exercise_Service>();
            services.AddSingleton<Food_Service>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Add your client's origin here
              .AllowAnyHeader()
              .AllowAnyMethod();
                });
            });


            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect; options.HttpsPort = 443;
                // The port for HTTPS, usually 443
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mongodbfront", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mongodbfront v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowSpecificOrigins");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
