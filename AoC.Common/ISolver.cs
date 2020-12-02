namespace AoC.Common
{
    public interface ISolver
    {
        string Name {get;}
        int SolvePart1();
        int SolvePart2();
    }
}