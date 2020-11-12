using DITypeFilterSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pachkoriya_HW09.Models;
using Pachkoriya_HW09.Infrastructure;

namespace Pachkoriya_HW09
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
            services.AddSingleton<Logger>();
            services.AddSingleton<ExceptionLogingAttribute>();

            services.AddControllersWithViews();
            services.AddMvc().AddMvcOptions(
                options => {
                    options.Filters.Add<ProfileAttribute>(); // без внедрения зависимострей
                    // фильтр исключений всегда создается как глобальный фильтр
                    options.Filters.AddService<ExceptionLogingAttribute>(); // с внедрением зависимостей
                });
            services.AddSingleton<BusRepository>();
            services.AddRazorPages().AddMvcOptions(options => {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "Обязательно к заполнению");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
