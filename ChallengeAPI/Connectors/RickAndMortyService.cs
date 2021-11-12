using ChallengeAPI.Connectors.Base;
using ChallengeAPI.Models;
using System.IO;
using System.Net;

namespace ChallengeAPI.Connectors
{
    public class RickAndMortyService<RESPONSE> : RestFulConnector<RESPONSE>
        where RESPONSE : class, new()
    {
        public RickAndMortyService(string url) : base(url) => Execute();
    }
}
