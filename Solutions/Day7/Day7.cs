using advent_of_code_2024.Helpers;

namespace advent_of_code_2024.Solutions
{
    internal class Day7
    {
        public static int ParseTargetValue(string equation)
        {
            return int.Parse(equation.Split(':')[0]);
        }

        public static List<int> ParseOperands(string equation)
        {
            return equation.Split(": ")[1].Split(' ').Select(int.Parse).ToList();
        }

        public void GenerateOperatorPermutations(
            List<string> operators,
            int numberOfOperators,
            ref string current,
            ref List<string> result)
        {
            if (numberOfOperators == 1)
            {
                result.Add(current);
                return;
            }

            for (int i = 0; i < operators.Count; i++)
            {
                for (int j = 0; j < operators.Count; j++)
                {
                    result.Add(operators[j]);
                }
            }
        }
        public static bool EquationIsTrue(string equation, out int targetValue)
        {
            targetValue = ParseTargetValue(equation);
            List<int> operands = ParseOperands(equation);

            return true;
        }

        public static int TotalCalibrationResult(string[] input)
        {
            int result = 0;

            foreach (string equation in input)
            {
                if (EquationIsTrue(equation,out int value))
                {
                    result += value;
                }
            }

            return result;
        }
    }
}
