using AoC.Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AoC.Solvers
{
    public class SolverDay2 : Solver
    {
        IEnumerable<Password> input;
        public SolverDay2(string inputFile):base(inputFile)
        {
            Name = "Day 2";
            input = System.IO.File.ReadAllLines(inputFile).Select(l=>new Password(l));
        } 
        public override string SolvePart1()
        {
           return input.Where(p => p.IsValid).Count().ToString();
        }
        public override string SolvePart2()
        {
            return input.Where(p => p.IsValidInNewPolicy).Count().ToString();
        }
    }

 class Password
    {
        private int min;
        private int max;
        private char characterToLimit;
        private string password;

        public bool IsValid { get { return isValid(); } }
        public bool IsValidInNewPolicy { get { return isValidInNewPolicy(); } }

        private bool isValidInNewPolicy()
        {
            var validationChars = new List<char>();
            validationChars.Add(password[min - 1]);
            validationChars.Add(password[max - 1]);
            return validationChars.Where(c => c == characterToLimit).Count() == 1;
        }


        private bool isValid()
        {
            var charCount = password.ToCharArray().Where(c => c == characterToLimit).Count();
            return min <= charCount && charCount <= max;
        }

        public Password(string input)
        {
            var regex = new Regex(@"(?<min>\d+)-(?<max>\d+) (?<char>.): (?<password>.+)");
            var match = regex.Match(input);
            if(match.Success)
            {
                min = int.Parse(match.Groups["min"].Value);
                max = int.Parse(match.Groups["max"].Value);
                characterToLimit = match.Groups["char"].Value.First();
                password = match.Groups["password"].Value;
            }
        }
        
    }

}