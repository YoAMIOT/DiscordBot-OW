using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordBot.Entities{
    internal class Player{
        public string battleTag;
        public int gamesPlayed;
        public float timePlayed;
        public float winRate;
        public float kda;

        public void SetDatas(string json){
            //Split the results into 2 json strings
            string[] Stats = json.Split("\"roles\":");
            string[] GeneralSplit = Stats[0].Split("\"total\":");
            GeneralSplit = GeneralSplit[0].Split("\"general\":");
            string generalStats = GeneralSplit[1].Substring(0, GeneralSplit[1].Length - 2) + "}";
            dynamic dyn = JsonConvert.DeserializeObject(generalStats);
            gamesPlayed = dyn.games_played;
            timePlayed = dyn.time_played;
            winRate = dyn.winrate;
            kda = dyn.kda;


            Stats = Stats[1].Split("\"heroes\":");
            string HeroesStats = "{\"heroes\":" + Stats[1];
            //TO-DO HEROES RESUME

        }

        public string ToString(){
            return (battleTag + ": gamesPlayed: " + gamesPlayed + ", timePlayed: " +
                timePlayed + ", winrate: " + winRate + "%, kda: " + kda);
        }
    }
}
