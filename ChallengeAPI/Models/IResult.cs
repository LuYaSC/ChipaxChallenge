using System.Collections.Generic;

namespace ChallengeAPI.Models
{
    public interface IResult<MODEL>
        where MODEL : class, new()
    {
        List<MODEL> Results { get; set; }
    }
}
