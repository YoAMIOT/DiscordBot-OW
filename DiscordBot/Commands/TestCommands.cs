using DiscordBot.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class TestCommands : BaseCommandModule{
        [Command("ping")]
        [Description("Test the bot by returning 'Pong'")]
        public async Task Ping(CommandContext ctx){
            //Checks the channel
            if(ctx.Channel.Id == 1066452105981870121){
                //Send a message containing "Pong" in the same channel
                await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
            }
        }

        [Command("OwQuery")]
        [Description("Get the datas of a player by entering it's BattleTag")]
        public async Task OwQuery(CommandContext ctx,[Description("Player Battletag")] string battleTag){
            //Checks the channel
            if (ctx.Channel.Id == 1066452105981870121){
                OverwatchCrud OwCrud = new OverwatchCrud();
                //Replace the normally used # by a - in the battleTag so the query does not fail
                string bTForQuery = Regex.Replace(battleTag, "#", "-", RegexOptions.IgnoreCase);
                //Get the response as a string
                string response = await OwCrud.GetDatasFromBT(bTForQuery);

                //Create a new player Object and assign the values
                Player player = new Player();
                player.battleTag = battleTag;
                if (response != "{}"){
                    player.SetDatas(response);
                    await ctx.Channel.SendMessageAsync(player.ToString()).ConfigureAwait(false);
                } else {
                    await ctx.Channel.SendMessageAsync(player.battleTag + " has a private profile.").ConfigureAwait(false);
                }
                //JsonConvert.DeserializeObject<Player>(response);
            }
        }
    }
}
