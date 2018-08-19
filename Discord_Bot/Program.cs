using Discord_Bot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Discord_Bot
{
    class Program
    {
        public static DiscordClient discord;
        static CommandsNextModule commands;

        static void Main()
        {
            MainAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var token = File.ReadAllText("DiscordSettings.json");
            var code = JsonConvert.DeserializeObject<BotKey>(token);

            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = code.Key,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!",
                EnableDms = false
            });

            commands.RegisterCommands<GetListCommand>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
