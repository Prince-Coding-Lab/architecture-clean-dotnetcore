using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperStore.Core.Entities;
using SuperStore.Core.Interfaces;
using SuperStore.Core.Services;
using SuperStore.Infrastructure.data;
using SuperStore.Infrastructure.Data;

namespace SuperStore.Api
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
            // use real database
            // Requires LocalDB which can be installed with SQL Server Express 2016
            // https://www.microsoft.com/en-us/download/details.aspx?id=54284
            //services.AddDbContext<SuperStoreContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            //    );
            services.AddAutoMapper(typeof(Item).Assembly);
            services.AddDbContext<SuperStoreContext>(options =>
                        options.UseSqlServer(
    Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("SuperStore.Infrastructure")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddCors();
            //services.AddAutoMapper(typeof(SuperStore.Api).Assembly);
            services.AddHealthChecks();
            services.AddAuthorization();
            services.AddControllers();
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
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
