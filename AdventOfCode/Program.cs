using System;
using AoC.Solvers;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new SolverDay1(@"input\2020\input_1.txt");
            Console.WriteLine($"Day 1 part 1 {solver.SolvePart1()}.");
            Console.WriteLine($"Day 1 part 2 {solver.SolvePart2()}.");
        }
    }
}
