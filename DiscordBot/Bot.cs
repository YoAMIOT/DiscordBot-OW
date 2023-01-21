using DiscordBot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot{
    public class Bot{

        public DiscordClient Client {get; private set;}
        public CommandsNextExtension Commands {get; private set;}


        //RUN THE BOT
        public async Task RunAsync(){
            //GET THE CONFIG FROM THE config.json file
            var json = string.Empty;
            using (FileStream fs = File.OpenRead("config.json"))
                using (StreamReader sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);
            ConfigJson configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            //SETUP THE CONFIG OF THE CLIENT
            DiscordConfiguration config = new DiscordConfiguration {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
                Intents = DiscordIntents.All
            };
            Client = new DiscordClient(config);
            //Subscribe to the event that's triggered when bot is fully started
            Client.Ready += OnClientReady;

            //SETUP THE CONFIG OF THE COMMAND MANAGER
            CommandsNextConfiguration commandsConfig = new CommandsNextConfiguration{
                StringPrefixes = new string[]{configJson.Prefix},
                EnableMentionPrefix = true,
                EnableDms = false,
                DmHelp = true,
            };
            Commands = Client.UseCommandsNext(commandsConfig);
            //Take in count all the commands in TestCommands
            Commands.RegisterCommands<TestCommands>();

            //WAIT FOR THE BOT TO CONNECT
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }


        //IS TRIGGERED WHEN BOT IS FULLY STARTED
        private Task OnClientReady(DiscordClient client, ReadyEventArgs e){
            return Task.CompletedTask;
        }
    }
}
