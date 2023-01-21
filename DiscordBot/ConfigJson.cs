using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot{
    public struct ConfigJson{
        //GET THE CONFIG TAG FROM THE JSON AND STORE THEM
        [JsonProperty("token")]
        public string Token {get; private set;}
        [JsonProperty("prefix")]
        public string Prefix {get; private set;}
    }
}
