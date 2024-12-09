namespace advent_of_code_2024.Solutions
{
    internal class Day1 : IDay
    {
        private static int SumDifferences(string[] lines)
        {
            List<int> leftNumbersAscending = [];
            List<int> rightNumbersAscending = [];

            foreach (string line in lines)
            {
                string[] numberStrings = line.Split(" ");
                int leftNum = int.Parse(numberStrings[0]);
                int rightNum = int.Parse(numberStrings[numberStrings.Length - 1]);

                leftNumbersAscending.Add(leftNum);
                rightNumbersAscending.Add(rightNum);
            }

            leftNumbersAscending.Sort();
            rightNumbersAscending.Sort();

            int sum = 0;
            for (int i = 0; i < leftNumbersAscending.Count; i++)
            {
                sum += Math.Abs(leftNumbersAscending[i] - rightNumbersAscending[i]);
            }

            return sum;
        }

        private static int SumSimilarityScores(string[] lines)
        {
            Dictionary<int, int> numberFrequency = new Dictionary<int, int>();
            List<int> leftNumbers = [];
            List<int> rightNumbers = [];

            foreach (string line in lines)
            {
                string[] numberStrings = line.Split(" ");
                int leftNum = int.Parse(numberStrings[0]);
                int rightNum = int.Parse(numberStrings[numberStrings.Length - 1]);

                if (!numberFrequency.ContainsKey(leftNum))
                {
                    numberFrequency.Add(leftNum, 0);
                }

                leftNumbers.Add(leftNum);
                rightNumbers.Add(rightNum);
            }

            foreach (int num in rightNumbers)
            {
                if (numberFrequency.ContainsKey(num))
                {
                    numberFrequency[num]++;
                }
            }

            int sum = 0;

            foreach (int num in leftNumbers)
            {
                sum += num * numberFrequency[num];
            }

            return sum;
        }

        public static void SolveProblem(string[] input)
        {
            Console.WriteLine(SumDifferences(input));
            Console.WriteLine(SumSimilarityScores(input));
        }
    }
}
