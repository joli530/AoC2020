using AoC.Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AoC.Solvers
{
    public class SolverDay3 : Solver
    {
        const char Tree = '#';
        public SolverDay3(string inputFile):base(inputFile)
        {
            Name = "Day 3";
        } 
        public override string SolvePart1()
        {
            return treeCount((1,3)).ToString();
        }
        public override string SolvePart2()
        {
            var slopes = new List<(int,int)>();
            slopes.Add((1,1));
            slopes.Add((1,3));
            slopes.Add((1,5));
            slopes.Add((1,7));
            slopes.Add((2,1));
            var treeCounts = new List<int>();
            foreach (var slope in slopes)
            {
                treeCounts.Add(treeCount(slope));
            }
            Int64 product = 1;
            foreach (var c in treeCounts)
            {
                product *= c;
            }
            return product.ToString();
        }

        private int treeCount((int,int) slope)
        {
            int treeCount = 0;
           var forest = new Forest(System.IO.File.ReadAllLines(inputFileName));
           int right = 0;
           for (int i = 0; i < forest.LineCount; i+=slope.Item1)
           {
               if(forest.ElementAt(i,right)==Tree)
               {
                   treeCount++;
               }
               right += slope.Item2;
           }
           return treeCount;
        }
    }

    class Forest
    {
        public int LineCount => _forestLines.Count();
    
        List<ForestLine> _forestLines = new List<ForestLine>();
        public Forest(IEnumerable<string> input)
        {
            _forestLines = input.Select(i=>new ForestLine(i)).ToList();
        }

        public char ElementAt(int row,int right)
        {
            return _forestLines[row].ElementAt(right);
        }
    }

    class ForestLine
    {
        private string _forestBaseLine;
        public ForestLine(string input)
        {
            _forestBaseLine = input;
        }

        public char ElementAt(int index)
        {
            if(index < _forestBaseLine.Length)
            {
                try
                {
                    return _forestBaseLine[index];
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
                
            }
            else
            {
                return ElementAt(index-_forestBaseLine.Length);
            }
        }
    }

}