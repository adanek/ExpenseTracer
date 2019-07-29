using System;
using System.Reflection;
using ExpenseTracer.Application.Expenses.Commands;
using ExpenseTracer.Application.Expenses.Queries;
using ExpenseTracer.Application.Infrastructure;
using ExpenseTracer.Application.Interfaces;
using ExpenseTracer.Common.Dates;
using ExpenseTracer.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ExpenseTracer.Web.Api
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
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            // Add MediatR
            services.AddMediatR(typeof(GetExpenseListQuery).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateExpenseCommandValidator>());

            services.AddDbContext<IDatabaseService, DatabaseService>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ExpenseTracerContext"));
                //options.UseInMemoryDatabase("ExpenseTracerContext");
            });

            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Expense Tracer Api",
                    Version = "v1",
                    Description = "Provides the functionality to trace your expenses",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Andreas Danek",
                        Email = "not.my@mail.com",
                        Url = new Uri("https://www.linkedin.com/in/andreas-danek/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "The MIT License",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using(var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetRequiredService<IDatabaseService>())
            {
                var dateTimeProvider = scope.ServiceProvider.GetRequiredService<IDateTimeProvider>();
                DatabaseInitializer.Initialize(context, dateTimeProvider).GetAwaiter().GetResult();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
