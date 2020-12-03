using AoC.Common;
using System;
using System.Collections.Generic;

namespace AoC.Solvers
{
    public class SolverDay1 : Solver
    {
        List<int> input = new List<int>();
        public SolverDay1(string inputFile):base(inputFile)
        {
            Name = "Day 1";
            var parser = new Parser<int>();
            input = parser.Parse(inputFile);
        } 
        public override string SolvePart1()
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if(i != j && (input[i] + input[j] == 2020))
                    {
                        return (input[i] * input[j]).ToString();
                    }
                }
            }
            throw new System.Exception("Solution not found");
        }
        public override string SolvePart2()
        {
             for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    for (int k = 0; k < input.Count; k++)
                    {
                        if(i != j && i != k && j != k && (input[i] + input[j] + input[k] == 2020))
                        {
                            return (input[i] * input[j] * input[k]).ToString();
                        }
                    }
                }
            }
            throw new System.Exception("Solution not found");
        }
    }
}