using AoC.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Solvers
{
    public class Computer
    {
        private List<Instruction> program;

        public long Accumulator = 0;

        private int programPointer;

        enum mode
        {
            position = 0,
            immediate = 1
        }

        public Computer(List<string> instructions)
        {
            program = instructions.Select(i=>new Instruction(i)).ToList();
        }
        public void Execute()
        {
            programPointer = 0;
            while(true)
            {
                if(programPointer == program.Count())
                {
                    return;
                }
                var instruction = program[programPointer];
                if(instruction.ExecutionCount > 0)
                {
                    throw new InfiniteLoopException(){Accumulator = Accumulator, ProgramPointer = programPointer};
                }
                instruction.ExecutionCount++;
                switch(instruction.Operation)
                {
                    case "acc": acc(instruction.Argument);
                    break;
                    case "jmp": jmp(instruction.Argument);
                    break;
                    case "nop": nop();
                    break;
                }
            }
        }


        void acc(string arg)
        {
            Accumulator += int.Parse(arg);
            programPointer++;
        }

        void jmp(string arg)
        {
            programPointer += int.Parse(arg);
        }

        void nop()
        {
            programPointer ++;
        }
    }

    public class InfiniteLoopException : Exception
    {
        public long Accumulator;
        public int ProgramPointer;
    }
    class Instruction
    {
        public int ExecutionCount = 0;
        public string Operation;
        public string Argument;

        public Instruction(string instruction)
        {
            var operation = instruction.Split(' ');
            Operation = operation[0];
            Argument = operation[1];
        }

    }

}