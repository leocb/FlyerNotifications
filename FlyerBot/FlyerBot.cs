using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Flyer.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Bot
{
    public class FlyerBot
    {
        private readonly BotConfig _botConfig;
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        public FlyerBot()
        {
            _botConfig = new BotConfig();

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Info,
                MessageCacheSize = 50,
            });
            _client.Log += LogAsync;

            _commands = new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Info,
                CaseSensitiveCommands = false,
            });
            _commands.Log += LogAsync;
        }

        public async Task Login()
        {
            await _client.LoginAsync(TokenType.Bot, _botConfig.Token);
            await _client.StartAsync();
            _client.Ready += _client_Ready;
        }

        private Task _client_Ready()
        {
            _client.MessageReceived += HandleCommandAsync;
            return Task.CompletedTask;
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            // Bail out if it's a System Message.
            var msg = arg as SocketUserMessage;
            if (msg == null) return;

            // We don't want the bot to respond to itself or other bots.
            if (msg.Author.Id == _client.CurrentUser.Id || msg.Author.IsBot) return;

            // Create a number to track where the prefix ends and the command begins
            int pos = 0;

            // Replace the '!' with whatever character
            // you want to prefix your commands with.
            // Uncomment the second half if you also want
            // commands to be invoked by mentioning the bot instead.
            if (msg.HasCharPrefix('!', ref pos) || msg.HasMentionPrefix(_client.CurrentUser, ref pos))
            {
                // Create a Command Context.
                var context = new SocketCommandContext(_client, msg);

                // Execute the command. (result does not indicate a return value, 
                // rather an object stating if the command executed successfully).
                // var result = await _commands.ExecuteAsync(context, pos, _services);

                // Uncomment the following lines if you want the bot
                // to send a message if it failed.
                // This does not catch errors from commands with 'RunMode.Async',
                // subscribe a handler for '_commands.CommandExecuted' to see those.
                //if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
            }
            await msg.Channel.SendMessageAsync($"Echo: {msg.Content}");

            return;
        }

        private Task LogAsync(LogMessage message)
        {
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Debug.Write("Error: ");
                    break;
                case LogSeverity.Warning:
                    Debug.Write("Warning: ");
                    break;
            }

            if (message.Exception is CommandException cmdException)
            {
                Debug.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()}"
                    + $" failed to execute in {cmdException.Context.Channel}.");
                Debug.WriteLine(cmdException);
            }
            else
                Debug.WriteLine($"[General/{message.Severity}] {message}");

            return Task.CompletedTask;
        }
    }
}
