using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;

namespace ChallengeAPI.Business
{
    public class PartServices : IEnumerable
    {
        List<Header> Constants;

        public PartServices(IConfiguration configuration)
        {
            Constants = new List<Header>();
            Constants.Add(new Header { Char = "l", Resource = "location", Url = $"{configuration.GetSection("ServiceAPI")["location"]}" });
            Constants.Add(new Header { Char = "e", Resource = "episode", Url = $"{configuration.GetSection("ServiceAPI")["episode"]}" });
            Constants.Add(new Header { Char = "c", Resource = "character", Url = $"{configuration.GetSection("ServiceAPI")["character"]}" });
        }

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < Constants.Count; index++)
            {
                yield return Constants[index];
            }
        }
    }

    public partial class Header
    {
        public string Char { get; set; }

        public string Resource { get; set; }

        public string Url { get; set; }
    }
}
