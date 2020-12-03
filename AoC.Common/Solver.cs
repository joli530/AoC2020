namespace AoC.Common
{
    abstract public class Solver : ISolver
    {
        public string Name { get; set;}
        protected string inputFileName;

        public Solver(string inputFileName)
        {
            this.inputFileName = inputFileName;
        }

        public abstract string SolvePart1();
        public abstract string SolvePart2();
    }
}