using System;
using DiscordBot.Entities;

namespace DiscordBot
{
    class Program{
        static void Main(string[] args){
            Bot bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}