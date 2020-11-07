using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NLog;
using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.Implementation;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Implementation;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Repository;
using Plush.Utils;
using System.IO;
using System.Linq;

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
            services.AddSingleton<ILoggerService, LoggerService>();

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

            //For Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(ConstantString.SwaggerJson, ConstantString.CoreApi);
            });

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
