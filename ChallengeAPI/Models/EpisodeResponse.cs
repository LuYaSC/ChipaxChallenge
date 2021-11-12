using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChallengeAPI.Models
{
    public class EpisodeResponse
    {
        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("results")]
        public List<DetailEpisode> Results { get; set; }
    }

    public partial class DetailEpisode : IName
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("air_date")]
        public string AirDate { get; set; }

        [JsonProperty("episode")]
        public string Episode { get; set; }

        [JsonProperty("characters")]
        public List<string> Characters { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }
    }
}
