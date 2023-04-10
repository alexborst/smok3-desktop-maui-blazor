using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace desktop_maui_blazor.Data.GraphQL
{
	public class GraphQLData
	{
		public GraphQLData()
		{
		}

        public partial class Welcome
        {
            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public partial class Data
        {
            [JsonProperty("games")]
            public Game[] Games { get; set; }
        }

        public partial class Game
        {
            [JsonProperty("id")]
            public Guid Id { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("release_date")]
            public DateTimeOffset? ReleaseDate { get; set; }
        }

        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
        }

        public static class Serialize
        {
            //public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }
}

