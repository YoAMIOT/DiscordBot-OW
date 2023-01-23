using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DiscordBot{
    public class OverwatchCrud{
        HttpClient client = new HttpClient();

        //TEST URL = https://overfast-api.tekrop.fr/players/TitoAlba-2986/summary
        public async Task<string> getDatasFromBattleTag(string battleTag){
            string url = "https://overfast-api.tekrop.fr/players/" + battleTag + "/summary";
            string apiResponse = await client.GetStringAsync(url);
            return apiResponse;
        }
    }
}
