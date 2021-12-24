using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Net.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DiscordBot.Modules
{
    public class General : ModuleBase<SocketCommandContext>
    {
        Random random = new Random();
        private readonly IHttpClientFactory _httpClientFacktory;

        public General(IHttpClientFactory httpClientFacktory)
        {
            _httpClientFacktory = httpClientFacktory;
        }



        [Command("ping")]
        [Alias("test", "pin")]
        public async Task PingAsync()
        {
            string _command = "Pong!";
            await Context.Channel.TriggerTypingAsync();
            await Task.Delay(TimeSpan.FromMilliseconds(200 * _command.Length));
            await ReplyAsync(_command);
        }

        [Command("info")]
        [Alias("i")]
        public async Task InfoAsync(SocketGuildUser socketGuildUser = null)
        {
            if (socketGuildUser == null)
            {
                socketGuildUser = Context.User as SocketGuildUser;
            }
            var embed = new EmbedBuilder()
                .WithTitle($"{socketGuildUser.Username}#{socketGuildUser.Discriminator}")
                .AddField("ID", socketGuildUser.Id, true)
                .AddField($"Name", $"{socketGuildUser.Username}#{socketGuildUser.Discriminator}", true)
                .AddField("Created at", socketGuildUser.CreatedAt, true)
                .WithColor(new Color(142, 0, 67))
                .WithThumbnailUrl(socketGuildUser.GetAvatarUrl() ?? socketGuildUser.GetDefaultAvatarUrl())
                .Build();

            await ReplyAsync(embed: embed);

        }

        [Command("boost")]
        [Alias("booster", "madmonq", "champion", "suport", "powerup")]
        public async Task BoosterMadmonq(SocketGuildUser socketGuildUser = null)
        {

            int _random = random.Next(0, 1);
            int _sleep;
            string _command;

            if (socketGuildUser == null)
            {
                socketGuildUser = Context.User as SocketGuildUser;
            }

            if (_random == 0)
            {
                _command = $"Hey {socketGuildUser}, Brain Booster für Gamer \n https://www.madmonq.gg/?ref=BSRMWOYKAB";

            }
            else
            {
                _command = $"Hey {socketGuildUser}, Die tägliche Dosis Gesundheit für Gamer \n https://www.madmonq.gg/?ref=BSRMWOYKAB";

            }
            if (_command.Length <= 100) { _sleep = (50 * _command.Length); } else { _sleep = (25 * _command.Length); };
            await Context.Channel.TriggerTypingAsync();
            await Task.Delay(TimeSpan.FromMilliseconds(_sleep));
            await ReplyAsync(_command);

        }

        [Command("invite")]
        [Alias("invite my", "invite my friends", "imf")]
        public async Task invite(SocketGuildChannel _channel = null, SocketGuildUser socketGuildUser = null)
        {

            if (socketGuildUser == null)
            {
                socketGuildUser = Context.User as SocketGuildUser;
            }

            var embed = new EmbedBuilder()
               .WithTitle($"Invite Link Temporär")
               .WithDescription($"Moin {socketGuildUser.Username}, hier kommt dein Link zum einladen eines Freundes \n dieser muss in 2Std benutzt werden. \n \n ")

               .WithColor(new Color(142, 0, 67))
               .Build();

            await Context.User.SendMessageAsync(embed: embed);


        }


        [Command("coininfo")]
        [Alias("coinprice")]
        public async Task CoinInfo(SocketGuildUser socketGuildUser = null, SocketCommandContext socketCommand = null )
        {

            var httpClient = _httpClientFacktory.CreateClient();
            var response = await httpClient.GetStringAsync("https://api.blockchain.com/v3/exchange/symbols");
            var coininfo = APIs.CoinInfo.FromJson(response);
            var _loops = 0;
            List<string> _availableCoins = new List<string>();
            var _availableCoinsStr = "";

            foreach (var item in coininfo)
            {
                _availableCoins.Add(Convert.ToString(item.Value.BaseCurrency));
            }
            //Dubletten entfernen.
            _availableCoins = _availableCoins.Distinct().ToList();

            foreach (var item in _availableCoins)
            {
                _availableCoinsStr += item.ToString();
                _loops++;
                if (_loops < _availableCoins.Count)
                {
                    _availableCoinsStr += ", ";
                }
            }


            if (socketGuildUser == null)
            {
                socketGuildUser = Context.User as SocketGuildUser;
            }

            var embed = new EmbedBuilder()
            .WithTitle($"Crypto Kurs")
            .WithDescription($"Moin {socketGuildUser.Username},\n" +
            $"Wir unterstützen derzeit ({_availableCoins.Count}) Crypto währungen daher musst du zuerst eine von ihnen auswählen.\n " +
            $"Versuche es z.B. mit {Context.Message.Content} BTC \n\n" +
            $"Oder eine der folgenden: \n {_availableCoinsStr}")


            .WithColor(new Color(142, 0, 67))
            .Build();

            await ReplyAsync(embed: embed);
        }


        //Sende eine Privat nachricht
        //await Context.User.SendMessageAsync("Private Message!");

    }
}
