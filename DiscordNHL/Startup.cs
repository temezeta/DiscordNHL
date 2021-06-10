using Discord.Commands;
using Discord.WebSocket;
using DiscordNHL.Integrations;
using DiscordNHL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DiscordNHL
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IConfigurationRoot Env { get; }

        public Startup(string[] args)
        {
            Env = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var environment = Env["RUNTIME_ENVIRONMENT"];

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{environment ?? "Production"}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>()
                .Build();
        }

        public static async Task RunAsync(string[] args)
        {
            var startup = new Startup(args);
            await startup.RunAsync();
        }

        public async Task RunAsync()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();
            provider.GetRequiredService<CommandHandler>();

            await provider.GetRequiredService<StartupService>().StartAsync();
            await Task.Delay(-1);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
                {
                    LogLevel = Discord.LogSeverity.Verbose,
                    MessageCacheSize = 1000,
                }))
                .AddSingleton(new CommandService(new CommandServiceConfig
                {
                    LogLevel = Discord.LogSeverity.Verbose,
                    DefaultRunMode = RunMode.Async,
                    CaseSensitiveCommands = false
                }))
                .AddSingleton<CommandHandler>()
                .AddSingleton<StartupService>()
                .AddSingleton(Configuration)
                .AddSingleton<INHLDataProvider, NHLDataProvider>()
                .AddHttpClient<INHLDataProvider, NHLDataProvider>((client) =>
                {
                    client.BaseAddress = new Uri(Configuration["URL:NHL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });
        }
    }
}
