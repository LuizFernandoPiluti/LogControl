using LogControl.Data.Data.Repositoty;
using LogControl.Data.Infra;
using LogControl.Kafka;
using LogControl.Model.Interface.Application;
using LogControl.Model.Interface.Data;
using LogControl.Model.Interface.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace LogControl.Service
{
    public   class Startup
    {
        IConfigurationRoot Configuration { get; }

      
        public Startup(IConfigurationRoot configurationRoot)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

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
    }
}
