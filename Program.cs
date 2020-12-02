using System;
using System.IO;
using AoC.Solvers;
using AoC.Common;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var builder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, builder) =>
                builder.AddUserSecrets("AOC2020"))
            .ConfigureServices((hostContext, services) =>
                services.AddHostedService<AoCHostedService>()
            ).RunConsoleAsync();
        }
    }
}
