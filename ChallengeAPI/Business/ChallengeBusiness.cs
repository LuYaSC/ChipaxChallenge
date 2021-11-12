using ChallengeAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace ChallengeAPI.Business
{
    public class ChallengeBusiness : Base, IChallengeBusiness
    {
        Exercise1 exercise1 = new Exercise1();
        Exercise2 exercise2 = new Exercise2();
        Result<Exercise2> result2 = new Result<Exercise2>();
        Stopwatch timeMeasure = new Stopwatch();
        Thread threadExcercise1;
        Thread threadExcercise2;
        string nextUrl = string.Empty;
        string locationUrl = string.Empty;
        DetailEpisode call = new DetailEpisode();

        public ChallengeBusiness(IConfiguration configuration) : base(configuration)
        {
        }

        public List<dynamic> ResponseChallenge()
        {
            List<dynamic> response = new List<dynamic>();
            response.Add(ResponseExercise1());
            response.Add(ResponseExercise2(1));
            return response;
        }

        public Result<Exercise1> ResponseExercise1(int performance = 0, bool isThead = true)
        {
            Result<Exercise1> result = new Result<Exercise1>();
            timeMeasure.Start();
            foreach (Header service in new PartServices(configuration))
            {
                exercise1 = new Exercise1 { Char = service.Char, Resource = service.Resource, Count = 0 };
                nextUrl = service.Url;
                var firstCall = CallService<Response>(service.Url);
                for (int i = 1; i <= firstCall.Info.Pages; i++)
                {
                    nextUrl = $"{service.Url}?page={i}";
                    if (isThead)
                    {
                        threadExcercise1 = new Thread(new ThreadStart(ProcessExercise1));
                        threadExcercise1.Start();
                        Thread.Sleep(performance);
                    }
                    else
                    {
                        ProcessExercise1();
                    }
                }
                if (isThead)
                {
                    threadExcercise1.Join();
                }
                result.Results.Add(exercise1);
            }
            timeMeasure.Stop();
            result.ExerciseName = "Char counter";
            result.In_time = timeMeasure.Elapsed.Seconds > 3 ? false : true;
            result.Time = $"{timeMeasure.Elapsed.Seconds} s {timeMeasure.Elapsed.Milliseconds} ms";
            return result;
        }

        private void ProcessExercise1()
        {
            var recursiveCall = CallService<Response>(nextUrl);
            exercise1.Count = GetCharCount(recursiveCall.Results.ToList(), exercise1.Char) + exercise1.Count;
        }

        public Result<Exercise2> ResponseExercise2(int performance = 0, bool isThread = true)
        {
            nextUrl = string.Empty;
            timeMeasure.Start();
            var firstCall = CallService<Response>(configuration.GetSection("ServiceAPI")["episode"]);
            for (int i = 1; i <= firstCall.Info.Pages; i++)
            {
                nextUrl = $"{configuration.GetSection("ServiceAPI")["episode"]}?page={i}";
                ProcessExercise2(performance, isThread);
            }
            timeMeasure.Stop();
            result2.ExerciseName = "Episode locations";
            result2.In_time = timeMeasure.Elapsed.Seconds > 3 ? false : true;
            result2.Time = $"{timeMeasure.Elapsed.Seconds} s {timeMeasure.Elapsed.Milliseconds} ms";
            return result2;
        }

        private void ProcessExercise2(int performance, bool isThread)
        {
            var recursiveEpisodeCalls = CallService<EpisodeResponse>(nextUrl);
            foreach (var callT in recursiveEpisodeCalls.Results.OrderBy(x => x.Id))
            {
                call = callT;
                if (isThread)
                {
                    threadExcercise2 = new Thread(new ThreadStart(CallCharacter));
                    threadExcercise2.Start();
                    Thread.Sleep(performance);
                }
                else
                {
                    CallCharacter();
                }

            }
            if (isThread)
            {
                threadExcercise2.Join();
            }
        }

        private void CallCharacter()
        {
            locationUrl = $"{configuration.GetSection("ServiceAPI")["character"]}/{ConvertIdtoString(call.Characters)}";
            result2.Results.Add(new Exercise2 { Episode = call.Episode, Name = call.Name, Locations = Characters() });
        }

        private List<string> Characters()
        {
            List<string> result = new List<string>();
            var locationCall = CallService<List<CharacterResponse>>(locationUrl);
            foreach (var location in locationCall)
            {
                if (!result.Contains(location.Origin.Name))
                {
                    result.Add(location.Origin.Name);
                }
            }
            return result;
        }
    }
}
