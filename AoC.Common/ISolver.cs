using System;
namespace AoC.Common
{
    public interface ISolver
    {
        string Name {get;}
        string SolvePart1();
        string SolvePart2();
    }
}