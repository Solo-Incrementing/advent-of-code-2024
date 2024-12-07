using advent_of_code_2024.Solutions;

namespace advent_of_code_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Day1.SumDifferences(InputReader.ReadAllLines(@"..\..\..\Solutions\Day1\Inputs\example.txt")));
            //Console.WriteLine(Day1.SumDifferences(InputReader.ReadAllLines(@"..\..\..\Solutions\Day1\Inputs\data.txt")));
            //Console.WriteLine(Day1.SumSimilarityScores(InputReader.ReadAllLines(@"..\..\..\Solutions\Day1\Inputs\example.txt")));
            //Console.WriteLine(Day1.SumSimilarityScores(InputReader.ReadAllLines(@"..\..\..\Solutions\Day1\Inputs\data.txt")));

            //Console.WriteLine(Day2.CountSafeReports(InputReader.ReadAllLines(@"..\..\..\Solutions\Day2\Inputs\example.txt")));
            //Console.WriteLine(Day2.CountSafeReports(InputReader.ReadAllLines(@"..\..\..\Solutions\Day2\Inputs\data.txt")));
            //Console.WriteLine(Day2.CountSafeReportsWithTolerance(InputReader.ReadAllLines(@"..\..\..\Solutions\Day2\Inputs\example.txt")));
            //Console.WriteLine(Day2.CountSafeReportsWithTolerance(InputReader.ReadAllLines(@"..\..\..\Solutions\Day2\Inputs\data.txt")));

            //Console.WriteLine(Day3.SolveCorruptedMuls(InputReader.ReadAllText(@"..\..\..\Solutions\Day3\Inputs\example.txt")));
            //Console.WriteLine(Day3.SolveCorruptedMuls(InputReader.ReadAllText(@"..\..\..\Solutions\Day3\Inputs\data.txt")));

            //Console.WriteLine(Day4.CountOfWordSearch(InputReader.ReadAllLines(@"..\..\..\Solutions\Day4\Inputs\example.txt"), "XMAS"));
            //Console.WriteLine(Day4.CountOfWordSearch(InputReader.ReadAllLines(@"..\..\..\Solutions\Day4\Inputs\data.txt"), "XMAS"));
            //Console.WriteLine(Day4.oddWordCrossSearch(InputReader.ReadAllLines(@"..\..\..\Solutions\Day4\Inputs\example.txt"), "MAS"));
            //Console.WriteLine(Day4.oddWordCrossSearch(InputReader.ReadAllLines(@"..\..\..\Solutions\Day4\Inputs\data.txt"), "MAS"));

            //Console.WriteLine(Day5.SumCorrectlyOrderedUpdates(InputReader.ReadAllLines(@"..\..\..\Solutions\Day5\Inputs\example.txt")));
            //Console.WriteLine(Day5.SumCorrectlyOrderedUpdates(InputReader.ReadAllLines(@"..\..\..\Solutions\Day5\Inputs\data.txt")));

            //Console.WriteLine(Day5.SumIncorrectUpdatesAfterOrdering(InputReader.ReadAllLines(@"..\..\..\Solutions\Day5\Inputs\example.txt")));
            //Console.WriteLine(Day5.SumIncorrectUpdatesAfterOrdering(InputReader.ReadAllLines(@"..\..\..\Solutions\Day5\Inputs\data.txt")));

            Console.WriteLine(Day6.CountDistinctGuardPositions(InputReader.ReadAllLines(@"..\..\..\Solutions\Day6\Inputs\example.txt"),'^','#'));
            Console.WriteLine(Day6.CountDistinctGuardPositions(InputReader.ReadAllLines(@"..\..\..\Solutions\Day6\Inputs\data.txt"), '^', '#'));
        }
    }
}