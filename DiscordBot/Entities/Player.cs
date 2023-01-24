using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordBot.Entities{
    internal class Player{
        public string battleTag = "";
        public int gamesPlayed;
        public float winRate;
        public float kda;
        public Hero[] BestHeroesList = new Hero[6];

        public void SetDatas(string json){
            //Split the results into 2 json strings
            string[] Stats = json.Split("\"roles\":");
            string[] GeneralSplit = Stats[0].Split("\"total\":");
            GeneralSplit = GeneralSplit[0].Split("\"general\":");
            string generalStats = GeneralSplit[1].Substring(0, GeneralSplit[1].Length - 2) + "}";
            //Gets the general datas
            dynamic dyn = JsonConvert.DeserializeObject(generalStats);
            gamesPlayed = dyn.games_played;
            winRate = dyn.winrate;
            kda = dyn.kda;


            Stats = Stats[1].Split("\"heroes\":");
            string heroesStats = "{\"heroes\":" + Stats[1];
            //Gets the heroes datas
            dyn = JsonConvert.DeserializeObject(heroesStats);
            Dictionary<string,Hero> DmgDictionnary = new Dictionary<string,Hero>(){{"ashe", new Hero()}, {"bastion", new Hero()}, {"cassidy", new Hero()}, {"echo", new Hero()}, {"genji", new Hero()}, {"hanzo", new Hero()}, {"junkrat", new Hero()}, {"mei", new Hero()}, {"pharah", new Hero()}, {"reaper", new Hero()}, {"soldier-76", new Hero()}, {"sombra", new Hero()}, {"sojourn", new Hero()}, {"symmetra", new Hero()}, {"torbjorn", new Hero()}, {"tracer", new Hero()}, {"widowmaker", new Hero()}};
            Dictionary<string,Hero> TankDictionnary = new Dictionary<string,Hero>(){{"dva", new Hero()}, {"doomfist", new Hero()}, {"junker-queen", new Hero()}, {"orisa", new Hero()}, {"ramattra", new Hero()}, {"reinhardt", new Hero()}, {"roadhog", new Hero()}, {"sigma", new Hero()}, {"winston", new Hero()}, {"wrecking-ball", new Hero()}, {"zarya", new Hero()}};
            Dictionary<string,Hero> SuppDictionnary = new Dictionary<string,Hero>(){{"ana", new Hero()}, {"baptiste", new Hero()}, {"brigitte", new Hero()}, {"kiriko", new Hero()}, {"lucio", new Hero()}, {"mercy", new Hero()}, {"moira", new Hero()}, {"zenyatta", new Hero()}};
            foreach (var h in dyn.heroes){
                Hero hero = new Hero();
                hero.name = h.Name;
                foreach (var g in h){
                    hero.timePlayed = g.time_played / 3600;
                    hero.winRate = g.winrate;
                }

                //Sorting heroes by role
                if (DmgDictionnary.ContainsKey(hero.name)){
                    hero.role = "dmg";
                    DmgDictionnary[hero.name] = hero;
                }
                else if (TankDictionnary.ContainsKey(hero.name)){
                    hero.role = "tank";
                    TankDictionnary[hero.name] = hero;
                }
                else if (SuppDictionnary.ContainsKey(hero.name)){
                    hero.role = "supp";
                    SuppDictionnary[hero.name] = hero;
                }

                foreach(var dmg in DmgDictionnary){
                    //Get the two most played DMG and put it in the Best Hero list
                }
                foreach(var tank in TankDictionnary){
                    //Get the two most played DMG and put it in the Best Hero list
                }
                foreach(var supp in SuppDictionnary){
                    //Get the two most played DMG and put it in the Best Hero list
                }
            }
            Console.WriteLine(SuppDictionnary.ToString() + TankDictionnary.ToString() + DmgDictionnary.ToString());
        }

        public string ToString(){
            return (battleTag + ": gamesPlayed: " + gamesPlayed + ", winrate: " + winRate + "%, kda: " + kda);
        }
    }
}
