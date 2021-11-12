using ChallengeAPI.Connectors;
using ChallengeAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace ChallengeAPI.Business
{
    public class Base
    {
        public IConfiguration configuration;

        public Base(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public MODEL CallService<MODEL>(string url)
            where MODEL : class, new()
        {
           var result =  new RickAndMortyService<MODEL>(url);
            return result.Response.Body;
        }

        public string ConvertIdtoString(List<string> array)
        {
            return string.Join(",", array.Select(p => p.ToString().Replace($"{configuration.GetSection("ServiceAPI")["character"]}/", string.Empty)).ToArray());
        }

        public int GetCharCount(List<Results> names, string word)
        {
            int total = 0;
            foreach (var number in names)
            {
                total = Regex.Matches(number.Name, word).Count + total;
            }
            return total;
        }
    }
}
