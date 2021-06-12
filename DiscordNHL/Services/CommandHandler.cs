using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace DiscordNHL.Services
{
    public class CommandHandler
    {
        public static IServiceProvider Services;
        public static DiscordSocketClient Discord;
        public static CommandService _commands;
        public static IConfigurationRoot Configuration;
        public CommandHandler(DiscordSocketClient discord, CommandService commands, IConfigurationRoot config, IServiceProvider provider)
        {
            Services = provider;
            Discord = discord;
            _commands = commands;
            Configuration = config;

            Discord.Ready += OnReady;
            Discord.MessageReceived += OnMessageReceived;
        }

        private async Task OnMessageReceived(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;

            if (msg.Author.IsBot) return;

            var context = new SocketCommandContext(Discord, msg);

            int position = 0;

            if(msg.HasStringPrefix(Configuration["prefix"], ref position) || msg.HasMentionPrefix(Discord.CurrentUser, ref position))
            {
                var result = await _commands.ExecuteAsync(context, position, Services);

                if (!result.IsSuccess)
                {
                    var error = result.Error;

                    await context.Channel.SendMessageAsync($"An error occured: \n {error}");
                    Console.WriteLine(error);
                }
            }
        }

        private Task OnReady()
        {
            Console.WriteLine($"Connected as {Discord.CurrentUser.Username}#{Discord.CurrentUser.Discriminator}");
            return Task.CompletedTask;
        }
    }
}
