using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands{
    public class TestCommands : BaseCommandModule{
        [Command("ping")]
        [Description("Test the bot by returning 'Pong'")]
        public async Task Ping(CommandContext ctx){
            if(ctx.Channel.Id == 1066452105981870121){
                await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
            }
        }
    }
}
