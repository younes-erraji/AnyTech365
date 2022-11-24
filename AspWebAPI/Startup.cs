using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;

using AspWebAPI.Data;
using AspWebAPI.Data.Services;

namespace AspWebAPI
{
    public class Startup
    {
        private readonly string _connectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("SQLServer");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<_DBContext>(options => options.UseSqlServer(_connectionString));

            services.AddTransient<BooksService>();
            services.AddTransient<AuthorsService>();
            services.AddTransient<ReadersService>();
            services.AddTransient<BooksReadersService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.01", new OpenApiInfo { Title = "Books Library", Version = "v0.01" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v0.01/swagger.json", "BooksLibrary v0.01"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DBInitializer.Seed(app);
        }
    }
}
