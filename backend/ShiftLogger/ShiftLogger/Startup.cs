using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShiftLogger.Domain;
using ShiftLogger.Infra;
using ShiftLogger.Model;
using ShiftLogger.Model.Request;


namespace ShiftLogger
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ShiftLogger", Version = "v1"});
            });
            
            services.AddSingleton<TextWriter>(new WrappingWriter(Console.Out));
            services.AddDbContext<ShiftLoggerContext>(opts => opts.UseInMemoryDatabase("ShipperLoggerDb"));
            services.AddScoped<IRepository<ShiftLog>, ShiftLogRepo>();
            services.AddMediatR(typeof(Startup));
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateShiftLogValidation>());
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShiftLogger v1"));
                app.UseCors(c =>
                {
                    c.AllowAnyHeader();
                    c.AllowAnyOrigin();
                    c.AllowAnyMethod();
                });
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}