using LogControl.Data.Data.Repositoty;
using LogControl.Data.Infra;
using LogControl.Kafka;
using LogControl.Model.Interface.Data;
using LogControl.Model.Interface.Service;
using LogControl.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogControl.Executor
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }


        public Startup()
        {
            var builder = new ConfigurationBuilder().SetBasePath(@"D:\Projetos\LogControl\LogControl\LogControl.Executor")
                .AddJsonFile("AppSettings.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.Configure<DataBaseConfig>(Configuration.GetSection(nameof(DataBaseConfig)));
            services.AddSingleton<IDataBaseConfig>(sp => sp.GetRequiredService<IOptions<DataBaseConfig>>().Value);
            services.AddSingleton<ILogRepository, LogRepository>();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<IKafkaService, KafkaService>();
            services.Configure<IKafkaConfig>(Configuration.GetSection(nameof(KafkaConfig)));
            services.AddSingleton<IKafkaConfig>(sp => sp.GetRequiredService<IOptions<KafkaConfig>>().Value);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
        }
    }
}
