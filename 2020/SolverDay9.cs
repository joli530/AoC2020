using AoC.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Solvers
{
    public class SolverDay9 : Solver
    {
        
        List<Int64> input = new List<Int64>();
        public SolverDay9(string inputFile):base(inputFile)
        {
            Name = "Day 9";
            var parser = new Parser<Int64>();
            input = parser.Parse(inputFile);
        } 
        public override string SolvePart1()
        {
            for (int i = 25; i < input.Count; i++)
            {
                var sums = getSums(input.Skip(i-25).Take(25).ToList());
                if(!sums.Contains(input[i]))
                {
                    return input[i].ToString();
                }
            }
            throw new Exception("Solution not found");
        }

        IEnumerable<Int64> getSums(IList<Int64> Int64s)
        {
            var sums = new List<Int64>();
            for (int i = 0; i < Int64s.Count(); i++)
            {
                for (int j = 0; j < Int64s.Count(); j++)
                {
                    if(i != j)
                    {
                        sums.Add(Int64s[i]+Int64s[j]);
                    }
                    
                }
            }
            return sums;
        }
        public override string SolvePart2()
        {
            Int64 invalidNumber =0;
            int indexOfInvalidNumber = 0;
            for (int i = 25; i < input.Count; i++)
            {
                var sums = getSums(input.Skip(i-25).Take(25).ToList());
                if(!sums.Contains(input[i]))
                {
                    invalidNumber = input[i];
                    indexOfInvalidNumber = i;
                    break;
                }
            }


             for (int i = 0; i < indexOfInvalidNumber; i++)
            {
                for (int j = 0; j < indexOfInvalidNumber-i; j++)
                {
                    var sum = input.Skip(i).Take(j).Sum();
                    var numbers = input.Skip(i).Take(j).ToList();
                    if(sum == invalidNumber)
                    {
                        return (numbers.Min()+numbers.Max()).ToString();
                    }
                    if(sum > invalidNumber)
                    {
                        break;
                    }
                }
            }
            throw new Exception("Solution not found");
        }
    }
}