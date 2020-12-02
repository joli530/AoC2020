using System;
using AoC.Solvers;
using AoC.Common;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solvers = new List<ISolver>();
            solvers.Add(new SolverDay1(@"input\2020\input_1.txt"));
            solvers.Add(new SolverDay2(@"input\2020\input_2.txt"));
            //solvers.Add(new SolverDay1(@"input\2020\input_1.txt"));

            foreach (var solver in solvers)
            {
                Console.WriteLine($"{solver.Name} part 1 {solver.SolvePart1()}");
                Console.WriteLine($"{solver.Name} part 2 {solver.SolvePart2()}");
            }
        }
    }
}
