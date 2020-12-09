using AoC.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Solvers
{
    public class SolverDay8 : Solver
    {
        List<string> input;
        public SolverDay8(string inputFile):base(inputFile)
        {
            Name = "Day 8";
            input = System.IO.File.ReadAllLines(inputFile).ToList();
        } 
        public override string SolvePart1()
        {
            var computer = new Computer(input);
            try
            {
                computer.Execute();
            }
            catch (InfiniteLoopException ex)
            {
                return ex.Accumulator.ToString();
            }
            
            throw new Exception("No solution found");
        }
        public override string SolvePart2()
        {
            var variants = getInputVaiants(input);
            foreach (var item in variants)
            {
                var computer = new Computer(item);
                try
                {
                    computer.Execute();
                    return computer.Accumulator.ToString();
                }
                catch (InfiniteLoopException ex)
                {
                    
                }
            }
            
            
            throw new Exception("No solution found");
        }

        IEnumerable<List<string>> getInputVaiants(List<string> program)
        {
            var variants = new List<List<String>>();
            variants.Add(program);
            for (int i = 0; i < program.Count; i++)
            {
                var op = program[i].Split(' ');
                
                if(op[0] == "nop")
                {
                    var tempProg = new List<string>();
                    tempProg.AddRange(program);
                    tempProg[i] = "jmp "+op[1];
                    variants.Add(tempProg);
                }
                else if (op[0] == "jmp")
                {
                    var tempProg = new List<string>();
                    tempProg.AddRange(program);
                    tempProg[i] = "nop " + op[1];
                    variants.Add(tempProg);
                }
            }
            return variants;
        }
    }
}