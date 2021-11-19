using FluentValidation;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Domain.Commands.UserCommands.CreateUser;
using Hahn.ApplicatonProcess.July2021.Domain.Contracts.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Dto.User;
using Hahn.ApplicatonProcess.July2021.Domain.Validators;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace Hahn.ApplicationProcess.July2021.Web
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
           .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(options => options.EnableEndpointRouting = false)
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateUserValidator>());

            services.AddDbContext<HahnDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "hahn_dev");
                //string connectionString = string.Empty;

                //if (_currentEnvironment.IsDevelopment())
                //    connectionString = Configuration.GetConnectionString("dbConnectionString");
                //else
                //    connectionString = Environment.GetEnvironmentVariable("dbConnectionString");

                //options.UseSqlServer(connectionString);
            });

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.ApplicationProcess.July2021.Web", Version = "v1" });
            });
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.RegisterRequestHandlers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicationProcess.July2021.Web v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
