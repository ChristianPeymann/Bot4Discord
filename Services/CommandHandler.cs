using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Discord;

namespace DiscordBot.Services
{
    public class CommandHandler : InitializedService
    {
        private readonly IServiceProvider provider;
        private readonly DiscordSocketClient client;
        private readonly CommandService service;
        private readonly IConfiguration configuation;

        public CommandHandler(IServiceProvider provider, DiscordSocketClient client, CommandService service, IConfiguration configuation)
        {
            this.provider = provider;
            this.client = client;
            this.service = service;
            this.configuation = configuation;

        }

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            this.client.MessageReceived += OnMessageReceived;
            this.service.CommandExecuted += OnCommandExecuted;
            await this.service.AddModulesAsync(Assembly.GetEntryAssembly(), this.provider);
        }

        private async Task OnCommandExecuted(Optional<CommandInfo> commandInfo, ICommandContext commandContext, IResult result)
        {
            if (result.IsSuccess)
            {
                return;
            }
            await commandContext.Channel.SendMessageAsync(result.ErrorReason);
        }


        private async Task OnMessageReceived(SocketMessage socketMessage)
        {
            if (!(socketMessage is SocketUserMessage message)) return;
            if (message.Source != Discord.MessageSource.User) return;

            var argPos = 0;
            if (!message.HasStringPrefix(this.configuation["Prefix"], ref argPos) && !message.HasMentionPrefix(this.client.CurrentUser, ref argPos)) return;

            var context = new SocketCommandContext(this.client, message);
            await this.service.ExecuteAsync(context, argPos, this.provider);
        }
    }
}
