using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DiscordBot.Entities{
    public class OverwatchCrud{
        HttpClient client = new HttpClient();

        //TEST URL = https://overfast-api.tekrop.fr/players/BaDWolf-22682/stats/summary
        public async Task<string> GetDatasFromBT(string battleTag){
            //Create the URL for the Query
            string url = "https://overfast-api.tekrop.fr/players/" + battleTag + "/stats/summary";
            //Make the HTTP GET request and get the response as a string
            string apiResponse = await client.GetStringAsync(url);
            return apiResponse;
        }
    }
}
