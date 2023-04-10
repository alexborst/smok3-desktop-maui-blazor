using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace desktop_maui_blazor.Data
{
    public class Game
    { 
        [JsonProperty("id")]
        public String GameId { get; set; }
        [JsonProperty("title")]
        public String Title { get; set; }
        [JsonProperty("release_date")]
        public String ReleaseDate { get; set; }

    }
}
