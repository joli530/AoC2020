using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using System;
namespace AoC.Common
{
    public class InputReader
    {
        string _session;
        ILogger<InputReader> _logger;
       public InputReader(IConfiguration configuration, ILogger<InputReader> logger)
       {
           _session = configuration["aoc2020:session"];
           _logger = logger;
       }

       public void GetInput(int year, int day, string fileName)
       {
           var baseAddress = new Uri("https://adventofcode.com");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                cookieContainer.Add(baseAddress, new Cookie("session", _session));
                var result = client.GetAsync($"/{year}/day/{day}/input").GetAwaiter().GetResult();
                result.EnsureSuccessStatusCode();
                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                System.IO.File.WriteAllText(fileName,content);
        }

       }
    }
}