using ChallengeAPI.Business;
using ChallengeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ChallengeController : ControllerBase
    {
        IChallengeBusiness business;

        public ChallengeController(IChallengeBusiness business)
        {
            this.business = business;
        }

        [HttpPost]
        public List<dynamic> ResponseChallenge() => business.ResponseChallenge();
    }
}
