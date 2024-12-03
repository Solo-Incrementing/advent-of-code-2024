using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace advent_of_code_2024.Solutions
{
    internal class Day3
    {
        private static int InstructionType(string instruction)
        {
            if (Regex.IsMatch(instruction, @"^don't\(\)$")){
                return 1;
            }
            else if (Regex.IsMatch(instruction, @"^do\(\)$"))
            {
                return 2;
            }
            else { return 3; }
        }

        private static int CalculateMul(string mulExpression)
        {
            IEnumerable<string> numbers = Regex.Matches(mulExpression, @"\d{1,3}").Select(match => match.Value).ToList();
            int product = 1;

            foreach (string number in numbers)
            {
                product *= int.Parse(number);
            }

            return product;
        }

        private static IEnumerable<string> GetInstructions(string corruptedMemory)
        {

            return Regex.Matches(corruptedMemory, @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)")
                .Select(match => match.Value).ToList();
        }

        public static int SolveCorruptedMuls(string corruptedMemory)
        {
            bool canMul = true;
            int sum = 0;

            IEnumerable<string> instructions = GetInstructions(corruptedMemory);
            
            foreach (string instruction in instructions)
            {
                switch (InstructionType(instruction))
                {
                    case 1:
                        canMul = false;
                        break;
                    case 2:
                        canMul = true;
                        // code block
                        break;
                    default:
                        if (canMul)
                        {
                            sum += CalculateMul(instruction);
                        }
                        // code block
                        break;
                }
            }

            return sum;
        }
    }
}
