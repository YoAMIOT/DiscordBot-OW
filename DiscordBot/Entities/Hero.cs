using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Entities{
    public class Hero{
        public string name;
        public float timePlayed;
        public float winRate;
        public string role;

        public override string ToString(){
            return (name + ", " + timePlayed + ", " + winRate + ", " + role);
        }
    }
}
