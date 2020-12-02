using System;
using System.Collections.Generic;
using System.Linq;
namespace AoC.Common
{
    public class Parser<T>
    {
        public List<T> Parse(string fileName)
        {
            return System.IO.File.ReadAllLines(fileName)
            .Select(l=>(T)Convert.ChangeType(l,typeof(T)))
            .ToList();
        }

        public List<T> Parse(string fileName, char separator)
        {
            return System.IO.File.ReadAllText(fileName).Split(separator)
            .Select(l=>(T)Convert.ChangeType(l,typeof(T)))
            .ToList();
        }
    }

}