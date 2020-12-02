namespace AoC.Common
{
    abstract public class Solver
    {
        protected string inputFileName;

        public Solver(string inputFileName)
        {
            this.inputFileName = inputFileName;
        }

        public abstract int SolvePart1();
        public abstract int SolvePart2();
    }
}