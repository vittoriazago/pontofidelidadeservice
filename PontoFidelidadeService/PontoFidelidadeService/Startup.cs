using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PontoFidelidade.Persistence;
using PontoFidelidade.WebApi;
using PontoFidelidade.WebApi.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PontoFidelidadeService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            TypesToRegister = Assembly.Load("PontoFidelidade.Domain")
                                      .GetTypes()
                                      .Where(x => !string.IsNullOrEmpty(x.Namespace))
                                      .Where(x => x.IsClass)
                                      .Where(x => x.Name.Contains("Service"))
                                      .ToList();
        }

        public IConfiguration Configuration { get; }
        public List<Type> TypesToRegister { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DbContext, PontoFidelidadeContexto>();
            services.AddDbContext<PontoFidelidadeContexto>(
                x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.ConfigureAuthentication(Configuration.GetSection("AppSettings:PrivateToken").Value);

            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter(policy));

                options.Filters.Add(typeof(MyExceptionFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(
                 options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );

            TypesToRegister.ForEach(x => services.AddScoped(x));

            services.AddCors();

            services.ConfigureDI();
            services.ConfigureAutoMapper();
            services.ConfigureSwaggerService();
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

            app.UseAuthentication();
            
            app.UseCors(x => x.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());

            //declare os middlewares antes do mvc
            app.UseMvc();

            app.ConfigureSwagger();
        }
    }
}

