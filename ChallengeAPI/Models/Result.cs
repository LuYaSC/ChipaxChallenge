using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;

namespace ChallengeAPI.Models
{
    public class Result<MODEL>: IResult<MODEL>
        where MODEL : class, new()
    {
        public Result()
        {
            Results = new List<MODEL>();
        }

        public string ExerciseName { get; set; }

        public string Time { get; set; }

        public bool In_time { get; set; }

        public List<MODEL> Results { get; set; }
    }

    public class Exercise1
    {
        public string Char { get; set; }

        public int Count { get; set; }

        public string Resource { get; set; }
    }

    public class Exercise2
    {
        public Exercise2()
        {
            Locations = new List<string>();
        }

        public string Name { get; set; }

        public string Episode { get; set; }

        public List<string> Locations { get; set; }
    }
}
