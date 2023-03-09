using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApiVS.Configuration;
using WebApiVS.Contracts.Validation;
using WebApiVS.Data.Interfaces;
using WebApiVS.Data.Repos;
using WebApiVS.Data;

namespace WebApiVS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } = new ConfigurationBuilder()
  .AddJsonFile("HomeOptions.json")
  .Build();


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавляем новый сервис
            services.Configure<HomeOptions>(Configuration);

            // Загружаем только адрес (вложенный Json-объект) 
            //services.Configure<Address>(Configuration.GetSection("Address"));

            //services.Configure<HomeOptions>(opt =>
            //{
            //    opt.Telephone = "+23213123123123";
            //    opt.Area = 120;
            //});

            // Подключаем автомаппинг
            var assembly = Assembly.GetAssembly(typeof(MappingProfile));
            services.AddAutoMapper(assembly);

            // регистрация сервиса репозитория для взаимодействия с базой данных
            services.AddSingleton<IDeviceRepository, DeviceRepository>();
            services.AddSingleton<IRoomRepository, RoomRepository>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HomeApiContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);

            // Подключаем валидацию
            services.AddValidatorsFromAssemblyContaining<AddDeviceRequestValidator>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WebApiVS", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI();
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
