using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MongoDbChangeStreamFunction.Startup))]

namespace MongoDbChangeStreamFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<ExecutionContextOptions>()
                .Configure<IConfiguration>((options, configuration) =>
                {
                    //options.AppDirectory = configuration[EnvironmentSettingNames.AzureWebJobsScriptRoot] ?? options.AppDirectory;
                });

            builder.Services.AddSingleton<ITriggerBindingProvider, ChangeStreamTriggerBindingProvider>();
        }
    }
}