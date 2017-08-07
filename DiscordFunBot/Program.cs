using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class Program
    {
        
        private DiscordSocketClient _client;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            

            _client.Log += Log;

            _client.MessageReceived += MessageReceived;

            _client.UserJoined += UserJoined;

            _client.UserIsTyping += UserIsTyping;



            string token = ""; // Remember to keep this private!
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            


            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "Halo?")
            {
                await message.Channel.SendMessageAsync("Kermit ciota");
            }
        }

        private async Task UserIsTyping(SocketUser u, ISocketMessageChannel m)
        {
            string username = u.Username;
            await m.SendMessageAsync("co tam piszesz " + username + "?");
        }

        private async Task UserJoined(SocketGuildUser u)
        {
            string username = u.Username;
            await u.SendMessageAsync("Elo " + username);

        }



        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
