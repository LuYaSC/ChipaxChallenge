using Newtonsoft.Json;
using System;

namespace ChallengeAPI.Models
{
    public class CharacterResponse : IName
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("origin")]
        public DetailCharacter Origin { get; set; }

        [JsonProperty("location")]
        public DetailCharacter Location { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("episode")]
        public Uri[] Episode { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }
    }

    public partial class DetailCharacter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
