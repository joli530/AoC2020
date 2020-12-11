using AoC.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Solvers
{
    public class SolverDay11 : Solver
    {
        
        char[,] input;
        const char Floor = '.';
        const char Empty = 'L';
        const char Taken = '#';
        public SolverDay11(string inputFile):base(inputFile)
        {
            Name = "Day 11";
            var parser = new Parser<Int64>();
            var inputLines = System.IO.File.ReadLines(inputFile);
            input = new char[inputLines.Count(),inputLines.First().Count()];
        } 
        public override string SolvePart1()
        {



            var currentSeating = input;
            while(true)
            {
                var nextIterationSeating = applyFilter(currentSeating);
                
                if(areEqual(nextIterationSeating,currentSeating))
                {
                    currentSeating = nextIterationSeating;
                    break;
                }
                currentSeating = nextIterationSeating;
            }
            
            return countSeats(currentSeating).ToString();
        }


        bool areEqual(char[,] in1 ,char[,] in2)
        {
            for (int i = 0; i < in1.GetLength(0); i++)
            {
                for (int j = 0; j < in1.GetLength(1); j++)
                    {
                        if(in1[i,j] != in2[i,j])
                        {
                            return false;
                        }
                    }
            }
            return true;
        } 

int countSeats(char[,] in1 )
        {
            int sum = 0;
            for (int i = 0; i < in1.GetLength(0); i++)
            {
                for (int j = 0; j < in1.GetLength(1); j++)
                    {
                        if(in1[i,j] == Taken)
                        {
                            sum++;
                        }
                    }
            }
            return sum;
        } 

        char[,] applyFilter(char[,] seating)
        {

            var newSeating = seating;

            for (int row = 0; row < seating.GetLength(0); row++)
            {
                for (int col = 0; col < seating.GetLength(1); col++)
                {
                    if (seating[row,col] == Floor)
                    {
                        continue;
                    }
                    int occupiedSeats = 0;
                    if(row-1 > 0)
                    {
                        if(col-1 > 0)
                        {
                            occupiedSeats += seating[row-1,col-1] == Taken ? 1 : 0;
                        }
                        occupiedSeats += seating[row-1,col] == Taken ? 1 : 0;
                        if(col+1 < seating.GetLength(1))
                        {
                            occupiedSeats += seating[row-1,col+1] == Taken ? 1 : 0;
                        }
                    }       

                    if(col-1 > 0)
                    {
                        occupiedSeats += seating[row,col-1] == Taken ? 1 : 0;
                    }
                    if(col+1 < seating.GetLength(1))
                    {
                        occupiedSeats += seating[row,col+1] == Taken ? 1 : 0;
                    } 
                    if(row+1 < seating.GetLength(0))
                    {
                        if(col-1 > 0)
                        {
                            occupiedSeats += seating[row+1,col-1] == Taken ? 1 : 0;
                        }
                        occupiedSeats += seating[row+1,col] == Taken ? 1 : 0;
                        if(col+1 < seating.GetLength(1))
                        {
                            occupiedSeats += seating[row+1,col+1] == Taken ? 1 : 0;
                        }
                    }       
                    var currentSeat = seating[row,col];
                    if(currentSeat == Empty && occupiedSeats == 0)
                    {
                        newSeating[row,col] = Taken;
                    }
                    if(currentSeat == Taken && occupiedSeats >= 4)
                    {
                        newSeating[row,col] = Empty;
                    }
                    

                }
            }
            return newSeating;

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
            throw new Exception("Solution not found");
        }
    }
}