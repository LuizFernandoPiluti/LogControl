using LogControl.Data.Data.Repositoty;
using LogControl.Data.Infra;
using LogControl.Kafka;
using LogControl.Model.Interface.Data;
using LogControl.Model.Interface.Service;
using LogControl.Model.Model;
using LogControl.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;

namespace LogControl.Executor
{
    internal class Program
    {
       
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder().SetBasePath(@"D:\Projetos\LogControl\LogControl\LogControl.Executor")
              .AddJsonFile("AppSettings.json");

            var  Configuration = builder.Build();
            var  services = new ServiceCollection();


            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.Configure<DataBaseConfig>(Configuration.GetSection(nameof(DataBaseConfig)));
            services.AddSingleton<IDataBaseConfig>(sp => sp.GetRequiredService<IOptions<DataBaseConfig>>().Value);
            services.AddSingleton<ILogRepository, LogRepository>();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<IKafkaService, KafkaService>();
            services.Configure<IKafkaConfig>(Configuration.GetSection(nameof(KafkaConfig)));
            services.AddSingleton<IKafkaConfig>(sp => sp.GetRequiredService<IOptions<KafkaConfig>>().Value);


            var serviceProvider = services.BuildServiceProvider();  

            // Get Service and call method
            var serviceKafka = serviceProvider.GetService<IKafkaService>();
            var serviceLog = serviceProvider.GetService<ILogService>();
            while (true)
            {
                string msg = serviceKafka.ConsumerMsg();
                if (string.IsNullOrEmpty(msg))
                {
                    var log = JsonSerializer.Deserialize<Log>(msg);
                    serviceLog.Insert(log);
                }



            }

        }
      
    }
}
