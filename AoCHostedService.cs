using System;
using System.IO;
using AoC.Solvers;
using AoC.Common;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;

namespace AdventOfCode
{
    public class AoCHostedService : IHostedService
    {

        private readonly IHostApplicationLifetime _appLifetime;
        private readonly ILogger<AoCHostedService> _logger;

        public AoCHostedService(
        ILogger<AoCHostedService> logger,
        IHostApplicationLifetime appLifetime)
    {
        _logger = logger;
        _appLifetime = appLifetime;
    }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var solvers = new List<ISolver>();
            solvers.Add(new SolverDay1(@"input\2020\input_1.txt"));
            solvers.Add(new SolverDay2(@"input\2020\input_2.txt"));
            solvers.Add(new SolverDay3(@"input\2020\input_3.txt"));

            foreach (var solver in solvers)
            {
                try
                {
                    Console.WriteLine($"{solver.Name} part 1 {solver.SolvePart1()}");
                }
                catch (NotImplementedException) { }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                try
                {
                Console.WriteLine($"{solver.Name} part 2 {solver.SolvePart2()}");
                }
                catch (NotImplementedException) { }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    }
}