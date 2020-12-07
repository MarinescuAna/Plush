using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Implementation;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Repository;
using Plush.Utils;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Plush
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), ConstantString.nlogConfig));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<PlushDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(ConstantString.DefaultConnection)));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProviderDeliveryService, ProviderDeliveryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Session
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
            });

            //For Jwt
            var tokenValidationParameter = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["SecretKey"])),
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddSingleton(tokenValidationParameter);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameter;
            });


            //For SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ConstantString.V1, new OpenApiInfo { Title = ConstantString.CoreApi, Description = ConstantString.SwaggerCoreApi });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            //For Angular Consumer
            services.AddCors(o => o.AddPolicy(ConstantString.CORSPolicy, builder => {
                builder.WithOrigins(Configuration.GetValue<string>(ConstantString.CORSOrigin))
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //For Angular Consumer
            app.UseCors(ConstantString.CORSPolicy);

            app.UseRouting();

            //Session
            app.UseSession();

            //For Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(ConstantString.SwaggerJson, ConstantString.CoreApi);
            });

            app.UseHttpsRedirection();

            //Add JWToken to all incoming HTTP Request Header
            app.Use(async (context, next) =>
            {
                var jwToken = context.Session.GetString("Token");
                if (!string.IsNullOrEmpty(jwToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + jwToken);
                }
                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
