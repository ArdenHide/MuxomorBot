using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MuxomorBot.Commands;
using MuxomorBot.Data;
using MuxomorBot.Services;
using System;

namespace MuxomorBot
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(opt =>
                opt.UseSqlServer(_configuration.GetConnectionString("Db")), ServiceLifetime.Singleton);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MuxomorBot", Version = "v1" });
            });
            services.AddSingleton<TelegramBot>();
            services.AddSingleton<ICommandExecutor, CommandExecutor>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<BaseCommand, StartCommand>();
            services.AddSingleton<BaseCommand, BackToMainCommand>();
            services.AddSingleton<BaseCommand, GetCategoriesCommand>();
            services.AddSingleton<BaseCommand, GetProductTypesCommand>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MuxomorBot v1"));
            }


            app.UseHttpsRedirection();
            serviceProvider.GetRequiredService<TelegramBot>().GetBot().Wait();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
