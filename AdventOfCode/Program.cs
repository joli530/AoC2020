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
        }
    }
}
